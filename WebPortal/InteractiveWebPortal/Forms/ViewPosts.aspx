<%@ Page Title="WebPortal | View Posts" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="ViewPosts.aspx.cs" Inherits="InteractiveWebPortal.Forms.ViewPosts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <style>
        .Grid {
            table-layout: fixed;
            width: 100%;
        }

            .Grid .Shorter {
                overflow: hidden;
                text-overflow: ellipsis;
                white-space: nowrap;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <section id="main">
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                        <div class="list-group">
                            <a href="ViewPosts.aspx" class="list-group-item active main-color-bg"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>Posts </a>
                            <a href="ViewEvents.aspx" class="list-group-item"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span>Events </a>
                            <a href="DownloadResource.aspx" class="list-group-item"><span class="glyphicon glyphicon-cloud-download" aria-hidden="true"></span>Resources </a>
                            <a href="ViewGroups.aspx" class="list-group-item"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="CreateSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Posts</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvPost" runat="server" GridLines="None" CssClass="Grid" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="PostID" Visible="false" />
                                                <asp:BoundField DataField="PostSubject" HeaderText="Subject" />
                                                <asp:BoundField DataField="PostBody" SortExpression="post" ItemStyle-CssClass="Shorter" HeaderText="Post" />
                                                <asp:BoundField DataField="CreatedBy" HeaderText="Posted By" />
                                                <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                                                <asp:BoundField DataField="Status" Visible="false" />
                                                <asp:BoundField DataField="UpdateBy" Visible="false" />
                                                <asp:BoundField DataField="UpdateDate" Visible="false" />
                                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAddComment" runat="server" OnClick="btnAddComment_Click" CssClass="btn btn-primary custom" Text="Add" />
                                                        <asp:Button ID="btnViewComment" runat="server" OnClick="btnViewComment_Click" CssClass="btn btn-primary custom" Text="View" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--  <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Write Comment</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <asp:TextBox ID="txtComment" Enabled="false" CssClass="medium m-wrap" Style="resize: none" Width="100%" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" style="text-align: center">
                                    <asp:Button ID="btnSaveComment" OnClick="btnSaveComment_Click" Enabled="false" class="btn btn-primary custom" runat="server" Text="Save" />
                                    <asp:Button ID="btnCancelComment" OnClick="btnCancelComment_Click" Enabled="false" class="btn btn-primary custom" runat="server" Text="Cancel" />
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </section>


        <div id="viewcommentpopup" runat="server" class="w3-modal">
            <div class="w3-modal-content">
                <header class="w3-container w3-teal" style="text-align: center; height: 50px">
                    <span onclick="closeviewcommentpopup()"
                        class="w3-button w3-display-topright">&times;</span>
                    <p>
                        <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label>
                    </p>
                </header>
                <div class="w3-container">
                    <asp:GridView ID="gvComment" runat="server" Width="100%" GridLines="None" CssClass="table table-striped table-bordered table-hover table-condensed"
                        AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                        <Columns>
                            <asp:BoundField DataField="CommentID" Visible="false" />
                            <asp:BoundField DataField="Comment" SortExpression="comment" ItemStyle-CssClass="Shorter" HeaderText="Comments" />
                            <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                            <asp:BoundField DataField="CreatedBy" HeaderText="Comment By" />
                        </Columns>
                    </asp:GridView>
                </div>
                <footer class="w3-container w3-teal">
                </footer>
            </div>
        </div>

        <div id="addcommentpopup" runat="server" class="w3-modal">
            <div class="w3-modal-content">
                <header class="w3-container w3-teal" style="text-align: center; height: 50px">
                    <span onclick="closecommentpopup()"
                        class="w3-button w3-display-topright">&times;</span>
                    <p>
                        Write Comment
                    </p>
                </header>
                <div class="w3-container">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 100%">
                                        <asp:TextBox ID="txtComment" TextMode="MultiLine" Height="100px" CssClass="medium m-wrap" Width="100%" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <footer class="w3-container w3-teal" style="text-align: center">
                    <asp:Button ID="btnSaveComment" OnClick="btnSaveComment_Click" Enabled="false" class="btn btn-primary custom" runat="server" Text="Submit" />
                    <asp:Button ID="btnCancelComment" OnClick="btnCancelComment_Click" Enabled="false" class="btn btn-primary custom" runat="server" Text="Cancel" />
                </footer>
            </div>
        </div>

    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        function closeviewcommentpopup() {
            document.getElementById('ContentPlaceHolder1_viewcommentpopup').style.display = "none";
        } function closecommentpopup() {
            document.getElementById('ContentPlaceHolder1_addcommentpopup').style.display = "none";
        }
    </script>
</asp:Content>
