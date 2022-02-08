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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                txtuserid.Text = Session["userid"].ToString();
                txtuserid.Enabled = false;
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
        objaccount.UserId = txtuserid.Text;
        objaccount.TopEntries = Session["topentries"].ToString();
        DataTable dt = new DataTable();
        dt = objaccount.getSmartContractWithdrawal(objaccount);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            if (lblstatus.Text == "Pending" || lblstatus.Text == "Requested")
            {
                //lblstatus.Text = "Pending";
                lblstatus.CssClass = "badge badge-warning";
            }
            else if (lblstatus.Text == "Processing")
            {
                lblstatus.Text = "Processing";
                lblstatus.CssClass = "badge badge-info";
            }
            else
                if (lblstatus.Text == "Approved" || lblstatus.Text == "true")
            {
                lblstatus.Text = "Success";
                lblstatus.CssClass = "badge badge-success";
            }
            else

                    if (lblstatus.Text == "Cancelled" || lblstatus.Text == "false")
            {
                lblstatus.Text = "failed";
                lblstatus.CssClass = "badge badge-danger";
            }
        }
    }
}