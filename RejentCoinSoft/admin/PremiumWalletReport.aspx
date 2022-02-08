<%@ Page Title="Premium Wallet Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="PremiumWalletReport.aspx.cs" Inherits="admin_UserReport" ValidateRequest="false" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
  <h4 class="page-title">Premium Wallet Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Premium Wallet Report</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal2">
                <div class="center2">
                    <img alt="" src="loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="card">
                    <div class="card-header">
                        <h5>Search Criteria</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">Name</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">Mobile</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtmobile" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">Email</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtemail" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="row form-group">
                                    <div class="col-md-2">From Date</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">To Date</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txttodate"  CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                        <div class="col-md-2">User Id</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtuserid"  CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                       
                               
                                <hr />
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit"  CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                               <asp:Button ID="btnExcel" CssClass="btn btn-secondary" runat="server" Text="Excel" OnClick="btnExcel_Click" />
                                    </div>
                                </div>
                </div>
            </div>

         <div class="card">
                    <div class="card-header">
                        <h5>Premium Wallet Report</h5>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">

                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AllowPaging="true" PageSize="40" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="User ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblusername" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField HeaderText="Monthly Return %">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("ReturnPercent") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Days">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("days") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                            <asp:TemplateField HeaderText="Coins">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("coins") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Limit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("Limit") %>'></asp:Label>
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
        </ContentTemplate><Triggers>
            <asp:PostBackTrigger ControlID="btnExcel" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
    
 
</asp:Content>

