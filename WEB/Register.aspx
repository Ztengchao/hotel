<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WEB.WebRegister" %>

<asp:Content ID="Register" ContentPlaceHolderID="body" runat="server">
    <div >
        <table class="register" align="center">
            <tr style="height: 40px">
                <td style="text-align: right;color: white">
                    昵称:
                </td>
                <td>
                    <asp:TextBox ID="Name" CssClass="register_text" runat="server" MaxLength="14"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 40px">
                <td style="text-align: right;color: white">
                    用户名:
                </td>
                <td>
                    <asp:TextBox ID="UserName" CssClass="register_text" runat="server"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="register_group" ControlToValidate="UserName" ErrorMessage="用户名不能为空" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ValidationGroup="register_group" ControlToValidate="UserName" ForeColor="Red" ErrorMessage="用户名为6-14位数字与字母的组合" ValidationExpression="([a-z]|[A-Z]|[0-9]){6,14}"/>
                </td>
            </tr>
            <tr style="height: 40px">
                <td style="text-align: right;color: white">
                    密码:
                </td>
                <td>
                    <asp:TextBox ID="PassWord" CssClass="register_text" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="register_group" ControlToValidate="PassWord" ErrorMessage="密码不能为空" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ValidationGroup="register_group" ControlToValidate="PassWord" ForeColor="Red" ErrorMessage="密码为6-14位数字与字母的组合" ValidationExpression="([a-z]|[A-Z]|[0-9]){6,14}"/>
                </td>
            </tr>
            <tr style="height: 40px">
                <td style="text-align: right;color: white">
                    重复密码:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="register_text" TextMode="Password" ID="SurePassWord"/>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="register_group" ControlToValidate="SurePassWord" ForeColor="red" ErrorMessage="请重复输入密码" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ValidationGroup="register_group" runat="server" ControlToCompare="PassWord" ControlToValidate="SurePassWord" Display="Dynamic" ErrorMessage="两次输入密码不同" ForeColor="red">两次输入密码不同</asp:CompareValidator>
                </td>
            </tr>
            <tr style="height: 40px">
                <td style="text-align: right;color: white">
                    电话:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="register_text" ID="Telephone"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="register_group" ControlToValidate="Telephone" ForeColor="red" ErrorMessage="请输入电话" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ValidationGroup="register_group" ControlToValidate="Telephone" ForeColor="red" ErrorMessage="电话格式不正确" ValidationExpression="\d{11}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr style="height: 40px">
                <td style="text-align: right;color: white">
                    验证码:
                </td>
                <td>
                    <asp:TextBox runat="server" CssClass="register_text" ID="VerifyCode"></asp:TextBox>
                </td>
                <td style="text-align: left">
                    <asp:ImageButton Height="40px" Width="110px" ID="VerifyImg" ImageUrl="ValidateCode.aspx" runat="server" OnClick="VerifyImg_Click"/>
                    <asp:RequiredFieldValidator ID="c" runat="server" ValidationGroup="register_group" ControlToValidate="VerifyCode" ForeColor="red" ErrorMessage="请输入验证码" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server" ID="d" ErrorMessage="验证码不正确" ForeColor="red" ValidationGroup="register_group" ControlToValidate="VerifyCode" OnServerValidate="VerifyValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr style="height: 40px">
                <td></td>
                <td></td>
                <td align="right">
                    <asp:Button runat="server" ValidationGroup="register_group" ID="register_btn" Text="注册" OnClick="Register_btn_Click"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
