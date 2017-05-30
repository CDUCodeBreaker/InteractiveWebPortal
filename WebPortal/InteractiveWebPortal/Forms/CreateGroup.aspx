<%@ Page Title="WebPortal | Group" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="CreateGroup.aspx.cs" Inherits="InteractiveWebPortal.Forms.CreateGroup" %>

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
                            <a href="CreateGroup.aspx" class="list-group-item active main-color-bg"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="ViewSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                            <a href="ViewBlockComments.aspx" class="list-group-item"><span class="glyphicon glyphicon-ban-circle" aria-hidden="true"></span>Block Comments </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">List of Groups</h3>
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
                                                        <asp:Button ID="btnEditGroup" OnClick="btnEditGroup_Click" CssClass="btn btn-primary" runat="server" Text="Edit" />
                                                        <asp:Button ID="btnDeleteGroup" OnClick="btnDeleteGroup_Click" CssClass="btn btn-primary" runat="server" Text="Delete" />
                                                        <asp:Button ID="btnViewMember" OnClick="btnViewMember_Click" CssClass="btn btn-primary" runat="server" Text="View Member" />
                                                        <asp:Button ID="btnSendEmail" OnClick="btnSendEmail_Click" CssClass="btn btn-primary" runat="server" Text="Send Mail" />
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
                                <h3 class="panel-title">Add Group</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <label class="control-label">Group Name</label>
                                    <asp:TextBox ID="txtGroupName" CssClass="medium m-wrap" Width="50%" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">Members</label>
                                    <asp:GridView ID="gvMemberList" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkMember" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UserID" Visible="false" />
                                            <asp:BoundField DataField="UserName" HeaderText="Name" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="form-group" style="text-align: center">
                                    <asp:Button ID="btnSubmitGroup" OnClick="btnSubmitGroup_Click" class="btn btn-info" runat="server" Text="Submit" />
                                    <asp:Button ID="btnCancelGroup" OnClick="btnCancelGroup_Click" class="btn" runat="server" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <div id="PopupSendMail" runat="server" class="w3-modal">
            <div class="w3-modal-content">
                <header class="w3-container w3-teal">
                    <span onclick="action()"
                        class="w3-button w3-display-topright">&times;</span>
                    <h2>Send Email</h2>
                </header>
                <div class="w3-container">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 20%">Subject</td>
                                    <td style="width: 80%">
                                        <asp:TextBox ID="txtSubjectMail" CssClass="medium m-wrap" Width="100%" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px" colspan="2"></td>
                                </tr>
                                <tr>
                                    <td style="width: 20%">Body</td>
                                    <td style="width: 80%">
                                        <asp:TextBox ID="txtBodyMail" CssClass="medium m-wrap" Width="100%" TextMode="MultiLine" Style="resize: none" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

                <footer class="w3-container w3-teal" style="text-align: center">
                    <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" class="btn btn-info" Text="Send" />
                </footer>
            </div>
        </div>

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
        function action() {
            document.getElementById('ContentPlaceHolder1_PopupSendMail').style.display = "none";
        }
        function closeMemberPopup() {
            document.getElementById('ContentPlaceHolder1_ViewMemberPopup').style.display = "none";
        }
    </script>
</asp:Content>
