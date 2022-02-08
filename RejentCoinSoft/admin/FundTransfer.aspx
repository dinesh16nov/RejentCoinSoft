<%@ Page Title="Credit Fund" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="FundTransfer.aspx.cs" Inherits="admin_FundTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Credit Fund</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Credit Fund</li>
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
       <%-- <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>--%>
        <ContentTemplate>
            <div class="card">
                    <div class="card-header">
                        <h5>Credit Fund</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">User Id</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtuserid" AutoPostBack="true" OnTextChanged="txtuserid_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">User Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtpersonname" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">User Mobile</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtpersonmobile" Enabled="false" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">User Email</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtpersonemail" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                          <div class="row form-group">
                                    <div class="col-md-2">Internal Wallet Balance</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtinternalwalletbalance" Enabled="false" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">External Wallet Balance</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtexternalwalletbalance" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                         <div class="row form-group">
                                    <div class="col-md-2">Coin Wallet Balance</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtcoinbalance" Enabled="false" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                   
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">Wallet Type</div>
                                    <div class="col-md-3">
                                        <asp:RadioButtonList ID="rbWalletType" RepeatDirection="Horizontal" style="width:100%;" runat="server">
                                            <asp:ListItem Value="MWallet" Selected="True">Internal Wallet</asp:ListItem>
                                            <asp:ListItem Value="EWallet">External Wallet</asp:ListItem>
                                            <asp:ListItem Value="Coin">Coin Wallet</asp:ListItem>

                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">Transfer Amount</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtamount" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                        <div class="row form-group">
                                        <div class="col-md-2"> Remark
                               </div>
                             <div class="col-md-3">
                                     <asp:TextBox ID="txtremark" TextMode="MultiLine" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                                <hr />
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                        </div>
                    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtuserid.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter User Id');
                document.getElementById("<%=txtuserid.ClientID%>").focus();
                   return false;
               }
               if (document.getElementById("<%=txtpersonmobile.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Person Mobile');
                document.getElementById("<%=txtpersonmobile.ClientID%>").focus();
                   return false;
               }
               if (document.getElementById("<%=txtamount.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Amount');
                document.getElementById("<%=txtamount.ClientID%>").focus();
                   return false;
               }
           }
    </script>
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



</asp:Content>

