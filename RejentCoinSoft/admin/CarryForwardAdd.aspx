<%@ Page Title="Add Carry Forward" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="CarryForwardAdd.aspx.cs" Inherits="admin_FundTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Add Carry Forward</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Carry Forward</li>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
        <ContentTemplate>
            <div class="card">
                    <div class="card-header">
                        <h5>Add Carry Forward</h5>
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
                                    <div class="col-md-2">Left Carryforward</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtleftcarryforward" Enabled="false" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">Right Carryforward</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtrightcarryforward" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">Standing Position</div>
                                    <div class="col-md-3">
                                        <asp:RadioButtonList ID="rbstandingposition" RepeatDirection="Horizontal" style="width:100%;" runat="server">
                                            <asp:ListItem Value="1" Selected="True">Left</asp:ListItem>
                                            <asp:ListItem Value="2">Right</asp:ListItem>

                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">Carry Amount</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtamount" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
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
               if (document.getElementById("<%=txtamount.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Amount');
                document.getElementById("<%=txtamount.ClientID%>").focus();
                   return false;
               }
           }
    </script>
</asp:Content>

