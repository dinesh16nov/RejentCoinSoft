<%@ Page Title="Add State" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="StateAdd.aspx.cs" Inherits="admin_StateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="server">
   <h4 class="page-title">Add State</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add State</li>
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
                        <h5>Add State</h5>
                    </div>
                    <div class="card-body">
                                        <div class="row form-group" id="rowid" runat="server" visible="false">
                                            <div class="col-md-3">
                                                <label class="control-label">State Id</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblstateid" runat="server" Font-Bold="true" Text=""></asp:Label>
                                            </div>

                                        </div>
                                        <div class="row form-group">
                                            <div class="col-md-3">
                                                <label class="control-label">Select Country </label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="ddcountry" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                                <label for="exampleInputEmail1">State Name</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="txtstatename" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>


                                        <div class="row form-group">
                                            <div class="col-md-3">
                                                <label class="control-label"></label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="SUbmit" OnClientClick="return validate();" OnClick="btnSubmit_Click" />
                                              
                                                <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" />
                                            </div>
                                        </div>
                                    </div>
           </div>
    
    <div class="card">
                    <div class="card-header">
                        <h5>State List</h5>
                    </div>
                    <div class="card-body">
                                    <div class="form-horizontal">
                                        <asp:GridView AutoGenerateColumns="False" CssClass="table table-striped table-bordered bootstrap-datatable datatable"
                                            runat="server" OnRowCommand="GridView1_RowCommand" ID="GridView1" AllowSorting="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="#">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Country Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcountryid" Visible="false" runat="server" Text='<%# Eval("countryid") %>'></asp:Label>
                                                        <asp:Label ID="lblcountryname" runat="server" Text='<%# Eval("countryname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="State Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatename" runat="server" Text='<%# Eval("statename") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                               
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEdit" CssClass="fa fa-pencil btn btn-warning btn-xs" runat="server"
                                                            title="Edit Profile"  />
                                                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("stateID") %>' Visible="False"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                            </div>
                        </div>
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
            if (document.getElementById("<%=ddcountry.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Country ');
                document.getElementById("<%=ddcountry.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtstatename.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter State Name');
                document.getElementById("<%=txtstatename.ClientID%>").focus();
                return false;
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="server">
</asp:Content>


