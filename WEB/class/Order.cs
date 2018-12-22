using System;

namespace WEB.@class
{
	[Serializable]
	public class Order
	{
		/// <summary>
		/// 订单号
		/// </summary>
		public int OrderID { get; set; }
		/// <summary>
		/// 房间号
		/// </summary>
		public int RoomID { get; set; }
		/// <summary>
		/// 酒店名
		/// </summary>
		public string HotelName { get; set; }
		/// <summary>
		/// 房间名
		/// </summary>
		public string RoomName { get; set; }
		/// <summary>
		/// 用户名
		/// </summary>
		public string Username { get; set; }
		/// <summary>
		///旅客信息
		/// </summary>
		public string OrderInfo { get; set; }
		/// <summary>
		/// 订单预留电话
		/// </summary>
		public string OrderPhone { get; set; }
		/// <summary>
		/// 入住时间
		/// </summary>
		public DateTime InTime { get; set; }
		/// <summary>
		/// 离开时间
		/// </summary>
		public DateTime OutTime { get; set; }
		/// <summary>
		/// 用户备注
		/// </summary>
		public string OrderRemark { get; set; }
		/// <summary>
		/// 订单状态：1-已下单，2-酒店已确定，3-已完成的订单，4-已取消的订单
		/// </summary>
		public char OrderState { get; set; }
		/// <summary>
		/// 下单时间
		/// </summary>
		public DateTime OrderTime { set; get; }
	}
}