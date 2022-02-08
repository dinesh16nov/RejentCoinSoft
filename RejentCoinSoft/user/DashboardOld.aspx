<%@ Page Title="" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="DashboardOld.aspx.cs" Inherits="admin_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        h6 {
            font-size: 0.775rem
        }

        .card {
            font-size: 13px;
        }

        .text-white {
            color: white !important;
        }

        .card-body {
            -webkit-box-flex: 1;
            -ms-flex: 1 1 auto;
            flex: 1 1 auto;
            padding: .5rem 1.25rem;
        }
    </style>

    <style>
        /*.text-muted {
            color: white !important;
        }*/

        /*.box1 {
            background-image: linear-gradient(red, #f8aa2f);
            color: white;
        }

        .box2 {
            background-image: linear-gradient(#00ff21, #00ffff);
            color: white;
        }

        .box3 {
            background-image: linear-gradient(#ec2efc, #e0a3df);
            color: white;
        }

        .box4 {
            background-image: linear-gradient(#f31212, #e87676);
            color: white;
        }

        .box5 {
            background-image: linear-gradient(#f8b40f, #f4d078);
            color: white;
        }*/
    </style>

    <style>
        #mask {
            position: fixed;
            left: 0;
            top: 0;
            z-index: 9000;
            background-color: #000;
            display: none;
            opacity: .7 !important
        }



        #boxes .window {
            position: absolute;
            left: 0;
            top: 0;
            width: 350px;
            height: 230px;
            display: none;
            z-index: 9999;
            padding: 20px;
            border-radius: 15px;
            text-align: center;
        }



        #boxes #dialog {
            width: 330px;
            height: 240px;
            padding: 10px;
            background-color: #ffffff;
            font-family: 'Segoe UI Light', sans-serif;
            font-size: 15pt;
        }



        #popupfoot {
            font-size: 16pt;
            position: absolute;
            bottom: 0px;
            left: 310px;
        }

        @media only screen and (max-width: 600px) {
            #boxes .window {
                position: absolute;
                left: 0;
                top: 100px;
                width: 91%;
                /*height: 890px;*/
                display: none;
                z-index: 9999;
                padding: 20px;
                border-radius: 15px;
                text-align: center;
            }



            #boxes #dialog {
                width: 90%;
                /*height: 800px;*/
                padding: 10px;
                padding-top: 60px;
                background-color: #ffffff;
                font-family: 'Segoe UI Light', sans-serif;
                font-size: 15pt;
            }
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Dashboard</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Dashboard</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

          <%--  <div class="card">
                <div class="card-body" style="padding: 1.25rem .75rem;">
                    <div class="row form-group">
                        <div class="col-md-12">

                            <div class="input-group mb-3"><span class="input-group-text">Left&nbsp;&nbsp;&nbsp;</span>
                              <asp:Label ID="lblreferencelinkleft" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                                <span class="input-group-text bg-secondary" title="Copy"><a onclick="copyToClipboardLeft(); return false;" style="color:white;"><i class="fa fa-copy"></i></a></span>
                                <span class="input-group-text bg-primary" title="Whatsapp" > <asp:Literal ID="ltwhatsapplinkleft" runat="server"></asp:Literal></span>
                                <span class="input-group-text bg-info" title="Facebook">
                                    <asp:Literal ID="ltfacebookshareleft" runat="server"></asp:Literal></span>
                            </div>

                           <div class="input-group mb-3"><span class="input-group-text">Right</span>
                              <asp:Label ID="lblreferencelinkright" CssClass="form-control" runat="server" Text="Label"></asp:Label>
                                   <span class="input-group-text bg-secondary" title="Copy"><a onclick="copyToClipboardRight(); return false;" style="color:white;"><i class="fa fa-copy"></i></a></span>
                                <span class="input-group-text bg-primary" title="Whatsapp" ><asp:Literal ID="ltwhatsapplinkright" runat="server"></asp:Literal></span>
                                <span class="input-group-text bg-info" title="Facebook">
                                    <asp:Literal ID="ltfacebookshareright" runat="server"></asp:Literal></span>
                            </div>
                            
                            <asp:Label ID="lbllinkleft" runat="server" style="display:none;" Text="Label"></asp:Label><asp:Label ID="lbllinkright"  runat="server" style="display:none;" Text="Label"></asp:Label>
                            
                           
                         
                        </div>

                    </div>
                </div>
            </div>--%>


            <div class="row">
                <div class="col-xl-5 box-col-12 des-xl-100">
                    <div class="row">
                        <div class="col-xl-6 col-md-3 col-sm-6 box-col-3 des-xl-25 rate-sec">
                            <div class="card income-card card-primary">
                                <div class="card-body text-center">
                                    <div class="round-box">
                                        <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewbox="0 0 448.057 448.057" style="enable-background: new 0 0 448.057 448.057;" xml:space="preserve">
                                            <g>
                                                <g>
                                                    <path d="M404.562,7.468c-0.021-0.017-0.041-0.034-0.062-0.051c-13.577-11.314-33.755-9.479-45.069,4.099                                            c-0.017,0.02-0.034,0.041-0.051,0.062l-135.36,162.56L88.66,11.577C77.35-2.031,57.149-3.894,43.54,7.417                                            c-13.608,11.311-15.471,31.512-4.16,45.12l129.6,155.52h-40.96c-17.673,0-32,14.327-32,32s14.327,32,32,32h64v144                                            c0,17.673,14.327,32,32,32c17.673,0,32-14.327,32-32v-180.48l152.64-183.04C419.974,38.96,418.139,18.782,404.562,7.468z"></path>
                                                </g>
                                            </g>
                                            <g>
                                                <g>
                                                    <path d="M320.02,208.057h-16c-17.673,0-32,14.327-32,32s14.327,32,32,32h16c17.673,0,32-14.327,32-32                                            S337.694,208.057,320.02,208.057z"></path>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <h5>
                                        <asp:Label ID="lblewalletbalance" runat="server" Text="0"></asp:Label></h5>
                                    <p>External Wallet</p>
                                    <a class="btn-arrow arrow-primary" href="javascript:void(0)"><i class="toprightarrow-primary fa fa-arrow-up me-2"></i>95.54% </a>
                                    <div class="parrten">
                                        <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewbox="0 0 448.057 448.057" style="enable-background: new 0 0 448.057 448.057;" xml:space="preserve">
                                            <g>
                                                <g>
                                                    <path d="M404.562,7.468c-0.021-0.017-0.041-0.034-0.062-0.051c-13.577-11.314-33.755-9.479-45.069,4.099                                            c-0.017,0.02-0.034,0.041-0.051,0.062l-135.36,162.56L88.66,11.577C77.35-2.031,57.149-3.894,43.54,7.417                                            c-13.608,11.311-15.471,31.512-4.16,45.12l129.6,155.52h-40.96c-17.673,0-32,14.327-32,32s14.327,32,32,32h64v144                                            c0,17.673,14.327,32,32,32c17.673,0,32-14.327,32-32v-180.48l152.64-183.04C419.974,38.96,418.139,18.782,404.562,7.468z"></path>
                                                </g>
                                            </g>
                                            <g>
                                                <g>
                                                    <path d="M320.02,208.057h-16c-17.673,0-32,14.327-32,32s14.327,32,32,32h16c17.673,0,32-14.327,32-32                                            S337.694,208.057,320.02,208.057z"></path>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-6 col-md-3 col-sm-6 box-col-3 des-xl-25 rate-sec">
                            <div class="card income-card card-secondary">
                                <div class="card-body text-center">
                                    <div class="round-box">
                                        <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewbox="0 0 512 512" style="enable-background: new 0 0 512 512;" xml:space="preserve">
                                            <g>
                                                <g>
                                                    <path d="M256,0C114.615,0,0,114.615,0,256s114.615,256,256,256s256-114.615,256-256S397.385,0,256,0z M96,100.16                                            c50.315,35.939,80.124,94.008,80,155.84c0.151,61.839-29.664,119.919-80,155.84C11.45,325.148,11.45,186.851,96,100.16z M256,480                                            c-49.143,0.007-96.907-16.252-135.84-46.24C175.636,391.51,208.14,325.732,208,256c0.077-69.709-32.489-135.434-88-177.6                                            c80.1-61.905,191.9-61.905,272,0c-98.174,75.276-116.737,215.885-41.461,314.059c11.944,15.577,25.884,29.517,41.461,41.461                                            C353.003,463.884,305.179,480.088,256,480z M416,412v-0.16c-86.068-61.18-106.244-180.548-45.064-266.616                                            c12.395-17.437,27.627-32.669,45.064-45.064C500.654,186.871,500.654,325.289,416,412z"></path>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <h5>
                                        <asp:Label ID="lblbalanceamount" runat="server" Text="0"></asp:Label></h5>
                                    <p>Internal Wallet</p>
                                    <a class="btn-arrow arrow-secondary" href="javascript:void(0)"><i class="toprightarrow-secondary fa fa-arrow-up me-2"></i>90.54% </a>
                                    <div class="parrten">
                                        <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewbox="0 0 512 512" style="enable-background: new 0 0 512 512;" xml:space="preserve">
                                            <g>
                                                <g>
                                                    <path d="M256,0C114.615,0,0,114.615,0,256s114.615,256,256,256s256-114.615,256-256S397.385,0,256,0z M96,100.16                                            c50.315,35.939,80.124,94.008,80,155.84c0.151,61.839-29.664,119.919-80,155.84C11.45,325.148,11.45,186.851,96,100.16z M256,480                                            c-49.143,0.007-96.907-16.252-135.84-46.24C175.636,391.51,208.14,325.732,208,256c0.077-69.709-32.489-135.434-88-177.6                                            c80.1-61.905,191.9-61.905,272,0c-98.174,75.276-116.737,215.885-41.461,314.059c11.944,15.577,25.884,29.517,41.461,41.461                                            C353.003,463.884,305.179,480.088,256,480z M416,412v-0.16c-86.068-61.18-106.244-180.548-45.064-266.616                                            c12.395-17.437,27.627-32.669,45.064-45.064C500.654,186.871,500.654,325.289,416,412z"></path>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-6 col-md-3 col-sm-6 box-col-3 des-xl-25 rate-sec">
                            <div class="card income-card card-primary">
                                <div class="card-body text-center">
                                    <div class="round-box">
                                        <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewbox="0 0 448.057 448.057" style="enable-background: new 0 0 448.057 448.057;" xml:space="preserve">
                                            <g>
                                                <g>
                                                    <path d="M404.562,7.468c-0.021-0.017-0.041-0.034-0.062-0.051c-13.577-11.314-33.755-9.479-45.069,4.099                                            c-0.017,0.02-0.034,0.041-0.051,0.062l-135.36,162.56L88.66,11.577C77.35-2.031,57.149-3.894,43.54,7.417                                            c-13.608,11.311-15.471,31.512-4.16,45.12l129.6,155.52h-40.96c-17.673,0-32,14.327-32,32s14.327,32,32,32h64v144                                            c0,17.673,14.327,32,32,32c17.673,0,32-14.327,32-32v-180.48l152.64-183.04C419.974,38.96,418.139,18.782,404.562,7.468z"></path>
                                                </g>
                                            </g>
                                            <g>
                                                <g>
                                                    <path d="M320.02,208.057h-16c-17.673,0-32,14.327-32,32s14.327,32,32,32h16c17.673,0,32-14.327,32-32                                            S337.694,208.057,320.02,208.057z"></path>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <h5>
                                        <asp:Label ID="lblcoinbalance" runat="server" Text="0"></asp:Label></h5>
                                    <p>Coin Wallet</p>
                                    <a class="btn-arrow arrow-primary" href="javascript:void(0)"><i class="toprightarrow-primary fa fa-arrow-up me-2"></i>95.54% </a>
                                    <div class="parrten">
                                        <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewbox="0 0 448.057 448.057" style="enable-background: new 0 0 448.057 448.057;" xml:space="preserve">
                                            <g>
                                                <g>
                                                    <path d="M404.562,7.468c-0.021-0.017-0.041-0.034-0.062-0.051c-13.577-11.314-33.755-9.479-45.069,4.099                                            c-0.017,0.02-0.034,0.041-0.051,0.062l-135.36,162.56L88.66,11.577C77.35-2.031,57.149-3.894,43.54,7.417                                            c-13.608,11.311-15.471,31.512-4.16,45.12l129.6,155.52h-40.96c-17.673,0-32,14.327-32,32s14.327,32,32,32h64v144                                            c0,17.673,14.327,32,32,32c17.673,0,32-14.327,32-32v-180.48l152.64-183.04C419.974,38.96,418.139,18.782,404.562,7.468z"></path>
                                                </g>
                                            </g>
                                            <g>
                                                <g>
                                                    <path d="M320.02,208.057h-16c-17.673,0-32,14.327-32,32s14.327,32,32,32h16c17.673,0,32-14.327,32-32                                            S337.694,208.057,320.02,208.057z"></path>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-6 col-md-3 col-sm-6 box-col-3 des-xl-25 rate-sec">
                            <div class="card income-card card-secondary">
                                <div class="card-body text-center">
                                    <div class="round-box">
                                        <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewbox="0 0 512 512" style="enable-background: new 0 0 512 512;" xml:space="preserve">
                                            <g>
                                                <g>
                                                    <path d="M256,0C114.615,0,0,114.615,0,256s114.615,256,256,256s256-114.615,256-256S397.385,0,256,0z M96,100.16                                            c50.315,35.939,80.124,94.008,80,155.84c0.151,61.839-29.664,119.919-80,155.84C11.45,325.148,11.45,186.851,96,100.16z M256,480                                            c-49.143,0.007-96.907-16.252-135.84-46.24C175.636,391.51,208.14,325.732,208,256c0.077-69.709-32.489-135.434-88-177.6                                            c80.1-61.905,191.9-61.905,272,0c-98.174,75.276-116.737,215.885-41.461,314.059c11.944,15.577,25.884,29.517,41.461,41.461                                            C353.003,463.884,305.179,480.088,256,480z M416,412v-0.16c-86.068-61.18-106.244-180.548-45.064-266.616                                            c12.395-17.437,27.627-32.669,45.064-45.064C500.654,186.871,500.654,325.289,416,412z"></path>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                    <h5>
                                        <asp:Label ID="lblrijentbalance" runat="server" Text="0"></asp:Label></h5>
                                    <p>Rijent Wallet</p>
                                    <a class="btn-arrow arrow-secondary" href="javascript:void(0)"><i class="toprightarrow-secondary fa fa-arrow-up me-2"></i>90.54% </a>
                                    <div class="parrten">
                                        <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewbox="0 0 512 512" style="enable-background: new 0 0 512 512;" xml:space="preserve">
                                            <g>
                                                <g>
                                                    <path d="M256,0C114.615,0,0,114.615,0,256s114.615,256,256,256s256-114.615,256-256S397.385,0,256,0z M96,100.16                                            c50.315,35.939,80.124,94.008,80,155.84c0.151,61.839-29.664,119.919-80,155.84C11.45,325.148,11.45,186.851,96,100.16z M256,480                                            c-49.143,0.007-96.907-16.252-135.84-46.24C175.636,391.51,208.14,325.732,208,256c0.077-69.709-32.489-135.434-88-177.6                                            c80.1-61.905,191.9-61.905,272,0c-98.174,75.276-116.737,215.885-41.461,314.059c11.944,15.577,25.884,29.517,41.461,41.461                                            C353.003,463.884,305.179,480.088,256,480z M416,412v-0.16c-86.068-61.18-106.244-180.548-45.064-266.616                                            c12.395-17.437,27.627-32.669,45.064-45.064C500.654,186.871,500.654,325.289,416,412z"></path>
                                                </g>
                                            </g>
                                        </svg>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-sm-6 col-xl-6 xl-50 col-lg-6 box-col-6">
                                <div class="card social-widget-card" style="padding-bottom: 5px; padding-top: 5px;">
                                    <div class="card-body" style="padding-bottom: 5px; padding-top: 5px;">
                                        <div class="redial-social-widget radial-bar-70" data-label="50%"><i class="fa fa-dollar font-primary"></i></div>
                                        <h5 class="b-b-light" style="margin-bottom: 24px;">Internal
                                            <br />
                                            Wallet</h5>
                                        <div class="row">
                                            <div class="col text-center b-r-light" style="font-size: 13px;">
                                                <span>Balance</span>
                                                <h4 class="counter mb-0">
                                                    <asp:Label ID="lblbalanceamount2" runat="server" Text="0"></asp:Label></h4>
                                            </div>
                                            <div class="col text-center" style="font-size: 13px;">
                                                <span>Redeem</span>
                                                <h4 class="counter mb-0">
                                                    <asp:Label ID="lblredeemedbalance" runat="server" Text="Label"></asp:Label></h4>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6 col-xl-6 xl-50 col-lg-6 box-col-6">
                                <div class="card social-widget-card" style="padding-bottom: 5px; padding-top: 5px;">
                                    <div class="card-body" style="padding-bottom: 5px; padding-top: 5px;">
                                        <div class="redial-social-widget radial-bar-70" data-label="50%"><i class="fa fa-money font-primary"></i></div>
                                        <h5 class="b-b-light" style="margin-bottom: 24px;">Coin
                                            <br />
                                            Balance</h5>
                                        <div class="row">
                                            <div class="col text-center b-r-light" style="font-size: 14px;">
                                                <span>RTC</span>
                                                <h4 class="counter mb-0">
                                                    <asp:Label ID="lblcoinbalance2" runat="server" Text="0"></asp:Label></h4>
                                            </div>
                                            <div class="col text-center" style="font-size: 14px;">
                                                <span>Dollar</span>
                                                <h4 class="counter mb-0">
                                                    <asp:Label ID="lblcoinbalancedollar" runat="server" Text="0"></asp:Label></h4>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row form-group">
                                    <div class="col-sm-6 col-xl-6 col-lg-6">
                                        <div class="card o-hidden border-0">
                                            <div class="bg-dark b-r-4 card-body">
                                                <div class="media static-top-widget">
                                                    <div class="align-self-center text-center"><i class="fa fa-sitemap fa-3x"></i></div>
                                                    <div class="media-body">
                                                        <span class="m-0">My Level</span>
                                                        <h4 class="mb-0 counter">
                                                            <asp:Label ID="lbltotaluser" runat="server" Text="0"></asp:Label></h4>
                                                        <i class="icon-bg" data-feather="database"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-xl-6 col-lg-6">
                                        <div class="card o-hidden border-0">
                                            <div class="bg-secondary b-r-4 card-body">
                                                <div class="media static-top-widget">
                                                    <div class="align-self-center text-center"><i class="fa fa-users  fa-3x"></i></div>
                                                    <div class="media-body">
                                                        <span class="m-0">Total Team</span>
                                                        <h4 class="mb-0 counter">
                                                            <asp:Label ID="lblmonthuser" runat="server" Text="0"></asp:Label></h4>
                                                        <i class="icon-bg" data-feather="shopping-bag"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-xl-6 col-lg-6">
                                        <div class="card o-hidden border-0">
                                            <div class="bg-success b-r-4 card-body">
                                                <div class="media static-top-widget">
                                                    <div class="align-self-center text-center"><i class="fa fa-users  fa-3x"></i></div>
                                                    <div class="media-body">
                                                        <span class="m-0">Left Team</span>
                                                        <h4 class="mb-0 counter">
                                                            <asp:Label ID="lblweekuser" runat="server" Text="0"></asp:Label></h4>
                                                        <i class="icon-bg" data-feather="message-circle"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-xl-6 col-lg-6">
                                        <div class="card o-hidden border-0">
                                            <div class="bg-danger b-r-4 card-body">
                                                <div class="media static-top-widget">
                                                    <div class="align-self-center text-center"><i class="fa fa-users  fa-3x"></i></div>
                                                    <div class="media-body">
                                                        <span class="m-0">Right Team</span>
                                                        <h4 class="mb-0 counter">
                                                            <asp:Label ID="lbltodayuser" runat="server" Text="0"></asp:Label></h4>
                                                        <i class="icon-bg" data-feather="user-plus"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-7 box-col-12 des-xl-100 dashboard-sec">
                    <div class="row p-0">
                        <div class="col-md-6 p-0">
                            <div class="card">
                                <div class="card-header  p-t-20 p-b-10">
                                    <div class="header-top text-center">
                                        <h5 class="text-center p-b-20">Deposit</h5>
                                        <i class="fa fa-arrow-up" style="font-size: 22px; color: #1B4C43"></i>
                                    </div>
                                </div>
                                <div class="card-body   ">
                                    <div class="row form-group text-center">
                                        <label>Enter Amount</label>
                                        <asp:TextBox ID="txtdepositamount" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>

                                    </div>
                                    <div class="row form-group">
                                        <asp:Button ID="btnDeposit" OnClick="btnDeposit_Click" CssClass=" btn btn-success" runat="server" Text="Deposit" />
                                    </div>
                                    <div class="row form-group">
                                        <asp:Button ID="btnDepositApprove" OnClick="btnDepositApprove_Click" CssClass=" btn btn-secondary" runat="server" Text="Approve" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 p-0">
                            <div class="card">
                                <div class="card-header  p-t-20 p-b-10">
                                    <div class="header-top text-center">
                                        <h5 class="text-center p-b-20">Withdrawal</h5>
                                        <i class="fa fa-arrow-down" style="font-size: 22px; color: #D22D3D;"></i>
                                    </div>
                                </div>
                                <div class="card-body   ">
                                    <div class="row form-group text-center">
                                        <label>Enter Amount</label>
                                        <asp:TextBox ID="txtwithdrawal" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>

                                    </div>
                                    <div class="row form-group">
                                        <asp:Button ID="btnwithdrawal" OnClick="btnwithdrawal_Click" CssClass=" btn btn-success" runat="server" Text="Withdrawal" />
                                    </div>
                                    <div class="row form-group">
                                        <asp:Button ID="btnwithdrawalapprove" OnClick="btnwithdrawalapprove_Click" CssClass=" btn btn-secondary" runat="server" Text="Approve" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card income-card">
                        <div class="card-header">
                            <div class="header-top d-sm-flex align-items-center">
                                <h5>Sales overview</h5>
                                <div class="center-content">
                                    <p class="d-sm-flex align-items-center"><span class="font-primary m-r-10 f-w-700">$859.25k</span><i class="toprightarrow-primary fa fa-arrow-up m-r-10"></i>86% More than last year</p>
                                </div>

                            </div>
                        </div>
                        <div class="card-body p-0">
                            <div id="chart-timeline-dashbord"></div>
                            <div class="code-box-copy">
                                <button class="code-box-copy__btn btn-clipboard" data-clipboard-target="#yearly-overview" title="Copy"><i class="icofont icofont-copy-alt"></i></button>
                                <pre><code class="language-html" id="yearly-overview">&lt;div class="card income-card"&gt; 
  &lt;div class="card-header"&gt;
    &lt;div class="header-top d-sm-flex align-items-center"&gt;
      &lt;h5&gt; yearly overview  &lt;/h5&gt;
       &lt;div class="center-content" &gt;
         &lt;p&gt; 
           &lt;span class="font-primary fontbold-600" &gt; $859.25k &lt;/span&gt;
           &lt;i class="toprightarrow-primary fa fa-arrow-up m-l-10 m-r-10" &gt; &lt;/i&gt;
            86% More than last year
         &lt;/p&gt; 
      &lt;/div&gt;
      &lt;div class="setting-list"&gt;
        &lt;ul class="list-unstyled setting-option"&gt;
          &lt;li&gt;&lt;div class="setting-primary"&gt;&lt;i class="icon-settings"&gt;&lt;/i&gt;&lt;/div&gt;&lt;/li&gt;
          &lt;li&gt;&lt;i class="view-html fa fa-code font-primary"&gt;&lt;/i&gt;&lt;/li&gt;
          &lt;li&gt;&lt;i class="icofont icofont-maximize full-card font-primary"&gt;&lt;/i&gt;&lt;/li&gt;
          &lt;li&gt;&lt;i class="icofont icofont-minus minimize-card font-primary"&gt;&lt;/i&gt;&lt;/li&gt;
          &lt;li&gt;&lt;i class="icofont icofont-refresh reload-card font-primary"&gt;&lt;/i&gt;&lt;/li&gt;
          &lt;li&gt;&lt;i class="icofont icofont-error close-card font-primary"&gt; &lt;/i&gt;&lt;/li&gt;
        &lt;/ul&gt;
      &lt;/div&gt;
    &lt;/div&gt;
  &lt;/div&gt;
  &lt;div class="card-body p-0"&gt;
    &lt;div id="chart-timeline-dashbord"&gt;&lt;/div&gt;
  &lt;/div&gt;
