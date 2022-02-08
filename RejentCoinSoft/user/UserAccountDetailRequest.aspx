<%@ Page Title="Edit User Account Detail Request" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="UserAccountDetailRequest.aspx.cs" Inherits="admin_UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
     <div class="row page-titles mx-0">
                    <div class="col-sm-6 p-md-0">
                        <div class="welcome-text">
                            <h4>Edit Account Detail</h4>
                        </div>
                    </div>
                    <div class="col-sm-6 p-md-0 justify-content-sm-end mt-2 mt-sm-0 d-flex">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active"><a href="javascript:void(0)">Edit Account Detail</a></li>
                        </ol>
                    </div>
                </div>
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
                             
                                 <h3>Bank Details</h3>
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
                                 
                                       <div class="col-md-2">Passbook Image</div>
                                    <div class="col-md-3">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">   
 
   

    <script type="text/javascript">
        function validate() {
          
              if (document.getElementById("<%=ddbank.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select Bank');
                document.getElementById("<%=ddbank.ClientID%>").focus();
                  return false;
              }
              if (document.getElementById("<%=txtaccountno.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Account No');
                document.getElementById("<%=txtaccountno.ClientID%>").focus();
                  return false;
              }
              if (document.getElementById("<%=txtaccountholdername.ClientID%>").value == "") {

                  toastr.warning('Warning', 'Enter Ac Holder Name');
                  document.getElementById("<%=txtaccountholdername.ClientID%>").focus();
                return false;
              }
              if (document.getElementById("<%=txtifsccode.ClientID%>").value == "") {

                  toastr.warning('Warning', 'Enter IFSC Code');
                  document.getElementById("<%=txtifsccode.ClientID%>").focus();
                  return false;
              }

              if (document.getElementById("<%=FileUpload1.ClientID%>").value != "") {

                  if (document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".jpg") || document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".png") || document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".jpeg")) {
                   }
                   else {
                       toastr.warning('Warning', 'Image  should be in .jpg or .jpeg or .png format');
                       document.getElementById("<%=FileUpload1.ClientID%>").focus();
                    return false;
                   }

               }
              if (document.getElementById("<%=txtbranchname.ClientID%>").value == "") {

                  toastr.warning('Warning', 'Enter Branch Name');
                  document.getElementById("<%=txtbranchname.ClientID%>").focus();
                  return false;
               }
        }
    </script>
   
  
</asp:Content>

