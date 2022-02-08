<%@ Page Title="Add Social Link" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="SocialLinkAdd.aspx.cs" Inherits="blue_Dashboard" EnableEventValidation="false" ValidateRequest="false"  MaintainScrollPositionOnPostBack = "true"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
       
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Add Social Link</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
        <li class="breadcrumb-item active">Add Social Link</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- end row -->
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
   

    <!-- end row -->
    <div class="row">
        <div class="col-xl-12">
            <div class="card">
                <div class="card-header">
                      <strong>Add Social Link</strong>
                </div>
                <div class="card-body">
                  
                    <div class="row form-group">
                              <div class="col-md-2">
                                  <label>Type</label>
                                  <asp:DropDownList ID="ddtype" CssClass="form-control" runat="server">
                                      <asp:ListItem Value="0">Select Type</asp:ListItem>
                                      <asp:ListItem>Facebook</asp:ListItem>
                                      <asp:ListItem>Instagram</asp:ListItem>
                                      <asp:ListItem>Twitter</asp:ListItem>
                                      <asp:ListItem>Linkedin</asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                                    <div class="col-md-10"><label>Link</label>
                                        <asp:TextBox ID="txtlink"  CssClass="form-control" runat="server"></asp:TextBox>
                                        <%--<textarea id="txtnews" runat="server" class="form-control" ></textarea>--%>
                                    </div>
                    </div>
                       <div class="row rowfooter">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" OnClick="btnSubmit_Click"  Text="Submit" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" OnClick="btnCancel_Click" Text="Cancel" />
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>

    </div>
      <div class="row">
        <div class="col-xl-12">
            <div class="card">
                <div class="card-header">
                     <strong>Social Link List</strong>
                </div>
                <div class="card-body">
                   
                    <div class="row">
                        <div class="col-md-12">
                          <div class="table-responsive">
                       <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("linktype") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Link">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllink" runat="server" Text='<%#Eval("link") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                         <asp:LinkButton ID="LinkButton1" CssClass="btn btn-warning btn-sm" CommandName="myedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="icon fa fa-edit" aria-hidden="true"></i></asp:LinkButton>
                                            <span onclick="return confirm_click();">
                                                <asp:LinkButton ID="lbEdit" CommandName="mydel" CssClass="btn btn-danger btn-sm" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="icon fa fa-trash" aria-hidden="true"></i></asp:LinkButton>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        </div>
                    </div>
                </div>
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
    <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Social Link Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                Type
                            <asp:Label ID="lblidedit" Visible="false" runat="server" Text=""></asp:Label>
                                 <asp:DropDownList ID="ddtypeedit" CssClass="form-control" runat="server">
                                      <asp:ListItem Value="0">Select Type</asp:ListItem>
                                      <asp:ListItem>Facebook</asp:ListItem>
                                      <asp:ListItem>Instagram</asp:ListItem>
                                      <asp:ListItem>Twitter</asp:ListItem>
                                      <asp:ListItem>Linkedin</asp:ListItem>
                                  </asp:DropDownList>
                            </div>
                              <div class="form-group">
                                Link
                            <asp:TextBox ID="txtlinkedit"  CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update"  CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                             <button type="button" class="btn btn-danger" data-bs-dismiss="modal" aria-label="Close">Close</button>
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
            if (document.getElementById("<%=txtlink.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Link');
                document.getElementById("<%=txtlink.ClientID%>").focus();
                return false;
            }
                 if (document.getElementById("<%=ddtype.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Type');
                document.getElementById("<%=ddtype.ClientID%>").focus();
                return false;
            }
        }
        function validate2() {
              if (document.getElementById("<%=ddtypeedit.ClientID%>").value == "0") {
                toastr.warning('Warning', 'Select Type');
                document.getElementById("<%=ddtypeedit.ClientID%>").focus();
                return false;
            }
            // alert('sd');
            if (document.getElementById("<%=txtlinkedit.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter Link');
                // alert("Enter Rank No"); 
                document.getElementById("<%=txtlinkedit.ClientID%>").focus();
                   return false;
               }
           }
    </script>

    <script type="text/javascript">
        function showModal() {
            //$('#myModal').modal({ backdrop: 'static', keyboard: false })
            $('#myModal').modal('show');
        }
        function Closepopup() {
            $('#myModal').modal('hide');
            $('body').removeClass('modal-open');  $("body").removeAttr("style");
            $('body').css('padding-right', '0');
            $('.modal-backdrop').remove();
        }
    </script>
  
   
</asp:Content>

