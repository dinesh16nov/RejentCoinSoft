<%@ Page Title="Add Level" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="LevelAdd.aspx.cs" Inherits="admin_CountryAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="server">
    <h4 class="page-title">Add Level</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Level</li>
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
            <strong>Add Level</strong>
        </div>

        <div class="card-body">
            <div class="row form-group" id="rowid" runat="server" visible="false">
                <div class="col-md-3">
                    <label class="control-label">Level Id</label>
                </div>
                <div class="col-md-3">
                
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-3">
                    <label class="control-label">Level No</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtlevelno" onkeypress="return isNumber(event)" class="form-control"></asp:TextBox>
                </div>
                 <div class="col-md-3">
                    <label class="control-label">Income(%)</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtincome" onkeypress="return isNumber(event)" class="form-control"></asp:TextBox>
                </div>

            </div>
                <div class="row form-group">
                <div class="col-md-3">
                    <label class="control-label">Min Joining Package($)</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtjoiningpackage" onkeypress="return isNumber(event)" class="form-control"></asp:TextBox>
                </div>
                      <div class="col-md-3">
                    <label class="control-label">Min Direct Sponser</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="txtmindirectsponser" onkeypress="return isNumber(event)" class="form-control"></asp:TextBox>
                </div>
                

            </div>
            <div class="row form-group">

              
               
                    <div class="col-md-3">
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" OnClientClick="return validate();" OnClick="btnSubmit_Click" />

                        <asp:Button ID="btnCancel" runat="server" class="btn btn-danger" Text="Cancel" OnClick="btnCancel_Click" />
                  
                </div>
            </div>
        </div>
        </div>
        

        <div class="card">
            <div class="card-header">
                <strong>Level List </strong>
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
                            <asp:TemplateField HeaderText="Level No">
                                <ItemTemplate>
                                    <asp:Label ID="lbllevelno" runat="server" Text='<%# Eval("levelno") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Income(%)">
                                <ItemTemplate>
                                    <asp:Label ID="lblincome" runat="server" Text='<%# Eval("Income") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Min Joining($)">
                                <ItemTemplate>
                                    <asp:Label ID="lbljoiningpackage" runat="server" Text='<%# Eval("joiningpackage") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Min Direct Sponser">
                                <ItemTemplate>
                                    <asp:Label ID="lblmindirectsponser" runat="server" Text='<%# Eval("mindirect") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                       <asp:LinkButton ID="lbEdit" CommandName="edt" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton>
                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("id") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="server">

     <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Level Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                Level No
                                <asp:Label ID="lbllevelid" runat="server" Font-Bold="true" Text=""></asp:Label>
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txtlevelnoedit"></asp:TextBox>
                            </div>
                             <div class="form-group">
                                Income
                                <asp:TextBox runat="server" class="form-control" ID="txtincomeedit"></asp:TextBox>
                            </div>
                              <div class="form-group">
                                Joining Package ($)
                                <asp:TextBox runat="server" class="form-control" ID="txtjoiningpackageedit"></asp:TextBox>
                            </div>
                              <div class="form-group">
                               Min Direct Sponser
                                <asp:TextBox runat="server" class="form-control" ID="txtmindirectsponseredit"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClientClick="return validate2();" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <script type="text/javascript">
      

        function validate() {
            if (document.getElementById("<%=txtlevelno.ClientID%>").value == "") {
                  toastr.warning('Warning', 'Enter Level No');      // 
                  //alert("Enter Rank No");
                  document.getElementById("<%=txtlevelno.ClientID%>").focus();
                  return false;
            }
            if (document.getElementById("<%=txtincome.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Income');      // 
                //alert("Enter Rank No");
                document.getElementById("<%=txtincome.ClientID%>").focus();
                  return false;
            }
             if (document.getElementById("<%=txtjoiningpackage.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Min Joining Package');      // 
                //alert("Enter Rank No");
                document.getElementById("<%=txtjoiningpackage.ClientID%>").focus();
                  return false;
              }
        }

        function validate2() {
            if (document.getElementById("<%=txtlevelnoedit.ClientID%>").value == "") {
                 toastr.warning('Warning', 'Enter Level No');
                 document.getElementById("<%=txtlevelnoedit.ClientID%>").focus();
                   return false;
            }
            if (document.getElementById("<%=txtincomeedit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Income');
                document.getElementById("<%=txtincomeedit.ClientID%>").focus();
                 return false;
            }
              if (document.getElementById("<%=txtjoiningpackageedit.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Joining Package');
                document.getElementById("<%=txtjoiningpackageedit.ClientID%>").focus();
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
