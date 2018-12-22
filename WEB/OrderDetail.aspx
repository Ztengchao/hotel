<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="WEB.WebOrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div style="margin:0 auto;text-align:center;">
        <div style="margin:0 auto; width: 600px">
            <table>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="OrderID" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="OrderPhone" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="HotelName" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="RoomName" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="InTime" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="OutTime" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="Address" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="GuestInfo" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="OrderTime" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="OrderStatute" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
