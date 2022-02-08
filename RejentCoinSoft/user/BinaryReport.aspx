<%@ Page Title="Binary Tree" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="BinaryReport.aspx.cs" Inherits="admin_BinaryReport" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
  <h4 class="page-title">Binary Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Binary Report</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" Runat="Server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnldata" runat="server">
           <div class="card">
                    <div class="card-header">
                        <h5>Search Criteria</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">User Id</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtuserid" AutoPostBack="true" OnTextChanged="txtuserid_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                  
                                </div>
                              
                                <hr />
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit"  CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                           <hr />
                         <div class="table-responsive">

                          <iframe id="f1" runat="server" style="height:850px;width:100%;border:0px;"></iframe>
                        </div>
                </div>
            </div>

           <div class="card" style="display:none">
                    <div class="card-header">
                        <h5>Binary Tree</h5>
                    </div>
                    <div class="card-body">
                        <div class="row form-group">
                            <div class="col-md-12">
                       
                                </div>
                        </div>
                    </div>
                </div>
                </asp:Panel>
                  <asp:Panel ID="pnlnotauthorize" runat="server">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>Binary Report</h5>
                </div>
                <div class="ibox-content collapse in">
                    <div class="widgets-container">
                        <div class="form-horizontal">
                            <fieldset>
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <h3>You are not authorize to access this page</h3>
                                    </div>
                                  
                                  
                                </div>
                                
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>

         
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>


