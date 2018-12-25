using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WEB.@class
{
	public static class RoomManager
	{
		//Room表 rID|hID|rType|rValue|rAmount|rPeople|rIntroduce|rPic
		/// <summary>
		/// 通过房间ID查找房间
		/// </summary>
		/// <param name="roomID">房间ID</param>
		/// <returns></returns>
		public static Room GetRoomByID(int roomID)
		{
			var sql = "SELECT * FROM [Room] WHERE rID = @roomID";
			SqlParameter[] parameter = {new SqlParameter("@roomID", roomID)};
			var u = SqlHelper.GetTable(sql, CommandType.Text, parameter);
			return new Room
			{
				RoomID = roomID,
				HotelID = Convert.ToInt32(u.Rows[0][1]),
				RoomName = Convert.ToString(u.Rows[0][2]).Trim(),
				Value = Convert.ToDouble(u.Rows[0][3]),
				Amount = Convert.ToInt16(u.Rows[0][4]),
				People = Convert.ToInt16(u.Rows[0][5]),
				Introduce = Convert.ToString(u.Rows[0][6]),
				Picture = Convert.ToString(u.Rows[0][7])
			};
		}

		/// <summary>
		/// 通过酒店ID查找住房
		/// </summary>
		/// <param name="hotelID">酒店ID</param>
		/// <returns></returns>
		public static List<Room> GetRoomsByHotelID(int hotelID)
		{
			var sql = "SELECT * FROM [Room] WHERE hID = @hotelID";
			SqlParameter[] parameter = { new SqlParameter("@hotelID", hotelID) };
			var u = SqlHelper.GetTable(sql, CommandType.Text, parameter);
			var returnValues = new List<Room>();
			for (var i = 0; i < u.Rows.Count; i++)
			{

				returnValues.Add(new Room
				{
					RoomID = Convert.ToInt32(u.Rows[i][0]),
					HotelID = hotelID,
					RoomName = Convert.ToString(u.Rows[i][2]).Trim(),
					Value = Convert.ToDouble(u.Rows[i][3]),
					Amount = Convert.ToInt16(u.Rows[i][4]),
					People = Convert.ToInt16(u.Rows[i][5]),
					Introduce = Convert.ToString(u.Rows[i][6]).Trim(),
					Picture = Convert.ToString(u.Rows[i][7])
				});
			}

			return returnValues;
		}

		/// <summary>
		/// 设置房间余量
		/// </summary>
		/// <param name="roomID">房间ID</param>
		/// <param name="newNumber">新余量</param>
		public static void SetAccount(int roomID ,int newNumber)
		{
			SqlParameter[] sqlParameters =
			{
				new SqlParameter("@roomID", roomID),
				new SqlParameter("@newCount", newNumber)
			};
			var sql = "UPDATE [Room] SET rAmount=@newCount WHERE rID = @roomID";
			SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameters);
		}
	}
}