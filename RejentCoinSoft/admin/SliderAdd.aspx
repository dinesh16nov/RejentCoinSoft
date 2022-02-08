<%@ Page Title="Add Sider" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="SliderAdd.aspx.cs" Inherits="admin_BankAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Add Slider</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
        <li class="breadcrumb-item active">Add Slider</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


             <div class="card">
        <div class="card-header">
            <strong >Add Slider</strong>   
            </div>
            
       

        <div class="card-body">
                            
             <div class="row form-group">
                                    <div class="col-md-2">Image(1300X510)</div>
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
                       <strong>Slider List</strong>   
                  </div>
           

        <div class="card-body">
            
                        <div class="table-responsive">

                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                            <asp:Label ID="lblstatus" runat="server" Visible="false" Text='<%#Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Image">
                                        <ItemTemplate>
                                          <img src='GalleryImages/<%#Eval("imagename") %>' style="width:500px;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEdit" CommandName="edt" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="icon fa fa-trash" aria-hidden="true"></i></asp:LinkButton>
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
            if (document.getElementById("<%=FileUpload1.ClientID%>").value == "") {
                toastr.warning('Warning', 'Select Image');
                document.getElementById("<%=FileUpload1.ClientID%>").focus();
                   return false;
               }
            if (document.getElementById("<%=FileUpload1.ClientID%>").value != "") {

                if (document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".jpg") || document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".png") || document.getElementById("<%=FileUpload1.ClientID%>").value.endsWith(".jpeg")) {
                }
                else {
                    toastr.warning('Warning', 'Image should be in .jpg or .jpeg or .png format');
                    document.getElementById("<%=FileUpload1.ClientID%>").focus();
                    return false;
                }

            }
           }
       
    </script>

  
</asp:Content>



