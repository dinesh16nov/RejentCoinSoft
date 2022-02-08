<%@ Page Title="Staking Report" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="StackingReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
  <h4 class="page-title">Staking Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Staking Report</li>
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
                        <h5>Staking Report</h5>
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
                                    <asp:TemplateField HeaderText="User Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblid" Visible="false" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                            <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                              <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Coins">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("coins") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Coins in Dollar">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamountdollar" runat="server" Text='<%#Eval("dollaramount") %>'></asp:Label>
                                           <br /> <span style="font-size:11px;padding:1px 4px" class="badge badge-warning">1 Coin= <%#Eval("qaurecointodollar") %> $</span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                              
                                   
                                  <asp:TemplateField HeaderText="Plan">
                                        <ItemTemplate>
                                            <asp:Label ID="lblplanname" runat="server" Text='<%#Eval("planname") %>'></asp:Label>
                                         (   <asp:Label ID="lbltenure" runat="server" Text='<%#Eval("tenure") %>'></asp:Label> Months)
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                     
                                     <asp:TemplateField HeaderText="Hash">
                                        <ItemTemplate>
                                           <a target="_blank" href='https://bscscan.com/tx/<%#Eval("Transactionhash") %>'> <asp:Label ID="lblremark" runat="server" Text='<%#Eval("Transactionhash") %>'></asp:Label><a>
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

