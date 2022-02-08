<%@ Page Title="" Language="C#" MasterPageFile="~/user/usermaster.master" AutoEventWireup="true" CodeFile="StakingAddAuto.aspx.cs" Inherits="user_StakingAddAuto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <link rel="stylesheet" type="text/css" href="assets/css/jkanban.css">
    <style>
        .kanban-board {
        width:100% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
     <h4 class="page-title">Add Staking</h4>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a></li>
								<li class="breadcrumb-item active" aria-current="page">Add Staking</li>
							</ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="col-12 colorfull-kanban">
        <div class="card">
            <div class="card-header pb-0">
                <h5>Staking</h5>

            </div>
            <div class="card-body kanban-block">
              <div class="row">
              <div class="col-md-7">
                    <div class="row">
                      <div class="col-md-4 text-center">
                        <div class="kanban-block" id="demo2">
                    <div class="kanban-container" >
                        <div data-id="_todo" data-order="1" class="kanban-board" >
                            <header class="kanban-board-header bg-primary">
                                <div class="kanban-title-board text-center"><h4>Plan 1</h4>
                                    <h5>Monthly Mint</h5>

                                </div>
                            </header>
                            <main class="kanban-drag">
                                <div class="kanban-item">
                                         <h2 class="avatar" style="width: 100px;
    height: 100px;
    max-width: 155px;
    max-height: 155px;
    border-radius: 50%;
    overflow: hidden;
    margin-left: auto;
    margin-right: auto;
    border: 7px solid rgba(36, 105, 92, 0.08);
    margin-bottom: 15px;line-height: 85px;
text-align: center;">2%</h2>
                                  
                                    <h6 class="text-center">
                                        Lockin Period <br/>6 Months
                                    </h6>
                                    <asp:TextBox ID="txtstaking1" placeholder="0" CssClass="form-control" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnstaking1" OnClientClick="return validate1();" OnClick="btnstaking1_Click" CssClass="btn btn-primary" runat="server" Text="Staking" />
                                      <br />
                                    <asp:Button ID="btnapprove1" OnClick="btnapprove1_Click" CssClass="btn btn-primary" runat="server" Text="Approve" />
                                        <%--<asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-danger has-ripple" runat="server" Text="Cancel" />--%>

                                </div>
                          
                            </main><footer></footer>
                        </div>
                      
                    </div>
                </div>
                  </div>
                         <div class="col-md-4 text-center">
                        <div class="kanban-block" id="demo2">
                    <div class="kanban-container" >
                        <div data-id="_todo" data-order="1" class="kanban-board" >
                            <header class="kanban-board-header bg-warning">
                                <div class="kanban-title-board text-center"><h4>Plan 2</h4>
                                    <h5>Monthly Mint</h5>

                                </div>
                            </header>
                            <main class="kanban-drag">
                                <div class="kanban-item">
                                         <h2 class="avatar" style="width: 100px;
    height: 100px;
    max-width: 155px;
    max-height: 155px;
    border-radius: 50%;
    overflow: hidden;
    margin-left: auto;
    margin-right: auto;
    border: 7px solid rgba(36, 105, 92, 0.08);
    margin-bottom: 15px;line-height: 85px;
text-align: center;">3%</h2>
                                  
                                    <h6 class="text-center">
                                        Lockin Period <br/>12 Months
                                    </h6>
                                    <asp:TextBox ID="txtstaking2" placeholder="0" CssClass="form-control" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnstaking2" OnClientClick="return validate2();" OnClick="btnstaking2_Click" CssClass="btn btn-warning" runat="server" Text="Staking" /> 
                                    <br />
                                    <asp:Button ID="btnapprove2" OnClick="btnapprove2_Click" CssClass="btn btn-primary" runat="server" Text="Approve" />
                                </div>
                          
                            </main><footer></footer>
                        </div>
                      
                    </div>
                </div>
                  </div>
                         <div class="col-md-4 text-center">
                        <div class="kanban-block" id="demo2">
                    <div class="kanban-container" >
                        <div data-id="_todo" data-order="1" class="kanban-board" >
                            <header class="kanban-board-header bg-danger">
                                <div class="kanban-title-board text-center"><h4>Plan 3</h4>
                                    <h5>Monthly Mint</h5>

                                </div>
                            </header>
                            <main class="kanban-drag">
                                <div class="kanban-item">
                                         <h2 class="avatar" style="width: 100px;
    height: 100px;
    max-width: 155px;
    max-height: 155px;
    border-radius: 50%;
    overflow: hidden;
    margin-left: auto;
    margin-right: auto;
    border: 7px solid rgba(36, 105, 92, 0.08);
    margin-bottom: 15px;line-height: 85px;
text-align: center;">5%</h2>
                                  
                                    <h6 class="text-center">
                                        Lockin Period <br/>24 Months
                                    </h6>
                                    <asp:TextBox ID="txtstaking3" placeholder="0" CssClass="form-control" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnstaking3" OnClientClick="return validate3();" OnClick="btnstaking3_Click" CssClass="btn btn-danger" runat="server" Text="Staking" />
                                     <br />
                                    <asp:Button ID="btnapprove3" OnClick="btnapprove3_Click" CssClass="btn btn-primary" runat="server" Text="Approve" />
                                </div>
                          
                            </main><footer></footer>
                        </div>
                      
                    </div>
                </div>
                  </div>
              </div>
              </div>
                       <div class="col-md-5">
                    <div class="row">
                      <div class="col-md-6 text-center">
                        <div class="kanban-block" id="demo2">
                    <div class="kanban-container" >
                        <div data-id="_todo" data-order="1" class="kanban-board" >
                            <header class="kanban-board-header bg-secondary">
                                <div class="kanban-title-board text-center"><h4>Plan 4</h4>
                                    <h5>Monthly Mint</h5>

                                </div>
                            </header>
                            <main class="kanban-drag">
                                <div class="kanban-item">
                                         <h2 class="avatar" style="width: 100px;
    height: 100px;
    max-width: 155px;
    max-height: 155px;
    border-radius: 50%;
    overflow: hidden;
    margin-left: auto;
    margin-right: auto;
    border: 7px solid rgba(36, 105, 92, 0.08);
    margin-bottom: 15px;line-height: 85px;
text-align: center;">7%</h2>
                                  
                                    <h6 class="text-center">
                                        Lockin Period <br/>36 Months
                                    </h6>
                                    <asp:TextBox ID="txtstaking4" placeholder="0" CssClass="form-control" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnstaking4"  OnClientClick="return validate4();" OnClick="btnstaking4_Click" CssClass="btn btn-secondary" runat="server" Text="Staking" />
                                     <br />
                                    <asp:Button ID="btnapprove4" OnClick="btnapprove4_Click" CssClass="btn btn-primary" runat="server" Text="Approve" />
                                </div>
                          
                            </main><footer></footer>
                        </div>
                      
                    </div>
                </div>
                  </div>
                         <div class="col-md-6 text-center">
                        <div class="kanban-block" id="demo2">
                    <div class="kanban-container" >
                        <div data-id="_todo" data-order="1" class="kanban-board" >
                            <header class="kanban-board-header bg-info">
                                <div class="kanban-title-board text-center"><h4>Plan 5</h4>
                                    <h5>Monthly Mint</h5>

                                </div>
                            </header>
                            <main class="kanban-drag">
                                <div class="kanban-item">
                                         <h2 class="avatar" style="width: 100px;
    height: 100px;
    max-width: 155px;
    max-height: 155px;
    border-radius: 50%;
    overflow: hidden;
    margin-left: auto;
    margin-right: auto;
    border: 7px solid rgba(36, 105, 92, 0.08);
    margin-bottom: 15px;line-height: 85px;
text-align: center;">9%</h2>
                                  
                                    <h6 class="text-center">
                                        Lockin Period <br/>60 Months
                                    </h6>
                                    <asp:TextBox ID="txtstaking5" placeholder="0" CssClass="form-control" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnstaking5" OnClientClick="return validate5();" OnClick="btnstaking5_Click" CssClass="btn btn-info" runat="server" Text="Staking" />
                                     <br />
                                    <asp:Button ID="btnapprove5" OnClick="btnapprove5_Click" CssClass="btn btn-primary" runat="server" Text="Approve" />
                                </div>
                          
                            </main><footer></footer>
                        </div>
                      
                    </div>
                </div>
                  </div>
                    
              </div>
              </div>
              </div>
            </div>
        </div>
        <div class="card">
                   <%-- <div class="card-header">
                        <h5>Previous Staking</h5>
                    </div>--%>
                    <div class="card-body">
                         <div class="  mb-5 h4 text-center ">
   
	 <div class="clam_center">
       Mint = <span id="withdrawable_roi">0 </span>  <button class="btn btn-secondary ml-4" onClick="claimRoi();">CLAIM</button>
     </div>
     </div>
  
  <div class="projict_box projict_table">
		<h4 class="mb-3">Claim</h4>
		<div class="table-responsive">
	      <table class="table tc" id="buHistory" style="color:#bac1c9;">
		   <thead>
			<tr>
			  <th>Sr No</th> 
			  <th>Plan</th>
			  <th>Amount</th>
			  <th>Withdrawn Amount</th>
			  <th>Next Withdraw Date</th>
			  <th>Withdraw</th>
			  
			</tr>
		   </thead>
		 <tbody id="set_kbody">
		 </tbody>
		 
	   </table> 
	    </div>
	       </div>
<%--                        <div class="table-responsive">

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
                              
                                   
                                  <asp:TemplateField HeaderText="Plan">
                                        <ItemTemplate>
                                            <asp:Label ID="lblplanname" runat="server" Text='<%#Eval("planname") %>'></asp:Label>
                                         (   <asp:Label ID="lbltenure" runat="server" Text='<%#Eval("tenure") %>'></asp:Label> Months)
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                     
                                     <asp:TemplateField HeaderText="Hash">
                                        <ItemTemplate>
                                           <a target="_blank" href='https://bscscan.com/tx/<%#Eval("Transactionhash") %>'> <asp:Label ID="lblremark" runat="server" Text='<%#Eval("Transactionhash") %>'></asp:Label><a>
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
                                   
                                </Columns>
                            </asp:GridView>
                        </div>--%>
                </div>
            </div>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentScript" runat="Server">
    <script src="https://cdn.jsdelivr.net/gh/ethereum/web3.js@1.0.0-beta.36/dist/web3.min.js" integrity="sha256-nWBTbvxhJgjslRyuAKJHK+XcZPlCnmIAAMixz6EefVk=" crossorigin="anonymous"></script>
 
  <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.1/moment.min.js" integrity="sha512-qTXRIMyZIFb8iQcfjXWCO8+M5Tbc38Qi5WzdPOYZHIlZpzBHG3L3by84BBBOiRGiEb7KKtAOAs5qYdUiZiQNNQ==" crossorigin="anonymous"></script>
<%--  <script src="ido_test.js?<?php echo time(); ?>"></script>--%>
  
    <script src="ido_test.js"></script>
 
     <script type="text/javascript">
         function validate1() {

             if (document.getElementById("<%=txtstaking1.ClientID%>").value == "") {
                toastr.warning('Warning', 'Enter Amount in Plan 1');
                document.getElementById("<%=txtstaking1.ClientID%>").focus();
                 return false;
             }
         }
         function validate2() {

             if (document.getElementById("<%=txtstaking2.ClientID%>").value == "") {
                  toastr.warning('Warning', 'Enter Amount in Plan 2');
                  document.getElementById("<%=txtstaking2.ClientID%>").focus();
                 return false;
             }
         }
         function validate3() {

             if (document.getElementById("<%=txtstaking3.ClientID%>").value == "") {
                  toastr.warning('Warning', 'Enter Amount in Plan 3');
                  document.getElementById("<%=txtstaking3.ClientID%>").focus();
                 return false;
             }
         }

         function validate4() {

             if (document.getElementById("<%=txtstaking4.ClientID%>").value == "") {
                  toastr.warning('Warning', 'Enter Amount in Plan 4');
                  document.getElementById("<%=txtstaking4.ClientID%>").focus();
                 return false;
             }
         }
         function validate5() {

             if (document.getElementById("<%=txtstaking5.ClientID%>").value == "") {
                  toastr.warning('Warning', 'Enter Amount in Plan 5');
                  document.getElementById("<%=txtstaking5.ClientID%>").focus();
                 return false;
             }
         }
         </script>
     <div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Staking Successfull</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                            <span id="stakingresult"></span>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>

