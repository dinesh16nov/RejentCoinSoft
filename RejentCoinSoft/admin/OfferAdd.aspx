<%@ Page Title="Add Offer" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="OfferAdd.aspx.cs" Inherits="admin_BankAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Add Offer</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
        <li class="breadcrumb-item active">Add Offer</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header">
                    <strong>Add Offer</strong>
                </div>
                <div class="card-body">
                    <div class="row form-group">
                            <div class="col-md-2">Offer Type</div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddoffertype" CssClass="form-control" runat="server">
                                <asp:ListItem Value="1">Before Login</asp:ListItem>
                                <asp:ListItem Value="2">After Login</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-1"></div>
                        <div class="col-md-2">Upload Image</div>
                        <div class="col-md-3">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                    </div>
                    <hr />
                    <div class="row form-group">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" />
                        </div>
                    </div>
                    </fieldset>
                </div>
            </div>
            <div class="card">
                <div class="card-header">
                    <strong>Offer List</strong>
                </div>

                <div class="card-body">

                    <div class="table-responsive">

                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                        
                                            <asp:Label ID="lblstatus" runat="server" Visible="false" Text='<%#Eval("status") %>'></asp:Label>
                                        <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Offer Type">
                                    <ItemTemplate>
                                     
                                        <asp:Label ID="lbloffertype" runat="server" Text='<%#Eval("offertype2") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblbankname" runat="server" Text='<%#Eval("Imagename") %>'></asp:Label>--%>
                                        <img src='userimage/<%#Eval("Imagename") %>' style="height:80px;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                        <label class="switch2">
 <asp:CheckBox ID="chkActive" runat="server" AutoPostBack="true" OnCheckedChanged="chkActive_CheckedChanged" Checked="true" />
  <span class="slider round"></span>
</label>
                                  
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbEdit" CommandName="mydel" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="icon fa fa-times" aria-hidden="true"></i></asp:LinkButton>
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">

    <script type="text/javascript">

        function validate() {
            // alert('sd');
            if (document.getElementById("<%=FileUpload1.ClientID%>").value == "") {

                toastr.warning('Warning', 'Upload Image');
                // alert("Enter Rank No"); 
                document.getElementById("<%=FileUpload1.ClientID%>").focus();
                   return false;
            }
            if (document.getElementById("<%=FileUpload1.ClientID%>").value != "") {

                if (document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".jpg") || document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".png") || document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".jpeg")) {
                }
                else {
                    toastr.warning('Warning', 'Image  should be in .jpg or .jpeg or .png format');
                    document.getElementById("<%=FileUpload1.ClientID%>").focus();
                       return false;
                }
            }

    </script>

    <script type="text/javascript">
            function showModal() {
                $('#myModal').modal({ backdrop: 'static', keyboard: false })
            }
            function Closepopup() {
                $('#myModal').modal('hide');
                $('body').removeClass('modal-open');
                $('body').css('padding-right', '0');
                $('.modal-backdrop').remove();
            }
    </script>
</asp:Content>



