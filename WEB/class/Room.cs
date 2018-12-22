using System;

namespace WEB.@class
{
	[Serializable]
	public class Room
	{
		/// <summary>
		/// 房间ID
		/// </summary>
		public int RoomID { get; set; }
		/// <summary>
		/// 所属酒店ID
		/// </summary>
		public int HotelID { get; set; }
		/// <summary>
		/// 房间名称
		/// </summary>
		public string RoomName { get; set; }
		/// <summary>
		/// 剩余数量
		/// </summary>
		public short Amount { get; set; }
		/// <summary>
		/// 房间可入住人数
		/// </summary>
		public short People { get; set; }
		/// <summary>
		/// 房间介绍
		/// </summary>
		public string Introduce { get; set; }
		/// <summary>
		/// 房间图片
		/// </summary>
		public string Picture { get; set; }
		/// <summary>
		/// 房间价格
		/// </summary>
		public double Value { get; set; }
	}
}