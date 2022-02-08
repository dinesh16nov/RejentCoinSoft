<%@ Page Title="Income Wallet To Rejent Coin Wallet Transfer" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="MWalletToEWallet.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
   <h4 class="page-title">Income Wallet To Coin Wallet Transfer</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Income Wallet To Coin Wallet Trasnfer</li>
							</ol>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
  
             
      <div class="card">
                    <div class="card-header">
                        <h5>Income Wallet To Rejent Coin Wallet Transfer   (Balance : <i class="fa fa-dollar"></i>
                            <asp:Literal ID="lbluserbalance" runat="server"></asp:Literal>)</h5>
                    </div>
                    <div class="card-body">
                        <div class="row form-group">                               
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">User Id :</label>
                            </div>
                            <div class="col-sm-3">                                  
                          <asp:TextBox ID="txtuserid" Enabled="false"  runat="server" CssClass="form-control"  />
                            </div>
                          <div class="col-sm-3">
                                <label for="exampleInputEmail1">User Name :</label>
                            </div>
                            <div class="col-sm-3">                                  
                          <asp:TextBox ID="txtusername" Enabled="false" runat="server"  CssClass="form-control" />
                            </div>                       
                        </div>
                    
                         <div class="row form-group">                               
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Amount ($):</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtamount" AutoPostBack="true" OnTextChanged="txtamount_TextChanged" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Rejent Coin :</label>
                             <span class="label label-warning">1Coin =<asp:Label ID="lblqauerecoinrate" runat="server" Text="0"></asp:Label> $</span>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtconvertedcoin" Enabled="false" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                            </div>
                              
                             </div>
                        <div class="row form-group">
                              
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Remark :</label>
                            </div>
                            <div class="col-sm-3">                                  
                         <asp:TextBox ID="txtremark"  runat="server" TextMode="MultiLine" CssClass="form-control"  />
                            </div>
                        </div>
                          <hr />

                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" OnClick="btnCancel_Click1" CssClass="btn btn-danger" runat="server" Text="Cancel" />
                                    </div>
                                </div>


                    </fieldset>
                </div>
            </div>

    
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" Runat="Server">
       <script type="text/javascript">

           function validate() {

              
               if (document.getElementById("<%=txtamount.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter Amount');
                   document.getElementById("<%=txtamount.ClientID%>").focus();
                   return false;
               }              
           }
         
    </script>
</asp:Content>

