<%@ Page Title="Sentbox" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="Sentbox.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Sentbox</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Sentbox</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:Panel ID="pnllist" runat="server" Visible="false">
               <div class="card">
            <div class="card-header text-uppercase">Sentbox
              
            </div>
             <div class="card-body">
                            <fieldset>
                                     <div class="row form-group">
                                 <div class="col-lg-12 col-md-12">
                        <div class="row table-responsive">
                            <div class="col-lg-12 col-md-12">
                           <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" Width="100%" AutoGenerateColumns="False">
                                    <Columns>
                                    <asp:TemplateField HeaderText="Sr.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfromid"  runat="server" Text='<%# Eval("FromId") %>'></asp:Label>


                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Message Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmessagetitle"  runat="server" Text='<%# Eval("MessageTitle") %>'></asp:Label>
                                            <asp:Label ID="lblmessageimagename" Visible="false" runat="server" Text='<%# Eval("imagename") %>'></asp:Label>
                                            <asp:Label ID="lblmessagedescription" Visible="false" runat="server" Text='<%# Eval("MessageDescription") %>'></asp:Label>

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate"  runat="server" Text='<%# Eval("mentiondate","{0:dd/MM/yyyy hh:mm tt}") %>'></asp:Label>

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="btnview" CommandName="ledger" OnClick="btnview_click" runat="server">View</asp:LinkButton>

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                         <div class="row form-group"> 
                      <div class="col-md-12">

                             <div class="row form-group" style="text-align: center;">
                            <div class="col-md-1">
                                <asp:LinkButton ID="lbtnFirst" runat="server" CausesValidation="false"
                                    OnClick="lbtnFirst_Click">First</asp:LinkButton>
                            </div>
                            <div class="col-md-1">
                                <asp:LinkButton ID="lbtnPrevious" runat="server" CausesValidation="false"
                                    OnClick="lbtnPrevious_Click">Previous</asp:LinkButton>
                            </div>
                            <div class="col-md-8">


                                <asp:ListView ID="ListPaging" runat="server" OnItemCommand="ListView2_ItemCommand" OnItemDataBound="ListView2_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnPaging" runat="server"
                                            CommandArgument='<%# Eval("PageIndex") %>' CommandName="Paging"
                                            Text='<%# Eval("PageText") %>'></asp:LinkButton>
                                        &nbsp;
                                    </ItemTemplate>

                                </asp:ListView>



                            </div>

                            <div class="col-md-1">
                                <asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false"
                                    OnClick="lbtnNext_Click">Next</asp:LinkButton>
                            </div>
                            <div class="col-md-1">
                                <asp:LinkButton ID="lbtnLast" runat="server" CausesValidation="false"
                                    OnClick="lbtnLast_Click">Last</asp:LinkButton>
                            </div>


                        </div>


                        <div class="row form-group" style="text-align: center;">
                            <div class="col-md-12">
                                <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                            </div>
                        </div>

                      </div>

                  </div>
                    </div>
                            </div>             </fieldset>
                        </div>
                    </div>
              </asp:Panel>
          

        </ContentTemplate>
        
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
     <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Message Detail</h4>
                        </div>
                        <div class="modal-body">
                          <div class="row form-group">
                                <div class="col-md-2" style="font-weight:bold;">From:</div>
                                <div class="col-md-10">
                                    <asp:Label ID="lblfromid" runat="server" Text="Label"></asp:Label></div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-2" style="font-weight:bold;">Title:</div>
                                <div class="col-md-10"><asp:Label ID="lbltitle" runat="server" Text="Label"></asp:Label></div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-2" style="font-weight:bold;">Detail:</div>
                                <div class="col-md-10"><asp:Label ID="lbldescription" runat="server" Text="Label"></asp:Label></div>
                            </div>
                             <div class="row form-group">
                                <div class="col-md-2" style="font-weight:bold;">Image:</div>
                                <div class="col-md-10"><asp:Label ID="lblimage" runat="server" Text=""></asp:Label></div>
                            </div>
                             <div class="row form-group">
                                <div class="col-md-2" style="font-weight:bold;">Date:</div>
                                <div class="col-md-10"><asp:Label ID="lbldate" runat="server" Text="Label"></asp:Label></div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
  
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

