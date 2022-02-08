<%@ Page Title="Withdrawl Request" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="WithdrawlRequstAdd.aspx.cs" Inherits="user_WithdrawlRequstAdd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Add Withdrawal Request</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Withdrawal Request</li>
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
            <asp:Panel ID="Panel1" Visible="false" runat="server">
                <div class="card">
                    <div class="card-header">
                        <h5>Add Withdrawl Request</h5>
                    </div>
                    <div class="card-body">
                        <div class="row form-group">
                            <div class="col-md-12">
                                <h5 class="text-center alert alert-warning dark alert-dismissible fade show">
                                   <span style="font-size:28px;font-weight:bold;">  TeamRijent Security Reason</span>
                                    <br />
                                    <br />
hello friends<br />
                                <br />
                                
                                <br />

It is informed to all of you that due to some update in Team Regent, wallet address of some people was showing wrong due to which the total manual request dated 22/01/2022 & 23/01/2022 has been rejected, All of you can do manual withdrawal by updating your wallet address again, through smart contract.
                       <br />  Thank you
                    <br />Team Rijent
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    
                                    Please Update Your Trust Wallet Address For withdrawal.<br /> <a href="UserEdit.aspx">Click here to update</a></h5>
                            </div>

                        </div>

                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlwithdrawl" runat="server">
                <div class="card">
                    <div class="card-header">
                        <h5>Add Withdrawl Request</h5>
                    </div>
                    <div class="card-body">
                        <div class="row form-group">
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">User Id :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtuserid" AutoPostBack="true" runat="server" CssClass="form-control" OnTextChanged="txtuserid_TextChanged" />

                            </div>
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">User Name :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtusername" Enabled="false" runat="server" CssClass="form-control" />

                            </div>
                        </div>
                          <div class="row form-group">
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Trust Wallet Address :</label>
                            </div>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txttrustwalletaddress" Enabled="false" runat="server" CssClass="form-control" />

                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Internal Wallet Bal($) :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtbalance" Enabled="false" runat="server" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                            </div>
                            <div class="col-md-3"> <label for="exampleInputEmail1">Coin Bal</label></div>
                            <div class="col-md-3">
                                  <asp:TextBox ID="txtcoinbalance" Enabled="false" runat="server" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                                <asp:Label ID="lblconversionrate" Visible="false" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                         <div class="row form-group">
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Withdrawl From :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:RadioButtonList ID="rbwithdrawlfrom" AutoPostBack="true" OnSelectedIndexChanged="rbwithdrawlfrom_SelectedIndexChanged" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="MWallet" Selected="True">Internal Wallet</asp:ListItem>
                                    <asp:ListItem Value="Coin">Coin Wallet</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                           
                        </div>
                 <%--       <div class="row form-group">
                              <div class="col-md-3"> <label for="exampleInputEmail1">Select Wallet Address</label></div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddwalletaddress" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0"> Select Wallet Address</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Conversion in $ :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtconversionrate" Enabled="false" runat="server"  CssClass="form-control" />
                            </div>
                        </div>--%>
                        <div class="row form-group">
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Enter Withdrawal Amount ($) :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtamount" runat="server" AutoPostBack="true" OnTextChanged="txtamount_TextChanged" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                            </div>
                                <div class="col-sm-3">
                                <label for="exampleInputEmail1">Converted Coin:</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtconvertedcoin" runat="server" Enabled="false" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                            </div>
                        </div>
    
                        <div class="row form-group">
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Transaction Charge $(5%) :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txttransactioncharge" Enabled="false" runat="server" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                            </div>
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Final Amount <asp:Label ID="lblfinalcurrency" runat="server" Text="$"></asp:Label>:</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtfinalamount" Enabled="false" runat="server" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                            </div>
                        </div>
                                            <div class="row ">
                            <div class="col-md-12">
                                <span class="badge badge-secondary"><strong>Note ! </strong> Minium Withdrawal <asp:Label ID="lblminlimit" Font-Bold="true" runat="server" Text="Label"></asp:Label>, Maximum Withdrawal <asp:Label ID="lblmaximumlimit" Font-Bold="true" runat="server" Text="Label"></asp:Label></span>

                            </div>
                        </div>
                        <hr />
                        <div class="row form-group">
                            <div class="col-md-12">
                                <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                      
                        <%-- <div class="row form-group">
                            <div class="col-md-12" style="color: red;">
                                <h3>Note : 15 % admin & transaction charge will deduct from your withdrawl amount</h3>
                            </div>

                        </div>
                        <div class="row form-group">
                            <div class="col-md-12" style="color: red;">
                                <h3>Note : Withdrawl amount will be credited in your bank account within 1 to 6 days.</h3>
                            </div>

                        </div>--%>
                    </div>
                </div>
            </asp:Panel>
            

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">

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
             <div id="myModalNotification" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Note</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group text-center">
                              
                              TeamRijent Security Reason<br />
hello friends<br />
                                <br />
                                <br />
                                <br />

It is informed to all of you that due to some update in Team Regent, wallet address of some people was showing wrong due to which the total manual request dated 22/01/2022 & 23/01/2022 has been rejected, All of you can do manual withdrawal by updating your wallet address again, through smart contract.
                       <br />  Thank you
                    <br />Team Rijent
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
         
       
            function validate3() {
             if (document.getElementById("<%=txtotpaddress.ClientID%>").value == "") {
                alert("Enter OTP");
                document.getElementById("<%=txtotpaddress.ClientID%>").focus();
                return false;
            }
        }
    </script>

  <script type="text/javascript">
        //function showModalNotification() {
        //    $('#myModalNotification').modal('show');
        //}
        //function ClosepopupNotification() {
        //    $('#myModalNotification').modal('hide');
        //    $('body').removeClass('modal-open');
        //    $('body').css('padding-right', '0');
        //    $('.modal-backdrop').remove();
        //}
        
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
           <%-- if (document.getElementById("<%=ddwallettype.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select Wallet Type');
                document.getElementById("<%=ddwallettype.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddwalletaddress.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select Wallet Address');
                document.getElementById("<%=ddwalletaddress.ClientID%>").focus();
                return false;
            }--%>
             if (document.getElementById("<%=txtamount.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Amount');
                document.getElementById("<%=txtamount.ClientID%>").focus();
                return false;
            }
        }
    </script>
</asp:Content>



