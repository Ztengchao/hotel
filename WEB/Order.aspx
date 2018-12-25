<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="WEB.WebOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div style="text-align: center">
        <div style="display: inline-block">
            <asp:GridView runat="server" AllowPaging="True" EmptyDataText="无订单数据" PageSize="15" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex + 1).ToString() %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="酒店">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("HotelName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("HotelName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="房间">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("RoomName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("RoomName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="入住时间">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Convert.ToDateTime(Eval("InTime")).ToShortDateString() %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(Eval("InTime")).ToShortDateString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="订单状态">
                        <ItemTemplate>
                            <%#Statute(Convert.ToChar(Eval("OrderState"))) %> <%-- 把字符值转换为订单状态--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="下单时间">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Convert.ToDateTime(Eval("OrderTime")).ToShortDateString() %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Convert.ToDateTime(Eval("OrderTime")).ToShortDateString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField HeaderText="详情" Text="详情" DataNavigateUrlFields="OrderID" DataNavigateUrlFormatString="OrderDetail.aspx?id={0}" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetOrderByUsername" TypeName="WEB.class.OrderManager">
                <SelectParameters>
                    <asp:SessionParameter Name="user" SessionField="user" Type="Object" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
