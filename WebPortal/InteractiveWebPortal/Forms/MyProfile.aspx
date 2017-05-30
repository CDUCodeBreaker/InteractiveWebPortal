<%@ Page Title="WebPortal | MyProfile" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="InteractiveWebPortal.Forms.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
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
                    <li class="">
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
                            <div class="portlet box">
                                <div class="portlet-title">
                                    <div class="caption">My Profile</div>
                                </div>
                                <div class="portlet-body">
                                    <div class="control-group">
                                        <label class="control-label visible-ie8 visible-ie9">First Name</label>
                                        <div class="controls">
                                            <div class="input-icon left">
                                                <i class="icon-user" aria-hidden="true"></i>
                                                <asp:TextBox ID="txtFirstName" class="m-wrap placeholder-no-fix" placeholder="First Name" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label visible-ie8 visible-ie9">Last Name</label>
                                        <div class="controls">
                                            <div class="input-icon left">
                                                <i class="icon-user" aria-hidden="true"></i>
                                                <asp:TextBox ID="txtLastName" class="m-wrap placeholder-no-fix" placeholder="Last Name" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label visible-ie8 visible-ie9">Email</label>
                                        <div class="controls">
                                            <div class="input-icon left">
                                                <i class="icon-envelope" aria-hidden="true"></i>
                                                <asp:TextBox ID="txtEmail" class="m-wrap placeholder-no-fix" placeholder="Email" onblur="return validate()" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label visible-ie8 visible-ie9">Date Of Birth</label>
                                        <div class="controls">
                                            <div class="input-icon left">
                                                <i class="icon-calendar" aria-hidden="true"></i>
                                                <asp:TextBox ID="txtDateOfBirth" class="m-wrap placeholder-no-fix" placeholder="Date Of Birth" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label visible-ie8 visible-ie9">Mobile No</label>
                                        <div class="controls">
                                            <div class="input-icon left">
                                                <i class="icon-phone" aria-hidden="true"></i>
                                                <asp:TextBox ID="txtMobileNo" class="m-wrap placeholder-no-fix" placeholder="Mobile No" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls">
                                            Upload Picture
                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label visible-ie8 visible-ie9">Address1</label>
                                        <div class="controls">
                                            <div class="input-icon left">
                                                <i class="icon-location-arrow" aria-hidden="true"></i>
                                                <asp:TextBox ID="txtAddress1" class="m-wrap placeholder-no-fix" placeholder="Address1" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label visible-ie8 visible-ie9">Address2</label>
                                        <div class="controls">
                                            <div class="input-icon left">
                                                <i class="icon-location-arrow" aria-hidden="true"></i>
                                                <asp:TextBox ID="txtAddress2" class="m-wrap placeholder-no-fix" placeholder="Address2" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label visible-ie8 visible-ie9">Post Code</label>
                                        <div class="controls">
                                            <div class="input-icon left">
                                                <i class="icon-envelope" aria-hidden="true"></i>
                                                <asp:TextBox ID="txtPostCode" class="m-wrap placeholder-no-fix" placeholder="Post Code" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="dropdown">
                                            Suburb
                    <asp:DropDownList ID="ddlSuburb" Width="312px" CssClass="select2-wrapper" runat="server">
                    </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="dropdown">
                                            State
                    <asp:DropDownList ID="ddlStates" Width="312px" CssClass="select2-wrapper" runat="server">
                    </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="dropdown">
                                            Country
                    <asp:DropDownList ID="ddlCountry" Width="312px" CssClass="select2-wrapper" runat="server">
                    </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="forget-password" style="text-align: center">
                                        <p>
                                            <asp:Button ID="btnSignUp" class="btn btn-primary" runat="server" Text="Save" />
                                            <asp:Button ID="btnBackToSignIn" class="btn btn-primary" runat="server" Text="Back" />
                                        </p>
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
</asp:Content>
