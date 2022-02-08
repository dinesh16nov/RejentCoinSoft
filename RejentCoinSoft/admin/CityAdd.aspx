<%@ Page Title="Add City" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="CityAdd.aspx.cs" Inherits="admin_CityAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
     <h4 class="page-title">Add City</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add City</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="card">
                    <div class="card-header">
                        <h5>Add City</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">Select Country</div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddcountry" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddcountry_SelectedIndexChanged">
                                            <asp:ListItem Value="0"> Select Country</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">Select State</div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddstate" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="0"> Select State</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div class="col-md-2">City Name</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtcityname" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                                <hr />

                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" />
                                    </div>
                                </div>
                            
                    </div></div>
             
        <div class="card">
                    <div class="card-header">
                        <h5>City List</h5>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("cityid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Country Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCountryname" runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatename" runat="server" Text='<%#Eval("statename") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcityname" runat="server" Text='<%#Eval("cityname") %>'></asp:Label>
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
                    </div></div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
    <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit City Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                City Name
                            <asp:Label ID="lblcityid" Visible="false" runat="server" Text=""></asp:Label>
                                <asp:TextBox runat="server" class="form-control" ID="txtcitynameedit"></asp:TextBox>
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

            if (document.getElementById("<%=ddcountry.ClientID%>").value == "0") {

                   toastr.warning('Warning', 'Select Country');
                   // alert("Enter Rank No"); 
                   document.getElementById("<%=ddcountry.ClientID%>").focus();
                   return false;
               }
               if (document.getElementById("<%=ddstate.ClientID%>").value == "0") {

                   toastr.warning('Warning', 'Select State');
                   // alert("Enter Rank No"); 
                   document.getElementById("<%=ddstate.ClientID%>").focus();
                   return false;
               }
               if (document.getElementById("<%=txtcityname.ClientID%>").value == "") {

                   toastr.warning('Warning', 'Enter City Name');
                   // alert("Enter Rank No"); 
                   document.getElementById("<%=txtcityname.ClientID%>").focus();
                   return false;
               }
           }
           function validate2() {
               // alert('sd');
               if (document.getElementById("<%=txtcitynameedit.ClientID%>").value == "") {

                   toastr.warning('Warning', 'Enter City Name');
                   // alert("Enter Rank No"); 
                   document.getElementById("<%=txtcitynameedit.ClientID%>").focus();
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

