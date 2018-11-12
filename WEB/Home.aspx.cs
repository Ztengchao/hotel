using System;
using System.Web.UI;
using System.Xml;

namespace WEB
{
	public partial class WebForm4 : Page
	{
		private readonly string City = "城市";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindProvince();
			}
		}
		//中国省份城市级联选择
		//作者：lori
		//来源：CSDN
		//原文：https://blog.csdn.net/hou_yongkui/article/details/6148776
		protected void DdlProvince_SelectedIndexChanged(object sender, EventArgs e)
		{
			BindCity();
		}
		private void BindProvince()
		{

			var CurrentPath = Server.MapPath(".");


			if (!System.IO.File.Exists(CurrentPath + "//resource//Province.xml")) return;
			ddlProvince.Items.Clear();

			var doc = new XmlDocument();
			doc.Load(CurrentPath + "//resource//Province.xml");

			if (doc.DocumentElement != null)
			{
				var nodes = doc.DocumentElement.ChildNodes;

				var nodeCity = doc.DocumentElement.SelectSingleNode(@"Province/City[@Name='" + City + "']");

				foreach (XmlNode node in nodes)
				{
					if (node.Attributes != null) ddlProvince.Items.Add(node.Attributes["Name"].Value);
					var n = ddlProvince.Items.Count - 1;

					if (nodeCity != null && node == nodeCity.ParentNode)
						ddlProvince.SelectedIndex = n;
				}
			}

			BindCity();
		}
		private void BindCity()
		{
			var CurrentPath = Server.MapPath(".");

			if (!System.IO.File.Exists(CurrentPath + "//resource//Province.xml")) return;
			ddlCity.Items.Clear();

			var doc = new XmlDocument();
			doc.Load(CurrentPath + "//resource//Province.xml");

			if (doc.DocumentElement != null)
			{
				var nodes = doc.DocumentElement.ChildNodes[ddlProvince.SelectedIndex].ChildNodes;

				foreach (XmlNode node in nodes)
				{
					if (node.Attributes == null) continue;
					ddlCity.Items.Add(node.Attributes["Name"].Value);
					var n = ddlCity.Items.Count - 1;
					if (node.Attributes["Name"].Value == City)
					{
						ddlCity.SelectedIndex = n;
					}
				}
			}
			if (ddlCity.SelectedIndex == -1)
				ddlCity.SelectedIndex = 0;
		}

		/// <summary>
		/// 选择日期，通过AJAX触发
		/// </summary>
		protected void RequestedDeliveryDateCalendar_SelectionChanged(object sender, EventArgs eventArgs)
		{
			requestedDeliveryDateInput.Text = requestedDeliveryDateCalendar.SelectedDate.ToShortDateString();
			// 隐藏日历
			calendar.Visible = false;
			//设置日历下textbox的焦点，方便用户输入。移除或改变下行代码设置为您自己的控件
			//someTextBox.Focus();
		}
		protected void RequestedDeliveryDateCalendar_SelectionChanged2(object sender, EventArgs eventArgs)
		{
			requestedDeliveryDateInput2.Text = requestedDeliveryDateCalendar2.SelectedDate.ToShortDateString();
			// 隐藏日历
			calendar2.Visible = false;
			//设置日历下textbox的焦点，方便用户输入。移除或改变下行代码设置为您自己的控件
			//someTextBox.Focus();
		}

		protected void RequestedDeliveryDateInput_onclick(object sender, EventArgs eventArgs)
		{
			if (calendar2.Visible)
				calendar2.Visible = false;
			calendar.Visible = !calendar.Visible;
		}

		protected void RequestedDeliveryDateInput_onclick2(object sender, EventArgs eventArgs)
		{
			if (calendar.Visible)
				calendar.Visible = false;
			calendar2.Visible = !calendar2.Visible;
		}
	}
}