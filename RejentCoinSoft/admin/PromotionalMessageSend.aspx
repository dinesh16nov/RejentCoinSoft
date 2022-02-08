<%@ Page Title="Send Promotional Message" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="PromotionalMessageSend.aspx.cs" Inherits="admin_BankAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
     <h4 class="page-title">Send Promotional Message</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Send Promotional Message</li>
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
                        <h5>Send Promotional Message</h5>
                    </div>
                    <div class="card-body">
                    <div class="row form-group">
                        <div class="col-md-2">Message</div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtmessage" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <hr />

                    <div class="row form-group">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" OnClientClick="return validate();" CssClass="btn btn-primary has-ripple" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">

    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtmessage.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Message');
                document.getElementById("<%=txtmessage.ClientID%>").focus();
                   return false;
               }
           }
    </script>
</asp:Content>



