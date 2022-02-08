<%@ Page Title="Coin Wallet Transfer" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="WalletTransfer.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Coin Wallet Transfer</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Coin Wallet Trasnfer</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header">
                    <h5>Rejent Coin Wallet Transfer</h5>
                </div>
                <div class="card-body">

                    <div class="row form-group">
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">Transfer User Id :</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txttransferuserid" AutoPostBack="true" runat="server" CssClass="form-control" OnTextChanged="txttransferuserid_TextChanged" />
                        </div>
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">Transfer User Name :</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txttransferusername" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">Amount :</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" />
                        </div>
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
                   document.getElementById("<%=txttransferusername.Text%>").focus();
                   return false;
               }
               if (document.getElementById("<%=txttransferusername.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter User Name');
                   document.getElementById("<%=txttransferusername.ClientID%>").focus();
                   return false;
               }
               if (document.getElementById("<%=txtamount.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter Amount');
                   document.getElementById("<%=txtamount.ClientID%>").focus();
                return false;
            }
        }

    </script>
</asp:Content>

