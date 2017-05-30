<%@ Page Title="WebPortal | News" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="CreateNews.aspx.cs" Inherits="InteractiveWebPortal.Forms.CreateNews" %>


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
                                <span class="glyphicon glyphicon-dashboard" aria-hidden="true"></span> Dashboard
                            </a>
                            <a href="CreatePost.aspx" class="list-group-item"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span> Posts </a>
                            <a href="CreateEvents.aspx" class="list-group-item"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span> Events </a>
                            <a href="CreateNews.aspx" class="list-group-item  active main-color-bg"><span class="glyphicon glyphicon-book" aria-hidden="true"></span> News </a>
                            <a href="UploadResource.aspx" class="list-group-item"><span class="glyphicon glyphicon-cloud-upload" aria-hidden="true"></span> Resources </a>
                            <a href="CreateAnnouncement.aspx" class="list-group-item"><span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span> Announcements </a>
                            <a href="CreateGroup.aspx" class="list-group-item"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span> Groups </a>
                            <a href="ViewSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span> Suggestions </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">List of News</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvNews" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="NewsID" Visible="false" />
                                                <asp:BoundField DataField="NewsHeadLine" HeaderText="HeadLine" />
                                                <asp:BoundField DataField="NewsBody" HeaderText="Body" />
                                                <asp:BoundField DataField="CreatedBy" Visible="false" />
                                                <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                                                <asp:BoundField DataField="Status" Visible="false" />
                                                <asp:BoundField DataField="UpdateBy" Visible="false" />
                                                <asp:BoundField DataField="UpdateDate" Visible="false" />
                                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEditNews" CssClass="btn btn-primary" runat="server" OnClick="btnEditNews_Click" Text="Edit" />
                                                        <asp:Button ID="btnDeleteNews" runat="server" CssClass="btn btn-primary" OnClick="btnDeleteNews_Click" Text="Delete" />
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
                                <h3 class="panel-title">Write News</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label class="control-label">Headline</label>
                                    <asp:TextBox ID="txtHeadLine" CssClass="medium m-wrap" Width="100%" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Body</label>
                                    <asp:TextBox ID="txtNewsBody" CssClass="medium m-wrap" Style="resize: none" TextMode="MultiLine" Height="100px" Width="100%" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" style="text-align: center">
                                    <asp:Button ID="btnSubmitNews" class="btn btn-info" OnClick="btnSubmitNews_Click" runat="server" OnClientClick="if ( ! CheckPostValidation()) return false;" Text="Save" />
                                    <asp:Button ID="btnCancelNews" class="btn" OnClick="btnCancelNews_Click" runat="server" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnShow"
            CancelControlID="btnClose" X="350" Y="150" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>

        <asp:Panel ID="Panel1" Style="display: none; height: 1000px; width: 600px" runat="server">
            <div class="HellowWorldPopup">
                <div class="PopupHeader" style="height: 40px; text-align: center; font-size: large; width: 600px; background-color: #21AFB8" id="PopupHeader">
                    <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label>
                </div>
                <div class="PopupBody" style="height: 270px; width: 600px">
                    <div style="margin-left: 10px; margin-right: 10px; margin-top: 10px; margin-bottom: 10px">
                        <asp:GridView ID="gvComment" runat="server" Width="100%" GridLines="None" CssClass="table table-striped table-bordered table-hover table-condensed"
                            AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                            <Columns>
                                <asp:BoundField DataField="CommentID" Visible="false" />
                                <asp:BoundField DataField="Comment" HeaderText="Comments" ItemStyle-Width="200px" />
                                <asp:BoundField DataField="CreateDate" HeaderText="Date" ItemStyle-Width="200px" />
                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="5px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDeletePost" runat="server" CssClass="btn btn-primary" Text="Delete" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="Controls" style="height: 40px; background-color: #FFFFFF; text-align: center; width: 600px">
                    <asp:Button ID="btnClose" runat="server" Text="Close" />
                    <input type="hidden" runat="server" id="btnShow" />
                </div>
            </div>

        </asp:Panel>


    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        function CheckPostValidation() {
            var subject = document.getElementById("txtPostSubject").value;
            var post = document.getElementById("txtPostBody").value;
            if (!document.getElementById("txtPostSubject").value) {
                $('#txtPostSubject').notify('Required!');
            }
            if (!document.getElementById("txtPostBody").value) {
                $('#txtPostBody').notify('Required!');
            }

            if (!subject || !post) {
                return false;
            }
            else
                return true;
        }
    </script>
</asp:Content>
