<%@ Page Title="Edit User Details" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="admin_UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
   <h4 class="page-title">Edit User Details</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Edit User Details</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" Runat="Server">
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
                        <h5>Edit Profile</h5>
                    </div>

<div class="card-body">
                      <div class="row">
                        <div class="col-md-4 mb-2">
                          <div class="mb-3">
                            <label class="form-label">Sponser Id</label>
                          <asp:TextBox ID="txtsponserid" Enabled="false"  CssClass="form-control" runat="server"></asp:TextBox>
                          </div>
                        </div>
<div class="d-none col-md-4 mb-2">
                          <div class="mb-3">
                            <label class="form-label">Sponser Name</label>
                          <asp:TextBox ID="txtsponsername" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                          </div>
                        </div>

                        <div class="col-sm-4 col-md-4 mb-2">
                          <div class="mb-3">
                            <label class="form-label">Name</label>
                           <asp:TextBox ID="txtname"   CssClass="form-control" runat="server"></asp:TextBox>
                          </div>
                        </div>
						<div class="col-sm-4 col-md-4 mb-2">
                          <div class="mb-3">
                            <label class="form-label">Mobile <asp:Literal ID="ltmobileverifystatus" runat="server"></asp:Literal></label>
                            
							<div class="input-group">
                             <asp:TextBox ID="txtmobile"  onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                            <span style="padding-left:.25rem  !important;padding-right:.25rem  !important;font-size: .75rem;" class="input-group-text btn btn-secondary btn-sm p-l-0 p-r-0"> <asp:LinkButton ID="lbVerifyMobile" OnClick="lbVerifyMobile_Click" runat="server" style="color:white">Verify</asp:LinkButton></span>
                           
                          </div>
                          </div>
                        </div>
						
						<div class="col-sm-6 col-md-4 mb-2">
                          <div class="mb-3">
                            <label class="form-label">Email <asp:Literal ID="ltemailverifystatus" runat="server"></asp:Literal></label>
							<div class="input-group">
                            <asp:TextBox ID="txtemail" CssClass="form-control" runat="server"></asp:TextBox>
                                            <span style="padding-left:.25rem  !important;padding-right:.25rem  !important;font-size: .75rem;" class="input-group-text btn btn-secondary btn-sm p-l-0 p-r-0"> <asp:LinkButton ID="lbVerifyEmail" OnClick="lbVerifyEmail_Click" runat="server" style="color:white">Verify</asp:LinkButton></span>
                            
                          </div>
                          </div>
                        </div>

<div class="col-sm-6 col-md-4 mb-2 d-none ">
                          <%--<div class="mb-3">
                            <label class="form-label">Gender </label>
							<div class="input-group">
                           <asp:DropDownList ID="ddgender" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">Select Gender</asp:ListItem>
                                            <asp:ListItem Value="Male">Male</asp:ListItem>
                                            <asp:ListItem Value="Female">Female</asp:ListItem>
                                        </asp:DropDownList>
                          </div>
                          </div>--%>
                        </div>
						
						<div class="col-sm-6 col-md-8 mb-2">
                          
                          <div class="mb-3">
                            <label class="form-label">Address</label>
                           <asp:TextBox ID="txtaddress" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox></div>
                        
                        </div>
                        
                        <div class="col-sm-12 col-md-4">
                          <div class="mb-3">
                            <label class="form-label">Select Country</label>
                             <asp:DropDownList ID="ddcountry" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddcountry_SelectedIndexChanged">
                                            <asp:ListItem Value="0"> Select Country</asp:ListItem>
                                        </asp:DropDownList>
                          </div>
                        </div>
                        <div class="col-sm-12 col-md-4">
                          <div class="mb-3">
                            <label class="form-label">Select State</label>
                            <asp:DropDownList ID="ddstate"  CssClass="form-control" runat="server" >
                                            <asp:ListItem Value="0"> Select State</asp:ListItem>
                                        </asp:DropDownList>
                          </div>
                        </div>
                        <div class="col-md-4">
                          <div class="mb-3">
                            <label class="form-label">City</label>
                           <asp:TextBox ID="txtcityname" CssClass="form-control" runat="server"></asp:TextBox>
                          </div>
                        </div>
                        
                       
                        
                      </div>
                    </div>
                    <div class="card-body d-none">
                                <h3>Personal Details</h3>
                                 <div class="row form-group">
                            <div class="col-md-2">Sponser Id</div>
                            <div class="col-md-3">
                                 
                            </div>
                             <div class="col-md-1"></div>
                               <div class="col-md-2"  style="display:none;">Sponser Name</div>
                            <div class="col-md-3"  style="display:none;">
                               
                            </div>
                        </div>
                                <div class="row form-group">
                                    <div class="col-md-2">Name</div>
                                    <div class="col-md-3">
                                       
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2"></div>
                                    <div class="col-md-3">
                                        <div class="input-group">
                             </div>
                                       
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2"></div>
                                    <div class="col-md-3">
                                           <div class="input-group">
                              </div>
                                  
                                    </div>
                                    <div class="col-md-1"></div>
                                  <%--  <div class="col-md-2">Gender</div>
                                    <div class="col-md-3">
                                       
                                    </div>--%>
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">Address</div>
                                    <div class="col-md-9">
                                        
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">Select Country</div>
                                    <div class="col-md-3">
                                       
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">Select State</div>
                                    <div class="col-md-3">
                                       
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">City</div>
                                    <div class="col-md-3">
                                         
                                    </div>
                                    <div class="col-md-1"></div>
                                   <%-- <div class="col-md-2">Area Name</div>
                                    <div class="col-md-3">
                                         <asp:TextBox ID="txtareaname" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>--%>

                                </div>
                             <%--   <div class="row form-group">
                                    <div class="col-md-2">Pincode</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtpincode" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                     <div class="col-md-2">Date of Birth</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtdateofbirth" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                </div>--%>
                          <%--  <h3>Nominee Details</h3>
                                  <div class="row form-group">
                                    <div class="col-md-2">Nominee Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtnomineename" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                     <div class="col-md-2">Nominee Relation</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtnomineerelation" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>--%>
                                 <%--<h3>Bank Details</h3>
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
                                    
                                </div>--%>
                                  <%-- <div class="row form-group">
                            <div class="col-md-2">Password</div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtuserpassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                       </div>--%>
                               <%--  <div class="row form-group">
                                 
                                       <div class="col-md-2">Paytm Mobile No</div>
                                    <div class="col-md-3">
                                         <asp:TextBox ID="txtpaytmmobileno" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    
                                </div>--%>
                                
                                
                </div>
