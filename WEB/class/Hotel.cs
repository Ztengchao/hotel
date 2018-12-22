using System;

namespace WEB.@class
{
	[Serializable]
	public class Hotel
	{
		/// <summary>
		/// 酒店ID
		/// </summary>
		public int HotelID { get; set; }
		/// <summary>
		/// 酒店名
		/// </summary>
		public string HotelName { get; set; }
		/// <summary>
		/// 酒店地址
		/// </summary>
		public string HotelAddress { get; set; }
		/// <summary>
		/// 酒店图片
		/// </summary>
		public string HotelPicture { get; set; }
		/// <summary>
		/// 酒店介绍
		/// </summary>
		public string HotelIntroduce { get; set; }
		/// <summary>
		/// 酒店电话1
		/// </summary>
		public string HotelPhone1 { get; set; }
		/// <summary>
		/// 酒店电话2
		/// </summary>
		public string HotelPhone2 { get; set; }
	}
}