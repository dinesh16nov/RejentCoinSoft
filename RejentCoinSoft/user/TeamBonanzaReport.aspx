<%@ Page Title="Team Bonanza Report" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="TeamBonanzaReport.aspx.cs" Inherits="admin_DownlineReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Team Bonanza Report</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Team Bonanza Report</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header">
                    <h5>Team Bonanza Report</h5>
                </div>
                <div class="card-body">
                   

                    <div class="row">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" PageSize="40" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="true" OnRowDataBound="GridView1_RowDataBound">
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
                                   <%-- <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblusername" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Level No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("levelno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField HeaderText="Self Target">
                                        <ItemTemplate>
                                            <asp:Label ID="lblselftarget" runat="server" Text='<%#Eval("frombusiness") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="TeamTarget">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltarget" runat="server" Text='<%#Eval("teamfrombusiness") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Self Remaining">
                                        <ItemTemplate>
                                            <asp:Label ID="lblteambusness22" runat="server" Text='<%#Eval("remaining") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="SelTeamf Remaining">
                                        <ItemTemplate>
                                            <asp:Label ID="lblteambusness22454" runat="server" Text='<%#Eval("remainingteam") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 
                                    <asp:TemplateField HeaderText="Reward">
                                        <ItemTemplate>
                                            <asp:Label ID="lblregdate" runat="server" Text='<%#Eval("rewardproduct") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-Width="130px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("achievestatus") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
      
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

