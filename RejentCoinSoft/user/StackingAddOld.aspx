<%@ Page Title="Add Staking" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="StackingAddOld.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <div class="row page-titles mx-0">
        <div class="col-sm-6 p-md-0">
            <div class="welcome-text">
                <h4>Add Staking</h4>
            </div>
        </div>
        <div class="col-sm-6 p-md-0 justify-content-sm-end mt-2 mt-sm-0 d-flex">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                <li class="breadcrumb-item active"><a href="javascript:void(0)">Add Staking</a></li>
            </ol>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header">
                    <h5>Add Staking</h5>
                </div>
                <div class="card-body">
                    <div class="alert alert-warning alert-dismissible fade show">
									<i class="fa fa-money fa-2x" ></i>
									<span style="line-height: 30px;
    vertical-align: top;"><strong>Notification -</strong> Please Scan QR Code and make payment.
</span>
									<button type="button" class="close h-100" data-dismiss="alert" aria-label="Close"><span><i class="mdi mdi-close"></i></span>
                                    </button>
                                </div>
                      <div class="row form-group">
                           <div class="col-sm-7">
                                <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Wallet Type :</label>
                        </div>
                        <div class="col-sm-6">
                         <asp:DropDownList ID="ddwallettype" AutoPostBack="true" OnSelectedIndexChanged="ddwallettype_SelectedIndexChanged"  CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0"> Select Wallet Type</asp:ListItem>
                                </asp:DropDownList>
                        </div>

                    </div>
                                <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Wallet Address :</label>
                        </div>
                        <div class="col-sm-6">
                             <asp:DropDownList ID="ddwalletaddress" AutoPostBack="true" OnSelectedIndexChanged="ddwalletaddress_SelectedIndexChanged" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0"> Select Wallet Address</asp:ListItem>
                                </asp:DropDownList>
                        </div>

                    </div>
                                     <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Coin :</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtamount" AutoPostBack="true" OnTextChanged="txtamount_TextChanged" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                    
                        </div>

                    </div>
                                 <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Amount In Dollar :</label>
                              <span class="badge badge-warning"> 1 Rejent Coin =      <asp:Label ID="lblqauretodollar" runat="server" Text="0"></asp:Label> $</span>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtamountindollar" Enabled="false" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                        </div>

                    </div>
                    <div class="row form-group">
                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Tenure(Months) :</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="ddtenure" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">Select Tenure</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>


                    </div>
                    <div class="row form-group">
                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Transaction Id :</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txttransactionid" runat="server" CssClass="form-control" />
                        </div>

                    </div>
                    <div class="row form-group">
                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Remark :</label>
                        </div>
                        <div class="col-sm-6">
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
              <div class="col-md-5">
                  <asp:Literal ID="ltimage" runat="server"></asp:Literal>
              </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
    <script type="text/javascript">
        function validate() {
         
            if (document.getElementById("<%=txtamount.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Amount');
                document.getElementById("<%=txtamount.ClientID%>").focus();
                return false;
            }
             if (document.getElementById("<%=ddtenure.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Tenure');
                document.getElementById("<%=ddtenure.ClientID%>").focus();
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
           
        }

    </script>
</asp:Content>

