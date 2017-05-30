<%@ Page Title="WebPortal | Change Password" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="ChangeYourPassword.aspx.cs" Inherits="InteractiveWebPortal.Forms.ChangeYourPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page-container row-fluid">
            <div class="page-sidebar nav-collapse collapse">
                <ul class="page-sidebar-menu">
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
                            <span class="arrow"></span>
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
                            <span class="arrow"></span>
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
                            <span class="arrow"></span>
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
                            <span class="arrow"></span>
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
                            <span class="arrow"></span>
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
                            <span class="arrow"></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="CreateSuggestions.aspx">Create Suggestions</a>
                            </li>
                        </ul>
                    </li>
                    <li class="">
                        <a href="javascript:;">
                            <span class="title">Advertisement</span>
                            <span class="arrow"></span>
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
                            <div class="portlet box">
                                <div class="portlet-title">
                                    <div class="caption">Change Password</div>
                                </div>
                                <div class="portlet-body">
                                    <div class="control-group">
                                        <label class="control-label">Temporary Password</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtTempPass" TextMode="Password" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">New Password</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtNewPass" onblur="checkPass(); return false;" TextMode="Password" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Repeat Password</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtRepeatPass" onblur="checkPass(); return false;" TextMode="Password" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-actions" style="text-align: center">
                                        <asp:Button ID="btnChangePassword" class="btn btn-info" runat="server"  OnClick="btnChangePassword_Click" Text="Save" />
                                        <asp:Button ID="btnCancel" class="btn" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script src="assets/scripts/webPortalScript.js"></script>

    <script type="text/javascript">
        function checkPass() {
            alert("hi");
            var pass1 = document.getElementById('txtNewPass');
            var pass2 = document.getElementById('txtRepeatPass');
            var goodColor = "#66cc66";
            var badColor = "#ff6666";
            if (pass1.value == pass2.value) {
                pass2.style.backgroundColor = goodColor;
                $(pass2).notify('Passwords Match!', 'success');
            } else {
                pass2.style.backgroundColor = badColor;
                $(pass2).notify('Passwords Do Not Match!');
            }

    </script>



</asp:Content>
