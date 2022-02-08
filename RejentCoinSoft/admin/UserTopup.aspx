<%@ Page Title="User Upgrade" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="UserTopup.aspx.cs" Inherits="user_UserTopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
<h4 class="page-title">User Upgrade</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">User Upgrade</li>
							</ol>
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
                        <h5>Upgrade User</h5>
                    </div>
                    <div class="card-body">
                                  <div class="row form-group">
                                    <div class="col-md-2">Sponser Id</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtsponserid" AutoPostBack="true" OnTextChanged="txtsponserid_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">Sponser Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtsponsername" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">Upgrade User Id</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtuserid" AutoPostBack="true" OnTextChanged="txtuserid_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">User Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtusername" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                       
                              
                              <div class="row form-group">
                                   <div class="col-md-2">Select Wallet</div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddwallettype" AutoPostBack="true" OnSelectedIndexChanged="ddwallettype_SelectedIndexChanged" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Wallet</asp:ListItem>
                                    <asp:ListItem Value="EWallet">External Wallet</asp:ListItem>
                                    <asp:ListItem Value="MWallet">Internal Wallet</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                               <div class="col-md-1"></div>
                       
                               <div class="col-md-2">Balance($)</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtbalance" Enabled="false" onkeypress="return isNumberKey(event);" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                    </div>
                       
                        </div>
                        <div class="row form-group">
                    
                               <div class="col-md-2">Topup Amount($)</div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtamount"  CssClass="form-control" onkeypress="return isNumberKey(event);" runat="server"></asp:TextBox>
                            </div>
                               <div class="col-md-1"></div>
                              <div class="col-md-2">Is Dummy Topup</div>
                            <div class="col-md-3">
                                  <asp:CheckBox ID="ck1" runat="server" />
                            </div>
                        </div>
                         <hr />
                        <div class="row form-group">
                            <div class="col-md-12">
                                <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                            </div>
                        </div>
                        </div>
                   </div>
            
                </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" Runat="Server">
     <script type="text/javascript">
         function validate() {
             if (document.getElementById("<%=txtuserid.ClientID%>").value == "") {
                 toastr.warning('Warning', 'Enter User Id');
                 document.getElementById("<%=txtuserid.ClientID%>").focus();
                 return false;
             }
             if (document.getElementById("<%=txtsponserid.ClientID%>").value == "") {
                 toastr.warning('Warning', 'Enter Sponser Id');
                 document.getElementById("<%=txtsponserid.ClientID%>").focus();
                 return false;
             }
             if (document.getElementById("<%=ddwallettype.ClientID%>").value == "0") {

                 toastr.warning('Warning', 'Select Wallet Type ');
                 document.getElementById("<%=ddwallettype.ClientID%>").focus();
                 return false;
             }
                  if (document.getElementById("<%=txtuserid.ClientID%>").value == "0") {

                 toastr.warning('Warning', 'Enter User Id');
                 document.getElementById("<%=txtuserid.ClientID%>").focus();
                 return false;
             }
         }
         </script>
</asp:Content>

