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
                                <h5 class="text-center alert alert-warning dark alert-dismissible fade show">Please Update Your Trust Wallet Address For withdrawal.<br /> <a href="UserEdit.aspx">Click here to update</a></h5>
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
                                <label for="exampleInputEmail1">Available Balance($) :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtbalance" Enabled="false" runat="server" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                            </div>
                          <%--  <div class="col-md-3"> <label for="exampleInputEmail1">Select Wallet Type</label></div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddwallettype" AutoPostBack="true" OnSelectedIndexChanged="ddwallettype_SelectedIndexChanged" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0"> Select Wallet Type</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblconversionrate" Visible="false" runat="server" Text="0"></asp:Label>
                            </div>--%>
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
                           <%--     <div class="col-sm-3">
                                <label for="exampleInputEmail1">Converted Amount in <b><asp:Label ID="lblwallettype" runat="server" Text=""></asp:Label> </b>:</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtconvertedamount" runat="server" Enabled="false" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                            </div>--%>
                        </div>
                        <div class="row form-group">
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Transaction Charge $(5%) :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txttransactioncharge" Enabled="false" runat="server" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                            </div>
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Final Amount $:</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtfinalamount" Enabled="false" runat="server" onkeypress="return isNumberKey(event);" CssClass="form-control" />
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



