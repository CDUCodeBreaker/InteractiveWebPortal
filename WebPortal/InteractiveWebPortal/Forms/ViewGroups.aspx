<%@ Page Title="WebPortal | Groups" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="ViewGroups.aspx.cs" Inherits="InteractiveWebPortal.Forms.ViewGroups" %>

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
                            <a href="ViewGroups.aspx" class="list-group-item  active main-color-bg"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="CreateSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">My Groups</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvGroupList" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="GroupID" Visible="false" />
                                                <asp:BoundField DataField="GroupName" HeaderText="Group Name" />
                                                <asp:BoundField DataField="CreatedBy" Visible="false" />
                                                <asp:BoundField DataField="CreateDate" HeaderText="Create Date" />
                                                <asp:BoundField DataField="Status" Visible="false" />
                                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnViewMember" OnClick="btnViewMember_Click" CssClass="btn btn-primary" runat="server" Text="View Member" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <div id="ViewMemberPopup" runat="server" class="w3-modal">
            <div class="w3-modal-content">
                <header class="w3-container w3-teal">
                    <span onclick="closeMemberPopup()"
                        class="w3-button w3-display-topright">&times;</span>
                    <h2>Group Members List</h2>
                </header>
                <div class="w3-container">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <asp:GridView ID="gvGroupMember" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                <Columns>
                                    <asp:BoundField DataField="UserID" Visible="false" />
                                    <asp:BoundField DataField="UserName" HeaderText="Name" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <footer class="w3-container w3-teal" style="text-align: center">
                </footer>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <script>
        function closeMemberPopup() {
            document.getElementById('ContentPlaceHolder1_ViewMemberPopup').style.display = "none";
        }
    </script>
</asp:Content>
