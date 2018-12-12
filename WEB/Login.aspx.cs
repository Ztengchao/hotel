using System;
using System.Web;
using System.Web.UI.WebControls;
using WEB.Class;

namespace WEB
{
	public partial class WebLogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void LoginButton_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
				Response.Redirect("~/Default.aspx");
			}
		}

		protected void CheckLogin_ServerValidate(object source, ServerValidateEventArgs args)
		{
			try
			{
				var user = UserManager.GetUserByUsername(UserName.Text.Trim()); //获取用户
				args.IsValid = user.Password == Password.Text.Trim(); //根据密码是否相等判断是否成功登录
				if (!args.IsValid) return; //验证失败返回
				Session.Add("user", user);

				if (!RememberMe.Checked) return;
				Response.Cookies.Add(new HttpCookie("user")
				{
					Expires = DateTime.Now.AddDays(7), //7日后过期
					Values =
					{
						["password"] = ((User) Session["user"]).Password,
						["username"] = ((User) Session["user"]).Username
					}
				});
			}
			catch
			{
				args.IsValid = false;
			}
		}
	}
}