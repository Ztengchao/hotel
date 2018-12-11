using System;
using System.Data;
using System.Data.SqlClient;

namespace WEB.Class
{
	public static class UserManager
	{
		/// <summary>
		/// 通过用户名查找用户
		/// </summary>
		/// <param name="username">用户名</param>
		/// <returns></returns>
		public static User GetUserByUsername(string username)
		{
			//表结构为  uAccount|uPassword|uName|uPhone
			var loginSql = "SELECT * FROM [User] WHERE uAccount = @username"; //通过账号选择用户
			SqlParameter[] parameter = {new SqlParameter("@username", username)};
			var u = SqlHelper.GetTable(loginSql, CommandType.Text, parameter);
			if (u.Rows.Count == 0) //查找到的行数为0
				throw new Exception(username + " not found.");
			return new User
			{
				Username = username.Trim(),
				Name = Convert.IsDBNull(u.Rows[0][2]) ? username : u.Rows[0][2].ToString().Trim(), //昵称为空时，昵称设置为用户名
				Password = u.Rows[0][1].ToString().Trim(),
				Phone = u.Rows[0][3].ToString()
			};
		}
		/// <summary>
		/// 添加用户函数
		/// </summary>
		/// <param name="user"></param>
		public static void AddUser(User user)
		{
			//表结构为  uAccount|uPassword|uName|uPhone
			SqlParameter[] parameter =
			{
				new SqlParameter("@username", user.Username),
				new SqlParameter("@password", user.Password),
				new SqlParameter("@name", user.Name),
				new SqlParameter("@phone", user.Phone)
			};
			var regSql = "INSERT INTO [User] VALUES (@username, @password, @name, @phone)";
			SqlHelper.ExecuteNonQuery(regSql, CommandType.Text, parameter);
		}
	}
}