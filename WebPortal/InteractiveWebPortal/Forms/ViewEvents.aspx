<%@ Page Title="WebPortal | Events" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewEvents.aspx.cs" Inherits="InteractiveWebPortal.Forms.ViewEvents" %>

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
                            <a href="ViewEvents.aspx" class="list-group-item active main-color-bg"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span>Events </a>
                            <a href="DownloadResource.aspx" class="list-group-item"><span class="glyphicon glyphicon-cloud-download" aria-hidden="true"></span>Resources </a>
                            <a href="ViewGroups.aspx" class="list-group-item"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="CreateSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Events</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvEventList" OnRowDataBound="gvEventList_RowDataBound" OnRowCommand="gvEventList_RowCommand" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="EventID" Visible="false" />
                                                <asp:BoundField DataField="EventName" HeaderText="Name" />
                                                <asp:BoundField DataField="EventDescription" HeaderText="EventDescription" Visible="false" />
                                                <asp:BoundField DataField="StartDate" HeaderText="StartDate" Visible="false" />
                                                <asp:BoundField DataField="EndDate" HeaderText="EndDate" Visible="false" />
                                                <asp:BoundField DataField="StartTime" HeaderText="StartTime" Visible="false" />
                                                <asp:BoundField DataField="EndTime" HeaderText="EndTime" Visible="false" />
                                                <asp:BoundField DataField="Location" HeaderText="Location" Visible="false" />
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

        <div id="vieweventpopup" runat="server" class="w3-modal">
            <div class="w3-modal-content">
                <header class="w3-container w3-teal" style="text-align: center; height: 50px">
                    <span onclick="closeeventpopup()"
                        class="w3-button w3-display-topright">&times;</span>
                </header>
                <div class="w3-container">
                    <table style="margin: 10px 10px 10px 10px">
                        <tr>
                            <td style="width: 40%">
                                <asp:Image ID="Image1" ImageUrl="~/Images/wallpapers/8.jpg" Width="400px" runat="server" />
                            </td>
                            <td style="width: 10%"></td>
                            <td style="width: 40%; vertical-align: top">


                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                            <div style="font-family: Cambria; font-size: large; font-weight: bold">
                                                <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="font-family: Cambria; font-size: small; font-weight: bold">
                                                <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                                                &nbsp; 
                                                <asp:Label ID="lblStartTime" runat="server" Text=""></asp:Label>
                                                - 
                                                <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                                                &nbsp;
                                                <asp:Label ID="lblEndTime" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="font-family: Cambria; font-size: small; font-weight: bold">
                                                Venue:
                                                <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="font-family: Cambria; font-size: small">
                                                <asp:Label ID="lblEventDescription" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <footer class="w3-container w3-teal">
                </footer>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
     <script>
         function closeeventpopup() {
             document.getElementById('ContentPlaceHolder1_vieweventpopup').style.display = "none";
        }
    </script>
</asp:Content>
