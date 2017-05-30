<%@ Page Title="WebPortal | Advertisement" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="CreateAdvertisement.aspx.cs" Inherits="InteractiveWebPortal.Forms.CreateAdvertisement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page-container row-fluid">
            <!-- BEGIN SIDEBAR -->
            <div class="page-sidebar nav-collapse collapse">
                <!-- BEGIN SIDEBAR MENU -->
                <ul class="page-sidebar-menu">

                    <li class="start">
                        <a href="AdminPage.aspx">
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
                                <a href="CreatePost.aspx">Create Posts</a>
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
                                <a href="CreateEvents.aspx">Create Events</a>
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
                                <a href="CreateNews.aspx">Create News</a>
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
                                <a href="UploadResource.aspx">Upload Resources</a>
                            </li>
                        </ul>
                    </li>
                    <li class="">
                        <a href="javascript:;">
                            <span class="title">Announcement</span>
                            <span class="arrow "></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="CreateAnnouncement.aspx">Make Announcement</a>
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
                                <a href="CreateGroup.aspx">Create Group</a>
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
                                <a href="ViewSuggestions.aspx">View Suggestions</a>
                            </li>
                        </ul>
                    </li>
                    <li class="active">
                        <a href="javascript:;">
                            <span class="title">Advertisements</span>
                            <span class="arrow "></span>
                        </a>
                        <ul class="sub-menu">
                            <li>
                                <a href="CreateAdvertisement.aspx">Create Advertisement</a>
                            </li>
                        </ul>
                    </li>
                </ul>
                <!-- END SIDEBAR MENU -->
            </div>
            <!-- END SIDEBAR -->
            <!-- BEGIN PAGE -->
            <div class="page-content">

                <div class="container-fluid">
                    <!-- BEGIN PAGE CONTENT-->
                    <div class="row-fluid">
                        <div class="span12">
                              <div class="portlet box">
                                <div class="portlet-title">
                                    <div class="caption">Advertisements</div>
                                </div>
                                <div class="portlet-body">
                                    <div class="table-re">
                                        <asp:GridView ID="gvAdvertisements" runat="server" Width="100%" GridLines="None" CssClass="table table-striped table-bordered table-hover table-condensed" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="AdvertisementID" Visible="false" />
                                                <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDelete" Text="Delete" CommandArgument='<%# Eval("AdvertisementID") %>' runat="server" OnClick="DeleteFile" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <!-- BEGIN SAMPLE FORM PORTLET-->
                            <div class="portlet box tabbable">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <span class="hidden-480">Add Addvertisements</span>
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <div class="tab-content" style="padding: 10px">
                                        <div class="control-group">
                                            <label class="control-label">Upload</label>
                                            <div class="controls">
                                                <asp:FileUpload ID="FileUploadControl" runat="server" />
                                            </div>
                                            <div class="form-actions" style="text-align: center">
                                                <asp:Button ID="btnSubmitResouce" OnClick="btnSubmitResouce_Click" class="btn btn-info" runat="server" Text="Save" />
                                                <asp:Button ID="btnCancelResouce" class="btn" runat="server" Text="Cancel" />
                                            </div>
                                        </div>
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
