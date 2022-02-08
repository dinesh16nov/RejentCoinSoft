<%@ Page Title="User Login Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="UserLoginReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">User Login Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">User Login Report</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal2">
                <div class="center2">
                    <img alt="" src="loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

           <div class="card">
                    <div class="card-header">
                        <h5>Search Criteria</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">Name</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">Mobile</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtmobile" onkeypress="return isNumber(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">User Id</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtuserid" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="row form-group">
                                    <div class="col-md-2">From Date</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">To Date</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txttodate"  CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
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
                        <h5>User List</h5>
                    </div>
                    <div class="card-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="true" PageSize="40" OnPageIndexChanging="GridView1_PageIndexChanging" >
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="User ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblusername" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("mobile") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcity" runat="server" Text='<%#Eval("cityname") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderText="Password">
                                        <ItemTemplate>
                                            <asp:Label ID="lblloginstatus" runat="server" Visible="false" Text='<%#Eval("status") %>'></asp:Label>
                                            <asp:Label ID="lblpassword" runat="server" Text='<%#Eval("password") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Login Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("loginstatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbactive" CssClass="badge badge-success  btn-sm" CommandName="myactive" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server">Active</asp:LinkButton>
                                            <asp:LinkButton ID="llbdeactive" CssClass="badge badge-danger btn-sm" CommandName="mydeactive" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server">Deactive</asp:LinkButton>
                                            <asp:LinkButton ID="lbllogin" CssClass="badge badge-info btn-sm" CommandName="mylogin" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server">Login</asp:LinkButton>
                                            <asp:LinkButton ID="lbresets" CssClass="badge badge-warning btn-sm" CommandName="myreset" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server">Reset</asp:LinkButton>
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
   
</asp:Content>

