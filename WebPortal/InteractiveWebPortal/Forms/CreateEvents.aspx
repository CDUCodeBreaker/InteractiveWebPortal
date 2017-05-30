<%@ Page Title="WebPortal | Events" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CreateEvents.aspx.cs" Inherits="InteractiveWebPortal.Forms.CreateEvents" %>

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
                            <a href="CreateEvents.aspx" class="list-group-item  active main-color-bg"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span>Events </a>
                            <a href="UploadResource.aspx" class="list-group-item"><span class="glyphicon glyphicon-cloud-upload" aria-hidden="true"></span>Resources </a>
                            <a href="CreateGroup.aspx" class="list-group-item"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="ViewSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                            <a href="ViewBlockComments.aspx" class="list-group-item"><span class="glyphicon glyphicon-ban-circle" aria-hidden="true"></span>Block Comments </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">List of Events</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvEvents" OnRowDataBound="gvEvents_RowDataBound" OnRowCommand="gvEvents_RowCommand" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="EventID" Visible="false" />
                                                <asp:BoundField DataField="EventName" HeaderText="Name" />
                                                <asp:BoundField DataField="EventDescription" HeaderText="Description" Visible="false" />
                                                <asp:BoundField DataField="StartDate" HeaderText="StartDate" Visible="false" />
                                                <asp:BoundField DataField="EndDate" HeaderText="EndDate" Visible="false" />
                                                <asp:BoundField DataField="StartTime" HeaderText="StartTime" Visible="false" />
                                                <asp:BoundField DataField="EndTime" HeaderText="EndTime" Visible="false" />
                                                <asp:BoundField DataField="Location" HeaderText="Location" Visible="false" />
                                                <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" />
                                                <asp:BoundField DataField="UpdatedBy" HeaderText="EditedBy" />
                                                <asp:BoundField DataField="FilePath" Visible="false" />
                                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEditEvent" OnClick="btnEditEvent_Click" CssClass="btn btn-primary" runat="server" Text="Edit" />
                                                        <asp:Button ID="btnDeleteEvent" OnClick="btnDeleteEvent_Click" runat="server" CssClass="btn btn-primary" Text="Delete" />
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
                                <h3 class="panel-title">Add Events</h3>
                            </div>
                            <div class="panel-body">
                                <table class="table">
                                    <tr>
                                        <td style="width: 15%; text-align: right">
                                            <label class="control-label">Event Name</label>
                                        </td>
                                        <td style="width: 5%; text-align: center">:</td>
                                        <td style="width: 70%; text-align: left">
                                            <asp:TextBox ID="txtEventName" Width="30%" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%; text-align: right">
                                            <label class="control-label">Description</label>
                                        </td>
                                        <td style="width: 5%; text-align: center">:</td>
                                        <td style="width: 70%; text-align: left">
                                            <asp:TextBox ID="txtEventDescription" Width="30%" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%; text-align: right">
                                            <label class="control-label">Start Date</label>
                                        </td>
                                        <td style="width: 5%; text-align: center">:</td>
                                        <td style="width: 70%; text-align: left">
                                            <asp:TextBox ID="txtStartDate" Width="30%" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtStartTime" Width="30%" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%; text-align: right">
                                            <label class="control-label">End Date</label>
                                        </td>
                                        <td style="width: 5%; text-align: center">:</td>
                                        <td style="width: 70%; text-align: left">
                                            <asp:TextBox ID="txtEndDate" Width="30%" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="txtEndTime" Width="30%" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 15%; text-align: right">
                                            <label class="control-label">Location</label>
                                        </td>
                                        <td style="width: 5%; text-align: center">:</td>
                                        <td style="width: 70%; text-align: left">
                                            <asp:TextBox ID="txtLocation" Width="30%" CssClass="medium m-wrap" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 15%; text-align: right">
                                            <label class="control-label">Upload</label>
                                        </td>
                                        <td style="width: 5%; text-align: center">:</td>
                                        <td style="width: 70%; text-align: left">
                                            <asp:FileUpload ID="FileUploadControl" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <div class="form-group" style="text-align: center">
                                    <asp:Button ID="btnSubmitEvents" OnClick="btnSubmitEvents_Click" OnClientClick="if ( ! CheckEventFormValidation()) return false;" class="btn btn-info" runat="server" Text="Submit" />
                                    <asp:Button ID="btnCancelEvents" OnClick="btnCancelEvents_Click" class="btn" runat="server" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>


        <input id="hdnEndTime" runat="server" type="hidden" value="" />
        <input id="hdnStartTime" runat="server" type="hidden" value="" />


        <div id="id01" runat="server" class="w3-modal">
            <div class="w3-modal-content">
                <header class="w3-container w3-teal" style="text-align: center; height: 50px">
                    <span onclick="action()"
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
        $(function () {
            var valStartTime = $('input[id$=hdnStartTime]').val();
            var valEndTime = $('input[id$=hdnEndTime]').val();
            $("[id$=txtStartDate]").datepicker({
                format: 'dd/mm/yyyy'
            });
            $("[id$=txtStartTime]").timepicker({
                defaultTime: valStartTime,
                showInputs: true
            });
            $("[id$=txtEndDate]").datepicker({
                format: 'dd/mm/yyyy'
            });
            $("[id$=txtEndTime]").timepicker({
                defaultTime: valEndTime,
                showInputs: true
            });
        });
        function action() {
            document.getElementById('ContentPlaceHolder1_id01').style.display = "none";
        }
    </script>
</asp:Content>
