<%@ Page Title="Staking Report" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="StackingRequestReport.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
 <h4 class="page-title">Staking Request Report</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Staking Request Report</li>
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
                                    <%--<div class="col-md-2">From Date</div>--%>
                                    <div class="col-md-3">
                                        From Date
                                        <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                    <%--<div class="col-md-2">To Date</div>--%>
                                    <div class="col-md-3">
                                        To Date
                                        <asp:TextBox ID="txttodate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                    <%--<div class="col-md-2">User Id</div>--%>
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
                                    </div>
                                </div>
                       
                        </div>
                    </div>

             <div class="card">
                    <div class="card-header">
                        <h5>Staking Report</h5>
                    </div>
                    <div class="card-body">

                        <div class="table-responsive">

                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblid" Visible="false" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                            <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Coins">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("coins") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Coins in Dollar">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamountdollar" runat="server" Text='<%#Eval("dollaramount") %>'></asp:Label>
                                           <br /> <span style="font-size:11px;padding:1px 4px" class="badge badge-warning">1 Coin= <%#Eval("qaurecointodollar") %> $</span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                              
                                       <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Plan">
                                        <ItemTemplate>
                                            <asp:Label ID="lblplanname" runat="server" Text='<%#Eval("planname") %>'></asp:Label>
                                         (   <asp:Label ID="lbltenure" runat="server" Text='<%#Eval("tenure") %>'></asp:Label> Months)
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                     
                                     <asp:TemplateField HeaderText="Hash">
                                        <ItemTemplate>
                                           <a target="_blank" href='https://bscscan.com/tx/<%#Eval("Transactionhash") %>'> <asp:Label ID="lbltransactionhash" runat="server" Text='<%#Eval("Transactionhash") %>'></asp:Label><a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Approved">
                                        <ItemTemplate>
                                                <asp:LinkButton ID="lbReverse" CommandName="myEdit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" class="btn btn-warning">Approved</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Reject">
                                        <ItemTemplate>
                                             <asp:LinkButton ID="lblreject" CommandName="myReject" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" class="btn btn-danger" style="display:inline-block">Reject</asp:LinkButton>
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
    <asp:UpdatePanel runat="server" ID="uplMaster" UpdateMode="Always">
        <ContentTemplate>
            <div id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Staking Request Status</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                User Id
                            <asp:Label ID="lblrequestid" Visible="false" runat="server" Text=""></asp:Label>
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txtuseridedit"></asp:TextBox>
                            </div>
                            <div class="form-group">
                               Coins
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txtamount"></asp:TextBox>
                            </div>
                               <div class="form-group">
                               Coins In Dollar
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txtamountdollar"></asp:TextBox>
                            </div>
                             
                              <%-- <div class="form-group">
                              Wallet Address
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txtwalletaddress"></asp:TextBox>
                            </div>--%>
                             <div class="form-group">
                               Tenure
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txttenure"></asp:TextBox>
                            </div>
                              <div class="form-group">
                               Transaction Id
                                <asp:TextBox runat="server" Enabled="false" class="form-control" ID="txttransactionid"></asp:TextBox>
                            </div>
                              <div class="form-group">
                              Status
                                <asp:DropDownList ID="ddstatus"  class="form-control" runat="server">
                                    <asp:ListItem>Select Status </asp:ListItem>
                                    <asp:ListItem>Approved</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClientClick="return validate2();" CssClass="btn btn-primary has-ripple" OnClick="btnUpdate_Click" />
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
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
</asp:Content>

