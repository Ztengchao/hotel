using System;
using WEB.Class;

namespace WEB
{
	public partial class WebForm3 : System.Web.UI.Page
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
			UserManager.AddUser(user);
			Session.Add("user", user);
			Response.Redirect("Home.aspx");
		}
	}
}