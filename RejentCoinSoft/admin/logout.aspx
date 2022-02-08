<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet">  
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/css/bootstrap-datepicker.css" rel="stylesheet">  
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <input  class="form-control" type="text" placeholder="click to show datepicker"  id="example1">
    </div>
    </form>
      <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.js"></script>  
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>  
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.0/js/bootstrap-datepicker.js"></script> 
   <script type="text/javascript">
          // When the document is ready
          $(document).ready(function () {

              $('#example1').datepicker({
                  format: "dd/mm/yyyy"
              });

          });
        </script>
</body>
</html>