<div class="card-footer">
<div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" />
                                    </div>
                                </div>
</div>
                 <div class="card ">
                 <div class="card-body">
                 <div class="row">
                         <div class="col-sm-9 col-md-9">
                          <div class="mb-3">
                            <label class="form-label">Trust Wallet Address</label>
                           <asp:TextBox ID="txttrustwalletaddress" CssClass="form-control" runat="server"></asp:TextBox>
                          </div>
                        
                          </div>
                          <div class="col-md-3">
                               <label class="form-label">&nbsp;</label><br />
                                    <asp:Button ID="btnUpdateaddress" OnClientClick="return validateAddress();" CssClass="btn btn-primary has-ripple" runat="server" Text="Update Address" OnClick="btnUpdateaddress_Click" />
                                     
                             </div>
                             </div>
                        </div>
                 </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">   
 
     <asp:UpdatePanel runat="server" ID="uplMaster" >
        <ContentTemplate>
     <div id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">OTP</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                               Enter OTP                      
                                <asp:TextBox runat="server" class="form-control" ID="txtotp"></asp:TextBox>
                            </div>
                         
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnSend" runat="server" Text="Submit" OnClientClick="return validate2();" CssClass="btn btn-primary has-ripple" OnClick="btnSend_Click" />
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                        </div>
                     
                       
                    </div>
                </div>
            </div>
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
        function validate() {
            if (document.getElementById("<%=txtsponserid.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Sponser Id');
                document.getElementById("<%=txtsponserid.ClientID%>").focus();
                  return false;
              }
              if (document.getElementById("<%=txtname.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Name');
                document.getElementById("<%=txtname.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtmobile.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Mobile');
                document.getElementById("<%=txtmobile.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtemail.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Email');
                document.getElementById("<%=txtemail.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtaddress.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Address');
                document.getElementById("<%=txtaddress.ClientID%>").focus();
                return false;
            }
           
            if (document.getElementById("<%=ddcountry.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select Country');
                document.getElementById("<%=ddcountry.ClientID%>").focus();
                  return false;
              }
              if (document.getElementById("<%=ddstate.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select State');
                document.getElementById("<%=ddstate.ClientID%>").focus();
                  return false;
              }
              if (document.getElementById("<%=txtcityname.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select City');
                document.getElementById("<%=txtcityname.ClientID%>").focus();
                  return false;
              }
        }
    </script>
     <script type="text/javascript">
           function validateAddress() {
             if (document.getElementById("<%=txttrustwalletaddress.ClientID%>").value == "") {
                alert("Enter Trust Wallet Address");
                document.getElementById("<%=txttrustwalletaddress.ClientID%>").focus();
                return false;
            }
         }
         function validate2() {
             if (document.getElementById("<%=txtotp.ClientID%>").value == "") {
                alert("Enter OTP");
                document.getElementById("<%=txtotp.ClientID%>").focus();
                return false;
            }
         }
            function validate3() {
             if (document.getElementById("<%=txtotpaddress.ClientID%>").value == "") {
                alert("Enter OTP");
                document.getElementById("<%=txtotpaddress.ClientID%>").focus();
                return false;
            }
        }
    </script>

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

