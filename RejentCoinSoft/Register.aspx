<%@ Page Language="C#" AutoEventWireup="true" Title="Register" CodeFile="Register.aspx.cs" Inherits="admin_index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
   <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="author" content="">
    <link rel="icon" href="user/assets/images/favicon.png" type="image/x-icon">
    <link rel="shortcut icon" href="user/assets/images/favicon.png" type="image/x-icon">
    <title>viho - Premium Admin Template</title>
    <!-- Google font-->
    <link rel="preconnect" href="../../../fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&amp;display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&amp;display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Rubik:ital,wght@0,400;0,500;0,600;0,700;0,800;0,900;1,300;1,400;1,500;1,600;1,700;1,800;1,900&amp;display=swap" rel="stylesheet">
    <!-- Font Awesome-->
    <link rel="stylesheet" type="text/css" href="user/assets/css/fontawesome.css">
    <!-- ico-font-->
    <link rel="stylesheet" type="text/css" href="user/assets/css/icofont.css">
    <!-- Themify icon-->
    <link rel="stylesheet" type="text/css" href="user/assets/css/themify.css">
    <!-- Flag icon-->
    <link rel="stylesheet" type="text/css" href="user/assets/css/flag-icon.css">
    <!-- Feather icon-->
    <link rel="stylesheet" type="text/css" href="user/assets/css/feather-icon.css">
    <!-- Plugins css start-->
    <!-- Plugins css Ends-->
    <!-- Bootstrap css-->
    <link rel="stylesheet" type="text/css" href="user/assets/css/bootstrap.css">
    <!-- App css-->
    <link rel="stylesheet" type="text/css" href="user/assets/css/style.css">
    <link id="color" rel="stylesheet" href="user/assets/css/color-1.css" media="screen">
    <!-- Responsive css-->
    <link rel="stylesheet" type="text/css" href="user/assets/css/responsive.css">
      <style>
        body {
        }

            body .modal2 {
                position: fixed;
                z-index: 99999;
                height: 100%;
                width: 100%;
                top: 0;
                background-color: white;
                filter: alpha(opacity=60);
                opacity: 0.6;
                -moz-opacity: 0.8;
                clear: both;
                left: 0px;
            }

            body .center2 {
                z-index: 100000;
                margin: 200px auto;
                padding: 10px;
                width: 200px;
                background-color: White;
                border-radius: 10px;
                filter: alpha(opacity=100);
                opacity: 1;
                -moz-opacity: 1;
            }

                body .center2 img {
                    height: 150px;
                    width: 200px;
                }

       
    </style>
    <style>
        option {
            /* Whatever color  you want */
            background-color: #1F1E26;
            color:white;
        }
    </style>
