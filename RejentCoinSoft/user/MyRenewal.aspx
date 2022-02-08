<%@ Page Title="My Renewal" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="MyRenewal.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">My Renewal</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">My Renewal</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="modal2">
                        <div class="center2">
                            <img alt="" src="loader.gif" />
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
   
             <div class="card">
                    <div class="card-header">
                        <h5>My Renewal</h5>
                    </div>
                    <div class="card-body">                      <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                              <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            
                                     <%--   <asp:TemplateField HeaderText="User Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblusenamegf" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Mobile">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("mobile") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                     <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinvestedamount" runat="server" Text='<%#Eval("topupamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Maximum Limit/Capping">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltenure" runat="server" Text='<%#Eval("capingamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Current Amount Position">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcurrentamount" runat="server" Text='<%#Eval("currentincome") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("levelname") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltimage" runat="server"></asp:Literal>
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

