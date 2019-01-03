<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="HotelDetail.aspx.cs" Inherits="WEB.WebHotelDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div>
        <div style="height: 170px">
            <div style="float: left">
                <asp:Image runat="server" Height="150px" Width="150px" ID="Picture" />
            </div>
            <div style="margin-left: 30px; float: left">
                <div>
                    <asp:Label runat="server" ForeColor="white" ID="Name"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" ForeColor="white" ID="Address"></asp:Label>
                </div>
                <div>
                    <asp:Label runat="server" ForeColor="white" ID="Introduce"></asp:Label>
                </div>
                <div>
                    <div style="float: left;color: white">联系电话：</div>
                    <div style="float: left">
                        <asp:Label runat="server" ForeColor="white" ID="Phone1"></asp:Label><br />
                        <asp:Label runat="server" ForeColor="white" ID="Phone2"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div runat="server" id="Rooms" style="margin-left: 50px">
        </div>
    </div>
</asp:Content>
