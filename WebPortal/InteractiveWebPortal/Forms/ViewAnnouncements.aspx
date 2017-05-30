<%@ Page Title="WebPortal | Announcement" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="ViewAnnouncements.aspx.cs" Inherits="InteractiveWebPortal.Forms.ViewAnnouncements" %>

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
                            <a href="ViewPosts.aspx" class="list-group-item"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>Posts </a>
                            <a href="ViewEvents.aspx" class="list-group-item"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span>Events </a>
                            <a href="DownloadResource.aspx" class="list-group-item"><span class="glyphicon glyphicon-cloud-download" aria-hidden="true"></span>Resources </a>
                            <a href="ViewGroups.aspx" class="list-group-item"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="CreateSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Announcements</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvAnnouncements" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="AnnouncementID" Visible="false" />
                                                <asp:BoundField DataField="Announcement" HeaderText="Announcement" />
                                                <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                                                <asp:BoundField DataField="CreatedBy" Visible="false" />
                                                <asp:BoundField DataField="Status" Visible="false" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Write Comment</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <asp:TextBox ID="txtComment" Enabled="false" CssClass="medium m-wrap" Style="resize: none" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" style="text-align: center">
                                    <asp:Button ID="btnSaveComment" Enabled="false" class="btn btn-primary custom" runat="server" Text="Save" />
                                    <asp:Button ID="btnCancelComment" Enabled="false" class="btn btn-primary custom" runat="server" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <asp:ModalPopupExtender ID="mpePopUp" runat="server" PopupControlID="pnlPopUp" TargetControlID="btnShow"
            CancelControlID="btnClose" X="350" Y="150" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
        <asp:Panel ID="pnlPopUp" Style="display: none; height: 1000px; width: 600px" runat="server">
            <div class="HellowWorldPopup">
                <div class="PopupHeader" style="height: 40px; text-align: center; font-size: large; width: 600px; background-color: #21AFB8" id="PopupHeader">
                    <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label>
                </div>
                <div class="PopupBody" style="height: 270px; width: 600px">
                    <div style="margin: 5px 5px 5px 5px; overflow-x: scroll; overflow-y: scroll; height: 270px">
                        <asp:GridView ID="gvComment" runat="server" Width="1000px" GridLines="None" CssClass="table table-striped table-bordered table-hover table-condensed"
                            AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                            <Columns>
                                <asp:BoundField DataField="CommentID" Visible="false" />
                                <asp:BoundField DataField="Comment" HeaderText="Comments" ItemStyle-Width="400px" />
                                <asp:BoundField DataField="CreateDate" HeaderText="Date" ItemStyle-Width="200px" />
                                <asp:BoundField DataField="CreatedBy" HeaderText="Comment By" ItemStyle-Width="200px" />
                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="5px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDeletePost" Width="85px" runat="server" CssClass="btn btn-primary" Text="Delete" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="Controls" style="height: 40px; background-color: #FFFFFF; text-align: center; width: 600px">
                    <asp:Button ID="btnClose" CssClass="btn btn-primary" Width="80px" runat="server" Text="Close" />
                    <input type="hidden" runat="server" id="btnShow" />
                </div>
                <div></div>
            </div>

        </asp:Panel>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>

