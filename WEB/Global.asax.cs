using System;
using System.Web.UI;
using WEB.Class;

namespace WEB
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			ScriptManager.ScriptResourceMapping.AddDefinition("jquery",new ScriptResourceDefinition{Path = "~/js/jquery.js"});
			
		}

		protected void Session_Start(object sender, EventArgs e)
		{
			if (Request.Cookies["user"] != null) //根据cookie自动登录
			{
				try
				{
					var user = UserManager.GetUserByUsername(Request.Cookies["user"]["username"]); //获取用户
					if (user.Password == Request.Cookies["user"]["password"]) //根据密码是否相等判断是否成功登录
					{
						Session.Add("user", user);
					}
				}
				catch //出错说明cookie不正确
				{
					Request.Cookies.Remove("user");
				}
			}
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}