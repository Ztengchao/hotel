using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WEB.@class
{
	public static class HotelManager
	{
		//Hotel表 |hID|hName|hAddress|hPic|hIntroduce|hPhone1|hPhone2|
		/// <summary>
		/// 通过ID获取旅馆
		/// </summary>
		/// <param name="hotelID">旅馆ID</param>
		/// <returns></returns>
		public static Hotel GetHotelByID(int hotelID)
		{
			var sql = "SELECT * FROM [Hotel] WHERE hID = @hotelID";
			SqlParameter[] parameter = { new SqlParameter("@hotelID", hotelID) };
			var u = SqlHelper.GetTable(sql, CommandType.Text, parameter);
			return new Hotel
			{
				HotelID = hotelID,
				HotelName = Convert.ToString(u.Rows[0][1]),
				HotelAddress = Convert.ToString(u.Rows[0][2]),
				HotelPicture = Convert.ToString(u.Rows[0][3]),
				HotelIntroduce = Convert.ToString(u.Rows[0][4]),
				HotelPhone1 = Convert.ToString(u.Rows[0][5]),
				HotelPhone2 = Convert.ToString(u.Rows[0][6])
			};
		}

		/// <summary>
		/// 获取酒店搜索结果
		/// </summary>
		/// <param name="SearchString"></param>
		/// <returns></returns>
		public static List<Hotel> GetHotelsBySearch(Dictionary<string, string> SearchString)
		{
			var InTime = SearchString["inTime"];
			var Address = new string[2];
			if (SearchString["address"] != "省份 城市")
				Address = SearchString["address"].Split(' ');
			var Text = SearchString["text"];
			SqlParameter[] sqlParameters =
			{
				new SqlParameter("@InTime", "%" + InTime + "%"),
				new SqlParameter("@Province", "%" + Address[0] + "%"),
				new SqlParameter("@City", "%" + Address[1] + "%"),
				new SqlParameter("@Text", "%" + Text + "%")
			};
			var sql =
				"SELECT * FROM [Hotel] WHERE hAddress LIKE @City AND hAddress LIKE @Province AND hName LIKE @Text";
			var u = SqlHelper.GetTable(sql, CommandType.Text, sqlParameters);
			var returnList = new List<Hotel>();
			for (var i = 0; i < u.Rows.Count; i++)
			{
				returnList.Add(new Hotel
				{
					HotelID = Convert.ToInt32(u.Rows[i][0]),
					HotelName = Convert.ToString(u.Rows[i][1]).Trim(),
					HotelAddress = Convert.ToString(u.Rows[i][2]).Trim(),
					HotelPicture = Convert.ToString(u.Rows[i][3]).Trim(),
					HotelIntroduce = Convert.ToString(u.Rows[i][4]).Trim(),
					HotelPhone1 = Convert.ToString(u.Rows[i][5]).Trim(),
					HotelPhone2 = Convert.ToString(u.Rows[i][6]).Trim()
				});
			}

			return returnList;
		}

		/// <summary>
		/// 返回某一页酒店
		/// </summary>
		/// <param name="SearchString"></param>
		/// <param name="pagesize">一页酒店数</param>
		/// <param name="currentpage">当前页</param>
		/// <returns></returns>
		public static List<Hotel> GetHotelsBySearch(Dictionary<string, string> SearchString, int pagesize,
			int currentpage)
		{
			var InTime = SearchString["inTime"];
			var Address = new string[2];
			if (SearchString["address"] != "省份 城市")
				Address = SearchString["address"].Split(' ');
			var Text = SearchString["text"];
			var rowLine = (currentpage - 1) * pagesize;
			SqlParameter[] sqlParameters =
			{
				new SqlParameter("@InTime", "%" + InTime + "%"),
				new SqlParameter("@Province", "%" + Address[0] + "%"),
				new SqlParameter("@City", "%" + Address[1] + "%"),
				new SqlParameter("@Text", "%" + Text + "%")
			};
			var sql =
				"SELECT TOP " + pagesize + " * " +
				"FROM [Hotel] " +
				"WHERE (hAddress LIKE @City ) AND (hAddress LIKE @Province) AND (hName LIKE @Text) AND hID NOT IN " +
				"(SELECT TOP " + rowLine +
				" hID FROM [Hotel] WHERE (hAddress LIKE @City ) AND (hAddress LIKE @Province ) AND (hName LIKE @Text ) ORDER BY hID)" +
				"ORDER BY hID";
			var u = SqlHelper.GetTable(sql, CommandType.Text, sqlParameters);
			var returnList = new List<Hotel>();
			for (var i = 0; i < u.Rows.Count; i++)
			{
				returnList.Add(new Hotel
				{
					HotelID = Convert.ToInt32(u.Rows[i][0]),
					HotelName = Convert.ToString(u.Rows[i][1]).Trim(),
					HotelAddress = Convert.ToString(u.Rows[i][2]).Trim(),
					HotelPicture = Convert.ToString(u.Rows[i][3]).Trim(),
					HotelIntroduce = Convert.ToString(u.Rows[i][4]).Trim(),
					HotelPhone1 = Convert.ToString(u.Rows[i][5]).Trim(),
					HotelPhone2 = Convert.ToString(u.Rows[i][6]).Trim()
				});
			}

			return returnList;
		}
	}
}