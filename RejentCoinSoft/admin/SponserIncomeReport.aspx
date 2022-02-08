<%@ Page Title="Direct Income Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="SponserIncomeReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
  <h4 class="page-title">Sponser Income Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Sponser Income Report</li>
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
                                    <div class="col-md-2">Closing Period</div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddclosingperiod"   CssClass="form-control " runat="server"></asp:DropDownList>
                                    </div>
                                   <div class="col-md-1"></div>
                                        <div class="col-md-2">User Id</div>
                                    <div class="col-md-3">
                                      <asp:TextBox ID="txtuserid"  CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                               
                               
                                <hr />
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit"  CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
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

                            <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"
                                 CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                               <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Closing Period">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfromdate" runat="server" Text='<%#Eval("fromdate","{0:dd/MM/yyyy}") %>'></asp:Label>-
                                            <asp:Label ID="lbltodate" runat="server" Text='<%#Eval("todate","{0:dd/MM/yyyy}") %>'></asp:Label>
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
                                 <%--   <asp:TemplateField HeaderText="Transaction Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblusername" runat="server" Text='<%#Eval("transactionid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="Comm %">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllevel" runat="server" Text='<%#Eval("commissionpercent") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Comm Amt">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("commissionamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                                   <asp:TemplateField HeaderText="TDS">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamounttds" runat="server" Text='<%#Eval("tds") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                                   <asp:TemplateField HeaderText="ProcessingCharge">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamogfagdsunt" runat="server" Text='<%#Eval("admindeduction") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                                      <asp:TemplateField HeaderText="Final Amt">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfinalamt" runat="server" Text='<%#Eval("finalamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>           
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>        
                                    <asp:TemplateField HeaderText="Payment Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("paymentstatus2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>   
                                     <asp:TemplateField HeaderText="Mode">
                                        <ItemTemplate>
                                               <asp:Label ID="lblmode" runat="server" Text='<%#Eval("paymentmode") %>'></asp:Label>
                                            <asp:DropDownList ID="ddmode" runat="server">
                                                <asp:ListItem Value="0">Select </asp:ListItem>
                                                <asp:ListItem>Cheque</asp:ListItem>
                                                <asp:ListItem>RTGS</asp:ListItem>
                                                <asp:ListItem>NEFT</asp:ListItem>
                                                <asp:ListItem>IMPS</asp:ListItem>
                                                <asp:ListItem>Paytm</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" InitialValue="0" ControlToValidate="ddmode"></asp:RequiredFieldValidator>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Transaction Id">
                                        <ItemTemplate>
                                               <asp:Label ID="lbltransactionid" runat="server" Text='<%#Eval("OnlineTransactionId") %>'></asp:Label>
                                            <asp:TextBox ID="txttransactionid"  runat="server"></asp:TextBox>
                                             <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5451" runat="server" ErrorMessage="*"  ControlToValidate="txttransactionid"></asp:RequiredFieldValidator>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbView" CommandName="myview" OnClick="lbView_Click" runat="server"> View </asp:LinkButton> |
                                            <asp:LinkButton ID="btnApprove" CommandName="approve" OnClick="btnApprove_click" runat="server"> Pay </asp:LinkButton> 
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
       <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit User Details (User Id: <asp:Label runat="server" ID="lbluseridedit"></asp:Label>)</h4>
                        </div>
                        <div class="modal-body">
                        <div class="row form-group">
                                    <div class="col-md-2">User Id</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtuseridedit" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">User Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtusernameedit" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                             <div class="row form-group">
                                    <div class="col-md-2">A/c Holder Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtaccountholdername" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                     <div class="col-md-2">A/c No</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtaccountno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">IFSC Code</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtifsccode" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                     <div class="col-md-2">PAN number</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtpan" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                   
                                </div>
                                 <div class="row form-group">
                                     <div class="col-md-2">Bank</div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddbank" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-1"></div>
                                       <div class="col-md-2">Branch</div>
                                    <div class="col-md-3">
                                         <asp:TextBox ID="txtbranchname" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    
                                </div>
                                 <div class="row form-group">
                                 
                                       <div class="col-md-2">Paytm Mobile No</div>
                                    <div class="col-md-3">
                                         <asp:TextBox ID="txtpaytmmobileno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    
                                </div>
                               
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
              
    </asp:UpdatePanel>
    
     <script type="text/javascript">


         function showModal() {
             $('#myModal').modal('show');
         }
         function Closepopup() {
             $('#myModal').modal('hide');
             $('body').removeClass('modal-open');
             $('body').css('padding-right', '0');
             $('.modal-backdrop').remove();


         }
    </script>
</asp:Content>

