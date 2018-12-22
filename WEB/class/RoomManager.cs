using System;
using System.Data;
using System.Data.SqlClient;

namespace WEB.@class
{
	public static class RoomManager
	{
		//Room表 rID|hID|rType|rAmount|rPeople|rIntroduce|rPic
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
				Amount = Convert.ToInt16(u.Rows[0][3]),
				People = Convert.ToInt16(u.Rows[0][4]),
				Introduce = Convert.ToString(u.Rows[0][5]),
				Picture = Convert.ToString(u.Rows[0][6])
			};
		}
	}
}