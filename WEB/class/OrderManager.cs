using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace WEB.@class
{
	public static class OrderManager
	{
		//Order表 oID|rID|uAccount|oInfo|oPhone|InTime|OutTime|oRemark|oStat|oTime
		/// <summary>
		/// 通过用户名返回订单
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns></returns>
		public static List<Order> GetOrderByUsername(User user)
		{
			var sql = "SELECT * FROM [Order] WHERE uAccount = @username ORDER BY InTime "; //查询订单
			SqlParameter[] parameter = {new SqlParameter("@username", user.Username)};
			var u = SqlHelper.GetTable(sql, CommandType.Text, parameter);
			var returnList = new List<Order>();
			for (var i = 0; i < u.Rows.Count; i++) //返回订单
			{
				var room = RoomManager.GetRoomByID(Convert.ToInt32(u.Rows[i][1]));
				returnList.Add(new Order
				{
					OrderID = Convert.ToInt32(u.Rows[i][0]),
					RoomID = room.RoomID,
					Username = u.Rows[i][2].ToString().Trim(),
					OrderInfo = u.Rows[i][3].ToString().Trim(),
					OrderPhone = u.Rows[i][4].ToString().Trim(),
					InTime = Convert.ToDateTime(u.Rows[i][5]),
					OutTime = Convert.ToDateTime(u.Rows[i][6]),
					OrderRemark = u.Rows[i][7].ToString().Trim(),
					OrderState = Convert.ToChar(u.Rows[i][8]),
					RoomName = room.RoomName,
					HotelName = HotelManager.GetHotelByID(room.HotelID).HotelName,
					OrderTime = Convert.ToDateTime(u.Rows[i][9])
				});
			}

			return returnList;
		}

		/// <summary>
		/// 根据订单号返回订单
		/// </summary>
		/// <param name="OrderID">订单号</param>
		/// <returns></returns>
		public static Order GetOrderByOrderID(int OrderID)
		{
			var sql = "SELECT * FROM [Order] WHERE oID = @oID"; //查询订单
			SqlParameter[] parameter = {new SqlParameter("@oID", OrderID)};
			var u = SqlHelper.GetTable(sql, CommandType.Text, parameter);
			if (u.Rows.Count == 0)
			{
				return null;
			}

			var room = RoomManager.GetRoomByID(Convert.ToInt32(u.Rows[0][1]));
			return new Order
			{
				OrderID = Convert.ToInt32(u.Rows[0][0]),
				RoomID = room.RoomID,
				Username = u.Rows[0][2].ToString().Trim(),
				OrderInfo = u.Rows[0][3].ToString().Trim(),
				OrderPhone = u.Rows[0][4].ToString().Trim(),
				InTime = Convert.ToDateTime(u.Rows[0][5]),
				OutTime = Convert.ToDateTime(u.Rows[0][6]),
				OrderRemark = u.Rows[0][7].ToString().Trim(),
				OrderState = Convert.ToChar(u.Rows[0][8]),
				RoomName = room.RoomName,
				HotelName = HotelManager.GetHotelByID(room.HotelID).HotelName,
				OrderTime = Convert.ToDateTime(u.Rows[0][9])
			};
		}

		/// <summary>
		/// 增加订单
		/// </summary>
		/// <param name="order">订单</param>
		public static void AddOrder(Order order)
		{
			SqlParameter[] sqlParameters =
			{
				new SqlParameter("@roomID", order.RoomID),
				new SqlParameter("@userAccount", order.Username),
				new SqlParameter("@orderPhone", order.OrderPhone),
				new SqlParameter("@orderInfo", order.OrderInfo),
				new SqlParameter("@InTime", order.InTime.ToShortDateString()),
				new SqlParameter("@OutTime", order.OutTime.ToShortDateString()),
				new SqlParameter("@orderRemark", order.OrderRemark),
				new SqlParameter("@orderState", order.OrderState),
				new SqlParameter("@orderTime", order.OrderTime.ToString("yyyy-MM-dd HH:mm:ss.f"))
			};
			var sql = "INSERT INTO [Order](rID,uAccount,oInfo,oPhone,InTime,OutTime,oRemark,oStat,oTime) " +
			          "VALUES (@roomID,@userAccount,@orderInfo,@orderPhone,@InTime,@OutTime,@orderRemark,@orderState,@orderTime)";
			SqlHelper.ExecuteNonQuery(sql, CommandType.Text, sqlParameters);
		}
	}
}