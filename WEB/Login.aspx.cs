using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.@class;

namespace WEB
{
	public partial class WebLogin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		/// <summary>
		/// 登陆成功跳转到首页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void LoginButton_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
				Response.Redirect("~/Default.aspx");
			}
		}

		/// <summary>
		/// 检查是否登录成功
		/// </summary>
		/// <param name="source"></param>
		/// <param name="args"></param>
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

		/// <summary>
		/// 判断验证码是否正确
		/// </summary>
		/// <param name="source"></param>
		/// <param name="args"></param>
		protected void VerifyValidate(object source, ServerValidateEventArgs args) => args.IsValid = string.Equals(Convert.ToString(args.Value), Session["VerificationCode"].ToString(), StringComparison.CurrentCultureIgnoreCase);
		/// <summary>
		/// 点击验证码更换图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void VerifyImg_Click(object sender, ImageClickEventArgs e)
		{
			VerifyImg.ImageUrl = "ValidateCode.aspx";
		}
	}
}