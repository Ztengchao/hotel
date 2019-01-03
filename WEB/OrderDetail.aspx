<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="WEB.WebOrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <style type="text/css">
        .tb td {
            border-style: solid;
            border-width: 1px;
            border-color: white;
        }
    </style>
    <div style="margin:0 auto;text-align:center;">
        <div style="margin:0 auto; width: 600px;text-align: left">
            <table class="tb">
                <tr>
                    <td>
                        <asp:Label runat="server" ForeColor="white" ID="OrderID" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ForeColor="white" ID="OrderPhone" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ForeColor="white" ID="HotelName" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ForeColor="white" ID="RoomName" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ForeColor="white" ID="InTime" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ForeColor="white" ID="OutTime" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ForeColor="white" ID="Address" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label runat="server" ForeColor="white" ID="GuestInfo" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ForeColor="white" ID="OrderTime" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ForeColor="white" ID="OrderStatute" CssClass="textbox" ReadOnly="True"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
