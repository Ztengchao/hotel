using System;

namespace WEB
{
	public partial class Default : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void Search_Textbox_TextChanged(object sender, EventArgs e)
		{
			if ("" == Search_Textbox.Text)
				Search_Textbox.Text = "搜索";
			if ("搜索" == Search_Textbox.Text)
			{
				Search_Textbox.CssClass = "header_search_textbox_content";
				//TODO 返回主页
				return;
			}

			Search_Textbox.CssClass = "header_search_textbox_content_coding";
			//TODO 根据输入进行搜索
		}

		protected void Login_Click(object sender, EventArgs e)
		{
			//TODO 弹出登录界面
		}

		protected void Register_Click(object sender, EventArgs e)
		{
			//TODO 弹出注册界面
		}
	}
}