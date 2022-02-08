<%@ Page Title="Add Wallet Address" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="BTCWalletAddressAdd.aspx.cs" Inherits="admin_BankAdd" %>

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
    <h4 class="page-title">Add Wallet Address</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Wallet Address</li>
							</ol>
					
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
                                    <div class="col-md-3">    <label for="exampleInputEmail1">Select Wallet Type </label> </div>
                                    <div class="col-md-3">
                                       <asp:DropDownList ID="ddwallettype" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0">Select Wallettype</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                        <div class="col-md-3"><label for="exampleInputEmail1">Enter Wallet Address </label> </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtwalletaddress" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
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
                         <div class="row form-group">
                                    <div class="col-md-3"><label for="exampleInputEmail1">Image </label> </div>
                                    <div class="col-md-3">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
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
                        <h5>Wallet Address List</h5>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblimagename" runat="server" Visible="false" Text='<%#Eval("imagename") %>'></asp:Label>
                                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                            
                                            <asp:Label ID="lblstatus" runat="server" Visible="false" Text='<%#Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Wallet Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwallettype" runat="server" Text='<%#Eval("wallettype") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Wallet Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwalletaddress" runat="server" Text='<%#Eval("walletaddress") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Account Details">
                                    <ItemTemplate>
                               A/c Holder Name :          <asp:Label ID="lblaccountholdername" runat="server" Text='<%#Eval("accountholdername") %>'></asp:Label><br />
                                        A/c No :  <asp:Label ID="lblaccountno" runat="server" Text='<%#Eval("accountno") %>'></asp:Label><br />
                                        Bank :   <asp:Label ID="lblbankname" runat="server" Text='<%#Eval("BankName") %>'></asp:Label><br />
                                        Branch :   <asp:Label ID="lblbranchname" runat="server" Text='<%#Eval("branchname") %>'></asp:Label><br />
                                        IFSC :  <asp:Label ID="lblifsccode" runat="server" Text='<%#Eval("ifsccode") %>'></asp:Label>
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
                                     <asp:TemplateField HeaderText="Image">
                                        <ItemTemplate>
                                         <img src='userimage/<%#Eval("imagename") %>' style="height:250px;" />
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
        <Triggers>
            <asp:PostBackTrigger  ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
       <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Wallet Address</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                              <label for="exampleInputEmail1">    Wallet Address </label>
                                <br />
                            <asp:Label ID="lblidedit" Visible="false" runat="server" Text=""></asp:Label>

                                <asp:TextBox runat="server" class="form-control" ID="txtwalletaddressedit"></asp:TextBox>
                            </div>
                              <div class="form-group">
                              <label for="exampleInputEmail1">  Image </label>
                            <asp:Label ID="lblimagenameedit" Visible="false" runat="server" Text=""></asp:Label>

                               <asp:FileUpload ID="FileUpload2" runat="server" />
                            </div>
                             <div class="form-group">
                           
                                    <label for="exampleInputEmail1">Deposit Account No </label>
                              
                               <asp:TextBox ID="txtaccountnoedit" onkeypress="return isNumber(event)" runat="server" CssClass="form-control" />
                                 </div>
                               
                                    <label for="exampleInputEmail1">Account Holder Name </label>
                               <div class="form-group">
                                    <asp:TextBox ID="txtaccholdernameedit" runat="server" CssClass="form-control" />
                               
                            </div>
                            <div class="form-group">
                             
                                    <label for="exampleInputEmail1">Deposit Bank </label>
                               
                                    <asp:TextBox ID="txtdepositbankedit" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">IFSC Code :</label>
                              
                                    <asp:TextBox ID="txtifscedit" runat="server" CssClass="form-control" />
                                </div>
                              <div class="form-group">
                             
                                    <label for="exampleInputEmail1">Branch Name :</label>
                             
                                    <asp:TextBox ID="txtbranchnameedit" runat="server" CssClass="form-control" />
                               
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
           <Triggers>
               <asp:PostBackTrigger ControlID="btnUpdate" />
           </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function validate() {
            if (document.getElementById("<%=ddwallettype.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Wallet Type');
                document.getElementById("<%=ddwallettype.ClientID%>").focus();
                   return false;
            }
            <%-- if (document.getElementById("<%=txtwalletaddress.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Wallet Address');
                document.getElementById("<%=txtwalletaddress.ClientID%>").focus();
                   return false;
            }--%>
             if (document.getElementById("<%=FileUpload1.ClientID%>").value != "") {

                if (document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".jpg") || document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".png") || document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".jpeg")) {
                }
                else {
                    toastr.warning('Warning', 'Image  should be in .jpg or .jpeg or .png format');
                    document.getElementById("<%=FileUpload1.ClientID%>").focus();
                    return false;
                }

            }
        }
        function validate2() {
            <%--if (document.getElementById("<%=txtwalletaddressedit.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter Wallet Address');
                   document.getElementById("<%=txtwalletaddressedit.ClientID%>").focus();
                   return false;
            }--%>
              if (document.getElementById("<%=FileUpload2.ClientID%>").value != "") {

                if (document.getElementById("<%=FileUpload2.ClientID%>").value.endsWith(".jpg") || document.getElementById("<%=FileUpload2.ClientID%>").value.endsWith(".png") || document.getElementById("<%=FileUpload2.ClientID%>").value.endsWith(".jpeg")) {
                }
                else {
                    toastr.warning('Warning', 'Image  should be in .jpg or .jpeg or .png format');
                    document.getElementById("<%=FileUpload2.ClientID%>").focus();
                    return false;
                }

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



