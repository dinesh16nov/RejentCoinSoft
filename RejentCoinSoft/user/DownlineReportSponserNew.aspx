<%@ Page Title="" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="DownlineReportSponserNew.aspx.cs" Inherits="admin_DownlineReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
     <h4 class="page-title">Level Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Level Report</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" Runat="Server">
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
                        <h5>Level Report</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-2">User Id</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtuserid" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>     
                                     
                        <div class="col-md-2">Level</div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddlevel" CssClass="form-control" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                                      <div class="col-md-2">Status</div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddstatus" CssClass="form-control" runat="server">
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">Inactive</asp:ListItem>
                                <asp:ListItem Value="2">Renew</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                                </div>                              
                               
                

          
<div class="row form-group">
                                    <div class="col-md-12">
                                       <asp:Button ID="btnSubmit"  CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
<div class="row">
<div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" AllowPaging="true" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
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
                                     <%--<asp:TemplateField HeaderText="Standing Position">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstandingposition" runat="server" Text='<%#Eval("standingposition") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Sponser Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsponserid" runat="server" Text='<%#Eval("sponserid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Sponser Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblparentname" runat="server" Text='<%#Eval("sponsername") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                      <asp:TemplateField HeaderText="Self Business">
                                        <ItemTemplate>
                                            <asp:Label ID="lblselfbusiness" runat="server" Text='<%#Eval("SelfBusiness2") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Team Business">
                                        <ItemTemplate>
                                            <asp:Label ID="lblteambusness" runat="server" Text='<%#Eval("sponserbusiness") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Level No">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllevelno" runat="server" Text='<%#Eval("levelno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Status" ItemStyle-Width="130px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("activestatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Topup Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblparentlbltopupdatename" runat="server" Text='<%#Eval("activationdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                    </div>

</div>
</div>
            </div>
              <div class="d-none card">
                    <div class="card-header">
                        <h5>Level Report</h5>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" AllowPaging="true" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                                     <%--<asp:TemplateField HeaderText="Standing Position">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstandingposition" runat="server" Text='<%#Eval("standingposition") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Sponser Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsponserid" runat="server" Text='<%#Eval("sponserid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Sponser Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblparentname" runat="server" Text='<%#Eval("sponsername") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                      <asp:TemplateField HeaderText="Self Business">
                                        <ItemTemplate>
                                            <asp:Label ID="lblselfbusiness" runat="server" Text='<%#Eval("selfbusiness") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Topup Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblparentlbltopupdatename" runat="server" Text='<%#Eval("activationdate","{0:dd/MM/yyyy}") %>'></asp:Label>
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
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>

