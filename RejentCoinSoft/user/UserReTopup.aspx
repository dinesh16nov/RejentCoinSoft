<%@ Page Title="Renewal" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="UserReTopup.aspx.cs" Inherits="user_UserTopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
   <h4 class="page-title">Renewal</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Renewal</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" Runat="Server">
       <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="900"></asp:ScriptManager>
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
                        <h5>Renewal</h5>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 alert alert-warning">
                                To Renew Your Plan Please Do Staking of $ Plan Amount or Above. <a href="https://teamrijent.com/stacking/">Click here for staking</a>
                            </div>
                        </div>
                        </div>
                   
                     </div>
             <div class="card" style="display:none;">
                    <div class="card-header">
                        <h5>Renewal</h5>
                    </div>
                    <div class="card-body">
                          <div class="row form-group">
                                   <div class="col-md-2">Select Wallet</div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddwallettype" AutoPostBack="true" OnSelectedIndexChanged="ddwallettype_SelectedIndexChanged" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Wallet</asp:ListItem>
                                    <asp:ListItem Value="EWallet">External Wallet</asp:ListItem>
                                    <asp:ListItem Value="MWallet">Internal Wallet</asp:ListItem>
                                    <asp:ListItem Value="Coin">Coin Wallet</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                               <div class="col-md-1"></div>
                       
                               <div class="col-md-2">Balance</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtbalance" Enabled="false" onkeypress="return isNumberKey(event);" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                    </div>
                       
                        </div>
                                <div class="row form-group">
                                    <div class="col-md-2">Renewal User Id</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtuserid" AutoPostBack="true" OnTextChanged="txtuserid_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">User Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtusername" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                     
                              
                        
                        <div class="row form-group">
                    
                               <div class="col-md-2">Topup Amount($)</div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtamount" AutoPostBack="true" OnTextChanged="txtamount_TextChanged"  CssClass="form-control" onkeypress="return isNumberKey(event);" runat="server"></asp:TextBox>
                            </div>
                               <div class="col-md-1"></div>
                       
                               <div class="col-md-2">Transaction Charge($)</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txttrancharge" Enabled="false" onkeypress="return isNumberKey(event);" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                    </div>
                        </div>
                        <div class="row form-group">
                    
                               <div class="col-md-2">Final Amount($)</div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtfinalamount" Enabled="false"  CssClass="form-control" onkeypress="return isNumberKey(event);" runat="server"></asp:TextBox>
                            </div>
                              <div class="col-md-1"></div>
                       
                               <div class="col-md-2">
                                   <asp:Label ID="lblconversionrate" runat="server" Visible="false" Text="0"></asp:Label>
                                   Convert Amount in (<asp:Label ID="lblwallettype" runat="server" Text=""></asp:Label>)</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtconvertedamount" Enabled="false" onkeypress="return isNumberKey(event);" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                    </div>
                        </div>
                         <hr />
                        <div class="row form-group">
                            <div class="col-md-12">
                                <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                            </div>
                        </div>
                        </div>
                    </div>
              
            
                </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" Runat="Server">
      <asp:UpdatePanel runat="server" ID="uplMaster" >
        <ContentTemplate>
                     <div id="myModalOTPAddress" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">OTP</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                               Enter OTP    
                                <asp:HiddenField ID="hdnOTP" runat="server" />
                                <asp:TextBox runat="server" class="form-control" ID="txtotpaddress"></asp:TextBox>
                            </div>
                         
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnOTPAddress" runat="server" Text="Submit" OnClientClick="return validate3();" CssClass="btn btn-primary has-ripple" OnClick="btnOTPAddress_Click" />
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                        </div>
                     
                       
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

  
     <script type="text/javascript">
         
       
            function validate3() {
             if (document.getElementById("<%=txtotpaddress.ClientID%>").value == "") {
                alert("Enter OTP");
                document.getElementById("<%=txtotpaddress.ClientID%>").focus();
                return false;
            }
        }
    </script>

    <script type="text/javascript">
      
        function showModalOTPAddress() {
            $('#myModalOTPAddress').modal('show');
        }
        function ClosepopupOTPAddress() {
            $('#myModalOTPAddress').modal('hide');
            $('body').removeClass('modal-open');
            $('body').css('padding-right', '0');
            $('.modal-backdrop').remove();
        }
    </script>
     <script type="text/javascript">
         function validate() {
             if (document.getElementById("<%=txtuserid.ClientID%>").value == "") {
                 toastr.warning('Warning', 'Enter User Id');
                 document.getElementById("<%=txtuserid.ClientID%>").focus();
                 return false;
             }
             if (document.getElementById("<%=ddwallettype.ClientID%>").value == "0") {

                 toastr.warning('Warning', 'Select Wallet Type ');
                 document.getElementById("<%=ddwallettype.ClientID%>").focus();
                 return false;
             }
                  if (document.getElementById("<%=txtuserid.ClientID%>").value == "0") {

                 toastr.warning('Warning', 'Enter User Id');
                 document.getElementById("<%=txtuserid.ClientID%>").focus();
                 return false;
             }
             
         }
         </script>
</asp:Content>

