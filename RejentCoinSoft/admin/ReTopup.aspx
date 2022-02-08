<%@ Page Title="Add Bonanza Achiever" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="ReTopup.aspx.cs" Inherits="admin_Retopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="server">
    <h4 class="page-title">Retopup List</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Retopup List</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <div class="card">
        <div class="card-header">
            <h5>Re-Topup List </h5>
        </div>
        <div class="card-body">
            <div class="form-horizontal">
                <asp:GridView AutoGenerateColumns="False" CssClass="table table-striped table-bordered bootstrap-datatable datatable"
                    runat="server"  ID="GridView1" AllowSorting="True">
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
                        <asp:TemplateField HeaderText="User Name">
                            <ItemTemplate>
                                <asp:Label ID="lblusername" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile No">
                            <ItemTemplate>
                                <asp:Label ID="lblmobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Capping Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblcapping" runat="server" Text='<%# Eval("CapingAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Current Income">
                            <ItemTemplate>
                                <asp:Label ID="lblCurrentIncome" runat="server" Text='<%# Eval("CurrentIncome") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Renewal Date">
                            <ItemTemplate>
                                <asp:Label ID="lblmentiondate" runat="server" Text='<%# Eval("MentionDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode; -
            if (charCode > 31 && (charCode < 45 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="server">
</asp:Content>


