using System;
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
			SqlParameter[] parameter = {new SqlParameter("@hotelID", hotelID)};
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
	}
}