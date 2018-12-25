<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RoomDetail.aspx.cs" Inherits="WEB.WebRoomDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <div>
        <div style="height: 500px; float: left">
            <div style="float: left">
                <div>
                    <asp:Image runat="server" Height="200px" Width="200px" ID="Picture" />
                </div>
                <div>
                    <asp:Label runat="server" ID="RoomName" Width="200px" Text="aaa"></asp:Label>
                </div>
                <div>
                    <a style="color: Gray; font-size: smaller">可住:</a>
                    <asp:Label runat="server" Font-Size="Small" ID="People" Text="2"></asp:Label>
                </div>
                <div>
                    <a style="color: Gray; font-size: smaller">剩余数量:</a>
                    <asp:Label runat="server" Font-Size="Small" ID="Amount" Text="2"></asp:Label>
                </div>
                <div>
                    <a style="color: Gray; font-size: smaller">其他:</a>
                    <asp:Label runat="server" Font-Size="Small" ID="Introduce" Text="2"></asp:Label>
                </div>
            </div>
        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div style="float: left; margin-left: 60px; width: 70%">
                    <h3 style="margin-left: -40px">预订信息</h3>
                    <table>
                        <tr>
                            <td>入离日期
                            </td>
                            <td style="width: 50px"></td>
                            <td>
                                <div style="float: left">
                                    <asp:Label runat="server" ID="InTime" Width="100px"></asp:Label>
                                    <asp:ImageButton runat="server" ID="calendar_show" Width="16px" Height="16px" OnClick="RequestedDeliveryDateInput_onclick" AlternateText="选择日期" ImageUrl="~/resource/images/calendar.png" />
                                    <div id="calendar" visible="false" runat="server" style="position: absolute">
                                        <asp:Calendar ID="Select_InTime" runat="server" OnSelectionChanged="Select_InTime_SelectionChanged" BackColor="White" Width="300px" />
                                    </div>
                                </div>
                                <div style="float: left">到:&nbsp;</div>
                                <div style="float: left">
                                    <asp:Label runat="server" ID="OutTime" Width="100px"></asp:Label>
                                    <asp:ImageButton runat="server" ID="calendar_show2" Width="16px" Height="16px" OnClick="RequestedDeliveryDateInput_onclick2" AlternateText="选择日期" ImageUrl="~/resource/images/calendar.png" />
                                    <div id="calendar2" visible="false" runat="server" style="position: absolute">
                                        <asp:Calendar ID="Select_OutTime" runat="server" OnSelectionChanged="Select_OutTime_SelectionChanged" BackColor="White" Width="300px" />
                                    </div>
                                </div>
                                <div style="float: left">
                                    共<asp:Label runat="server" ID="CurrentDay" Text="1"></asp:Label>晚
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>房间数量</td>
                            <td></td>
                            <td>
                                <asp:Button runat="server" Text="-" OnCommand="SelectAmount_Command" CommandName="-" />
                                <asp:Label runat="server" ID="RoomAmount" Text="1"></asp:Label>
                                <asp:Button runat="server" Text="+" OnCommand="SelectAmount_Command" CommandName="+" />
                            </td>
                        </tr>
                        <tr>
                            <td>房费总计</td>
                            <td></td>
                            <td>
                                <asp:Label runat="server" ID="Value_Total" Text="10" ForeColor="red" Font-Size="Larger"></asp:Label></td>
                        </tr>
                    </table>
                    <hr style="border-style: dashed; color: #cde; margin-left: -40px" />
                    <h3 style="margin-left: -40px">入住信息</h3>
                    <table>
                        <tr>
                            <td>姓名</td>
                            <td style="width: 50px"></td>
                            <td>
                                <asp:TextBox runat="server" ID="GuestName"></asp:TextBox>
                            </td>
                            <td style="color: grey">
                                <asp:RequiredFieldValidator ControlToValidate="GuestName" ValidationGroup="Order" Display="Dynamic" runat="server" ForeColor="red">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ControlToValidate="GuestName" ValidationGroup="Order" runat="server" ForeColor="red" OnServerValidate="Order_ServerValidate">一个房间一个姓名，用中文逗号或空格隔开</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>联系电话</td>
                            <td></td>
                            <td>
                                <asp:TextBox runat="server" ID="ContractPhone"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ContractPhone" ValidationGroup="Order" ForeColor="red" Display="Dynamic">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="ContractPhone" ValidationGroup="Order" ForeColor="red" ValidationExpression="\d{11}">电话不正确</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>备注</td>
                            <td></td>
                            <td>
                                <asp:TextBox runat="server" ID="ReMark" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:Button runat="server" Text="支付" BackColor="#FF5050" ValidationGroup="Order" ForeColor="white" Font-Bold="True" OnClick="Order_Sure_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
