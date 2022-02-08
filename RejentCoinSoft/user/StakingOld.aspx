<%@ Page Title="Add Staking" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="StakingOld.aspx.cs" Inherits="admin_EPinAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Old Staking</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Old Staking Value</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header">
                    <h5>Old Staking</h5>
                </div>
                <div class="card-body">
                    <div class="row form-group">
                        <div class="col-sm-7">
                            <div class="row form-group">

                                <div class="col-sm-6">
                                    <label for="exampleInputEmail1">Old Staking Value</label>
                                </div>
                                <div class="col-sm-6">
                                    $
                                    <asp:TextBox ID="txtoldStaking" AutoPostBack="true" Enabled="false"  runat="server" CssClass="form-control" />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

