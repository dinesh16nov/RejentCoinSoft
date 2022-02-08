<%@ Page Title="Team Rijent Wallet Transfer Report" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="RijentPayWalletTransferReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Team Rijent Wallet Trasnfer Report</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Team Rijent Wallet Transfer Report</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header">
                    <h5>Search Criteria</h5>
                </div>
                <div class="card-body">
                    <fieldset>
                        <div class="row form-group">
                            <div class="col-md-2">From Date</div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">To Date</div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txttodate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-2">User Id</div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtuserid" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <hr />
                        <div class="row form-group">
                            <div class="col-md-12">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div class="card">
                <div class="card-header">
                    <h5>Team Rijent Wallet Transfer Report</h5>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="From User Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid" Visible="false" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                        <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("fromuserid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="To User Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltouserid" runat="server" Text='<%#Eval("touserid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblusername" runat="server" Text='<%#Eval("transactionid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblemail" runat="server" Text='<%#Eval("Remark") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <span onclick="return confirm_click();">
                                                <asp:LinkButton ID="lbReverse" CommandName="myReverse" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server">Reverse</asp:LinkButton>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

