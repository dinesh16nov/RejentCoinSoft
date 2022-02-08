<%@ Page Title="Withdrawal(Smart Contract)" Language="C#" MasterPageFile="usermaster.master" AutoEventWireup="true" CodeFile="SmartContractWithdrawal.aspx.cs" Inherits="admin_UserReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
  <h4 class="page-title">Withdrawal(Smart Contract)</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Withdrawal(Smart Contract)</li>
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
                                    <div class="col-md-2">From Date</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtfromdate" CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">To Date</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txttodate"  CssClass="form-control datepicker-here" runat="server"></asp:TextBox>
                                    </div>
                                        <div class="col-md-2">User Id</div>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="txtuserid"  CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                               
                                <hr />
                                <div class="row form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSubmit"  CssClass="btn btn-primary has-ripple" runat="server" Text="Search" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </div>
                                </div>
<div class="row">
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
                                            <asp:Label ID="lbluserid" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transaction Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblusername" runat="server" Text='<%#Eval("transactionid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("dramount") %>'></asp:Label>
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                     
                                      <%-- <asp:TemplateField HeaderText="From Address" ItemStyle-Width="190px">
                                        <ItemTemplate>
                                            <div style="  white-space: nowrap;   width: 110px;   overflow: hidden;  text-overflow: ellipsis; ">
                                            <asp:Label ID="lblfromadress" runat="server" Text='<%#Eval("fromwalletaddress") %>'></asp:Label></div>
                                            <a onclick="copyaddress('<%#Eval("fromwalletaddress") %>')" style="display:inline "> <i class="fa fa-copy"></i></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="To Address">
                                        <ItemTemplate>
                                             <div style="  white-space: nowrap;   width: 110px;   overflow: hidden;  text-overflow: ellipsis; ">
                                            <asp:Label ID="lbltoadress" runat="server" Text='<%#Eval("towalletaddress") %>'></asp:Label>
                                                 </div>
                                           <a onclick="copyaddress('<%#Eval("towalletaddress") %>')"> <i class="fa fa-copy"></i></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="ReferenceId">
                                        <ItemTemplate>
                                             <%--<div style="  white-space: nowrap;   width: 110px;   overflow: hidden;  text-overflow: ellipsis; ">--%>
                                            <asp:Label ID="lblreferenceid" runat="server" Text='<%#Eval("referenceid") %>'></asp:Label>
                                                 <%--</div>--%>
                                         <a class="badge badge-primary badge-sm"  onclick="copyaddress('<%#Eval("referenceid") %>')"> <i class="fa fa-copy"></i></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>   
                                   <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>   
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy hh:mm tt}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                   
                                </Columns>
                            </asp:GridView>
                        </div>
</div>
                </div>
            </div>

               <div class="d-none card">
                    <div class="card-header">
                        <h5>Withdrawal(Smart Contract)</h5>
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
                                    <asp:TemplateField HeaderText="Transaction Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblusername" runat="server" Text='<%#Eval("transactionid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("dramount") %>'></asp:Label>
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                     
                                       <asp:TemplateField HeaderText="From Address" ItemStyle-Width="190px">
                                        <ItemTemplate>
                                            <div style="  white-space: nowrap;   width: 110px;   overflow: hidden;  text-overflow: ellipsis; ">
                                            <asp:Label ID="lblfromadress" runat="server" Text='<%#Eval("fromwalletaddress") %>'></asp:Label></div>
                                            <a onclick="copyaddress('<%#Eval("fromwalletaddress") %>')" style="display:inline "> <i class="fa fa-copy"></i></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="To Address">
                                        <ItemTemplate>
                                             <div style="  white-space: nowrap;   width: 110px;   overflow: hidden;  text-overflow: ellipsis; ">
                                            <asp:Label ID="lbltoadress" runat="server" Text='<%#Eval("towalletaddress") %>'></asp:Label>
                                                 </div>
                                           <a onclick="copyaddress('<%#Eval("towalletaddress") %>')"> <i class="fa fa-copy"></i></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ReferenceId">
                                        <ItemTemplate>
                                             <div style="  white-space: nowrap;   width: 110px;   overflow: hidden;  text-overflow: ellipsis; ">
                                            <asp:Label ID="lblreferenceid" runat="server" Text='<%#Eval("referenceid") %>'></asp:Label>
                                                 </div>
                                         <a onclick="copyaddress('<%#Eval("referenceid") %>')"> <i class="fa fa-copy"></i></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>   
                                   <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>   
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("mentiondate","{0:dd/MM/yyyy hh:mm tt}") %>'></asp:Label>
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
     <script>
  function copyaddress(copytext) {
                var element = document.getElementById("ctl00_contentData_lbllinkleft")

                var $temp = $("<input>");
                $("body").append($temp);
                $temp.val(copytext).select();
                document.execCommand("copy");
                $temp.remove();
                // alert('Link Copied');
                toastr.success('Success', 'Copied Successfully');
                return false
            }
     </script>
</asp:Content>

