using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_adminmaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rijentadmin45852_4"] == null)
            Server.Transfer("logout.aspx");

        else
        {
           
            //Response.ClearHeaders();
            //Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            //Response.AddHeader("Pragma", "no-cache");
        }
    }
}
