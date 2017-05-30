<%@ Page Title="WebPortal | Announcement" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="CreateAnnouncement.aspx.cs" Inherits="InteractiveWebPortal.Forms.CreateAnnouncement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <section id="main">
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                        <div class="list-group">
                            <a href="AdminPage.aspx" class="list-group-item">
                                <span class="glyphicon glyphicon-dashboard" aria-hidden="true"></span>Dashboard
                            </a>
                            <a href="CreatePost.aspx" class="list-group-item"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>Posts </a>
                            <a href="CreateEvents.aspx" class="list-group-item"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span>Events </a>
                            <a href="UploadResource.aspx" class="list-group-item"><span class="glyphicon glyphicon-cloud-upload" aria-hidden="true"></span>Resources </a>
                            <a href="CreateGroup.aspx" class="list-group-item"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="ViewSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">List of Announcement</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvAnnouncementList" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="AnnouncementID" Visible="false" />
                                                <asp:BoundField DataField="Announcement" HeaderText="Announcement" />
                                                <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                                                <asp:BoundField DataField="CreatedBy" Visible="false" />
                                                <asp:BoundField DataField="Status" Visible="false" />
                                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEditAnnouncement" CssClass="btn btn-primary" runat="server" OnClick="btnEditAnnouncement_Click" Text="Edit" />
                                                        <asp:Button ID="btnDeleteAnnouncement" runat="server" CssClass="btn btn-primary" OnClick="btnDeleteAnnouncement_Click" Text="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Write Announcement</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label class="control-label">Announcement</label>
                                    <asp:TextBox ID="txtAnnouncement" CssClass="medium m-wrap" Width="100%" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" style="text-align: center">
                                    <asp:Button ID="btnSubmitAnnouncement" class="btn btn-info" OnClick="btnSubmitAnnouncement_Click" runat="server" Text="Save" />
                                    <asp:Button ID="btnCancelAnnouncement" class="btn" OnClick="btnCancelAnnouncement_Click" runat="server" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
