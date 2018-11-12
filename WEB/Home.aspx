<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WEB.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <div style="width: 400px; margin-left: auto;margin-right: auto">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width: 400px">
                            <tr>
                                <td style="float: right;width: 100px">目的地</td>
                                <td>
                                    <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlProvince_SelectedIndexChanged" />
                                    <asp:DropDownList ID="ddlCity" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td style="float: right;width: 100px">入住日期</td>
                                <td>
                                    <asp:TextBox runat="server" ID="requestedDeliveryDateInput"  Width="170px"></asp:TextBox>
                                    <asp:ImageButton runat="server" ID="calendar_show" Width="16px" Height="16px" OnClick="RequestedDeliveryDateInput_onclick" AlternateText="选择日期" ImageUrl="~/resource/images/search_light.png" />
                                    <div id="calendar" visible="false" runat="server" style="position: absolute">
                                        <asp:Calendar ID="requestedDeliveryDateCalendar" runat="server" OnSelectionChanged="RequestedDeliveryDateCalendar_SelectionChanged" BackColor="White" Width="300px" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="float: right;width: 100px">退房日期</td>
                                <td>
                                    <asp:TextBox runat="server" ID="requestedDeliveryDateInput2" Width="170px"></asp:TextBox>
                                    <asp:ImageButton runat="server" ID="calendar_show2" Width="16px" Height="16px" OnClick="RequestedDeliveryDateInput_onclick2" AlternateText="选择日期" ImageUrl="~/resource/images/search_light.png" />
                                    <div id="calendar2" visible="false" runat="server" style="position: absolute">
                                        <asp:Calendar ID="requestedDeliveryDateCalendar2" runat="server" OnSelectionChanged="RequestedDeliveryDateCalendar_SelectionChanged2" BackColor="White" Width="300px" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div style="float: right">
                                   <asp:Button ID="search" runat="server" Text="搜索" Width="100px" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>


    </div>
</asp:Content>
