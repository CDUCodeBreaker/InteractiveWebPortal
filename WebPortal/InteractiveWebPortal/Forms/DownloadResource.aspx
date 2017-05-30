﻿<%@ Page Title="WebPortal | Resource" Language="C#" MasterPageFile="~/Forms/WebPortal.Master" AutoEventWireup="true" CodeBehind="DownloadResource.aspx.cs" Inherits="InteractiveWebPortal.Forms.DownloadResource" %>

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
                            <a href="DownloadResource.aspx" class="list-group-item  active main-color-bg"><span class="glyphicon glyphicon-cloud-download" aria-hidden="true"></span>Resources </a>
                            <a href="ViewGroups.aspx" class="list-group-item"><span class="glyphicon glyphicon-tree-deciduous" aria-hidden="true"></span>Groups </a>
                            <a href="CreateSuggestions.aspx" class="list-group-item"><span class="glyphicon glyphicon-inbox" aria-hidden="true"></span>Suggestions </a>
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <div class="panel panel-default">
                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Documents</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvDocuments" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="ResourceID" Visible="false" />
                                                <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("ResourceID") %>' runat="server" OnClick="DownloadFile" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Videos</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvVideos" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="ResourceID" Visible="false" />
                                                <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                                <%--<asp:TemplateField>
                                                    <ItemTemplate>
                                                        <video style="height: 300px; width: 200px" controls="controls">
                                                            <source src='<%# Page.ResolveClientUrl(Eval("FilePath").ToString()) %>' type="video/mp4">
                                                        </video>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("ResourceID") %>' runat="server" OnClick="DownloadFile" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-heading main-color-bg">
                                <h3 class="panel-title">Audios</h3>
                            </div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div style="overflow-x: auto;">
                                        <asp:GridView ID="gvAudios" runat="server" GridLines="None" CssClass="table table-striped table-hover" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
                                            <Columns>
                                                <asp:BoundField DataField="ResourceID" Visible="false" />
                                                <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                              <%--  <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <audio controls="controls">
                                                            <source src='<%# Page.ResolveClientUrl(Eval("FilePath").ToString()) %>' type="audio/mpeg">
                                                        </audio>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("ResourceID") %>' runat="server" OnClick="DownloadFile" />
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
