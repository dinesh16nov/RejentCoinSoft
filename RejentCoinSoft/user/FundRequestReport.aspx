<%@ Page Title="Fund Request Report" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="FundRequestReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
 <h4 class="page-title">Fund Request Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Fund Request Report</li>
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

                                <div class="row form-group">
                                    <div class="col-md-2">From Date</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">To Date</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txttodate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
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

            <div class="ibox float-e-margins">
          <div class="card">
                    <div class="card-header">
                        <h5>Fund Request Report</h5>
                    </div>
                    <div class="card-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                   <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Request">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcreatingdate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Deposit Wallet">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepositwallet" runat="server" Text='<%#Eval("DepositWalletType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approve Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblreleasedate" runat="server" Text='<%#Eval("approvedate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Wallet Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwallettype" runat="server" Text='<%#Eval("wallettype") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     
                                          <%--  <asp:TemplateField HeaderText="Wallet Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwalletaddress" runat="server" Text='<%#Eval("walletaddress") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                          
                                 
                                    <asp:TemplateField HeaderText="Transaction Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltransactionid" runat="server" Text='<%#Eval("OnlineTransactionId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Remark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblremark" runat="server" Text='<%#Eval("remark") %>'></asp:Label>
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

