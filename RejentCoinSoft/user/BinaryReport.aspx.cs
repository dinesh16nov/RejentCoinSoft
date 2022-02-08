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
        if (HttpContext.Current.Session["userid"] != null)
        {
            if (!IsPostBack)
            {
                txtuserid.Text = HttpContext.Current.Session["userid"].ToString();
                loaddata();
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

    protected void txtuserid_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        objuser.UserId = txtuserid.Text;
        objuser.SponserId = Session["userid"].ToString();
        dt = objuser.getUserNameDownline(objuser);
        if (dt.Rows.Count > 0)
        {
            txtuserid.Text = dt.Rows[0]["userid"].ToString();
        }
        else
        {
            Message.Show("Invalid User id");
            txtuserid.Text = "";
        }
    }
}