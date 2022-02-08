<%@ Page Title="Minting Bonus Report" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="ROIReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Minting Bonus Report</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
        <li class="breadcrumb-item active" aria-current="page">Minting Bonus Report</li>
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
                    <h5>Minting Bonus Report</h5>
                </div>
                <div class="card-body">
                    <div class="row form-group">
                        <div class="col-md-2">Inested Amount</div>
                        <div class="col-md-2">
                            <asp:DropDownList ID="ddtopup" CssClass="form-control" runat="server">
                                <asp:ListItem Value="0">Select Amount</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">From Date</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-2">To Date</div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txttodate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <hr />
                    <div class="row form-group">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

                        </div>
                    </div>
                    <div class="row">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" ShowFooter="true"
                                Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkViewDetails" CssClass="btn-primary btn-sm" OnClick="ViewDetails_Click"><i class="fa fa-eye"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <%--     <asp:TemplateField HeaderText="User Id">
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
                                    <%--      <asp:TemplateField HeaderText="Topup Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinvestedamount" runat="server" Text='<%#Eval("topupamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Total Coins">
                                        <ItemTemplate>
                                            <asp:Label ID="lblinvestedamount" runat="server" Text='<%#Eval("totalcoin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Total Days">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltenure" runat="server" Text='<%#Eval("ROIDays") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Minting Coin">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Minting Amount($)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblconvertedamount" runat="server" Text='<%#Eval("convertedamount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("closingdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            <%--<asp:Label ID="lblclosingdate" Visible="false" runat="server" Text='<%#Eval("closingdate") %>'></asp:Label>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("closingdate2","{0:dd/MM/yyyy}") %>'></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("mintingtype") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="d-none card">
                <div class="card-header">
                    <h5>Minting Bonus Report</h5>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView2" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="User Id">
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
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invested Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblinvestedamount" runat="server" Text='<%#Eval("dollaramount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tenure">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltenure" runat="server" Text='<%#Eval("tenure") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ROI Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblclosingdate" Visible="false" runat="server" Text='<%#Eval("closingdate") %>'></asp:Label>
                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("closingdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>





            <div class="modal" id="divModalPopup" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Date Wise Coin Details</h4>
                            <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <asp:GridView ID="GridView3" runat="server" CssClass="table table-bordered table-hover" ShowFooter="true" Width="100%" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Minting Coin">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Minting Amount($)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblconvertedamount" runat="server" Text='<%#Eval("convertedamount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("closingdate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltype" runat="server" Text='<%#Eval("mintingtype") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <asp:Button ID="btnClose" class="btn btn-danger" Text="Close" runat="server" OnClientClick="return CloseModalPopup();" />
                        </div>


                    </div>
                </div>
            </div>

            <script type="text/javascript">
                function CloseModalPopup() {
                    try {
                        $("#divModalPopup").modal('hide');
                        $(".modal-backdrop.show").css({ opacity: 0 });
                    }
                    catch (ex) {
                        ex.toString();
                    }                   
                }
            </script>

        </ContentTemplate>

    </asp:UpdatePanel>

    

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
</asp:Content>