&lt;/div&gt;</code></pre>
                            </div>
                        </div>
                    </div>
                         <div class="row">
                                   <div class="col-xl-12 xl-100 box-col-12">
                <div class="widget-joins card widget-arrow">
                  <div class="row">
                    <div class="col-sm-6 pe-0">
                      <div class="media border-after-xs">
                        <div class="align-self-center me-3 text-start"><span class="widget-t mb-1">Left</span>
                          <h5 class="mb-0">Business</h5>
                        </div>
                        <div class="media-body align-self-center"><i class="font-primary" data-feather="arrow-up"></i></div>
                        <div class="media-body">
                          <h5 class="mb-0"><span class="counter">0</span></h5><%--<span class="mb-1">-$2658(36%)</span>--%>
                        </div>
                      </div>
                    </div>
                    <div class="col-sm-6 ps-0">
                      <div class="media">
                        <div class="align-self-center me-3 text-start"><span class="widget-t mb-1">Right</span>
                          <h5 class="mb-0">Business</h5>
                        </div>
                        <div class="media-body align-self-center"><i class="font-primary" data-feather="arrow-up"></i></div>
                        <div class="media-body ps-2">
                          <h5 class="mb-0"><span class="counter">0</span></h5><%--<span class="mb-1">+$369(15%)</span>--%>
                        </div>
                      </div>
                    </div>
                    <div class="col-sm-6 pe-0">
                      <div class="media border-after-xs">
                        <div class="align-self-center me-3 text-start"><span class="widget-t mb-1">My</span>
                          <h5 class="mb-0">Business</h5>
                        </div>
                        <div class="media-body align-self-center"><i class="font-primary" data-feather="arrow-up"></i></div>
                        <div class="media-body">
                          <h5 class="mb-0"><span class="counter">0</span></h5><%--<span class="mb-1">+$69(65%)</span>--%>
                        </div>
                      </div>
                    </div>
                    <div class="col-sm-6 ps-0">
                      <div class="media">
                        <div class="align-self-center me-3 text-start"><span class="widget-t mb-1">Total</span>
                          <h5 class="mb-0">Business</h5>
                        </div>
                        <div class="media-body align-self-center ps-3"><i class="font-primary" data-feather="arrow-up"></i></div>
                        <div class="media-body ps-2">
                          <h5 class="mb-0"><span class="counter">0</span></h5>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
                      </div>
                </div>

            </div>



        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
    
    <script src="assets/js/bootstrap.min.js"></script>
        <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
                <ContentTemplate>
                           <div id="myModalOffer" class="modal fade">
                    <div class="modal-dialog  modal-lg">
                        <div class="modal-content">

                            <div class="modal-body">
                                <div class="row form-group">
                                    <div class="col-sm-12">
                                        <asp:Literal ID="ltofferimage" runat="server"></asp:Literal>
                                    </div>



                                </div>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-danger" data-bs-dismiss="modal" aria-label="Close">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                    </ContentTemplate>
            </asp:UpdatePanel>
   
     <script>
           function showModalOffer(cookiename) {

                var myCookie = getCookie(cookiename)


                if (myCookie == null) {
                    $('#myModalOffer').modal('show');
                      setCookie(cookiename, cookiename, 1);
                }
                //else {
                //    alert(cookiename);
                //}


                //if (!cookiename) {
                //    $('#myModalOffer').modal('show');
                //}
                //else {
                //       //$('#myModalOffer').modal('show');
                //    alert('a');
                //}

            }
            function ClosepopupOffer() {
                $('#myModalOffer').modal('hide');
                $('body').removeClass('modal-open'); $("body").removeAttr("style");
                $('body').css('padding-right', '0');
                $('.modal-backdrop').remove();
            }
            function getCookie(name) {
                var dc = document.cookie;
                var prefix = name + "=";
                var begin = dc.indexOf("; " + prefix);
                if (begin == -1) {
                    begin = dc.indexOf(prefix);
                    if (begin != 0) return null;
                }
                else {
                    begin += 2;
                    var end = document.cookie.indexOf(";", begin);
                    if (end == -1) {
                        end = dc.length;
                    }
                }
                // because unescape has been deprecated, replaced with decodeURI
                //return unescape(dc.substring(begin + prefix.length, end));
                return decodeURI(dc.substring(begin + prefix.length, end));
            }
            function setCookie(cname, cvalue, exdays) {
                const d = new Date();
                d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
                let expires = "expires=" + d.toUTCString();
                document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
            }
   </script>
</asp:Content>
