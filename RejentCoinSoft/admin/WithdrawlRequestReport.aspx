<%@ Page Title="Withdrawl Request Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="WithdrawlRequestReport.aspx.cs" Inherits="admin_UserReport" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript"> functionCheckall(Checkbox)
        {
            var GridView1 = document.getElementById("<%=GridView1.ClientID %>"); for (i = 1;
                i < GridView1.rows.length; i++) {
                GridView1.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        } </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
  <h4 class="page-title">Withdrawal Request Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Withdrawal Request Report</li>
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

           <div class="card">
                    <div class="card-header">
                        <h5>Search Criteria</h5>
                    </div>
                    <div class="card-body">
                    <div class="row form-group">
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">From Date</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" CssClass="form-control datepicker-here" ID="txtfromdate"></asp:TextBox>

                        </div>
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">To Date</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox runat="server" CssClass="form-control datepicker-here" ID="txttodate"></asp:TextBox>

                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-md-3">
                            <label for="exampleInputEmail1">User Id</label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtuserid" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label for="exampleInputEmail1">Status</label>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddstatus" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">Select Status</asp:ListItem>
                                <asp:ListItem Selected="True">Pending</asp:ListItem>
                                <asp:ListItem>Approved</asp:ListItem>
                                <asp:ListItem>Rejected</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="row form-group">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btncancel_Click" />
                                        <%--<asp:Button ID="btnPayAll" CssClass="btn btn-info" runat="server" Text="Pay All" OnClick="btnPayAll_Click" />--%>
                               <asp:Button ID="btnExcel" CssClass="btn btn-secondary" runat="server" Text="Excel" OnClick="btnExcel_Click" />
                        </div>
                    </div>
                </div>
            </div>

             <div class="card">
                    <div class="card-header">
                        <h5>Withdrawal Request List</h5>
                    </div>
                    <div class="card-body">

                    <div class="table-responsive">

                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowDataBound="grdGetHelp_RowDataBound">
                            <Columns>
                               <%-- <asp:TemplateField>  
                                                <HeaderTemplate>  
                                                  
                                                    <asp:CheckBox ID="CheckBox1" OnCheckedChanged="chckchanged" AutoPostBack="true" runat="server" />
                                                </HeaderTemplate>  
                                                <ItemTemplate>  
                                                   

                                                    <asp:CheckBox ID="CheckBox2" runat="server" />

                                                </ItemTemplate>  
                                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <%--<asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Request">
                                    <ItemTemplate>
                                           <asp:Label ID="lblId" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                        <asp:Label ID="lblcreatingdate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblusername" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Approve Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreleasedate" runat="server" Text='<%#Eval("approvedate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                 <%--  <asp:TemplateField HeaderText="Bal Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbalamount" runat="server" Text='<%#Eval("balanceamount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="Admin & Transaction charge">
                                    <ItemTemplate>
                                        <asp:Label ID="lbladmintranamount" runat="server" Text='<%#Eval("admincharge") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                   <asp:TemplateField HeaderText="Amount($)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Amount(RTC)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconvetredamount" runat="server" Text='<%#Eval("convertedamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Tran Charge($)">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltrandcharge" runat="server" Text='<%#Eval("transactioncharge") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Tran Charge(RTC)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcontrandcharge" runat="server" Text='<%#Eval("convertedtransactioncharge") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Final Amount($)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfinalamount" runat="server" Text='<%#Eval("finalamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Final Amount(RTC)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfinalamounjtrtc" runat="server" Text='<%#Eval("convertedfinalamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Wallet Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwallettype" runat="server" Text='<%#Eval("wallettype") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Trust Wallet Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwalletaddress" runat="server" Text='<%#Eval("trustwalletaddress") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                          
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                           <%--     <asp:TemplateField HeaderText="Mode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmode" runat="server" Text='<%#Eval("paymentmode") %>'></asp:Label>
                                        <asp:DropDownList ID="ddmode" runat="server">
                                            <asp:ListItem Value="0">Select </asp:ListItem>
                                            <asp:ListItem>Cheque</asp:ListItem>
                                            <asp:ListItem>Online</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Transaction Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltransactionid" runat="server" Text='<%#Eval("OnlineTransactionId") %>'></asp:Label>
                                        <asp:TextBox ID="txttransactionid" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="lbView" CommandName="myview" OnClick="lbView_Click" runat="server"> View |</asp:LinkButton>--%>
                                        <asp:LinkButton ID="btnApprove" CommandName="approve" OnClick="btnApprove_click" runat="server"> Approve |</asp:LinkButton>
                                        <asp:LinkButton ID="btnReject" CommandName="reject" OnClick="btnReject_click" runat="server">Reject</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExcel" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
    <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">User Details (User Id:
                                <asp:Label runat="server" ID="lbluseridedit"></asp:Label>)</h4>
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

