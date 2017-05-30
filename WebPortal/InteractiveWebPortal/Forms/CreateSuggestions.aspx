<%@ Page Title="WebPortal | Suggestions" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="CreateSuggestions.aspx.cs" Inherits="InteractiveWebPortal.Forms.CreateSuggestions" %>

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
                            <a href="CreateSuggestions.aspx" class="list-group-item  active main-color-bg"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">List of Suggestion</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvMySuggestionList" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="SuggestionID" Visible="false" />
                                                <asp:BoundField DataField="Suggestions" HeaderText="Suggestions" />
                                                <asp:BoundField DataField="CreatedBy" Visible="false" />
                                                <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                                                <asp:BoundField DataField="UserID" Visible="false" />
                                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEditSuggestion" runat="server" OnClick="btnEditSuggestion_Click" CssClass="btn btn-primary" Text="Edit" />
                                                        <asp:Button ID="btnDeleteSuggestion" runat="server" OnClick="btnDeleteSuggestion_Click" CssClass="btn btn-primary" Text="Delete" />
                                                        <asp:Button ID="btnReply" runat="server" OnClick="btnReply_Click" CssClass="btn btn-primary" Text="Reply" />
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
                                <h3 class="panel-title">Write Suggestion</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label class="control-label">Suggestion</label>
                                    <asp:TextBox ID="txtSuggestion" CssClass="medium m-wrap" Style="resize: none" TextMode="MultiLine" Height="100px" Width="100%" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" style="text-align: center">
                                    <asp:Button ID="btnSaveSuggestion" OnClick="btnSaveSuggestion_Click" class="btn btn-info" runat="server" Text="Submit" />
                                    <asp:Button ID="btnCancelSuggestion" OnClick="btnCancelSuggestion_Click" class="btn btn-info" runat="server" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <div id="popupreply" runat="server" class="w3-modal">
            <div class="w3-modal-content">
                <header class="w3-container w3-teal">
                    <span onclick="CloseReplyPopup()"
                        class="w3-button w3-display-topright">&times;</span>
                    <h3>Reply</h3>
                </header>
                <div class="w3-container">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 80%">
                                        <asp:TextBox ID="txtReply" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" CssClass="btn btn-primary custom" Text="Submit" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 80%">
                                        <asp:GridView ID="gvReplySuggestion" runat="server" Width="100%" GridLines="None" CssClass="table table-striped table-bordered table-hover table-condensed"
                                            AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="ReplyID" Visible="false" />
                                                <asp:BoundField DataField="SuggestionID" Visible="false" />
                                                <asp:BoundField DataField="Reply" HeaderText="Reply" />
                                                <asp:BoundField DataField="RepliedBy" HeaderText="Replied By" />
                                                <asp:BoundField DataField="ReplyDate" HeaderText="Date" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                </div>
                <footer class="w3-container w3-teal">
                </footer>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        function CloseReplyPopup() {
            document.getElementById('ContentPlaceHolder1_popupreply').style.display = "none";
        }
    </script>
</asp:Content>
