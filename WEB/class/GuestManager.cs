using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WEB.@class
{
	public static class GuestManager
	{
		//Guest表 uAccount|gName|gID
		/// <summary>
		/// 通过用户名返回旅客
		/// </summary>
		/// <param name="username">用户名</param>
		/// <returns></returns>
		public static List<Guest> GetGuestByUsername(string username)
		{
			var sql = "SELECT * FROM [Guest] WHERE uAccount = @username";
			SqlParameter[] parameter = { new SqlParameter("@username", username) };
			var u = SqlHelper.GetTable(sql, CommandType.Text, parameter);
			var returnList = new List<Guest>();
			for (var i = 0; i < u.Rows.Count; i++)
			{
				returnList.Add(new Guest
				{
					Username = username,
					GuestID = u.Rows[i][2].ToString(),
					GuestName = u.Rows[i][1].ToString()
				});
			}

			return returnList;
		}
		/// <summary>
		/// 查找旅客是否存在
		/// </summary>
		/// <param name="username">用户名</param>
		/// <param name="guestName">旅客名</param>
		/// <returns></returns>
		public static Guest GetGuest(string username, string guestName)
		{
			var sql = "SELECT gID FROM [Guest] WHERE uAccount = @username AND gName = @guestName";
			SqlParameter[] parameter =
			{
				new SqlParameter("@username", username),
				new SqlParameter("@guestName", guestName)
			};
			var u = SqlHelper.GetTable(sql, CommandType.Text, parameter);
			if (u.Rows.Count==0)
			{
				throw new Exception(username + "不存在名为" + guestName + "的旅客");
			}

			return new Guest
			{
				Username = username,
				GuestName = guestName,
				GuestID = u.Rows[0][0].ToString()
			};
		}
		/// <summary>
		/// 查找旅客是否存在
		/// </summary>
		/// <param name="guest">旅客</param>
		/// <returns></returns>
		public static bool GetGuest(Guest guest)
		{
			var sql = "SELECT * FROM [Guest] WHERE uAccount = @username AND gName = @guestName";
			SqlParameter[] parameter =
			{
				new SqlParameter("@username", guest.Username),
				new SqlParameter("@guestName", guest.GuestName)
			};
			var u = SqlHelper.GetTable(sql, CommandType.Text, parameter);
			return u.Rows.Count != 0;
		}
		/// <summary>
		/// 添加旅客
		/// </summary>
		/// <param name="guest">要添加的旅客</param>
		/// <returns></returns>
		public static void AddGuest(Guest guest)
		{
			if (GetGuest(guest))
			{
				throw new Exception(guest.Username + "已存在名为" + guest.GuestName + "的旅客");
			}
			SqlParameter[] sqlParameters =
			{
				new SqlParameter("@uAccount", guest.Username),
				new SqlParameter("@gName", guest.GuestName),
				new SqlParameter("@gID", guest.GuestID)
			};
			var sql = "INSERT INTO [Guest] VALUES (@uAccount, @gName, @gID)";
			SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameters);
		}
		/// <summary>
		/// 删除旅客
		/// </summary>
		/// <param name="guest">要删除的旅客</param>
		public static void DeleteGuest(Guest guest)
		{
			if (!GetGuest(guest))
			{
				throw new Exception(guest.Username + "不存在名为" + guest.GuestName + "的旅客");
			}
			SqlParameter[] sqlParameters =
			{
				new SqlParameter("@uAccount", guest.Username),
				new SqlParameter("@gName", guest.GuestName)
			};
			var sql = "DELETE FROM [Guest] WHERE uAccount = @uAccount AND gName = @gName";
			SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameters);
		}
		/// <summary>
		/// 修改旅客
		/// </summary>
		/// <param name="oldGuest">旧旅客</param>
		/// <param name="newGuest">修改后的旅客</param>
		public static void UpdateGuset(Guest oldGuest, Guest newGuest)
		{
			if (!GetGuest(oldGuest))
			{
				throw new Exception(oldGuest.Username + "不存在名为" + oldGuest.GuestName + "的旅客");
			}
			DeleteGuest(oldGuest);
			AddGuest(newGuest);
		}
	}
}