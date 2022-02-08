<%@ Page Title="Add Premium Wallet" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="PremiumWalletAdd.aspx.cs" Inherits="admin_FundTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Add Premium Wallet</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Premium Wallet</li>
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
                        <h5>Add Premium Wallet</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">User Id</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtuserid" AutoPostBack="true" OnTextChanged="txtuserid_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">User Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtpersonname" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">User Mobile</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtpersonmobile" Enabled="false" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">User Email</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtpersonemail" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                          <div class="row form-group">
                                    <div class="col-md-2">Premium Wallet bal</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtbalance" Enabled="false" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                   
                                </div>
                                <div class="row form-group">
                                   
                                    <div class="col-md-2">Monthly Return(%) </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtreturnpercent" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                       <div class="col-md-1"> </div>
                                       <div class="col-md-2">Days </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtdays" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                          <div class="row form-group">
                                   
                                    <div class="col-md-2">Coins </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtcoins" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                <div class="col-md-1"> </div>
                                       <div class="col-md-2">Limit </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtlimit" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
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
               if (document.getElementById("<%=txtpersonmobile.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Person Mobile');
                document.getElementById("<%=txtpersonmobile.ClientID%>").focus();
                   return false;
               }
               if (document.getElementById("<%=txtreturnpercent.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Monthly Return Percent');
                document.getElementById("<%=txtreturnpercent.ClientID%>").focus();
                   return false;
            }
             if (document.getElementById("<%=txtdays.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Days');
                document.getElementById("<%=txtdays.ClientID%>").focus();
                   return false;
            }
             if (document.getElementById("<%=txtcoins.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Coins');
                document.getElementById("<%=txtcoins.ClientID%>").focus();
                   return false;
            }
             if (document.getElementById("<%=txtlimit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Limit');
                document.getElementById("<%=txtlimit.ClientID%>").focus();
                   return false;
               }
           }
    </script>
</asp:Content>

