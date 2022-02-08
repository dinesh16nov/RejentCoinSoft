<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="User_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <script src="assets/js/jquery-1.8.2.js"></script>
    <script src="assets/js/jquery.tooltip.min.js" type="text/javascript"></script>
    
 <style>
     .label {
    display: inline;
    padding: .2em .6em .3em;
    font-size: 75%;
    font-weight: 700;
    line-height: 1;
    color: #fff;
    text-align: center;
    white-space: nowrap;
    vertical-align: baseline;
    /* border-radius: .25em; */
}
     .label-gold {
    background-color: #F7AB58;
}
.label-diamond {
    background-color: #56A7C6;
}
.label-platinum {
    background-color: #E4806E;
}
     
 </style>
    <script type="text/javascript">

        function InitializeToolTip() {

            $(".gridViewToolTip").tooltip({

                track: true,

                delay: 0,

                showURL: false,

                fade: 100,

                bodyHandler: function () {

                    return $($(this).next().html());

                },

                showURL: false

            });

        }

    </script>

    <script type="text/javascript">

        $(function () {

            InitializeToolTip();

        })

    </script>
    <style>
        .container {
    margin: 40px;
}
    </style>
    <link href="popover/bootstrap.min.css" rel="stylesheet" />
  
</head>
<body>
    <form id="form1" runat="server">
        <div>
       <%--   <div class="container">
    <a id="popOver" class="showpopover" href="#" data-content="Popover with data-trigger" rel="popover" data-placement="bottom" data-original-title="Title" data-trigger="hover">Popover with data-trigger</a>    
