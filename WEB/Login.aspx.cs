using System;
using System.Web.UI.WebControls;

namespace WEB
{
	public partial class WebForm2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Login_box_Authenticate(object sender, AuthenticateEventArgs e)
		{
			//if (Login_box.Password == "10010" && Login_box.UserName == "10086")
			//	e.Authenticated = true;
			//else
			//{
			//	e.Authenticated = false;
			//}
			//TODO 在数据库中查找用户名密码判断是否登录成功
		}

		protected void Login_box_LoggedIn(object sender, EventArgs e)
		{
			//if (Session["login-statute"] != null)
			//	Session.Remove("login-statute");
			//Session.Add("login-statute", 1);
			//TODO 在session中添加各种用户信息
		}
	}
}