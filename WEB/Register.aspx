<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WEB.WebForm3" %>

<asp:Content ID="Register" ContentPlaceHolderID="body" runat="server">
    <table class="register" align="center">
        <tr style="height: 40px">
            <td style="text-align: right;">用户名:
            </td>
            <td>
                <asp:TextBox ID="UserName" CssClass="register_text" runat="server"></asp:TextBox>
            </td>
            <td style="text-align: left">
                <asp:RequiredFieldValidator runat="server" ValidationGroup="register_group" ControlToValidate="UserName" ErrorMessage="用户名不能为空" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="height: 40px">
            <td style="text-align: right">密码:
            </td>
            <td>
                <asp:TextBox ID="PassWord" CssClass="register_text" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="text-align: left">
                <asp:RequiredFieldValidator runat="server" ValidationGroup="register_group" ControlToValidate="PassWord" ErrorMessage="密码不能为空" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="height: 40px">
            <td style="text-align: right">确定密码:
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="register_text" TextMode="Password" ID="SurePassWord"></asp:TextBox>
            </td>
            <td style="text-align: left">
                <asp:RequiredFieldValidator runat="server" ValidationGroup="register_group" ControlToValidate="Email" ForeColor="red" ErrorMessage="请重复输入密码" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ValidationGroup="register_group" runat="server" ControlToCompare="PassWord" ControlToValidate="SurePassWord" Display="Dynamic" ErrorMessage="两次输入密码不同" ForeColor="red">两次输入密码不同</asp:CompareValidator>
            </td>
        </tr>
        <tr style="height: 40px">
            <td style="text-align: right">邮箱:
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="register_text" ID="Email"></asp:TextBox>
            </td>
            <td style="text-align: left">
                <asp:RequiredFieldValidator runat="server" ValidationGroup="register_group" ControlToValidate="Email" ForeColor="red" ErrorMessage="请输入邮箱" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ValidationGroup="register_group" ControlToValidate="Email" ErrorMessage="邮箱格式不正确" ForeColor="red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">邮箱格式不正确</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr style="height: 40px">
            <td></td>
            <td></td>
            <td align="right">
                <asp:Button runat="server" ValidationGroup="register_group" ID="register_btn" Text="注册" OnClick="register_btn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
