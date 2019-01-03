<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB.WebLogin" %>

<asp:Content ID="Login" ContentPlaceHolderID="body" runat="server">
    <div class="login">
        <table cellpadding="0" style="height: 200px;">
            <tr>
                <td align="right">
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" ForeColor="white" Font-Bold="True">用户名:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" ForeColor="red" runat="server" ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login_box">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" ForeColor="white" Font-Bold="True">密码:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" ForeColor="red" runat="server" ControlToValidate="Password" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login_box">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="height: 40px">
                <td style="text-align: right; color: white;font-weight: bold">验证码:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="VerifyCode"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="c" runat="server" ValidationGroup="Login_box"  ControlToValidate="VerifyCode" ForeColor="red" ErrorMessage="请输入验证码" Display="Dynamic">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:ImageButton Height="40px" Width="110px" ID="VerifyImg" ImageUrl="ValidateCode.aspx" runat="server" OnClick="VerifyImg_Click" />
                    
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="RememberMe" runat="server" ForeColor="white" Font-Bold="True" Text="记住我" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="color: Red;">
                    <asp:CustomValidator ID="CheckLogin" runat="server" ErrorMessage="用户名或密码不正确" ControlToValidate="Password" ValidationGroup="Login_box" ViewStateMode="Inherit" OnServerValidate="CheckLogin_ServerValidate"></asp:CustomValidator>
                    <asp:CustomValidator runat="server" ID="d" ErrorMessage="验证码不正确" ForeColor="red" ValidationGroup="Login_box" ControlToValidate="VerifyCode" OnServerValidate="VerifyValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td align="right" colspan="2">
                    <asp:Button ID="LoginButton" CssClass="login_btn" runat="server" Text="登录" ValidationGroup="Login_box" OnClick="LoginButton_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
