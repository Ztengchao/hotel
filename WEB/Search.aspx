<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WEB.WebSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <div style="width: 1000px; margin-left: auto; margin-right: auto">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="float: left">
                            <div style="float: left">目的地</div>
                            <div style="float: left;margin-left: 10px">
                                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlProvince_SelectedIndexChanged" />
                                <asp:DropDownList ID="ddlCity" runat="server" />
                            </div>
                        </div>
                        <div style="float: left;margin-left: 20px">
                            <div style="float: left">入住日期</div>
                            <div style="float: left;margin-left: 10px">
                                <asp:TextBox runat="server" ID="requestedDeliveryDateInput" Width="70px"></asp:TextBox>
                                <asp:ImageButton runat="server" ID="calendar_show" Width="16px" Height="16px" OnClick="RequestedDeliveryDateInput_onclick" AlternateText="选择日期" ImageUrl="~/resource/images/calendar.png" />
                                <div id="calendar" visible="false" runat="server" style="position: absolute">
                                    <asp:Calendar ID="requestedDeliveryDateCalendar" runat="server" OnSelectionChanged="RequestedDeliveryDateCalendar_SelectionChanged" BackColor="White" Width="300px" />
                                </div>
                            </div>
                        </div>
                        <div style="float: left;margin-left: 20px">
                            <div style="float: left">退房日期</div>
                            <div style="float: left;margin-left: 10px">
                                <asp:TextBox runat="server" ID="requestedDeliveryDateInput2" Width="70px"></asp:TextBox>
                                <asp:ImageButton runat="server" ID="calendar_show2" Width="16px" Height="16px" OnClick="RequestedDeliveryDateInput_onclick2" AlternateText="选择日期" ImageUrl="~/resource/images/calendar.png" />
                                <div id="calendar2" visible="false" runat="server" style="position: absolute">
                                    <asp:Calendar ID="requestedDeliveryDateCalendar2" runat="server" OnSelectionChanged="RequestedDeliveryDateCalendar_SelectionChanged2" BackColor="White" Width="300px" />
                                </div>
                            </div>
                        </div>
                        <div style="float: left;margin-left: 20px">
                            <asp:TextBox runat="server" ID="Search_Textbox"></asp:TextBox>
                        </div>
                        <div style="float: left;margin-left: 20px">
                            <asp:Button ID="Search_Btn" runat="server" Text="搜索" Width="100px" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
            </div>
        </div>


    </div>
</asp:Content>
