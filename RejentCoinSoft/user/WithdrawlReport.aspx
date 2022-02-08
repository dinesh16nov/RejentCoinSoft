<%@ Page Title="Withdrawl Report" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="WithdrawlReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Withdrawal Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Withdrawal Report</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <div class="card">
                    <div class="card-header">
                        <h5>Withdrawl List</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">From Date</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox runat="server" CssClass="form-control datepicker-here" ID="txtfromdate"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">To Date</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox runat="server" CssClass="form-control datepicker-here" ID="txttodate"></asp:TextBox>
                                    </div>
                                </div>
                               <%-- <div class="row form-group" style="display:none;">
                                    <div class="col-md-3">
                                        <label for="exampleInputEmail1">Status</label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddstatus" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">Select Status</asp:ListItem>
                                            <asp:ListItem>Pending</asp:ListItem>
                                            <asp:ListItem>Approved</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>--%>
                                <hr />
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                    </div>
                                </div>
<div class="row">
 <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grdGetHelp_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcreatingdate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Transaction Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltransactionid" runat="server" Text='<%#Eval("TransactionId") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount($)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("dramount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Transaction Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwallettype" runat="server" Text='<%#Eval("transactiontype") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remark">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwalletaddress" runat="server" Text='<%#Eval("remark") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
</div>
                </div>
            </div>
       
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

