<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminmaster.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="admin_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
              <h3>Dashboard</h3>
                  <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Dashboard.aspx" data-bs-original-title="" title="">Home</a></li>                 
                    <li class="breadcrumb-item active">Dashboard</li>
                  </ol>			
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" Runat="Server">
        <div class="row form-group">
              <div class="col-sm-6 col-xl-3 col-lg-6">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="database"></i></div>
                      <div class="media-body"><span class="m-0">Total Users</span>
                        <h4 class="mb-0 counter"><asp:Label ID="lbltotaluser" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="database"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-sm-6 col-xl-3 col-lg-6">
                <div class="card o-hidden border-0">
                  <div class="bg-secondary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="shopping-bag"></i></div>
                      <div class="media-body"><span class="m-0">Current Month</span>
                        <h4 class="mb-0 counter"> <asp:Label ID="lblmonthuser" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="shopping-bag"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-sm-6 col-xl-3 col-lg-6">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="message-circle"></i></div>
                      <div class="media-body"><span class="m-0">Current Week</span>
                        <h4 class="mb-0 counter"><asp:Label ID="lblweekuser" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="message-circle"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-sm-6 col-xl-3 col-lg-6">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="user-plus"></i></div>
                      <div class="media-body"><span class="m-0">Today Users</span>
                        <h4 class="mb-0 counter"><asp:Label ID="lbltodayuser" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="user-plus"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
                <div class="col-sm-6 col-xl-3 col-lg-6">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="user-plus"></i></div>
                      <div class="media-body"><span class="m-0">Pending Deposit</span>
                        <h4 class="mb-0 counter"><asp:Label ID="lblpendingdeposit" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="user-plus"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-sm-6 col-xl-3 col-lg-6">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="user-plus"></i></div>
                      <div class="media-body"><span class="m-0">Pending Withdrawal</span>
                        <h4 class="mb-0 counter"><asp:Label ID="lblpendingwithdrawal" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="user-plus"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
                <div class="col-sm-6 col-xl-3 col-lg-6">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="user-plus"></i></div>
                      <div class="media-body"><span class="m-0">Total Deposit</span>
                        <h4 class="mb-0 counter"><asp:Label ID="lbltotaldepsit" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="user-plus"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-sm-6 col-xl-3 col-lg-6">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="user-plus"></i></div>
                      <div class="media-body"><span class="m-0">Total Withdrawal</span>
                        <h4 class="mb-0 counter"><asp:Label ID="lbltotalwithdrawal" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="user-plus"></i>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-sm-6 col-xl-3 col-lg-6">
                  <a href="UserReport2.aspx?wtype=MWallet">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="user-plus"></i></div>
                      <div class="media-body"><span class="m-0">Internal Wallet </span>
                        <h4 class="mb-0 counter"><asp:Label ID="lblbalanceamount" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="user-plus"></i>
                      </div>
                    </div>
                  </div>
                </div>
                  </a>
              </div>
                 <div class="col-sm-6 col-xl-3 col-lg-6">
                       <a href="UserReport2.aspx?wtype=EWallet">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="user-plus"></i></div>
                      <div class="media-body"><span class="m-0">External Wallet </span>
                        <h4 class="mb-0 counter"><asp:Label ID="lblewalletbalance" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="user-plus"></i>
                      </div>
                    </div>
                  </div>
                </div>
                     </a>
              </div>
                 <div class="col-sm-6 col-xl-3 col-lg-6">
                       <a href="UserReport2.aspx?wtype=Coin">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="user-plus"></i></div>
                      <div class="media-body"><span class="m-0">Coin Wallet </span>
                        <h4 class="mb-0 counter"><asp:Label ID="lblcoinbalance" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="user-plus"></i>
                      </div>
                    </div>
                  </div>
                </div>
                     </a>
              </div>
                 <div class="col-sm-6 col-xl-3 col-lg-6">
                       <a href="UserReport2.aspx?wtype=Rijent">
                <div class="card o-hidden border-0">
                  <div class="bg-primary b-r-4 card-body">
                    <div class="media static-top-widget">
                      <div class="align-self-center text-center"><i data-feather="user-plus"></i></div>
                      <div class="media-body"><span class="m-0">Rijent Wallet</span>
                        <h4 class="mb-0 counter"><asp:Label ID="lblrijentbalance" runat="server" Text="0"></asp:Label></h4><i class="icon-bg" data-feather="user-plus"></i>
                      </div>
                    </div>
                  </div>
                </div>
                     </a>
              </div>
              <div class="col-sm-3 col-xl-3 xl-25 col-lg-3 box-col-3">
                    <a href="UserTopupReport.aspx">
                                <div class="card social-widget-card" style="padding-bottom: 5px; padding-top: 5px;">
                                    <div class="card-body" style="padding-bottom: 5px; padding-top: 5px;">
                                        <%--<div class="redial-social-widget radial-bar-70" data-label="50%"><i class="fa fa-dollar font-primary"></i></div>--%>
                                        <h5 class="b-b-light" style="margin-bottom: 24px;">Today 
                                            <br />
                                            Topup</h5>
                                        <div class="row">
                                            <div class="col text-center b-r-light" style="font-size: 13px;">
                                                <span>Amount</span>
                                                <h4> $
                                                    <span  class="counter mb-0" style="font-size: 18px;font-weight: 600;color:black">  <asp:Label ID="lbltodaytopupamount" runat="server" Text="0"></asp:Label></span>
                                                  </h4>
                                            </div>
                                            <div class="col text-center" style="font-size: 13px;">
                                                <span>Count</span>
                                                 <h4> 
                                                    <span  class="counter mb-0" style="font-size: 18px;font-weight: 600;color:black"> 
                                                    <asp:Label ID="lbltodaytopup" runat="server" Text="0"></asp:Label></span></h4>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                        </a>
                            </div>
                   <div class="col-sm-3 col-xl-3 xl-25 col-lg-3 box-col-3">


                       <a href="UserTopupReport.aspx">
                                <div class="card social-widget-card" style="padding-bottom: 5px; padding-top: 5px;">
                                    <div class="card-body" style="padding-bottom: 5px; padding-top: 5px;">
                                        <%--<div class="redial-social-widget radial-bar-70" data-label="50%"><i class="fa fa-dollar font-primary"></i></div>--%>
                                        <h5 class="b-b-light" style="margin-bottom: 24px;">Today 
                                            <br />
                                            Retopup</h5>
                                        <div class="row">
                                            <div class="col text-center b-r-light" style="font-size: 13px;">
                                                <span>Amount</span>
                                                <h4> $
                                                    <span  class="counter mb-0" style="font-size: 18px;font-weight: 600;color:black">  <asp:Label ID="lbltodayretopupamount" runat="server" Text="0"></asp:Label></span>
                                                  </h4>
                                            </div>
                                            <div class="col text-center" style="font-size: 13px;">
                                                <span>Count</span>
                                                 <h4> 
                                                    <span  class="counter mb-0" style="font-size: 18px;font-weight: 600;color:black"> 
                                                    <asp:Label ID="lbltodayretopupcount" runat="server" Text="Label"></asp:Label></span></h4>
                                            </div>
                                        </div>
                                    </div>
                                </div></a>
                            </div>
                   <div class="col-sm-3 col-xl-3 xl-25 col-lg-3 box-col-3">
                    <a href="FundRequestReport.aspx">
                                <div class="card social-widget-card" style="padding-bottom: 5px; padding-top: 5px;">
                                    <div class="card-body" style="padding-bottom: 5px; padding-top: 5px;">
                                        <%--<div class="redial-social-widget radial-bar-70" data-label="50%"><i class="fa fa-dollar font-primary"></i></div>--%>
                                        <h5 class="b-b-light" style="margin-bottom: 24px;">Today 
                                            <br />
                                            Deposit</h5>
                                        <div class="row">
                                            <div class="col text-center b-r-light" style="font-size: 13px;">
                                                <span>Amount</span>
                                                <h4> $
                                                    <span  class="counter mb-0" style="font-size: 18px;font-weight: 600;color:black">  <asp:Label ID="lbltodaydepositamount" runat="server" Text="0"></asp:Label></span>
                                                  </h4>
                                            </div>
                                            <div class="col text-center" style="font-size: 13px;">
                                                <span>Count</span>
                                                 <h4> 
                                                    <span  class="counter mb-0" style="font-size: 18px;font-weight: 600;color:black"> 
                                                    <asp:Label ID="lbltodaydeposit" runat="server" Text="0"></asp:Label></span></h4>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                        </a>
                            </div>
                   <div class="col-sm-3 col-xl-3 xl-25 col-lg-3 box-col-3">


                       <a href="WithdrawlRequestReport.aspx">
                                <div class="card social-widget-card" style="padding-bottom: 5px; padding-top: 5px;">
                                    <div class="card-body" style="padding-bottom: 5px; padding-top: 5px;">
                                        <%--<div class="redial-social-widget radial-bar-70" data-label="50%"><i class="fa fa-dollar font-primary"></i></div>--%>
                                        <h5 class="b-b-light" style="margin-bottom: 24px;">Today 
                                            <br />
                                            Withdrawal</h5>
                                        <div class="row">
                                            <div class="col text-center b-r-light" style="font-size: 13px;">
                                                <span>Amount</span>
                                                <h4> $
                                                    <span  class="counter mb-0" style="font-size: 18px;font-weight: 600;color:black">  <asp:Label ID="lbltodaywithdrawalamount" runat="server" Text="0"></asp:Label></span>
                                                  </h4>
                                            </div>
                                            <div class="col text-center" style="font-size: 13px;">
                                                <span>Count</span>
                                                 <h4> 
                                                    <span  class="counter mb-0" style="font-size: 18px;font-weight: 600;color:black"> 
                                                    <asp:Label ID="lbltodaywithdrawal" runat="server" Text="0"></asp:Label></span></h4>
                                            </div>
                                        </div>
                                    </div>
                                </div></a>
                            </div>
            </div>
    <div class="row">
        <div class="col-md-6">
             <div class="row">
                                   <div class="col-xl-12 xl-100 box-col-12">
                <div class="widget-joins card widget-arrow">
                  <div class="row">
                        <div class="col-sm-6 pe-0">
                      <div class="media border-after-xs">
                        <div class="align-self-center me-3 text-start">
                          <h5 class="mb-0">Binary</h5>
                            <span class="widget-t mb-1">Income</span>
                        </div>
                        <div class="media-body align-self-center"><i class="font-primary" data-feather="arrow-up"></i></div>
                        <div class="media-body">
                          <h5 class="mb-0">$<span class="counter">
                                       <asp:Label ID="lblbinaryincome" runat="server" Text="0"></asp:Label></span></h5><%--<span class="mb-1">-$2658(36%)</span>--%>
                        </div>
                      </div>
                    </div>
                    <div class="col-sm-6 ps-0">
                      <div class="media">
                        <div class="align-self-center me-3 text-start">
                          <h5 class="mb-0">Level</h5>
                            <span class="widget-t mb-1">Income</span>
                        </div>
                        <div class="media-body align-self-center"><i class="font-primary" data-feather="arrow-up"></i></div>
                        <div class="media-body ps-2">
                          <h5 class="mb-0">$<span class="counter"> <asp:Label ID="lbllevelincome" runat="server" Text="0"></asp:Label></span></h5><%--<span class="mb-1">+$369(15%)</span>--%>
                        </div>
                      </div>
                    </div>
                    <div class="col-sm-6 pe-0">
                      <div class="media border-after-xs">
                        <div class="align-self-center me-3 text-start">
                          <h5 class="mb-0">Direct</h5>
                            <span class="widget-t mb-1">Income</span>
                        </div>
                        <div class="media-body align-self-center"><i class="font-primary" data-feather="arrow-up"></i></div>
                        <div class="media-body">
                          <h5 class="mb-0">$<span class="counter">
                                       <asp:Label ID="lbldirectincome" runat="server" Text="0"></asp:Label></span></h5><%--<span class="mb-1">-$2658(36%)</span>--%>
                        </div>
                      </div>
                    </div>
                    <div class="col-sm-6 ps-0">
                      <div class="media">
                        <div class="align-self-center me-3 text-start">
                          <h5 class="mb-0">Minting</h5>
                            <span class="widget-t mb-1">Income</span>
                        </div>
                        <div class="media-body align-self-center"><i class="font-primary" data-feather="arrow-up"></i></div>
                        <div class="media-body ps-2">
                          <h5 class="mb-0">$<span class="counter"> <asp:Label ID="lblmintingincome" runat="server" Text="0"></asp:Label></span></h5><%--<span class="mb-1">+$369(15%)</span>--%>
                        </div>
                      </div>
                    </div>
                 
                  </div>
                </div>
              </div>
                      </div>
        </div>
    </div>
       
 
       
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" Runat="Server">
 
</asp:Content>

