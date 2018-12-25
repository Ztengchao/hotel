<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Passport.aspx.cs" Inherits="WEB.WebPassport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <style type="text/css">
        .btn {
            margin-left: 5px;
        }
    </style>
    <div style="height: 40px">
        <div style="float: left">昵称：</div>
        <div style="float: left">
            <asp:TextBox runat="server" ID="Name" ReadOnly="True" Text="昵称" MaxLength="14"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ValidationGroup="change_group" ControlToValidate="Name" ForeColor="red" ErrorMessage="请输入昵称" Display="Static">*</asp:RequiredFieldValidator>
        </div>
        <div style="float: left; margin-left: 20px">电话：</div>
        <div style="float: left">
            <asp:TextBox runat="server" ID="Phone" ReadOnly="True" Text="电话" MaxLength="11"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ValidationGroup="change_group" ControlToValidate="phone" ForeColor="red" ErrorMessage="请输入电话" Display="Static">*</asp:RequiredFieldValidator>
        </div>
        <div style="float: left; margin-left: 20px;">
            <div style="float: left; " runat="server" id="ChangeDiv">
                <asp:Button runat="server" Text="修改" OnClick="Change_Click"/>
            </div>
            <div style="float: left;" runat="server" Visible="False" id="SureDiv">
                <asp:Button runat="server" Text="保存" ValidationGroup="change_group" ID="Save" OnClick="Save_Click"/>
                <asp:Button runat="server" Text="取消" OnClick="Cancle_Click"/>
            </div></div>
        <div style="visibility: hidden; width: 0px; float: left">
            <!--临时储存数据-->
            <asp:Label ID="UsernameLabel" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="GuestName" runat="server"></asp:Label>
            <asp:Label ID="GuestID" runat="server"></asp:Label>
        </div>
        <div style="float: left">
            <asp:RegularExpressionValidator runat="server" ValidationGroup="change_group" ControlToValidate="Phone" ForeColor="red" ErrorMessage="电话格式不正确" ValidationExpression="\d{11}" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
    </div>
    <div>
        <asp:GridView runat="server" AllowPaging="True" ID="GuestTable" EmptyDataText="无旅客" PageSize="15" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowSorting="True" OnRowCancelingEdit="GuestTable_RowCancelingEdit" OnRowDeleting="GuestTable_RowDeleting" OnRowUpdating="GuestTable_RowUpdating" ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="姓名" SortExpression="gName">
                    <EditItemTemplate>
                        <asp:TextBox MaxLength="5" ID="TextBox1" runat="server" Text='<%# Bind("gName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("gName") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox OnTextChanged="NameChanged" MaxLength="5" runat="server" Text="填写旅客名"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="身份证号" SortExpression="gID">
                    <EditItemTemplate>
                        <asp:TextBox MaxLength="14" ID="TextBox2" runat="server" Text='<%# Bind("gID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("gID") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox OnTextChanged="IDChanged" runat="server" MaxLength="14" Text="填写身份证号"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="AddButton" OnClick="AddButton_OnClick" runat="server" Text="添加"></asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" OnClientClick="return confirm('确定删除？')"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hotelConnectionString %>" SelectCommand="SELECT [gName], [gID] FROM [Guest] WHERE ([uAccount] = @uAccount)">
            <SelectParameters>
                <asp:ControlParameter ControlID="UsernameLabel" Name="uAccount" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>
