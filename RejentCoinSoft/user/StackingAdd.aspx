<%@ Page Title="Add Staking" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="StackingAdd.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Add Staking</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Staking</li>
							</ol>
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
                   <%-- <div class="alert alert-secondary dark alert-dismissible fade show" role="alert">
                      <p><i class="fa fa-money"></i> <strong>Notification -</strong> Please Scan QR Code and make payment.</p>
                      <button class="btn-close" type="button" data-bs-dismiss="alert" aria-label="Close" data-bs-original-title="" title=""></button>
                    </div>--%>
           
                      <div class="row form-group">
                           <div class="col-sm-7">
                                <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">User id</label>
                        </div>
                        <div class="col-sm-6">
                         <asp:TextBox ID="txtuserid" AutoPostBack="true" Enabled="false" OnTextChanged="txtuserid_TextChanged" runat="server"  CssClass="form-control" />
                        </div>

                    </div>
                                <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Username</label>
                        </div>
                        <div class="col-sm-6">
                         <asp:TextBox ID="txtusername" runat="server" Enabled="false" CssClass="form-control" />
                        </div>

                    </div>
                                   <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Select Type</label>
                        </div>
                        <div class="col-sm-6">
                         <asp:DropDownList ID="ddtype" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Type</asp:ListItem>
                                    <asp:ListItem >Bonanza</asp:ListItem>
                                    <asp:ListItem >Renewal</asp:ListItem>
                                    <asp:ListItem >Topup</asp:ListItem>
                                   
                                </asp:DropDownList>
                        </div>

                    </div>
                                <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Select Plan</label>
                        </div>
                        <div class="col-sm-6">
                         <asp:DropDownList ID="ddplan" CssClass="form-control" runat="server">
                                   <%-- <asp:ListItem Value="0">Select Plan</asp:ListItem>
                                    <asp:ListItem Value="1">Plan 1 (6 Month)</asp:ListItem>
                                    <asp:ListItem Value="2">Plan 2 (12 Month)</asp:ListItem>
                                    <asp:ListItem Value="3">Plan 3 (24 Month)</asp:ListItem>
                                    <asp:ListItem Value="4">Plan 4 (36 Month)</asp:ListItem>
                                    <asp:ListItem Value="5">Plan 5 (60 Month)</asp:ListItem>--%>
                                </asp:DropDownList>
                        </div>

                    </div>
                                  

                             
                                     <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Staking Amount :</label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtamount" AutoPostBack="true" OnTextChanged="txtamount_TextChanged" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                    
                        </div>

                    </div>
                                <div class="row form-group">

                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Amount in In Dollar :
                                <span class="label label-warning">1 Coin =<asp:Label ID="lblqauerecoinrate" runat="server" Text="0"></asp:Label> $</span>
                            </label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtdollaramount" Enabled="false" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                    
                        </div>

                    </div>
                    <div class="row form-group">
                        <div class="col-sm-6">
                            <label for="exampleInputEmail1">Enter Hash :</label>
                        </div>
                        <div class="col-sm-6">
                          <asp:TextBox ID="txthash"  runat="server" CssClass="form-control" />
                        </div>


                    </div>
                   <%-- <div class="row form-group">
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
                    </div>--%>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" OnClick="btnCancel_Click1" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" />
                        
                        </div>
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
         
            if (document.getElementById("<%=txtamount.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Amount');
                document.getElementById("<%=txtamount.ClientID%>").focus();
                return false;
            }
             if (document.getElementById("<%=txthash.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Hash');
                document.getElementById("<%=txthash.ClientID%>").focus();
                return false;
            }
              if (document.getElementById("<%=ddplan.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Plan');
                document.getElementById("<%=ddplan.ClientID%>").focus();
                return false;
            }
              if (document.getElementById("<%=ddtype.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Type');
                document.getElementById("<%=ddtype.ClientID%>").focus();
                return false;
            }
             
            
           
        }

    </script>
</asp:Content>

