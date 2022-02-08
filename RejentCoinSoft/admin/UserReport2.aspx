<%@ Page Title="User Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="UserReport2.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
  <h4 class="page-title">User Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">User Report</li>
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
                        <div class="col-md-2">Name</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-2">Mobile</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtmobile" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                         <div class="col-md-2">User Id</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtuserid" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                     </div>
                   
                   
                    <div class="row form-group">
                       
                           <div class="col-md-2">Wallet Type</div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddwallettype" CssClass="form-control" runat="server">
                                <asp:ListItem Value="MWallet">Internal Wallet</asp:ListItem>
                                <asp:ListItem Value="EWallet">External Wallet</asp:ListItem>
                                <asp:ListItem Value="Coin">Coin Balance</asp:ListItem>
                                <asp:ListItem Value="Rijent">Rijent Balance</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="row form-group">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            <asp:Button ID="btnExcel" CssClass="btn btn-danger has-ripple" runat="server" Text="Export" OnClick="btnExcel_Click" />
                        </div>
                    </div>

                </div>
            </div>

            <div class="card">
                <div class="card-header">
                    <h5>User List</h5>
                </div>
                <div class="card-body">

                    <div class="table-responsive">

                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" AllowPaging="true" PageSize="40" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting" AllowSorting="true">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblusername" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sponser Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsponserid" runat="server" Text='<%#Eval("sponserid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("mobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Internal Wallet" SortExpression="balanceamount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("balanceamount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="External Wallet" SortExpression="ewalletbalance">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("ewalletbalance") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Coin Wallet" SortExpression="coinbalance">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("coinbalance") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Rijent Wallet" SortExpression="rijentbalance">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("rijentbalance") %>'></asp:Label>
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
                            <h4 class="modal-title">Edit User Details (User Id:
                                <asp:Label runat="server" ID="lbluseridedit"></asp:Label>)</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row form-group">
                                <div class="col-md-2">Name</div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtnameedit" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">Mobile</div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtmobileedit" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-2">Email</div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtemailedit" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">Gender</div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddgenderedit" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Select Gender</asp:ListItem>
                                        <asp:ListItem Value="Male">Male</asp:ListItem>
                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-2">Address</div>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtaddressedit" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-2">Select Country</div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddcountryedit" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddcountryedit_SelectedIndexChanged">
                                        <asp:ListItem Value="0"> Select Country</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">Select State</div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddstateedit" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0"> Select State</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-2">Select City</div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtcitynamedit" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">Area Name</div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtareaname" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row form-group">
                                <div class="col-md-2">Pincode</div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtpincodeedit" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">Date of Birth</div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtdateofbirthedit" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                </div>
                            </div>
                           <%-- <h3>Bank Details</h3>
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
                            <div class="row form-group">
                                <div class="col-md-2">Select Image</div>
                                <div class="col-md-3">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:Label ID="lblimagename" Visible="false" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-md-1"></div>

                            <%--    <div class="col-md-2">Is Dummy Data</div>
                                <div class="col-md-3">
                                    <asp:CheckBox ID="ck1" runat="server" />
                                </div>--%>
                            </div>
                             <%--<div class="row form-group">
                                <div class="col-md-2">Is Direct ROI</div>
                                <div class="col-md-3">
                                    <asp:CheckBox ID="ckdirectroi" runat="server" />
                                </div>
                                 <div class="col-md-1"></div>

                                <div class="col-md-2">Is Normal ROI</div>
                                <div class="col-md-3">
                                    <asp:CheckBox ID="cknormalroi" runat="server" />
                                </div>
                                 </div>
                            </div>--%>
                      
                        <div class="modal-footer">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClientClick="return validate2();" CssClass="btn btn-primary has-ripple" OnClick="btnUpdate_Click" />
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpdate" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function validate2() {
            if (document.getElementById("<%=txtnameedit.ClientID%>").value == "") {

                   toastr.warning('Warning', 'Enter Name');
                   document.getElementById("<%=txtnameedit.ClientID%>").focus();
                return false;
               }
               if (document.getElementById("<%=txtmobileedit.ClientID%>").value == "") {

                   toastr.warning('Warning', 'Enter Mobile');
                   document.getElementById("<%=txtmobileedit.ClientID%>").focus();
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
</asp:Content>

