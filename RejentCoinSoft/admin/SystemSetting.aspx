<%@ Page Title="System Setting" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="SystemSetting.aspx.cs" Inherits="admin_SystemSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
   <h4 class="page-title">Sysytem Setting</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">System Setting</li>
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
                    <strong>System Setting</strong>
                </div>

                <div class="card-body">
                    <fieldset>

                        <div class="col-md-12">
                            <div id="defaultForm" class="form-horizontal">
                               
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">Direct Icnome</label>
                                    <div class="col-lg-5">
                                        <asp:TextBox ID="txtdirectincome" onkeypress="return isNumber(event)" runat="server" ValidationGroup="WhiteLabel" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">Matching Income</label>
                                    <div class="col-lg-5">
                                        <asp:TextBox ID="txtmatchingincome" onkeypress="return isNumber(event)" runat="server" ValidationGroup="WhiteLabel" class="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-lg-4 control-label">Dollar To Rupee</label>
                                    <div class="col-lg-5">
                                        <asp:TextBox ID="txtdollartorupee" onkeypress="return isNumber(event)" runat="server" ValidationGroup="WhiteLabel" class="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                 <div class="form-group">
                                    <label class="col-lg-4 control-label">Rejent Coin To Dollar</label>
                                    <div class="col-lg-5">
                                        <asp:TextBox ID="txtqaurecointodollar" onkeypress="return isNumber(event)" runat="server" ValidationGroup="WhiteLabel" class="form-control"></asp:TextBox>

                                    </div>
                                </div>
                              
                                <hr />
                                <div class="form-group">
                                    <label class="col-lg-3 control-label"></label>
                                    <div class="col-lg-9">
                                        <asp:Button ID="ButSubmit" runat="server" OnClick="ButSubmit_Click" ValidationGroup="WhiteLabel" Text="Submit" class="btn btn-primary btn-round" />
                                        <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" class="btn btn-danger btn-round" />
                                    </div>
                                </div>
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