</div>--%>
        </div>

        <table style="width: 100%">
            <tr>
                <td style="text-align: center;" colspan="8">
                    <%--<img src="img/0.png" style="height:70px;" />--%>
                  
                    <div style=" margin: auto;height:80px;width:80px;border-radius:40px;border:5px solid gainsboro;overflow:hidden;text-align:center;">
                    <asp:Literal ID="ltuser1" runat="server"></asp:Literal>
                      
                        </div>
                        <div id="Div1" style="display: none;">
                        <table style="width:100%;">
                            <tr>
                                <td style="white-space: nowrap;">
                                    <b>L:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblleftid1" runat="server" Text="Label"></asp:Label>
                                </td> 
                                  <td style="white-space: nowrap;">
                                    <b>R:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblrightid1" runat="server" Text="Label"></asp:Label>
                                </td>
                                   <td style="white-space: nowrap;">
                                    <b>Total Pair:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbltotalid1" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <asp:Label ID="lbluserid1" runat="server" Text=""></asp:Label><br/><asp:Label ID="lblusername1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="8">
                    <img src="img/band1.gif" />
                </td>
            </tr>
            <tr>

                <td style="text-align: center;" colspan="4">
                     <div style=" margin: auto;height:80px;width:80px;border-radius:40px;border:5px solid gainsboro;overflow:hidden;text-align:center;">
                    
                    <asp:Literal ID="ltuser2" runat="server"></asp:Literal>
                         </div>
                              <div id="Div3" style="display: none;">
                        <table style="width:100%;">
                            <tr>
                                 <td style="white-space: nowrap;">
                                    <b>L:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblleftid2" runat="server" Text="Label"></asp:Label>
                                </td>
                                  <td style="white-space: nowrap;">
                                    <b>R:</b>&nbsp;
                                </td>
                               
                                <td>
                                    <asp:Label ID="lblrightid2" runat="server" Text="Label"></asp:Label>
                                </td>
                                 <td style="white-space: nowrap;">
                                    <b>Total Pair:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbltotalid2" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                         

                        </table>

                    </div>
                    <br />
                    <asp:Label ID="lbluserid2" runat="server" Text=""></asp:Label><br/><asp:Label ID="lblusername2" runat="server" Text=""></asp:Label>

                    


      
                </td>
                <td style="text-align: center;" colspan="4">
                  <div style=" margin: auto;height:80px;width:80px;border-radius:40px;border:5px solid gainsboro;overflow:hidden;text-align:center;">
                       <asp:Literal ID="ltuser3" runat="server"></asp:Literal>
                      </div>
                          <div id="Div2" style="display: none;">
                        <table style="width:100%;">                        
                            <tr>
                                 <td style="white-space: nowrap;">
                                    <b>L:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblleftid3" runat="server" Text="Label"></asp:Label>
                                </td>
                                  <td style="white-space: nowrap;">
                                    <b>R:</b>&nbsp;
                                </td>
                                 <td>
                                    <asp:Label ID="lblrightid3" runat="server" Text="Label"></asp:Label>
                                </td> 
                                 <td style="white-space: nowrap;">
                                    <b>Total Pair:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbltotalid3" runat="server" Text="Label"></asp:Label>
                                </td>                              
                            </tr>                       
                        </table>
                    </div>
                    <br />
                    <asp:Label ID="lbluserid3" runat="server" Text=""></asp:Label><br/><asp:Label ID="lblusername3" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>

                <td style="text-align: center;" colspan="4">
                    <img src="img/band2.gif" />
                </td>
                <td style="text-align: center;" colspan="4">
                    <img src="img/band2.gif" />
                </td>
            </tr>

            <tr>

                <td style="text-align: center;" colspan="2">
                   <div style=" margin: auto;height:80px;width:80px;border-radius:40px;border:5px solid gainsboro;overflow:hidden;text-align:center;">
                      <asp:Literal ID="ltuser4" runat="server"></asp:Literal>
                     </div>
                         <div id="Div4" style="display: none;">

                        <table style="width:100%;">
                         
                           <tr>
                                 <td style="white-space: nowrap;">
                                    <b>L:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblleftid4" runat="server" Text="Label"></asp:Label>
                                </td>
                                  <td style="white-space: nowrap;">
                                    <b>R:</b>&nbsp;
                                </td>
                                 <td>
                                    <asp:Label ID="lblrightid4" runat="server" Text="Label"></asp:Label>
                                </td> 
                                <td style="white-space: nowrap;">
                                    <b>Total Pair:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbltotalid4" runat="server" Text="Label"></asp:Label>
                                </td>                              
                            </tr>
                         
                        </table>

                    </div>
                    <br />
                    <asp:Label ID="lbluserid4" runat="server" Text=""></asp:Label><br/><asp:Label ID="lblusername4" runat="server" Text=""></asp:Label>

                </td>
                <td style="text-align: center;" colspan="2">
                     <div style=" margin: auto;height:80px;width:80px;border-radius:40px;border:5px solid gainsboro;overflow:hidden;text-align:center;">
                    
                    <asp:Literal ID="ltuser5" runat="server"></asp:Literal>
                     </div>
                           <div id="Div5" style="display: none;">

                        <table style="width:100%;">     
                              <tr>
                                 <td style="white-space: nowrap;">
                                    <b>L:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblleftid5" runat="server" Text="0"></asp:Label>
                                </td>
                                  <td style="white-space: nowrap;">
                                    <b>R:</b>&nbsp;
                                </td>
                                 <td>
                                    <asp:Label ID="lblrightid5" runat="server" Text="0"></asp:Label>
                                </td> 
                                   <td style="white-space: nowrap;">
                                    <b>Total Pair:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbltotalid5" runat="server" Text="0"></asp:Label>
                                </td>                              
                            </tr>

                        </table>

                    </div>
                    <br />
                    <asp:Label ID="lbluserid5" runat="server" Text=""></asp:Label><br/><asp:Label ID="lblusername5" runat="server" Text=""></asp:Label>

                </td>
                <td style="text-align: center;" colspan="2">
                     <div style=" margin: auto;height:80px;width:80px;border-radius:40px;border:5px solid gainsboro;overflow:hidden;text-align:center;">
                    
                    <asp:Literal ID="ltuser6" runat="server"></asp:Literal>
                   </div>
                             <div id="Div6" style="display: none;">

                        <table style="width:100%;">
                           <tr>
                                 <td style="white-space: nowrap;">
                                    <b>L:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblleftid6" runat="server" Text="0"></asp:Label>
                                </td>
                                  <td style="white-space: nowrap;">
                                    <b>R:</b>&nbsp;
                                </td>
                                 <td>
                                    <asp:Label ID="lblrightid6" runat="server" Text="0"></asp:Label>
                                </td> 
                                <td style="white-space: nowrap;">
                                    <b>Total Pair:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbltotalid6" runat="server" Text="Label"></asp:Label>
                                </td>                              
                            </tr>
                        </table>

                    </div>
                    <br />
                    <asp:Label ID="lbluserid6" runat="server" Text=""></asp:Label><br/><asp:Label ID="lblusername6" runat="server" Text=""></asp:Label>


                </td>
                <td style="text-align: center;" colspan="2">
                     <div style=" margin: auto;height:80px;width:80px;border-radius:40px;border:5px solid gainsboro;overflow:hidden;text-align:center;">
                    
                    <asp:Literal ID="ltuser7" runat="server"></asp:Literal>
                         </div>
                       <div id="Div7" style="display: none;">

                        <table style="width:100%;">
                             <tr>
                                 <td style="white-space: nowrap;">
                                    <b>L:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblleftid7" runat="server" Text="Label"></asp:Label>
                                </td>
                                  <td style="white-space: nowrap;">
                                    <b>R:</b>&nbsp;
                                </td>
                                 <td>
                                    <asp:Label ID="lblrightid7" runat="server" Text="Label"></asp:Label>
                                </td>  
                                  <td style="white-space: nowrap;">
                                    <b>Total Pair:</b>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lbltotalid7" runat="server" Text="Label"></asp:Label>
                                </td>                             
                            </tr>
                        </table>

                    </div>
                    <br />
                    <asp:Label ID="lbluserid7" runat="server" Text=""></asp:Label><br/><asp:Label ID="lblusername7" runat="server" Text=""></asp:Label>

                </td>
            </tr>
            <tr>
                <td style="text-align: center;">&nbsp;</td>
                <td style="text-align: center;">&nbsp;</td>
                <td style="text-align: center;">&nbsp;</td>
                <td style="text-align: center;">&nbsp;</td>
                <td style="text-align: center;">&nbsp;</td>
                <td style="text-align: center;">&nbsp;</td>
                <td style="text-align: center;">&nbsp;</td>
                <td style="text-align: center;">&nbsp;</td>
                  <asp:Label ID="lbluserid1new" visible="false" runat="server" Text=""></asp:Label>
                  <asp:Label ID="lbluserid2new" visible="false" runat="server" Text=""></asp:Label>
                  <asp:Label ID="lbluserid3new" visible="false" runat="server" Text=""></asp:Label>
                  <asp:Label ID="lbluserid4new" visible="false" runat="server" Text=""></asp:Label>
                  <asp:Label ID="lbluserid5new" visible="false" runat="server" Text=""></asp:Label>
                  <asp:Label ID="lbluserid6new" visible="false" runat="server" Text=""></asp:Label>
                  <asp:Label ID="lbluserid7new" visible="false" runat="server" Text=""></asp:Label>
            </tr>
        </table>

          <script src="popover/bootstrap.min.js"></script>
    <script>
        $('.showpopover').popover();
    </script>
    </form>
</body>
</html>
