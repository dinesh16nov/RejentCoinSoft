using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class admin_UserReport : System.Web.UI.Page
{
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
              
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }

  

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loaduser();
    }
    void loaduser()
    {

        if (txtfromdate.Text != "")
        {
            objuser.FromDate = Message.GetIndianDate(txtfromdate.Text);
        }
        else
        {
            objuser.FromDate = DateTime.MinValue;
        }
        if (txttodate.Text != "")
        {
            objuser.ToDate = Message.GetIndianDate(txttodate.Text);
        }
        else
        {
            objuser.ToDate = DateTime.MinValue;
        }

        DataTable dt = new DataTable();
        dt = objuser.getContactRequestReport(objuser);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
  
   
}