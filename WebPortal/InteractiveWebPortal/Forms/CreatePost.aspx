<%@ Page Title="WebPortal | Post" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="InteractiveWebPortal.Forms.CreatePost" %>

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
                            <a href="MemberRequestList.aspx" class="list-group-item">
                                <span class="glyphicon glyphicon-dashboard" aria-hidden="true"></span>Member Request List
                            </a>
                            <a href="MemberApproveList.aspx" class="list-group-item">
                                <span class="glyphicon glyphicon-dashboard" aria-hidden="true"></span>Member Approval List
                            </a>
                            <a href="MemberBlockList.aspx" class="list-group-item">
                                <span class="glyphicon glyphicon-dashboard" aria-hidden="true"></span>Member Block List
                            </a>
                            <a href="CreatePost.aspx" class="list-group-item  active main-color-bg"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>Posts </a>
                            <a href="CreateEvents.aspx" class="list-group-item"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span>Events </a>
                            <a href="UploadResource.aspx" class="list-group-item"><span class="glyphicon glyphicon-cloud-upload" aria-hidden="true"></span>Resources </a>
                            <a href="CreateGroup.aspx" class="list-group-item"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="ViewSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                            <a href="ViewBlockComments.aspx" class="list-group-item"><span class="glyphicon glyphicon-ban-circle" aria-hidden="true"></span>Block Comments </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">List of Posts</h3>
                            </div>
                            <div class="panel-body">
                                <div style="overflow-x: auto;">
                                    <asp:GridView ID="gvPost" CssClass="Grid" runat="server" Width="100%" RowStyle-Wrap="false" GridLines="None" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                        <Columns>
                                            <asp:BoundField DataField="PostID" Visible="false" />
                                            <asp:BoundField DataField="PostSubject" SortExpression="subject" ItemStyle-CssClass="Shorter" HeaderText="Subject" />
                                            <asp:BoundField DataField="PostBody" SortExpression="post" ItemStyle-CssClass="Shorter" HeaderText="Post" />
                                            <asp:BoundField DataField="CreatedBy" HeaderText="Posted By" />
                                            <asp:BoundField DataField="UpdateBy" HeaderText="Updated By" />
                                            <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                                            <asp:BoundField DataField="Status" Visible="false" />
                                            <asp:BoundField DataField="UpdateDate" Visible="false" />
                                            <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEditPost" CssClass="btn btn-primary" runat="server" OnClick="btnEditPost_Click" Text="Edit" />
                                                    <asp:Button ID="btnDeletePost" runat="server" CssClass="btn btn-primary" OnClick="btnDeletePost_Click" Text="Delete" />
                                                    <asp:Button ID="btnComment" runat="server" CssClass="btn btn-primary" OnClick="btnComment_Click" Text="User Comments" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Write Post</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label class="control-label">Subject</label>
                                    <asp:TextBox ID="txtPostSubject" CssClass="medium m-wrap" Width="100%" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Body</label>
                                    <asp:TextBox ID="txtPostBody" CssClass="medium m-wrap" Style="resize: none" TextMode="MultiLine" Height="100px" Width="100%" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" style="text-align: center">
                                    <asp:Button ID="btnSubmitPost" class="btn btn-info" OnClick="btnSubmitPost_Click" runat="server" OnClientClick="if ( ! CheckPostValidation()) return false;" Text="Submit" />
                                    <asp:Button ID="btnCancelPost" class="btn" OnClick="btnCancelPost_Click" runat="server" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <div id="id01" runat="server" class="w3-modal">
            <div class="w3-modal-content">
                <header class="w3-container w3-teal" style="text-align: center; height: 50px">
                    <span onclick="action()"
                        class="w3-button w3-display-topright">&times;</span>
                    <p>
                        <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label>
                    </p>
                </header>
                <div class="w3-container" style="margin: 10px 10px 10px 10px">
                    <asp:GridView ID="gvComment" OnRowDataBound="gvComment_RowDataBound" CssClass="Grid" runat="server" Width="100%" GridLines="None"
                        AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                        <Columns>
                            <asp:BoundField DataField="CommentID" Visible="false" />
                            <asp:BoundField DataField="Comment" SortExpression="comment" ItemStyle-CssClass="Shorter" HeaderText="Comments" />
                            <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                            <asp:BoundField DataField="CreatedBy" HeaderText="Commented By" />
                            <asp:BoundField DataField="PostID" Visible="false" />
                            <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Button ID="btnDeleteComment" runat="server" CssClass="btn btn-primary" OnClick="btnDeleteComment_Click" Text="Delete" />
                                    <asp:Button ID="btnBlockComment" runat="server" CssClass="btn btn-primary" OnClick="btnBlockComment_Click" Text="Block" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <footer class="w3-container w3-teal">
                </footer>
            </div>
        </div>
    </form>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        function action() {
            document.getElementById('ContentPlaceHolder1_id01').style.display = "none";
        }
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
