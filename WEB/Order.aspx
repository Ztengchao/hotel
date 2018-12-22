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
                    <asp:BoundField DataField="HotelName" HeaderText="酒店" />
                    <asp:BoundField DataField="RoomName" HeaderText="房间" />
                    <asp:BoundField DataField="OrderPhone" HeaderText="预留电话" />
                    <asp:BoundField DataField="InTime" HeaderText="入住时间" />
                    <asp:BoundField DataField="OutTime" HeaderText="离开时间" />
                    <asp:TemplateField HeaderText="订单状态">
                        <ItemTemplate>
                            <%#Statute(Convert.ToChar(Eval("OrderState"))) %> <%-- 把字符值转换为订单状态--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrderTime" HeaderText="下单时间" />
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
