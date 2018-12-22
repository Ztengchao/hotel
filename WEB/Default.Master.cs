using System;
using WEB.@class;

namespace WEB
{
	public partial class Default : System.Web.UI.MasterPage
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] != null)
			{
				login_register.Visible = false;
				logined_in.Visible = true;
				MyInfor.Text = ((User) Session["user"]).Name;
			}
			else
			{
				logined_in.Visible = false;
				login_register.Visible = true;
				
			}
		}

		//protected void Search_Textbox_TextChanged(object sender, EventArgs e)
		//{
		//	if ("" == Search_Textbox.Text)
		//		Search_Textbox.Text = "搜索";
		//	if ("搜索" == Search_Textbox.Text)
		//	{
		//		Search_Textbox.CssClass = "header_search_textbox_content";
		//		Response.Redirect("~/Search.aspx");
		//		return;
		//	}

		//	Search_Textbox.CssClass = "header_search_textbox_content_coding";
		//	//TODO 根据输入进行搜索
		//}

		protected void Login_Click(object sender, EventArgs e)
			=> Response.Redirect("Login.aspx");

		protected void Register_Click(object sender, EventArgs e) 
			=> Response.Redirect("Register.aspx");

		protected void Home_Click(object sender, System.Web.UI.ImageClickEventArgs e)
			=> Response.Redirect("~/Default.aspx");

		protected void Search_Image_Click(object sender, System.Web.UI.ImageClickEventArgs e)
			=> Response.Redirect("Search.aspx");

		protected void ToOrder(object sender, EventArgs e) 
			=> Response.Redirect("Order.aspx");

		protected void MyInfor_Click(object sender, EventArgs e)
			=> Response.Redirect("Passport.aspx");

		protected void Log_off(object sender, EventArgs e)
		{
			Session.Remove("user"); //移除登录信息
			if (Response.Cookies["user"] != null) //移除cookie
			{
				Response.Cookies["user"].Expires = DateTime.Now;
			}

			Response.Redirect("~/Default.aspx");
		}
	}
}