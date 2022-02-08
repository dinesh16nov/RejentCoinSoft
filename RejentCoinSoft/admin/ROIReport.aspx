<%@ Page Title="ROI Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="ROIReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">ROI Report</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">ROI Report</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="modal2">
                        <div class="center2">
                            <img alt="" src="loader.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="card">
                <div class="card-header">
                    <h5>Search Criteria</h5>
                </div>
                <div class="card-body">
                    <div class="row form-group">
                        <div class="col-md-3">
                            From Date
                                        <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            To Date
                                        <asp:TextBox ID="txttodate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            User Id
                                        <asp:TextBox ID="txtuserid" AutoPostBack="true" OnTextChanged="txtuserid_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Invested Amount
                                        <asp:DropDownList ID="ddtopup" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">Select Amount</asp:ListItem>
                                        </asp:DropDownList>
                        </div>
                    </div>

                    <hr />
                    <div class="row form-group">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            <asp:Button ID="btnExport" CssClass="btn" runat="server" Text="Excel" OnClick="ExportToExcel" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header">
                    <h5>ROI Report</h5>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="true" PageSize="40" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--   
                                    <asp:TemplateField HeaderText="User Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblusenamegf" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Mobile">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                <%--   <asp:TemplateField HeaderText="Topup Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinvestedamount" runat="server" Text='<%#Eval("topupamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Total Coins">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinvestedamount" runat="server" Text='<%#Eval("totalcoin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Total Days">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltenure" runat="server" Text='<%#Eval("ROIDays") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField> --%>
                                <asp:TemplateField HeaderText="Minting Coin">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Minting Amount($)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblconvertedamount" runat="server" Text='<%#Eval("convertedamount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblclosingdate" Visible="false" runat="server" Text='<%#Eval("closingdate") %>'></asp:Label>
                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("closingdate2","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltype" runat="server" Text='<%#Eval("mintingtype") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

