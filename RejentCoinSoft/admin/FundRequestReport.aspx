<%@ Page Title="Fund Request Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="FundRequestReport.aspx.cs" Inherits="admin_UserReport" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Fund Request Report</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Fund Request Report</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="card">
                <div class="card-header">
                    <h5>Search Criteria</h5>
                </div>
                <div class="card-body">

                    <div class="row form-group">
                        <div class="col-md-3">
                            From Date
                                        <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            To Date
                                        <asp:TextBox ID="txttodate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            User Id
                                        <asp:TextBox ID="txtuserid" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Status
                                    <asp:DropDownList ID="ddstatussearch" CssClass="form-control" runat="server">
                                     <asp:ListItem Value="0">Select Status </asp:ListItem>
                                        <asp:ListItem Selected="True">Pending</asp:ListItem>
                                        <asp:ListItem>Approved</asp:ListItem>
                                        <asp:ListItem>Rejected</asp:ListItem>
                                    </asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="row form-group">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                            
                               <asp:Button ID="btnExcel" CssClass="btn btn-secondary" runat="server" Text="Excel" OnClick="btnExcel_Click" />
                        </div>
                    </div>

                </div>
            </div>

            <div class="card">
                <div class="card-header">
                    <h5>Fund Request Report</h5>
                </div>
                <div class="card-body">

                    <div class="table-responsive">

                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="true" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbReverse" CommandName="myEdit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server">Edit</asp:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="User Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid" Visible="false" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                        <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="User Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldepousername" runat="server" Text='<%#Eval("username") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Deposit Wallet">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldepositwallet" runat="server" Text='<%#Eval("DepositWalletType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date of Request">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcreatingdate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approve Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreleasedate" runat="server" Text='<%#Eval("approvedate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Wallet Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblwallettype" runat="server" Text='<%#Eval("wallettype") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--     <asp:TemplateField HeaderText="Wallet Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblwalletaddress" runat="server" Text='<%#Eval("walletaddress") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Transaction Id">
                                    <ItemTemplate>
                                     <a href='https://bscscan.com/tx/<%#Eval("onlinetransactionid") %>' target="_blank">   <asp:Label ID="lbltranis" runat="server" Text='<%#Eval("onlinetransactionid") %>'></asp:Label></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Remark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblremark" runat="server" Text='<%#Eval("remark") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger  ControlID="btnExcel" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
    <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Request Status</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                User Id
                            <asp:Label ID="lblrequestid" Visible="false" runat="server" Text=""></asp:Label>
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txtuseridedit"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                Amount
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txtamount"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                Transaction Id
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txttransactionid"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                Status
                                <asp:DropDownList ID="ddstatus" class="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Status </asp:ListItem>
                                    <asp:ListItem>Approved</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                Remark:
                                     <asp:TextBox ID="txtremark" TextMode="MultiLine" runat="server" CssClass="form-control" />
                            </div>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClientClick="return validate2();" CssClass="btn btn-primary has-ripple" OnClick="btnUpdate_Click" />
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">

        function validate2() {
            if (document.getElementById("<%=ddstatus.ClientID%>").value == "0") {
                   toastr.warning('Warning', 'Select Status');
                   document.getElementById("<%=ddstatus.ClientID%>").focus();
                return false;
            }
        }
    </script>

    <script type="text/javascript">
        function showModal() {
            $('#myModal').modal('show');
        }
        function Closepopup() {
            $('#myModal').modal('hide');
            $('body').removeClass('modal-open');
            $('body').css('padding-right', '0');
            $('.modal-backdrop').remove();
        }
    </script>
        <%--<script src="assets/js/datepicker/date-picker/datepicker.js"></script>--%>
    <script src="assets/js/datepicker/date-picker/datepicker.en.js"></script>
    <%--<script src="assets/js/datepicker/date-picker/datepicker.custom.js"></script>--%>
</asp:Content>

