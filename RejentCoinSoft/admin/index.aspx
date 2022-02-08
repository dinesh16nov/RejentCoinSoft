<%@ Page Language="C#" AutoEventWireup="true" Title="Login" CodeFile="index.aspx.cs" Inherits="admin_index" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js " lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="author" content="">
    <link rel="icon" href="assets/images/favicon.png" type="image/x-icon">
    <link rel="shortcut icon" href="assets/images/favicon.png" type="image/x-icon">
    <title>Team  Rijent</title>
    <!-- Google font-->
    <link rel="preconnect" href="../../../fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&amp;display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&amp;display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Rubik:ital,wght@0,400;0,500;0,600;0,700;0,800;0,900;1,300;1,400;1,500;1,600;1,700;1,800;1,900&amp;display=swap" rel="stylesheet">
    <!-- Font Awesome-->
    <link rel="stylesheet" type="text/css" href="assets/css/fontawesome.css">
    <!-- ico-font-->
    <link rel="stylesheet" type="text/css" href="assets/css/icofont.css">
    <!-- Themify icon-->
    <link rel="stylesheet" type="text/css" href="assets/css/themify.css">
    <!-- Flag icon-->
    <link rel="stylesheet" type="text/css" href="assets/css/flag-icon.css">
    <!-- Feather icon-->
    <link rel="stylesheet" type="text/css" href="assets/css/feather-icon.css">
    <!-- Plugins css start-->
    <!-- Plugins css Ends-->
    <!-- Bootstrap css-->
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.css">
    <!-- App css-->
    <link rel="stylesheet" type="text/css" href="assets/css/style.css">
    <link id="color" rel="stylesheet" href="assets/css/color-1.css" media="screen">
    <!-- Responsive css-->
    <link rel="stylesheet" type="text/css" href="assets/css/responsive.css">
</head>
<body>
    <form id="form1" runat="server" style="height: 100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="uplMaster">
            <ContentTemplate>
                 </ContentTemplate>
        </asp:UpdatePanel>
                <!-- Loader starts-->
                <div class="loader-wrapper">
                    <div class="theme-loader">
                        <div class="loader-p"></div>
                    </div>
                </div>
                <!-- Loader ends-->
                <!-- page-wrapper Start-->
                <section>
                    <div class="container-fluid">
                        <div class="row form-group">
                            <div class="col-xl-7">
                                <img class="bg-img-cover bg-center" src="assets/images/login/2.jpg" alt="looginpage"></div>
                            <div class="col-xl-5 p-0">
                                <div class="login-card">
                                    <div class="theme-form login-form">
                                        <img src="assets/images/logo.png" style="height: 60px;" />
                                        <h4>Login</h4>
                                        <h6>Welcome back! Log in to your account.</h6>
                                        <div class="form-group">
                                            <label>Email Address</label>
                                            <div class="input-group">
                                                <span class="input-group-text"><i class="icon-email"></i></span>
                                                <%--<input class="form-control" type="email" required="" placeholder="Test@gmail.com">--%>
                                                <asp:TextBox ID="txtusername" CssClass="form-control" required="" runat="server" placeholder="Username"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Password</label>
                                            <div class="input-group">
                                                <span class="input-group-text"><i class="icon-lock"></i></span>
                                                <asp:TextBox ID="txtpassword" CssClass="form-control text-input" TextMode="Password" required="" runat="server" placeholder="Password"></asp:TextBox>


                                            </div>
                                        </div>
                                        
                                        <div class="form-group">
                                            <div class="checkbox">
                                            </div>
                                            <a class="link" href="#">Forgot password?</a>
                                        </div>
                                        <div class="form-group">
                                            <asp:Button runat="server" ID="btnLogin" Text="Login" class="btn btn-primary btn-block" OnClick="btnLogin_Click" />
                                        </div>


                                        <p>Don't have account?<a class="ms-2" href="#">Create Account</a></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- page-wrapper end-->
                <!-- latest jquery-->
                <script src="assets/js/jquery-3.5.1.min.js"></script>
                <!-- feather icon js-->
                <script src="assets/js/icons/feather-icon/feather.min.js"></script>
                <script src="assets/js/icons/feather-icon/feather-icon.js"></script>
                <!-- Sidebar jquery-->
                <script src="assets/js/sidebar-menu.js"></script>
                <script src="assets/js/config.js"></script>
                <!-- Bootstrap js-->
                <script src="assets/js/bootstrap/popper.min.js"></script>
                <script src="assets/js/bootstrap/bootstrap.min.js"></script>
                <!-- Plugins JS start-->
                <!-- Plugins JS Ends-->
                <!-- Theme js-->
                <script src="assets/js/script.js"></script>
                <!-- login js-->
                <!-- Plugin used-->
                <div id="myModalOTP" class="modal fade">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" style="color: black;">OTP</h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label style="color: black;">Enter OTP   </label>

                                    <asp:TextBox runat="server" class="form-control" ID="txtotp"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label style="color: black;">New Password</label>

                                    <asp:TextBox ID="txtuserpassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>


                                </div>
                                <div class="form-group">
                                    <label style="color: black;">Confirm Password</label>

                                    <asp:TextBox ID="txtconfirmpassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnUpdatepassword" runat="server" formnovalidate Text="Submit" OnClientClick="return validateOTP();" CssClass="btn btn-primary has-ripple" OnClick="btnUpdatepassword_Click" />
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                            </div>
                            <div class="row form-group" id="div1" runat="server" visible="false">
                                <div class="col-md-12">
                                    <div class="alert alert-success">
                                        <strong>Success!</strong>
                                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>.
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
           

    </form>
</body>
</html>
