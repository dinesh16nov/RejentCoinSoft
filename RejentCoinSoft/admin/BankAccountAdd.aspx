<%@ Page Title="Add Bank Account" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="BankAccountAdd.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
      <h4 class="page-title">Add Bank Account</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Bank Account</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

                <div class="card">
                    <div class="card-header">
                        <h5>Add Bank Account</h5>
                    </div>
                    <div class="card-body">
                    <div class="row form-group">
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">Deposit Account No :</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtdepositaccountno" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">Account Holder Name :</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtaccountholdername" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">Deposit Bank :</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtdepositbank" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">IFSC Code :</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtifsccode" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col-sm-3">
                            <label for="exampleInputEmail1">Branch Name :</label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtbranchname" runat="server" CssClass="form-control" />
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
                <div class="card">
                    <div class="card-header">
                        <h5>Bank Account List</h5>
                    </div>
                    <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                        <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acc Holder name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblaccountholdername" runat="server" Text='<%#Eval("accountholdername") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblaccountno" runat="server" Text='<%#Eval("accountno") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbankname" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IFSC Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblifsccode" runat="server" Text='<%#Eval("ifsccode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch Name ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbranchname" runat="server" Text='<%#Eval("branchname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbEdit" CommandName="edt" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton>
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">

    <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Bank Account Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row form-group">
                                <div class="col-sm-3">
                                    <label for="exampleInputEmail1">Deposit Account No :</label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="lblbankaccountid" runat="server" Visible="false" Text="0"></asp:Label>
                                    <asp:TextBox ID="txtaccountnoedit" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-sm-3">
                                    <label for="exampleInputEmail1">Account Holder Name :</label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtaccholdernameedit" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-3">
                                    <label for="exampleInputEmail1">Deposit Bank :</label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtdepositbankedit" runat="server" CssClass="form-control" />
                                </div>
                                <div class="col-sm-3">
                                    <label for="exampleInputEmail1">IFSC Code :</label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtifscedit" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-sm-3">
                                    <label for="exampleInputEmail1">Branch Name :</label>
                                </div>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtbranchnameedit" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClientClick="return validate2();" CssClass="btn btn-primary has-ripple" OnClick="btnUpdate_Click" />
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtaccountholdername.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Acc Holder Name');
                document.getElementById("<%=txtaccountholdername.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtdepositaccountno.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Account No');
                document.getElementById("<%=txtdepositaccountno.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtdepositbank.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Bank Name');
                document.getElementById("<%=txtdepositbank.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtifsccode.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter IFSC Code ');
                document.getElementById("<%=txtifsccode.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtbranchname.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Branch Name');
                document.getElementById("<%=txtbranchname.ClientID%>").focus();
                return false;
            }
        }

        function validate2() {
            if (document.getElementById("<%=txtaccholdernameedit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Account Holder Name');
                document.getElementById("<%=txtaccholdernameedit.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtaccountnoedit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Account No');
                document.getElementById("<%=txtaccountnoedit.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtdepositbankedit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Bank Name');
                document.getElementById("<%=txtdepositbankedit.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtifscedit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter IFSC Code ');
                document.getElementById("<%=txtifscedit.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtbranchnameedit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Branch Name');
                document.getElementById("<%=txtbranchnameedit.ClientID%>").focus();
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function showModal() {
            $('#myModal').modal('show');
        }
        function Closepopup() {
            $('#myModal').modal('hide');
            $('body').removeClass('modal-open');
            $('body').css('padding-right', '0');
            $('.modal-backdrop').remove();
        }
    </script>
</asp:Content>

