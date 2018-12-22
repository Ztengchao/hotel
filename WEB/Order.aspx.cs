using System;

namespace WEB
{
	public partial class WebOrder : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null) //未登录
			{
				Response.Write("<script>alert('您还未登录！');location.href='Login.aspx';</script>"); //跳转到登录界面
				Response.End();
			}
		}
		/// <summary>
		/// 根据字符返回订单状态
		/// </summary>
		/// <param name="statute"></param>
		/// <returns></returns>
		protected static string Statute(char statute)
		{
			switch (statute)
			{
				case '1': return "等待处理";
				case '2': return "酒店已确认";
				case '3': return "已完成";
				case '4': return "已取消";
				default: return "错误";
			}
		}
	}
}