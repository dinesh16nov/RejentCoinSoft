<%@ Page Title="Add Country" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="CountryAdd.aspx.cs" Inherits="admin_CountryAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="server">
        <h4 class="page-title">Add Country</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Country</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="card">
                    <div class="card-header">
                        <h5>Add Country</h5>
                    </div>
                    <div class="card-body">
            <div class="row form-group" id="rowid" runat="server" visible="false">
                <div class="col-md-3">
                    <label class="control-label">Country Id</label>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblcountryid" runat="server" Font-Bold="true" Text=""></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-3">
                    <label class="control-label">Country Name</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtcountryname" class="form-control"></asp:TextBox>
                </div>

            </div>
           <hr />
               
                <div class="row form-group">
                    <div class="col-md-3">
                        <label class="control-label"></label>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" OnClientClick="return validate();" OnClick="btnSubmit_Click" />

                        <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
           
        </div>
        
         </div>
       <div class="card">
                    <div class="card-header">
                        <h5>Country List</h5>
                    </div>
                    <div class="card-body">
                <div class="form-horizontal">
                    <asp:GridView AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="table table-striped table-bordered bootstrap-datatable datatable"
                        runat="server" ID="GridView1" AllowSorting="True">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblcountryname" runat="server" Text='<%# Eval("Countryname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="lbEdit" CssClass="fa fa-pencil btn btn-warning"  runat="server"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnEdit" CssClass="fa fa-pencil btn btn-warning btn-xs" runat="server"
                                        title="Edit" />
                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("CountryID") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="server">
    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 45 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function validate() {
            if (document.getElementById("<%=txtcountryname.ClientID%>").value == "") {
                  toastr.warning('Warning', 'Enter Country Name');      // 
                  //alert("Enter Rank No");
                  document.getElementById("<%=txtcountryname.ClientID%>").focus();
                  return false;
              }
          }
    </script>
</asp:Content>
