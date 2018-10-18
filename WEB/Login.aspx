<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB.WebForm2" %>
<!--登录界面-->
<asp:Content ID="Login" ContentPlaceHolderID="body" runat="server">
    <asp:Login ID="Login_box" CssClass="login" runat="server" TitleText="" VisibleWhenLoggedIn="False" Width="500px" Height="200px">
        <LoginButtonStyle CssClass="login_btn" />
    </asp:Login>
</asp:Content>
