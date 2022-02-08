<%@ Page Title="Add Bonanza Achiever" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="BananzaAchiever.aspx.cs" Inherits="admin_StateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="server">
   <h4 class="page-title">Add Bananza Achiever</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Bananza Achiever</li>
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
                        <h5>Add Bananza Achiever</h5>
                    </div>
                    <div class="card-body">
                                        <div class="row form-group" id="rowid" runat="server" visible="false">
                                            <div class="col-md-3">
                                                <label class="control-label">Bo Id</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Label ID="lblstateid" runat="server" Font-Bold="true" Text=""></asp:Label>
                                            </div>

                                        </div>
                                        <div class="row form-group">
                                            <div class="col-md-3">
                                                <label class="control-label">Select Bonanza</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="ddlbonanza" CssClass="form-control" runat="server">
                                                    <asp:ListItem Value="0">Select Bonanza</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3">
                                                <label for="exampleInputEmail1">UserID</label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:TextBox ID="txtuser" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                        </div>


                                        <div class="row form-group">
                                            <div class="col-md-3">
                                                <label class="control-label"></label>
                                            </div>
                                            <div class="col-md-3">
                                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="SUbmit" OnClientClick="return validate();" OnClick="btnSubmit_Click1" />
                                              
                                                <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" />
                                            </div>
                                        </div>
                                    </div>
           </div>
    
    <div class="card">
                    <div class="card-header">
                        <h5>Bonanza Achiever List</h5>
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
                                                <asp:TemplateField HeaderText="UserID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblbonanzaAchiever" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                        <asp:Label ID="lbluserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bonanza Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBonanzaName" runat="server" Text='<%# Eval("BonanzaName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Designation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Matching Business">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMatchingBusiness" runat="server" Text='<%# Eval("MatchingBusiness") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Direct Business">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDirectBusiness" runat="server" Text='<%# Eval("DirectBusiness") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Self Staking">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSelStaking" runat="server" Text='<%# Eval("SelStaking") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Reward">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReward" runat="server" Text='<%# Eval("Reward") %>'></asp:Label>
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
            var charCode = (evt.which) ? evt.which : evt.keyCode;-
            if (charCode > 31 && (charCode < 45 || charCode > 57)) {
                return false;
            }
            return true;
        }

        function validate() {
            if (document.getElementById("<%=ddlbonanza.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Bonanza ');
                document.getElementById("<%=ddlbonanza.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtuser.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter User ID');
                document.getElementById("<%=txtuser.ClientID%>").focus();
                return false;
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="server">
</asp:Content>