</head>
<body >
    <form id="form1"  runat="server" style="height:100%;" >
    
        
               <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal2">
                <div class="center2">
                    <img alt="" src="user/loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                          <!-- Loader starts-->
     <section>         
      <div class="container-fluid p-0">
        <div class="row">
          <div class="col-12">
            <div class="login-card" style="height:auto">
           <div class="theme-form login-form">
                <h4>Register</h4>
                <h6>Welcome back!</h6>
                       <div class="form-group">
                                            <label class="mb-1"><strong>Sponsor Id</strong></label>
                                            <asp:TextBox ID="txtsponserid" AutoPostBack="true" OnTextChanged="txtsponserid_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                     
                                        </div>
                                        <div class="form-group">
                                            <label class="mb-1"><strong>Sponser Name</strong></label>
                                               <asp:TextBox ID="txtsponsername" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    
                                        </div>
              
                  <div class="form-group">
                                            <label class="mb-1"><strong>Standing Position</strong></label>
                                            <asp:RadioButtonList ID="rbstandingposition" RepeatDirection="Horizontal" runat="server" style="width:100%;">
                                    <asp:ListItem Value="1" Selected="True">Left</asp:ListItem>
                                    <asp:ListItem Value="2">Right</asp:ListItem>
                                </asp:RadioButtonList>
                                        </div>
                  <div class="form-group">
                                            <label class="mb-1"><strong>Name</strong></label>
                                              <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                  <div class="form-group">
                                            <label class="mb-1"><strong>Mobile</strong></label>
                                               <asp:TextBox ID="txtmobile" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                  <div class="form-group">
                                            <label class="mb-1"><strong>Email</strong></label>
                                             <asp:TextBox ID="txtemail" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                  <div class="form-group">
                                            <label class="mb-1"><strong>Gender</strong></label>
                                             <asp:DropDownList ID="ddgender"  CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Gender</asp:ListItem>
                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                </asp:DropDownList>
                                        </div>
                                                      <div class="form-group">
                                            <label class="mb-1"><strong>Password</strong></label>
                                            <asp:TextBox ID="txtuserpassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                  <div class="form-group">
                                            <label class="mb-1"><strong>Confirm Password</strong></label>
                                             <asp:TextBox ID="txtconfirmpassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                       <div class="form-group">
                                        <div class="text-center">
                                            <br />
                                              <asp:Button ID="btnRegister" OnClick="btnRegister_Click" OnClientClick="return validate();"  runat="server" class="btn btn-primary btn-block" Text="Register"  />
            
                                            <%--<button type="submit" class="btn btn-primary btn-block">Sign Me In</button>--%>
                                        </div>
              </div>

              
             
         
                <p style="color:#0a7a4d"><a class="ms-2" href="user/index.aspx">Click here, If You already Have an Account</a></p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <!-- Loader ends-->
    <!-- page-wrapper Start-->
   


                 
    </ContentTemplate>
            </asp:UpdatePanel>


    <!--**********************************
        Scripts
    ***********************************-->
    <!-- Required vendors -->
    
        
    <!-- JAVASCRIPT -->
    <script src="user/assets/js/jquery-3.5.1.min.js"></script>
    <!-- feather icon js-->
    <script src="user/assets/js/icons/feather-icon/feather.min.js"></script>
    <script src="user/assets/js/icons/feather-icon/feather-icon.js"></script>
    <!-- Sidebar jquery-->
    <script src="user/assets/js/sidebar-menu.js"></script>
    <script src="user/assets/js/config.js"></script>
    <!-- Bootstrap js-->
    <script src="user/assets/js/bootstrap/popper.min.js"></script>
    <script src="user/assets/js/bootstrap/bootstrap.min.js"></script>
            <link href="user/assets/js/toastr.css" rel="stylesheet" />
        <script src="user/assets/js/toastr.js"></script>

            <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
                     <div id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">User Details</h4>
                        </div>
                        <div class="modal-body">
                                <div class="form-group text-center">
                               <img src="user/assets/images/logo.png" style="width:250px;" />
                                    <h3>Registration Succeessful</h3>
                                    <b>Your Name :   <asp:Label ID="lblnamepopup" runat="server" Text=""></asp:Label></b><br />
                                    <b>Your User id :   <asp:Label ID="lbluseridpopup" runat="server" Text=""></asp:Label></b><br />
                                    Your account has been created successfully. We have sent you an email and message containing your login details. Please keep the email safe.<br />
                                    Thank You.
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
                <!-- JAVASCRIPT FILES -->

            
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
            if (document.getElementById("<%=txtuserpassword.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Password');
                document.getElementById("<%=txtuserpassword.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtconfirmpassword.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Confirm Password');
                document.getElementById("<%=txtconfirmpassword.ClientID%>").focus();
                return false;
            }
          <%--  if (document.getElementById("<%=ddcountry.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select Country');
                document.getElementById("<%=ddcountry.ClientID%>").focus();
                return false;
            }--%>
          <%--  if (document.getElementById("<%=ddplan.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select Plan');
                document.getElementById("<%=ddplan.ClientID%>").focus();
                return false;
             }--%>
           <%-- if (document.getElementById("<%=ddplan.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select Plan');
                document.getElementById("<%=ddplan.ClientID%>").focus();
                return false;
            }
           if (document.getElementById("<%=ddepin.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select E-Pin');
                document.getElementById("<%=ddepin.ClientID%>").focus();
                return false;
            }--%>
           <%-- if (document.getElementById("<%=ddstate.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select State');
                document.getElementById("<%=ddstate.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtcityname.ClientID%>").value == "") {

                toastr.warning('Warning', 'City');
                document.getElementById("<%=txtcityname.ClientID%>").focus();
                return false;
            }--%>
          
        <%--    if (document.getElementById("<%=txtpanno.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Pan No');
                document.getElementById("<%=txtpanno.ClientID%>").focus();
                return false;
            }--%>
            if (document.getElementById("<%=txtuserpassword.ClientID%>").value != document.getElementById("<%=txtconfirmpassword.ClientID%>").value) {

            toastr.warning('Warning', 'Password Not Match');
            document.getElementById("<%=txtuserpassword.ClientID%>").focus();
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
        </script>
    </form>
</body>
</html>
