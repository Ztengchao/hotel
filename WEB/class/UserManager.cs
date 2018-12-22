using System;
using System.Data;
using System.Data.SqlClient;

namespace WEB.@class
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
			SqlParameter[] parameter = {new SqlParameter("@username", username.Trim())};
			var u = SqlHelper.GetTable(loginSql, CommandType.Text, parameter);
			if (u.Rows.Count == 0) //查找到的行数为0
				throw new Exception(username + "不存在。");
			return new User
			{
				Username = username.Trim(),
				Name = Convert.IsDBNull(u.Rows[0][2]) ? username : u.Rows[0][2].ToString().Trim(), //昵称为空时，昵称设置为用户名
				Password = u.Rows[0][1].ToString().Trim(),
				Phone = u.Rows[0][3].ToString()
			};
		}
		/// <summary>
		/// 添加用户
		/// </summary>
		/// <param name="user"></param>
		public static void AddUser(User user)
		{
			//表结构为  uAccount|uPassword|uName|uPhone
			//尝试查找用户
			try
			{
				GetUserByUsername(user.Username);
				//未抛出错误说明查找到了
				throw new Exception(user.Username + "已存在");
			}
			catch
			{
				// ignored
			}

			SqlParameter[] parameter =
			{
				new SqlParameter("@username", user.Username.Trim()),
				new SqlParameter("@password", user.Password.Trim()),
				new SqlParameter("@name", user.Name.Trim()),
				new SqlParameter("@phone", user.Phone.Trim())
			};
			var regSql = "INSERT INTO [User] VALUES (@username, @password, @name, @phone)";
			SqlHelper.ExecuteNonQuery(regSql, CommandType.Text, parameter);
		}
		/// <summary>
		/// 修改信息
		/// </summary>
		/// <param name="newUser">修改后的信息</param>
		public static void ChangeInfo(User newUser)
		{
			SqlParameter[] parameter =
			{
				new SqlParameter("@username", newUser.Username),
				new SqlParameter("@name", newUser.Name),
				new SqlParameter("@phone", newUser.Phone),
				new SqlParameter("@password", newUser.Password)
			};
			var sql =
				"UPDATE [User] SET uPhone = @phone, uName = @name, uPassword = @password WHERE uAccount = @username";
			SqlHelper.ExecuteNonQuery(sql, CommandType.Text, parameter);
		}
	}
}