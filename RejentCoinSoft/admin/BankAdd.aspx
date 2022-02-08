<%@ Page Title="Add Bank" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="BankAdd.aspx.cs" Inherits="admin_BankAdd" %>

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
      <h3>Add bank</h3>
                  <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Dashboard.aspx" data-bs-original-title="" title="">Home</a></li>                 
                    <li class="breadcrumb-item active">Add Bank</li>
                  </ol>			
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


                <div class="card">
                    <div class="card-header">
                        <h5>Add Bank</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">Bank Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtbankname" CssClass="form-control" runat="server"></asp:TextBox>
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
                        <h5>Bank List</h5>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("Bankid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bank Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbankname" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
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
                            <h4 class="modal-title">Edit Bank Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                Bank Name
                            <asp:Label ID="lblbankid" Visible="false" runat="server" Text=""></asp:Label>

                                <asp:TextBox runat="server" class="form-control" ID="txtbanknameedit"></asp:TextBox>
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
            if (document.getElementById("<%=txtbankname.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Bank Name');
                // alert("Enter Rank No"); 
                document.getElementById("<%=txtbankname.ClientID%>").focus();
                   return false;
            }
        }
        function validate2() {
            // alert('sd');
            if (document.getElementById("<%=txtbanknameedit.ClientID%>").value == "") {

                   toastr.warning('Warning', 'Enter Bank Name');
                   // alert("Enter Rank No"); 
                   document.getElementById("<%=txtbanknameedit.ClientID%>").focus();
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



