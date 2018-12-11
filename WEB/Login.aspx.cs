using System;
using System.Web;
using System.Web.UI.WebControls;
using WEB.Class;

namespace WEB
{
	public partial class WebForm2 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void LoginButton_Click(object sender, EventArgs e) 
			=> Response.Redirect("Home.aspx");
		protected void CheckLogin_ServerValidate(object source, ServerValidateEventArgs args)
		{
			try
			{
				var user = UserManager.GetUserByUsername(UserName.Text.Trim()); //获取用户
				args.IsValid = user.Password == Password.Text.Trim(); //根据密码是否相等判断是否成功登录
				if (args.IsValid) //成功验证加入到session中
				{
					Session.Add("user", user);
				}

				if (!RememberMe.Checked) return;
				var httpCookie = new HttpCookie("user") {Expires = DateTime.Now.AddDays(7)}; //7日后过期
				httpCookie.Values["username"] = ((User) Session["user"]).Username;
				httpCookie.Values["password"] = ((User) Session["user"]).Password;
			}
			catch
			{
				args.IsValid = false;
			}
		}
	}
}