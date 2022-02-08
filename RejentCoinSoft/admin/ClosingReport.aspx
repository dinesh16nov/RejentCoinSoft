<%@ Page Title="Closing Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="ClosingReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
           <h4 class="page-title">Closing Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Closing Report</li>
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
                                         <asp:Button ID="btnExcel" CssClass="btn info" runat="server" Text="Excel" OnClick="btnExcel_Click" />
                                    </div>
                                </div>
                        </div>
            </div>

            <div class="card">
                    <div class="card-header">
                        <h5>Closing List</h5>
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
                                     <asp:TemplateField HeaderText="User ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="User Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblusername" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblusername" runat="server" Text='<%#Eval("closingdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                      <asp:TemplateField HeaderText="Matching Business">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbusamy" runat="server" Text='<%#Eval("matchingbusiness") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                                     
                                    <asp:TemplateField HeaderText="Income">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("income") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                                     
                                  <%--    <asp:TemplateField HeaderText="Ac Holder Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("AccountHolderName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Account No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("AccountNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="BankName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="IFSC Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("IFSCCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Branch Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Pan No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" Text='<%#Eval("PanNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
         <Triggers>
            <asp:PostBackTrigger ControlID="btnExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
      
</asp:Content>

