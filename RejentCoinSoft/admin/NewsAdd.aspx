<%@ Page Title="Add News" Language="C#" MasterPageFile="adminmaster.master" AutoEventWireup="true" CodeFile="NewsAdd.aspx.cs" Inherits="blue_Dashboard" EnableEventValidation="false" ValidateRequest="false"  MaintainScrollPositionOnPostBack = "true"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
          <script type="text/javascript" src="../AdminAssets/tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
<script type="text/javascript">
    tinyMCE.init({
        mode: "textareas",
        theme: "advanced",
        plugins: "safari,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,imagemanager,filemanager",
        theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
        theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,insertdate,inserttime,preview,|,forecolor,backcolor",
        theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
        theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
        theme_advanced_toolbar_location: "top",
        theme_advanced_toolbar_align: "left",
        theme_advanced_statusbar_location: "bottom",
        theme_advanced_resizing: false,
        template_external_list_url: "js/template_list.js",
        external_link_list_url: "js/link_list.js",
        external_image_list_url: "js/image_list.js",
        media_external_list_url: "js/media_list.js"
    });




</script>
       <style>
     table.mceLayout, textarea.tinyMCE {
    width: 100% !important;
}

.mceToolbar td {
    display:table-row;
    float: left;
}
.mceToolbar td:nth-of-type(11){
    clear: left;
}

@media only screen and (min-width: 600px) {
    table.mceLayout, textarea.richEditor {
       width: 600px !important;
    }
    
    .mceToolbar td {
        display:table-cell;
        float: none;
    }
    mceToolbar td:nth-of-type(11){
        clear: none;
    }
}

table.mceLayout, textarea.tinyMCE {width:100%!important;}

/* make the toolbar wrap */
.mceToolbar td {
    display:table-row;
    float: left;
}
.mceToolbar td:nth-of-type(11){
    clear: left;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="Server">
    <h4 class="page-title">Add News</h4>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="Dashboard.aspx">Dashboard</a></li>
        <li class="breadcrumb-item active">Add News</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentData" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- end row -->
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
   

    <!-- end row -->
    <div class="row">
        <div class="col-xl-12">
            <div class="card">
                <div class="card-header">
                      <strong>Add News</strong>
                </div>
                <div class="card-body">
                  
                    <div class="row form-group">
                              <div class="col-md-2">News</div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtnews" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                        <%--<textarea id="txtnews" runat="server" class="form-control" ></textarea>--%>
                                    </div>
                    </div>
                       <div class="row rowfooter">
                        <div class="col-md-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" OnClick="btnSubmit_Click"  Text="Submit" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" OnClick="btnCancel_Click" Text="Cancel" />
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>

    </div>
      <div class="row">
        <div class="col-xl-12">
            <div class="card">
                <div class="card-header">
                     <strong>News List</strong>
                </div>
                <div class="card-body">
                   
                    <div class="row">
                        <div class="col-md-12">
                          <div class="table-responsive">
                       <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:Label ID="lblstatus" runat="server" Visible="false" Text='<%#Eval("status") %>'></asp:Label>
                                            <asp:Label ID="lblid" runat="server" Visible="false" Text='<%#Eval("newsid") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="News">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnews" runat="server" Text='<%#Eval("newsdetail") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <%--<asp:Label ID="lblisactive2" runat="server" Text='<%# Eval("isactive2") %>'></asp:Label>--%>
                                        <label class="switch2">
 <asp:CheckBox ID="chkActive" runat="server" AutoPostBack="true" OnCheckedChanged="chkActive_CheckedChanged" Checked="true" />
  <span class="slider round"></span>
</label>
                                  
                                </ItemTemplate>
                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                         <asp:LinkButton ID="LinkButton1" CssClass="btn btn-warning btn-sm" CommandName="myedit" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="icon fa fa-edit" aria-hidden="true"></i></asp:LinkButton>
                                            <span onclick="return confirm_click();">
                                                <asp:LinkButton ID="lbEdit" CommandName="mydel" CssClass="btn btn-danger btn-sm" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server"><i class="icon fa fa-trash" aria-hidden="true"></i></asp:LinkButton>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        </div>
                        
                    </div>
                     
                </div>
            </div>
        </div>

    </div>
                 </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="btnSubmit" />
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
                            <h4 class="modal-title">Edit News Details</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                News
                            <asp:Label ID="lblnewsid" Visible="false" runat="server" Text=""></asp:Label>

                                <asp:TextBox runat="server" class="form-control" ID="txtnewsedit" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update"  CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                             <button type="button" class="btn btn-danger" data-bs-dismiss="modal" aria-label="Close">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
          <Triggers>
             <asp:PostBackTrigger ControlID="btnUpdate" />
         </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        <%--function validate() {
            // alert('sd');
            if (document.getElementById("<%=txtnews.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter News');
                // alert("Enter Rank No"); 
                document.getElementById("<%=txtnews.ClientID%>").focus();
                return false;
            }
        }
        function validate2() {
            // alert('sd');
            if (document.getElementById("<%=txtnewsedit.ClientID%>").value == "") {

                toastr.warning('Warning', 'Enter News');
                // alert("Enter Rank No"); 
                document.getElementById("<%=txtnewsedit.ClientID%>").focus();
                   return false;
               }
           }--%>
    </script>

    <script type="text/javascript">
        function showModal() {
            //$('#myModal').modal({ backdrop: 'static', keyboard: false })
            $('#myModal').modal('show');
        }
        function Closepopup() {
            $('#myModal').modal('hide');
            $('body').removeClass('modal-open');  $("body").removeAttr("style");
            $('body').css('padding-right', '0');
            $('.modal-backdrop').remove();
        }
    </script>
      <script type="text/javascript">
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_endRequest(function () {
                createCarousel();
            });

            function createCarousel() {

                tinyMCE.init({
                    mode: "textareas",
                    theme: "advanced",
                    plugins: "safari,spellchecker,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,imagemanager,filemanager",
                    theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
                    theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,insertdate,inserttime,preview,|,forecolor,backcolor",
                    theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
                    theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
                    theme_advanced_toolbar_location: "top",
                    theme_advanced_toolbar_align: "left",
                    theme_advanced_statusbar_location: "bottom",
                    theme_advanced_resizing: false,
                    template_external_list_url: "js/template_list.js",
                    external_link_list_url: "js/link_list.js",
                    external_image_list_url: "js/image_list.js",
                    media_external_list_url: "js/media_list.js"
                });
            }
</script>
   
</asp:Content>

