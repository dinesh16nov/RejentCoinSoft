<%@ Page Title="Add Holiday" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="HolidayAdd.aspx.cs" Inherits="admin_CountryAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
  <h4 class="page-title">Add Holiday</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Holiday</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div class="card">
                    <div class="card-header">
                        <h5>Add Holiday</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">Title</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txttitle" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">Date</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <hr />

                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" />
                                    </div>
                                </div>


                </div>
            </div>

              <div class="panel panel-default">
        <div class="panel-heading panel-heading-transparent">
            <strong>Holiday List</strong>
        </div>
        <div class="panel-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltitle" runat="server" Text='<%#Eval("title") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("holidaydate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbEdit" CommandName="edt" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton1" CommandName="mydel" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="icon fa fa-remove" aria-hidden="true"></i></asp:LinkButton>
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
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Holiday Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                Title
                            <asp:Label ID="lblholidayid" Visible="false" runat="server" Text=""></asp:Label>

                                <asp:TextBox runat="server" class="form-control" ID="txttitleedit"></asp:TextBox>
                            </div>
                             <div class="form-group">
                                Date

                                <asp:TextBox runat="server" class="form-control datepicker-here" ID="txtdateedit"></asp:TextBox>
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
            if (document.getElementById("<%=txttitle.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter Title');
                   document.getElementById("<%=txttitle.ClientID%>").focus();
                   return false;
               }
               if (document.getElementById("<%=txtdate.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter Holiday Date');
                   document.getElementById("<%=txtdate.ClientID%>").focus();
                   return false;
               }
           }
           function validate2() {
               if (document.getElementById("<%=txttitleedit.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter Title');
                   document.getElementById("<%=txttitleedit.ClientID%>").focus();
                   return false;
               }
               if (document.getElementById("<%=txtdateedit.ClientID%>").value == "") {
                   toastr.warning('Warning', 'Enter Date');
                   document.getElementById("<%=txtdateedit.ClientID%>").focus();
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

