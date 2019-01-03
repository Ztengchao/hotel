using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Xml;
using WEB.@class;

namespace WEB
{
	public partial class WebSearch : Page
	{
		private readonly string City = "城市";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindProvince();
			}
		}

		#region 城市选择

		//中国省份城市级联选择
		//作者：lori
		//原文：https://blog.csdn.net/hou_yongkui/article/details/6148776

		protected void DdlProvince_SelectedIndexChanged(object sender, EventArgs e)
		{
			BindCity();
		}

		private void BindProvince()
		{
			var CurrentPath = Server.MapPath(".");


			if (!File.Exists(CurrentPath + "//resource//Province.xml")) return;
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

			if (!File.Exists(CurrentPath + "//resource//Province.xml")) return;
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

		#endregion

		/// <summary>
		/// 按下搜索按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Search_Btn_Click(object sender, EventArgs e)
		{
			var SearchString = new Dictionary<string, string>
			{
				{"text", Search_Textbox.Text.Trim()},
				{"address", ddlCity.SelectedValue.Trim()}
			};
			var count = HotelManager.GetHotelsBySearch(SearchString).Count;
			Search_Result.RecordCount = count;
			Bind(1, SearchString);
		}

		/// <summary>
		/// 换页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Search_Result_PageChanged(object sender, EventArgs e)
		{
			var SearchString = new Dictionary<string, string>
			{
				{"text", Search_Textbox.Text.Trim()},
				{"address", ddlProvince.SelectedValue.Trim() + " " + ddlCity.SelectedValue.Trim()}
			};
			Bind(Search_Result.CurrentPageIndex, SearchString);
		}

		/// <summary>
		/// 绑定函数
		/// </summary>
		/// <param name="currentPage">当前页数</param>
		/// <param name="SearchString">搜索字符串</param>
		private void Bind(int currentPage, Dictionary<string, string> SearchString)
		{
			var value = HotelManager.GetHotelsBySearch(SearchString, 6, currentPage);
			content.InnerHtml = "";
			//循环加入酒店
			foreach (var t in value)
			{
				content.InnerHtml += "<div style=\"width: 33.33%; float: left;\">" +
									 "	<div style=\"width: 200px; margin: 0 auto\">" +
									 "		<div style=\"height: 200px; width: 200px\">" +
									 "			<img style=\"height: 200px; width: 200px\" src=\"" + t.HotelPicture + "\"/>" +
									 "		</div>" +
									 "		<div style=\"width: 200px\">" +
									 "			<a style=\"color:red\" href=\"HotelDetail.aspx?HotelID=" + t.HotelID + "\">" + t.HotelName + "</a>" +
									 "		</div>" +
									 "		<div style=\"width: 200px\" >" +
									 "			<div style=\"width:200px;color:white\">" + t.HotelAddress + "</div>" +
									 "		</div>" +
									 "	</div>" +
									 "</div>";
			}

		}
	}
}