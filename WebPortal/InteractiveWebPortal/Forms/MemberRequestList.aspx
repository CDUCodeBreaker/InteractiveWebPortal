<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="MemberRequestList.aspx.cs" Inherits="InteractiveWebPortal.Forms.MemberRequestList" %>

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
                                <span class="glyphicon glyphicon-dashboard  active main-color-bg" aria-hidden="true"></span>Member Request List
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
                            <a href="ViewBlockComments.aspx" class="list-group-item"><span class="glyphicon glyphicon-ban-circle" aria-hidden="true"></span>Block Comments </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Request List</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvMemberRequest" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="UserID" Visible="false" />
                                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                                <asp:BoundField DataField="MembershipNo" HeaderText="Membership#" />
                                                <asp:BoundField DataField="Email" HeaderText="Email" Visible="false" />
                                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" Visible="false" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" Visible="false" />
                                                <asp:BoundField DataField="Suburb" HeaderText="Suburb" Visible="false" />
                                                <asp:BoundField DataField="FilePath" Visible="false" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnApprove" CssClass="btn btn-primary" runat="server" OnClick="btnApprove_Click" Text="Approve" />
                                                        <asp:Button ID="btnReject" runat="server" CssClass="btn btn-primary" OnClick="btnReject_Click" Text="Reject" />
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
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
