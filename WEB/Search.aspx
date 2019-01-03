<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WEB.WebSearch" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <div style="height: 60px; text-align: center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="float: left">
                            <div style="float: left; color: white;font-weight: bold">目的地</div>
                            <div style="float: left; margin-left: 10px">
                                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlProvince_SelectedIndexChanged" />
                                <asp:DropDownList ID="ddlCity" runat="server" />
                            </div>
                        </div>
                        <div style="float: left; margin-left: 20px">
                            <asp:TextBox runat="server" ID="Search_Textbox"></asp:TextBox>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div style="float: left; margin-left: 20px">
                    <asp:Button ID="Search_Btn" runat="server" Text="搜索" Width="100px" OnClick="Search_Btn_Click" />
                </div>
            </div>
        </div>
        <div>
            <div runat="server" style="height: 500px" ID="content" >
                </div>
            <div style="text-align: center;">
                <webdiyer:AspNetPager ID="Search_Result" CssClass="pages" runat="server" CurrentPageButtonPosition="Center" NumericButtonCount="5" PagingButtonType="Text" ShowDisabledButtons="True" OnPageChanged="Search_Result_PageChanged" PageSize="6">
                </webdiyer:AspNetPager>
            </div>
        </div>
    </div>
</asp:Content>
