using System;

namespace WEB
{
	public partial class Default : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//if (Session["login-statute"] != null)
			//{
			//	login_register.Visible = false;
			//	myprofile.Visible = true;
			//}
			//else
			//{
			//	login_register.Visible = true;
			//	myprofile.Visible = false;
			//}
			//TODO 根据session来判断登陆按钮是否显示和个人信息
		}

		protected void Search_Textbox_TextChanged(object sender, EventArgs e)
		{
			if ("" == Search_Textbox.Text)
				Search_Textbox.Text = "搜索";
			if ("搜索" == Search_Textbox.Text)
			{
				Search_Textbox.CssClass = "header_search_textbox_content";
				Response.Redirect("~/Home.aspx");
				return;
			}

			Search_Textbox.CssClass = "header_search_textbox_content_coding";
			//TODO 根据输入进行搜索
		}

		protected void Login_Click(object sender, EventArgs e)
			=> Response.Redirect("~/Login.aspx");

		protected void Register_Click(object sender, EventArgs e)
			=> Response.Redirect("~/Register.aspx");

		protected void Home_Click(object sender, System.Web.UI.ImageClickEventArgs e)
			=> Response.Redirect("~/Home.aspx");
	}
}