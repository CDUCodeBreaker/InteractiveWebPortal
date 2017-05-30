<%@ Page Title="WebPortal | Advertisement" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="ViewAdvertisements.aspx.cs" Inherits="InteractiveWebPortal.Forms.ViewAdvertisements" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">

    <style type="text/css">
        .transition {
            -webkit-transform: scale(1.6);
            -moz-transform: scale(1.6);
            -o-transform: scale(1.6);
            transform: scale(1.6);
        }

        #content {
            -webkit-transition: all .4s ease-in-out;
            -moz-transition: all .4s ease-in-out;
            -o-transition: all .4s ease-in-out;
            -ms-transition: all .4s ease-in-out;
        }

        #content {
            width: 80px;
            margin: 25px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page-container row-fluid">
            <div class="page-sidebar nav-collapse collapse">
                <ul class="page-sidebar-menu">
                    <li class="start">
                        <a href="MemberPage.aspx">
                            <i class="icon-home"></i>
                            <span class="title">Dashboard</span>
                        </a>
                    </li>
                    <li class="">
                        <a href="javascript:;">
                            <span class="title">Posts</span>
                            <span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="ViewPosts.aspx">View Posts</a>
                            </li>
                        </ul>
                    </li>
                    <li class="">
                        <a href="javascript:;">
                            <span class="title">Events</span>
                            <span class="arrow "></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="ViewEvents.aspx">View Events</a>
                            </li>
                        </ul>
                    </li>
                    <li class="">
                        <a href="javascript:;">
                            <span class="title">News</span>
                            <span class="arrow "></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="ViewNews.aspx">View News</a>
                            </li>
                        </ul>
                    </li>
                    <li class="">
                        <a href="javascript:;">
                            <span class="title">Resources</span>
                            <span class="arrow "></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="DownloadResource.aspx">Download Resources</a>
                            </li>
                        </ul>
                    </li>
                    <li class="">
                        <a href="javascript:;">
                            <span class="title">Announcements</span>
                            <span class="arrow "></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="ViewAnnouncements.aspx">View Announcements</a>
                            </li>
                        </ul>
                    </li>
                    <li class="">
                        <a href="javascript:;">
                            <span class="title">Groups</span>
                            <span class="arrow "></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="ViewGroups.aspx">View Groups</a>
                            </li>
                        </ul>
                    </li>
                    <li class="">
                        <a href="javascript:;">
                            <span class="title">Suggestions</span>
                            <span class="arrow "></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="CreateSuggestions.aspx">Create Suggestions</a>
                            </li>
                        </ul>
                    </li>
                    <li class="active">
                        <a href="javascript:;">
                            <span class="title">Advertisement</span>
                            <span class="arrow "></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="ViewAdvertisements.aspx">View Advertisements</a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="page-content">
                <div class="container-fluid">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="slideshow" runat="server" id="slideshow"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".img-responsive img-rounded").hover(function () {
                $(".img-responsive img-rounded").addClass('transition');

            }, function () {
                $(".img-responsive img-rounded").removeClass('transition');
            });
        });
    </script>

</asp:Content>
