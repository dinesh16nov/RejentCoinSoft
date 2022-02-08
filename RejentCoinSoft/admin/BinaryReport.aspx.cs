using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;

public partial class admin_BinaryReport : System.Web.UI.Page
{
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rijentadmin45852_4"] != null)
        {
            if (!IsPostBack)
            {
              //  loaddata();
            }
        }
        else
        {
            Server.Transfer("logout.aspx");
        }
    }
    void loaddata()
    {
        if (txtuserid.Text != "")
        {
            //ltiframe.Text = @"<iframe src=""test.aspx?SuperId=" + txtuserid.Text + @""" style=""width:100%;height:700px;""  />";
            f1.Src = "test.aspx?SuperId=" + txtuserid.Text + "";
        }
        else
        {
            Message.Show("Enter User Id...!!!!");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loaddata();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
}