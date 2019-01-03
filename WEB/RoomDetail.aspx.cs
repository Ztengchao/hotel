using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.@class;

namespace WEB
{
	public partial class WebRoomDetail : System.Web.UI.Page
	{
		private Room room;

		protected void Page_Load(object sender, EventArgs e)
		{
			Bind();
		}

		#region 日期选择

		/// <summary>
		/// 选择日期，通过AJAX触发
		/// </summary>
		protected void Select_InTime_SelectionChanged(object sender, EventArgs eventArgs)
		{
			//入住时间小于今天
			if (Select_InTime.SelectedDate.CompareTo(DateTime.Today) == -1)
			{
				return;
			}

			InTime.Text = Select_InTime.SelectedDate.ToShortDateString();
			//如果入住时间比离开时间大
			if (Select_InTime.SelectedDate.CompareTo(Select_OutTime.SelectedDate) == 1)
			{
				Select_OutTime.SelectedDate = Select_InTime.SelectedDate.AddDays(1);
				OutTime.Text = Select_OutTime.SelectedDate.ToShortDateString();
			}
			// 隐藏日历
			calendar.Visible = false;
			//设置日历下textbox的焦点，方便用户输入。移除或改变下行代码设置为您自己的控件
			//someTextBox.Focus();
			Bind();
		}

		protected void Select_OutTime_SelectionChanged(object sender, EventArgs eventArgs)
		{
			//离开时间必进入时间少
			if (Select_OutTime.SelectedDate.CompareTo(Convert.ToDateTime(InTime.Text)) != 1)
			{
				return;
			}
			OutTime.Text = Select_OutTime.SelectedDate.ToShortDateString();
			// 隐藏日历
			calendar2.Visible = false;
			//设置日历下textbox的焦点，方便用户输入。移除或改变下行代码设置为您自己的控件
			//someTextBox.Focus();
			Bind();
		}

		protected void RequestedDeliveryDateInput_onclick(object sender, EventArgs eventArgs)
		{
			if (calendar2.Visible)
				calendar2.Visible = false;
			calendar.Visible = !calendar.Visible;
		}

		protected void RequestedDeliveryDateInput_onclick2(object sender, EventArgs eventArgs)
		{
			if (calendar.Visible)
				calendar.Visible = false;
			calendar2.Visible = !calendar2.Visible;
		}

		#endregion

		/// <summary>
		/// 增加减少选择房间数
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SelectAmount_Command(object sender, CommandEventArgs e)
		{
			if (e.CommandName == "-")
			{
				if (RoomAmount.Text == "1")
					return;
				RoomAmount.Text = Convert.ToString(int.Parse(RoomAmount.Text) - 1);
			}
			else
			{
				if (RoomAmount.Text == "10")
					return;
				RoomAmount.Text = Convert.ToString(int.Parse(RoomAmount.Text) + 1);
			}
			Bind();
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		private void Bind()
		{
			try
			{
				room = RoomManager.GetRoomByID(int.Parse(Request.QueryString["roomID"]));
			}
			catch
			{
				Response.Write("<script>alert('住房ID不正确!');location.href='Default.aspx';</script>");
				Response.End();
			}
			if (!IsPostBack)
			{
				Picture.ImageUrl = room.Picture;
				RoomName.Text = room.RoomName;
				People.Text = room.People.ToString();
				Amount.Text = room.Amount.ToString();
				Introduce.Text = room.Introduce;
				InTime.Text = DateTime.Now.ToShortDateString();
				OutTime.Text = DateTime.Now.AddDays(1).ToShortDateString();
				Select_InTime.SelectedDate = DateTime.Now;
				Select_OutTime.SelectedDate = DateTime.Now.AddDays(1);
			}
			CurrentDay.Text = Convert.ToDateTime(OutTime.Text).Subtract(Convert.ToDateTime(InTime.Text)).Days
				.ToString();
			Value_Total.Text = "￥" + Convert.ToString(int.Parse(RoomAmount.Text) * room.Value * int.Parse(CurrentDay.Text));
		}

		/// <summary>
		/// 自定义验证
		/// </summary>
		/// <param name="source"></param>
		/// <param name="args"></param>
		protected void Order_ServerValidate(object source, ServerValidateEventArgs args)
		{
			char[] m = { '，', ' ' };
			var x = GuestName.Text.Split(m, StringSplitOptions.None);
			if (x.Length != int.Parse(RoomAmount.Text))
			{
				args.IsValid = false;
				return;
			}
			//存在大于5的姓名返回false
			args.IsValid = !x.Any(s => s.Length > 5);
		}

		/// <summary>
		/// 确定订单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Order_Sure_Click(object sender, EventArgs e)
		{
			if(!Page.IsValid)
				return;
		    if (Session["user"] == null)
		    {
		        Response.Write("<script>alert('您还未登录！');location.href='Login.aspx';</script>"); //跳转到登录界面
		        Response.End();
		    }
			char[] m = { '，', ' ' };
			var x = GuestName.Text.Split(m, StringSplitOptions.None);
			var order = new Order
			{
				RoomID = room.RoomID,
				InTime = Convert.ToDateTime(InTime.Text),
				OutTime = Convert.ToDateTime(OutTime.Text),
				Username = ((User) Session["user"]).Username,
				OrderPhone = ContractPhone.Text,
				OrderRemark = ReMark.Text,
				OrderTime = DateTime.Now,
				OrderState = '1',
				OrderInfo = x[0]
			};
			for (var i = 1; i < x.Length; i++)
			{
				order.OrderInfo += "," + x[i];
			}
			OrderManager.AddOrder(order);
			RoomManager.SetAccount(room.RoomID, room.Amount - int.Parse(RoomAmount.Text));
			Response.Redirect("Default.aspx");
		}
	}
}