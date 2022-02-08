<%@ Page Title="Add Fund Request" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="FundRequestAdd.aspx.cs" Inherits="user_WithdrawlRequstAdd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Add Fund Reqeust</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Fund Request</li>
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
             <div class="row form-group" style="display:none;">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h5>Add Fund Request</h5>
                        </div>
                        <div class="card-body">
                            <div class="row form-group">
                                  <div class="col-sm-12 bg-warning">
                                      <h5>Fund Request Option is temporarily down. Please Use Automatic Deposit Option</h5>
                                      </div>
                                </div>
                            </div>

                        </div>
                    </div>
                 </div>

            <asp:Panel ID="Panel1" runat="server" >
            <div class="row form-group">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header">
                            <h5>Add Fund Request</h5>
                        </div>
                        <div class="card-body">
                            <div class="row form-group">
                                <div class="col-sm-6">
                                    <label for="exampleInputEmail1">User Id :</label>
                                     <asp:TextBox ID="txtuserid" AutoPostBack="true" runat="server" CssClass="form-control" OnTextChanged="txtuserid_TextChanged" />
                                </div>
                                <div class="col-sm-6">
                                    <label for="exampleInputEmail1">User Name :</label>
                                       <asp:TextBox ID="txtusername" Enabled="false" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row form-group">
                                 <div class="col-sm-6">
                                    <label for="exampleInputEmail1">Deposit Wallet :</label>
                                     <asp:RadioButtonList ID="rbdepositwallet" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbdepositwallet_SelectedIndexChanged" runat="server">
                                         <asp:ListItem Value="EWallet" Selected="True">External Wallet</asp:ListItem>
                                         <asp:ListItem Value="Coin">Coin Wallet</asp:ListItem>
                                     </asp:RadioButtonList>
                                </div>
                                  <div class="col-md-6"> <label for="exampleInputEmail1">Select Wallet Type</label>
                                      <asp:DropDownList ID="ddwallettype" AutoPostBack="true" OnSelectedIndexChanged="ddwallettype_SelectedIndexChanged" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0"> Select Wallet Type</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="lblconversiontoqauere" Visible="false" runat="server" Text="0"></asp:Label>
                                    <asp:Label ID="lblconversionrate" Visible="false" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                            
                            <asp:Panel ID="pnlWalletAddress" runat="server">
                                    <div class="row form-group">
                                 <div class="col-md-6"> <label for="exampleInputEmail1">Select Wallet Address/Account </label> 
                                      <asp:DropDownList ID="ddwalletaddress" AutoPostBack="true" OnSelectedIndexChanged="ddwalletaddress_SelectedIndexChanged" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0"> Select Wallet Address</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            </asp:Panel>

                            <asp:Panel ID="pnlAccountDetail" runat="server" Visible="false">
                                     <div class="row form-group">
                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Deposit Account No :</label>
                        
                            <asp:TextBox ID="txtdepositaccountno" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Account Holder Name :</label>
                      
                            <asp:TextBox ID="txtaccountholdername" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Deposit Bank :</label>
                     
                            <asp:TextBox ID="txtdepositbank" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">IFSC Code :</label>
                       
                            <asp:TextBox ID="txtifsccode" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Branch Name :</label>
                        
                            <asp:TextBox ID="txtbranchname" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                            </asp:Panel>
                            <div class="row form-group">

                               
                                 <div class="col-sm-6">
                                    <label for="exampleInputEmail1">Enter Amount (<asp:Label ID="lblwallettype" runat="server" Text=""></asp:Label>) :</label>
                                      <asp:TextBox ID="txtamount" runat="server" AutoPostBack="true" OnTextChanged="txtamount_TextChanged1" onkeypress="return isNumberKey(event);" CssClass="form-control" />
                                </div>
                                 <div class="col-sm-6">
                                    <label for="exampleInputEmail1">Converted Amount (in <asp:Label ID="lbldepositwallet" runat="server" Text=""></asp:Label>) :</label>
                                      <asp:TextBox ID="txtconvertedamount" runat="server" onkeypress="return isNumberKey(event);" Enabled="false" CssClass="form-control" />
                                </div>
                                 <div class="col-sm-6">
                                    <label for="exampleInputEmail1">Transaction Id:</label>
                                     <asp:TextBox ID="txtonlinetransactionid" runat="server"  CssClass="form-control" />
                                </div>
                                
                            </div>
                            <div class="row form-group">
                              
                                
                                 
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
                </div>
                <div class="col-md-4">

                    <div class="card">
                        <div class="card-header">
                            <h5>QR Code</h5>
                        </div>
                        <div class="card-body">
                            <div class="row form-group">
                                <div class="col-sm-12">
                                    <asp:Literal ID="ltimage" runat="server"></asp:Literal>
                                    <br />
                   Address :               <b>   <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label></b><asp:Literal ID="ltcopybutton" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
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
            if (document.getElementById("<%=ddwallettype.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select Wallet Type');
                document.getElementById("<%=ddwallettype.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=ddwalletaddress.ClientID%>").value == "0") {

                toastr.warning('Warning', 'Select Wallet Address');
                document.getElementById("<%=ddwalletaddress.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtamount.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Amount');
                document.getElementById("<%=txtamount.ClientID%>").focus();
                return false;
            }
        }
    </script>
       <script>
  function copyaddress(copytext) {
                //var element = document.getElementById("ctl00_contentData_lbllinkleft")

                var $temp = $("<input>");
                $("body").append($temp);
                $temp.val(copytext).select();
                document.execCommand("copy");
                $temp.remove();
                // alert('Link Copied');
                toastr.success('Success', 'Copied Successfully');
                return false
            }
     </script>
</asp:Content>



