<%@ Page Title="" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="CompletedBonanza.aspx.cs" Inherits="admin_CompleteBonanza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" Runat="Server">
     <h4 class="page-title">Level Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Complete Bonanza Report</li>
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
                        <h5>Complete Bonanza Report</h5>
                    </div>
            </div>
              <div class="d-none card">
                    <div class="card-header">
                        <h5>Complete Bonanza Report</h5>
                    </div>
                    
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand">
                                <Columns>
                                                <asp:TemplateField HeaderText="#">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UserID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblbonanzaAchiever" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                        <asp:Label ID="lbluserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bonanza Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBonanzaName" runat="server" Text='<%# Eval("BonanzaName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Designation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Matching Business">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMatchingBusiness" runat="server" Text='<%# Eval("MatchingBusiness") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Direct Business">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDirectBusiness" runat="server" Text='<%# Eval("DirectBusiness") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Self Staking">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSelStaking" runat="server" Text='<%# Eval("SelStaking") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                                <asp:TemplateField HeaderText="Reward">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReward" runat="server" Text='<%# Eval("Reward") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField> 
                                               <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstatus" runat="server" Text='Pending'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                            </asp:GridView>
                    </div>
                </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" Runat="Server">
</asp:Content>

