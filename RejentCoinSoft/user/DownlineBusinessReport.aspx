<%@ Page Title="Business Report" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="DownlineBusinessReport.aspx.cs" Inherits="admin_DownlineReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
     <h4 class="page-title">Business Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Business Report</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" Runat="Server">
       <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="900"></asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal2">
                <div class="center2">
                    <img alt="" src="loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
            <div class="card">
                    <div class="card-header">
                        <h5>Search Criteria</h5>
                    </div>
                    <div class="card-body">
                                <div class="row form-group">
                                    <div class="col-md-3">User Id</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtuserid" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>     
                       
                       <%-- <div class="col-md-2">Standing Position</div>
                        <div class="col-md-2">
                            <asp:RadioButtonList ID="rbstandingposition" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Value="1">Left</asp:ListItem>
                                <asp:ListItem Value="2">Right</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>--%>
                                    <div class="col-md-3">Business Type</div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddbusinesstype" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">Select Value</asp:ListItem>
                                <asp:ListItem>Topup</asp:ListItem>
                                <asp:ListItem>Retopup</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                                </div>  
                        
                      
                            <div class="row form-group">
                                    <div class="col-md-3">From Date</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">To Date</div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txttodate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
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
              <div class="card">
                    <div class="card-header">
                        <h5>Business List</h5>
                    </div>
                    <div class="card-body">
                        <div class="row form-group">
                                    <div class="col-md-3">Left Business</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblleftbusiness" runat="server" Text="0"></asp:Label>
                                    </div>
                        
                                    <div class="col-md-3">Right Business</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblrightbusiness" runat="server" Text="0"></asp:Label>
                                    </div>
                        </div>
                         <div class="row form-group">
                                    <div class="col-md-3">Left Business(Retopup)</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblleftbusinessRetopup" runat="server" Text="0"></asp:Label>
                                    </div>
                        
                                    <div class="col-md-3">Right Business(Retopup)</div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblrightbusinessRetopup" runat="server" Text="0"></asp:Label>
                                    </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" AllowPaging="true" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                                     <asp:TemplateField HeaderText="Standing Position">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstandingposition" runat="server" Text='<%#Eval("standingnew") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Parent Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsponserid" runat="server" Text='<%#Eval("parentuserid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Parent Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblparentname" runat="server" Text='<%#Eval("parentname") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Topup Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltopupamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("topuptype") %>'></asp:Label>
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

