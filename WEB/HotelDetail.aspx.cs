using System;
using WEB.@class;

namespace WEB
{
	public partial class WebHotelDetail : System.Web.UI.Page
	{
		private int hotelID;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.QueryString["HotelID"] == null) //查询字符串为空
				{
					Response.Write("<script>alert('酒店ID为空!');location.href='Default.aspx';</script>");
					Response.End();
				}
				else
				{
					try
					{
						hotelID = int.Parse(Request.QueryString["HotelID"]);
					}
					catch
					{
						Response.Write("<script>alert('酒店ID不为数字!');location.href='Default.aspx';</script>");
						Response.End();
					}

					try
					{
						var hotel = HotelManager.GetHotelByID(hotelID);
						Bind(hotel);
					}
					catch
					{
						Response.Write("<script>alert('酒店ID不正确!');location.href='Default.aspx';</script>");
						Response.End();
					}
				}
			}
		}

		/// <summary>
		/// 绑定函数
		/// </summary>
		/// <param name="hotel">酒店</param>
		private void Bind(Hotel hotel)
		{
			Picture.ImageUrl = hotel.HotelPicture;
			Name.Text = hotel.HotelName;
			Address.Text = hotel.HotelAddress;
			Introduce.Text = hotel.HotelIntroduce;
			Phone1.Text = hotel.HotelPhone1;
			Phone2.Text = hotel.HotelPhone2;
			//循环加入住房信息
			Rooms.InnerHtml = "";
			var t = RoomManager.GetRoomsByHotelID(hotel.HotelID);
			foreach (var t1 in t)
			{
				Rooms.InnerHtml += "<div style=\"height:60px;margin-top:4px \">" +
				                   "	<div style=\"float: left; height: 50px;width: 50px\">" +
				                   "		<a href=\"RoomDetail.aspx?roomID=" + t1.RoomID + "\">" +
				                   "			<img style=\"height: 50px;width: 50px\" src=\"" + t1.Picture + "\"/>" +
				                   "		</a>" +
				                   "	</div>" +
				                   "	<div style=\"float: left;width: 80%\">" +
				                   "		<div style=\"height:30px;\">" +
								   "			<div style=\"float: left;margin-left:10px;width:180px;color:white\">类型：" + t1.RoomName + "</div>" +
                                   "			<div style=\"float: left;margin-left:10px;color:white\">价格：" + t1.Value + "</div>" +
				                   "		</div>" +
								   "		<div style=\"height:30px;\">" +
                                   "			<div style=\"float: left;margin-left:10px;width:180px;color:white\">可入住人数：" + t1.People + "</div>" +
                                   "			<div style=\"float: left;margin-left:10px;color:white\">余量：" + t1.Amount + "</div>" +
				                   "		</div>" +
				                   "	</div>" +
				                   "</div>";
			}
		}

		
	}
}