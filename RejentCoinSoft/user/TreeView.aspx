<%@ Page Title="Tree View" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="TreeView.aspx.cs" Inherits="admin_DownlineReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
  <h4 class="page-title">Treeview</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Treeview</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" Runat="Server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="card">
                    <div class="card-header">
                        <h5>Search Criteria</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">User Id</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtuserid" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                  
                                </div>
                              
                                <hr />
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit"  CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                </div>
            </div>

              <div class="card">
                    <div class="card-header">
                        <h5>Tree View</h5>
                    </div>
                    <div class="card-body">

                        <div class="table-responsive">

                                <asp:Panel ID="pnllist" runat="server" Visible="false">
                     <div class="widget  box-inverse">
            <h4 class="widgettitle">User List</h4>
            <div class="widgetcontent">
                 <div class="table-responsive">
                         `<asp:TreeView ShowLines="true" ID="Account_Chart" runat="server" ExpandDepth="0" ImageSet="Simple"  OnTreeNodePopulate="Account_Chart_TreeNodePopulate" BorderStyle="None">
                                            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                                            <ParentNodeStyle Font-Bold="False" />
                                            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" ForeColor="#5555DD" />
                                            <LeafNodeStyle ForeColor="#C00000" />
                                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                                                NodeSpacing="0px" VerticalPadding="0px" />
                                        </asp:TreeView>

                        <asp:Literal ID="ltteam" runat="server"></asp:Literal>
                     </div>

             
            </div>          
                
            </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>

