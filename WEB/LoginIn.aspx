<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginIn.aspx.cs" Inherits="WEB.LoginIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            var searchbox = $("#<%= Search_Textbox.ClientID %>");
            $(searchbox).focus(function() {
                if (searchbox.val() === "搜索") {
                    searchbox.val("");
                }
                searchbox.addClass("header_search_textbox_content_focus");
            });
            $(searchbox).blur(function() {
                if (searchbox.val() === "") {
                    searchbox.val("搜索");
                    this.className = "header_search_textbox_content";
                } else {
                    this.className = "header_search_textbox_content_coding";
                }

            });
        })
    </script>
    <link rel="stylesheet" href="css/LoginIn.css" type="text/css"/>
    <title>XXX酒店预订</title>
</head>
<body>
<form id="form1" runat="server">
    <!--头部开始-->
    <div class="header">
        <!--搜索框部分-->
        <div class="header_search">
            <div class="header_search_top"></div>
            <div class="header_search_pic_div">
                <img alt="搜索符号" src="resource/images/search.png" class="header_search_pic"/>
            </div>
            <div class="header_search_textbox_div">
                <div class="header_search_textbox">
                    <asp:TextBox ID="Search_Textbox" Text="搜索" CssClass="header_search_textbox_content" runat="server" Wrap="False" OnTextChanged="Search_Textbox_TextChanged"/>
                </div>
            </div>
        </div>
        <!--搜索框部分结束-->
        <!--登录注册-->
        <div class="header_right">
            <ul class="header_right_ul">
                <li style="float: right">
                    <asp:Button ID="Login" runat="server" Text="登录" CssClass="header_right_ul_btn" OnClick="Login_Click"/>
                </li>
                <li style="float: right">
                    <asp:Button ID="Register" runat="server" Text="注册" CssClass="header_right_ul_btn" OnClick="Register_Click"/>
                </li>
            </ul>
        </div>
        <!--登录注册结束-->
    </div>
    <!--头部结束-->
    <!--主体开始-->
    <div class="main">
        <div style="width: 50%;">
            <div>
                <h3 style="font-size: 24px; padding-bottom: 2px; padding-top: 2px; margin-left: 20px; margin-bottom: 8px; color: black; font-weight: 800">推荐酒店</h3>
            </div>
        </div>
        <div>
            <div class="select">
                <div>
                    <div>
                        <img src="resource/images/SaleRemit_pic01_20160601.jpg" alt=""/>
                    </div>
                    <div>
                        <a href="http://www.baidu.com">
                            每晚50
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--主体结束-->
</form>
</body>
</html>
