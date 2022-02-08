<%@ Page Title="New Message" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="NewMessage.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">New Message</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">New Message</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
              <div class="card">
            <div class="card-header text-uppercase">New Message
               
            </div>
             <div class="card-body">
                            <fieldset>
                                <div class="row form-group">
                            <div class="col-md-3">
                                <label for="exampleInputEmail1">To</label>
                            </div>
                            <div class="col-md-3">
                               <asp:TextBox ID="txttoid" CssClass="form-control" runat="server"></asp:TextBox>
                            
                            </div>
                        </div>

                        <div class="row form-group">
                            <div class="col-md-3">
                                <label for="exampleInputEmail1">Title</label>
                            </div>
                            <div class="col-md-3">
                               <asp:TextBox ID="txtmessagetitle" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                           

                        </div>
                          <div class="row  form-group">
                               <div class="col-md-3">
                                <label for="exampleInputEmail1">Description</label>
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtdescription" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>

                            </div>
                              </div>
                                  <hr />
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit"  CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
            

        </ContentTemplate>
        
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
      
</asp:Content>

