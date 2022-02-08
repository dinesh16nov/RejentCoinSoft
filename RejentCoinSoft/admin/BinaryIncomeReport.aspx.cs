using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class admin_UserReport : System.Web.UI.Page
{
    clsAccount objaccount = new clsAccount();
    clsClosing objclosing = new clsClosing();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
                Session["topentries"] = "50";
                loaduser();

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
        Session["topentries"] = "99999999";
        loaduser();
    }
  
    void loaduser()
    {

        objaccount.UserId = txtuserid.Text;
        if (txtfromdate.Text != "")
        {
            objaccount.FromDate = Message.GetIndianDate(txtfromdate.Text);
        }
        else
        {
            objaccount.FromDate = DateTime.MinValue;
        }
        if (txttodate.Text != "")
        {
            objaccount.ToDate = Message.GetIndianDate(txttodate.Text);
        }
        else
        {
            objaccount.ToDate = DateTime.MinValue;
        }
        objaccount.TopEntries = Session["topentries"].ToString();
        DataTable dt = new DataTable();
        dt = objaccount.getBinaryIncome(objaccount);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
}