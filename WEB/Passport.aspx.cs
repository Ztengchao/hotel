using System;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using WEB.@class;

namespace WEB
{
	public partial class WebPassport : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null) //未登录
			{
				Response.Write("<script>alert('您还未登录！');location.href='Login.aspx';</script>"); //跳转到登录界面
				Response.End();
			}

			if (!IsPostBack)
			{
				Bind();
			}
		}

		/// <summary>
		/// 绑定数据
		/// </summary>
		private void Bind()
		{
			Name.Text = ((User)Session["user"]).Name;
			Phone.Text = ((User)Session["user"]).Phone;
			UsernameLabel.Text = ((User)Session["user"]).Username;
		}

		/// <summary>
		/// 删除一行时执行
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GuestTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			SqlDataSource1.DeleteCommand = "SELECT * FROM HOTEL WHERE hID='-1'";
			GuestManager.DeleteGuest(new Guest
			{
				GuestID = e.Values["gID"].ToString().Trim(),
				GuestName = e.Values["gName"].ToString().Trim(),
				Username = UsernameLabel.Text
			});
			GuestTable.DataBind();
		}

		/// <summary>
		/// 修改一行时执行
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GuestTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			SqlDataSource1.UpdateCommand = "SELECT * FROM HOTEL WHERE hID='-1'";
			if (!Regex.IsMatch(e.NewValues["gID"].ToString(), "\\d{14}"))
			{
				//身份证号不为14位数字
				Response.Write("<script>alert('身份证号不正确！');</script>");
				return;
			}
			GuestManager.UpdateGuset(new Guest
			{
				Username = UsernameLabel.Text,
				GuestID = e.OldValues["gID"].ToString().Trim(),
				GuestName = e.OldValues["gName"].ToString()
			}, new Guest
			{
				Username = UsernameLabel.Text,
				GuestID = e.NewValues["gID"].ToString().Trim(),
				GuestName = e.NewValues["gName"].ToString()
			});
			GuestTable.DataBind();
		}

		/// <summary>
		/// 取消修改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void GuestTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			GuestTable.EditIndex = -1;
			GuestTable.DataBind();
		}

		#region 修改电话密码

		/// <summary>
		/// 点击修改按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Change_Click(object sender, EventArgs e)
		{
			Name.ReadOnly = false;
			Phone.ReadOnly = false;
			ChangeDiv.Visible = false;
			SureDiv.Visible = true;
		}

		/// <summary>
		/// 保存姓名电话按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Save_Click(object sender, EventArgs e)
		{
			if (!IsValid)
			{
				return;
			}
			//更新session
			((User)Session["user"]).Name = Name.Text.Trim();
			((User)Session["user"]).Phone = Phone.Text.Trim();
			//更新数据库
			UserManager.ChangeInfo((User)Session["user"]);
			Bind();
			SureDiv.Visible = false;
			ChangeDiv.Visible = true;
			Name.ReadOnly = true;
			Phone.ReadOnly = true;
		}

		/// <summary>
		/// 取消保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Cancle_Click(object sender, EventArgs e)
		{
			Name.Text = ((User)Session["user"]).Name;
			Phone.Text = ((User)Session["user"]).Phone;
			SureDiv.Visible = false;
			ChangeDiv.Visible = true;
			Name.ReadOnly = true;
			Phone.ReadOnly = true;
		}

		#endregion

		/// <summary>
		/// 添加旅客按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void AddButton_OnClick(object sender, EventArgs e)
		{
			if (GuestName.Text == "" || GuestID.Text == "" ||
				!Regex.IsMatch(GuestID.Text, "\\d{14}"))
			{
				Response.Write("<script>alert('旅客信息不正确！');</script>");
				return;
			}

			try
			{
				GuestManager.AddGuest(new Guest
				{
					GuestID = GuestID.Text,
					GuestName = GuestName.Text.Trim(),
					Username = UsernameLabel.Text
				});
			}
			catch
			{
				Response.Write("<script>alert('该旅客已存在！');</script>");
			}
			GuestTable.DataBind();
		}

		#region 临时储存数据
		protected void NameChanged(object sender, EventArgs e)
		{
			GuestName.Text = ((TextBox)sender).Text.Trim();
		}
		protected void IDChanged(object sender, EventArgs e)
		{
			GuestID.Text = ((TextBox)sender).Text.Trim();
		}
		#endregion
	}
}