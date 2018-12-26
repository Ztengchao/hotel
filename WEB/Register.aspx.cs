using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.@class;

namespace WEB
{
	public partial class WebRegister : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void Register_btn_Click(object sender, EventArgs e)
		{
			var user = new User
			{
				Username = UserName.Text.Trim(),
				Password = PassWord.Text.Trim(),
				Name = Name.Text.Length == 0 ? UserName.Text.Trim() : Name.Text.Trim(), //昵称栏为空，昵称为用户名
				Phone = Telephone.Text.Trim()
			};
			try
			{
				UserManager.AddUser(user);
				Session.Add("user", user);
				Response.Write(" <script language=javascript>alert('注册成功');location.href='Default.aspx';</script> ");
			}
			catch //抛出错误说明用户存在
			{
				Response.Write(
					" <script language=javascript>confirm('该用户已存在，点击确定前往登录');location.href='Login.aspx';</script> ");
			}
		}

		#region 验证码

		protected void VerifyValidate(object source, ServerValidateEventArgs args) => args.IsValid =
			string.Equals(Convert.ToString(args.Value), Session["VerificationCode"].ToString(),
				StringComparison.CurrentCultureIgnoreCase);

		protected void VerifyImg_Click(object sender, ImageClickEventArgs e)
		{
			VerifyImg.ImageUrl = "ValidateCode.aspx";
		}

		#endregion
	}
}