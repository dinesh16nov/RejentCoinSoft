<%@ Page Title="Direct Income Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="DirectIncomeReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Direct Income Report</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Direct Income Report</li>
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
                </div>
            </div>

            <div class="card">
                <div class="card-header">
                    <h5>Direct Income Report</h5>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
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
                                <asp:TemplateField HeaderText="User Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblusenamegf" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblusername" runat="server" Text='<%#Eval("transactionid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Topup Amount($)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("Topupamount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comm %">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("commissionPercent") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comm Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("commissionamount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Junior User Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljuniotruserid" runat="server" Text='<%#Eval("junioruserid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
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

