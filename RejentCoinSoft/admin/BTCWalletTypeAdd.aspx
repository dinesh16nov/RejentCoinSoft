<%@ Page Title="Add Wallet Type" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="BTCWalletTypeAdd.aspx.cs" Inherits="admin_BankAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--   <style>
        .fade.in {
  opacity: 1;
}
.modal.in .modal-dialog {
  -webkit-transform: translate(0, 0);
  -o-transform: translate(0, 0);
  transform: translate(0, 0);
}

.modal-backdrop .fade .in {
  opacity: 0.5 !important;
}


.modal-backdrop.fade {
    opacity: 0.5 !important;
}
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <div class="row page-titles mx-0">
        <div class="col-sm-6 p-md-0">
            <div class="welcome-text">
                <h4>Add Wallet Type</h4>
            </div>
        </div>
        <div class="col-sm-6 p-md-0 justify-content-sm-end mt-2 mt-sm-0 d-flex">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
                <li class="breadcrumb-item active"><a href="javascript:void(0)">Add Wallet Type</a></li>
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
                    <h5>Add Wallet Type</h5>
                </div>
                <div class="card-body">
                    <div class="row form-group">
                        <div class="col-md-2">Wallet Type</div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtwallettype" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-1"></div>
                        <div class="col-md-2">Conversion To Dollar</div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtconversiontodollar" onkeypress="return isNumberKey(event);" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row form-group">

                        <div class="col-md-2">Conversion To Rijent</div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtconversiontoqauere" onkeypress="return isNumberKey(event);" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <hr />

                    <div class="row form-group">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" OnClick="btnCancel_Click" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" />
                        </div>
                    </div>


                    </fieldset>
                </div>
            </div>

            <div class="card">
                <div class="card-header">
                    <h5>Wallet Type List</h5>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                        <asp:Label ID="lblstatus" runat="server" Visible="false" Text='<%#Eval("status") %>'></asp:Label>
                                        <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wallet Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblwallettype" runat="server" Text='<%#Eval("wallettype") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Conversion To Dollar">
                                    <ItemTemplate>
                                        <asp:Label ID="lblconversion" runat="server" Text='<%#Eval("ConversionToDollar") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Conversion To Rijent">
                                    <ItemTemplate>
                                        <asp:Label ID="lblconversiontoqauere" runat="server" Text='<%#Eval("ConversionToQauere") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblisactive2" runat="server" Text='<%# Eval("isactive2") %>'></asp:Label>--%>
                                        <label class="switch2">
                                            <asp:CheckBox ID="chkActive" runat="server" AutoPostBack="true" OnCheckedChanged="chkActive_CheckedChanged" Checked="true" />
                                            <span class="slider round"></span>
                                        </label>

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
    <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Wallet Type</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                Wallet Type
                            <asp:Label ID="lblidedit" Visible="false" runat="server" Text=""></asp:Label>

                                <asp:TextBox runat="server" class="form-control" ID="txtwallettypeedit"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                Conversion To Dollar
                                <asp:TextBox runat="server" class="form-control" ID="txtconversiontodollaredit"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                Conversion To Rijent
                                <asp:TextBox runat="server" class="form-control" ID="txtconversiontoqauereedit"></asp:TextBox>
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
            // alert('sd');
            if (document.getElementById("<%=txtwallettype.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Wallet Type');
                // alert("Enter Rank No"); 
                document.getElementById("<%=txtwallettype.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtconversiontodollar.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Conversion To Dollar');
                // alert("Enter Rank No"); 
                document.getElementById("<%=txtconversiontodollar.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtconversiontoqauere.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Conversion To Rijent');
                // alert("Enter Rank No"); 
                document.getElementById("<%=txtconversiontoqauere.ClientID%>").focus();
                return false;
            }
        }
        function validate2() {
            // alert('sd');
            if (document.getElementById("<%=txtwallettypeedit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Wallet Type');
                document.getElementById("<%=txtwallettypeedit.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtconversiontodollaredit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Conversion To Dollar');
                document.getElementById("<%=txtconversiontodollaredit.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtconversiontoqauereedit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Conversion To Rijent');
                document.getElementById("<%=txtconversiontoqauereedit.ClientID%>").focus();
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function showModal() {
            // alert('a');
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
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>



