<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="ViewBlockComments.aspx.cs" Inherits="InteractiveWebPortal.Forms.ViewBlockComments" %>

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
                            <a href="CreatePost.aspx" class="list-group-item"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>Posts </a>
                            <a href="CreateEvents.aspx" class="list-group-item"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span>Events </a>
                            <a href="UploadResource.aspx" class="list-group-item"><span class="glyphicon glyphicon-cloud-upload" aria-hidden="true"></span>Resources </a>
                            <a href="CreateGroup.aspx" class="list-group-item"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="ViewSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                            <a href="ViewBlockComments.aspx" class="list-group-item active main-color-bg"><span class="glyphicon glyphicon-ban-circle" aria-hidden="true"></span>Block Comments </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">List of Block Comments</h3>
                            </div>
                            <div class="panel-body">
                                <div style="overflow-x: scroll; overflow-y: scroll">
                                    <asp:GridView ID="gvBlockComment" CssClass="Grid" runat="server" Width="100%" GridLines="None"
                                        AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                        <Columns>
                                            <asp:BoundField DataField="CommentID" Visible="false" />
                                            <asp:BoundField DataField="Comment" SortExpression="comment" ItemStyle-CssClass="Shorter" HeaderText="Comments" />
                                            <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                                            <asp:BoundField DataField="CreatedBy" HeaderText="Commented By" />
                                            <asp:BoundField DataField="PostID" Visible="false" />
                                        </Columns>
                                    </asp:GridView>
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
