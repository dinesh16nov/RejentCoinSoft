<%@ Page Title="Coin To Team Rijent Wallet Transfer" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="RijentPayWalletTransfer.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
     <h4 class="page-title">Coin To Team Rijent Transfer</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Coin To Team Rijent Transfer</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header">
                    <h5>Rijent Coin Balance : <i class="fa fa-money"></i>
                        <asp:Label ID="lbluserbalance" runat="server" Text="Label"></asp:Label></h5>
                </div>
                <div class="card-body">
                    <fieldset>
                        <div class="row form-group">
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">User Id :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtuserid" Enabled="false" runat="server" CssClass="form-control" />
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
                                <label for="exampleInputEmail1">Balance :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtbalance" Enabled="false" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Transfer User Mobile :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txttransferuserid"  runat="server" CssClass="form-control" />
                            </div>
                           
                        </div>
                        <div class="row form-group">
                         
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Coins :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtamount" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                            </div>
                         <%--   <div class="col-sm-3">
                                <label for="exampleInputEmail1">Admin & Transaction Charge(10%) :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtadmincharge" ReadOnly="true" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                            </div>--%>
                        </div>
                        <div class="row form-group">
                         <%--   <div class="col-sm-3">
                                <label for="exampleInputEmail1">Total Amount :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txttotalamount" ReadOnly="true" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                            </div>--%>
                            <div class="col-sm-3">
                                <label for="exampleInputEmail1">Remark :</label>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine" CssClass="form-control" />
                            </div>
                        </div>
                        <hr />
                        <div class="row form-group">
                            <div class="col-md-12">
                                <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" OnClick="btnCancel_Click1" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" />
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
    <script type="text/javascript">

        function validate() {

            if (document.getElementById("<%=txttransferuserid.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter User Id');
                   document.getElementById("<%=txttransferuserid.ClientID%>").focus();
                   return false;
               }
               if (document.getElementById("<%=txtamount.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter Amount');
                   document.getElementById("<%=txtamount.ClientID%>").focus();
                   return false;
               }
        }
      <%--  function gettotal() {

            var amount = 0, admincharge = 0, totalamount = 0;
            if (document.getElementById("<%=txtamount.ClientID%>").value != "") {
                   amount = document.getElementById("<%=txtamount.ClientID%>").value;
               }
               admincharge = (parseFloat(amount) * parseFloat(10)) / 100;
               document.getElementById("<%=txtadmincharge.ClientID%>").value = admincharge;


               totalamount = parseFloat(amount) - parseFloat(admincharge);
               document.getElementById("<%=txttotalamount.ClientID%>").value = totalamount;
        }--%>
    </script>
</asp:Content>

