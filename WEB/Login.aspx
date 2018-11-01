<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB.WebForm2" %>
<asp:Content ID="Login" ContentPlaceHolderID="body" runat="server">
    <asp:Login ID="Login_box" runat="server" CssClass="login" Width="500px" Height="200px" VisibleWhenLoggedIn="False" TitleText="" OnAuthenticate="Login_box_Authenticate" DestinationPageUrl="~/Home.aspx" OnLoggedIn="Login_box_LoggedIn">
        <LoginButtonStyle CssClass="login_btn" />
    </asp:Login>
</asp:Content>
