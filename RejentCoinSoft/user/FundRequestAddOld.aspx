<%@ Page Title="Add Fund Request" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="FundRequestAddOld.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <div class="row page-titles mx-0">
                    <div class="col-sm-6 p-md-0">
                        <div class="welcome-text">
                            <h4>Add Fund Request</h4>
                        </div>
                    </div>
                    <div class="col-sm-6 p-md-0 justify-content-sm-end mt-2 mt-sm-0 d-flex">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active"><a href="javascript:void(0)">Add Fund Request</a></li>
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
                        <h5>Add Fund Request</h5>
                    </div>
                    <div class="card-body">
                                 <div class="row form-group">
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">Select Deposit Account :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddbankaccountno" AutoPostBack="true" OnSelectedIndexChanged="ddbankaccountno_SelectedIndexChanged"  CssClass="form-control"  runat="server">
                                            <asp:ListItem Value="0">Select Account No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">Deposit Account No :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtdepositaccountno" Enabled="false" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">Account Holder Name :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtaccountholdername" Enabled="false" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">Deposit Bank :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtdepositbank" Enabled="false" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">IFSC Code :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtifsccode" Enabled="false" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">Branch Name :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtbranchname" Enabled="false" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
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
                                        <label for="exampleInputEmail1">Payment Mode :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:DropDownList ID="ddpaymentmode" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">Select Mode</asp:ListItem>
                                            <asp:ListItem>NEFT</asp:ListItem>
                                            <asp:ListItem>RTGS</asp:ListItem>
                                            <asp:ListItem>Cheque</asp:ListItem>
                                            <asp:ListItem>IMPS</asp:ListItem>
                                            <asp:ListItem>Cash Deposit</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">Amount :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtamount" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">Transaction Id :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txttransactionid" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">Cheque No  :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtchequeno" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-sm-3">
                                        <label for="exampleInputEmail1">Mobile No(In Bank)  :</label>
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:TextBox ID="txtmobilenoinbank" runat="server" CssClass="form-control" />
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
            if (document.getElementById("<%=ddbankaccountno.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Bank Account');
                document.getElementById("<%=ddbankaccountno.ClientID%>").focus();
                   return false;
            }
            if (document.getElementById("<%=txtdepositaccountno.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Account No');
                document.getElementById("<%=txtdepositaccountno.ClientID%>").focus();
                   return false;
               }
            if (document.getElementById("<%=txtamount.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter Amount');
                   document.getElementById("<%=txtamount.ClientID%>").focus();
                   return false;
            }
            if (document.getElementById("<%=ddpaymentmode.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Payment Mode');
                document.getElementById("<%=ddpaymentmode.ClientID%>").focus();
                return false;
            }
           }

    </script>
</asp:Content>

