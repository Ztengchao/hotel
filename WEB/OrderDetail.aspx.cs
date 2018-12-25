using System;
using System.Web.UI;
using WEB.@class;

namespace WEB
{
	public partial class WebOrderDetail : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null) //未登录
			{
				Response.Write("<script>alert('您还未登录！');location.href='Login.aspx';</script>"); //跳转到登录界面
				Response.End();
			}
			Bind();
		}
		/// <summary>
		/// 绑定数据
		/// </summary>
		private void Bind()
		{
			var oID = Convert.ToInt32(Request.QueryString["id"]); //获取订单号
			var order = OrderManager.GetOrderByOrderID(oID); //获得订单
			if (order == null)
			{
				Response.Write("<script>alert('未查找到此订单！');location.href='Default.aspx';</script>"); //跳转到主页
				Response.End();
			}
			
			if (order.Username != ((User)Session["user"]).Name) //订单中的用户名与当前登录的用户名不相等
			{
				Response.Write("<script>alert('当前账户不包含此订单！');location.href='Default.aspx';</script>"); //跳转到主页
				Response.End();
			}
			
			var hotel = HotelManager.GetHotelByID(RoomManager.GetRoomByID(order.RoomID).HotelID);
			OrderID.Text = "订单号：" + order.OrderID;
			OrderPhone.Text = "联系电话：" + order.OrderPhone;
			HotelName.Text = "酒店：" + order.HotelName;
			RoomName.Text = "房间：" + order.RoomName;
			InTime.Text = "入住时间：" + order.InTime;
			OutTime.Text = "离开时间：" + order.OutTime;
			Address.Text = "酒店地址" + hotel.HotelAddress;
			GuestInfo.Text = "旅客信息：" + order.OrderInfo;
			OrderTime.Text = "下单时间：" + order.OrderTime;
			switch (order.OrderState)
			{
				case '1':
					OrderStatute.Text = "等待处理";
					return;
				case '2':
					OrderStatute.Text = "酒店已确认";
					return;
				case '3':
					OrderStatute.Text = "已完成";
					return;
				case '4':
					OrderStatute.Text = "已取消";
					return;
			}
		}
	}
}