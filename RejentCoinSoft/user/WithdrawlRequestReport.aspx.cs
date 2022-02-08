using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using BusinessLogicTier;
public partial class admin_UserReport : System.Web.UI.Page
{
    clsAccount objaccount = new clsAccount();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (!IsPostBack)
            {
                loadgethelp();

            }
        }
        else
        {
            Server.Transfer("logout.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loadgethelp();
    }
    void loadgethelp()
    {
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            objaccount.FromDate = Message.GetIndianDate(txtfromdate.Text);
            objaccount.ToDate = Message.GetIndianDate(txttodate.Text);
        }
        else
        {
            objaccount.FromDate = DateTime.MinValue;
            objaccount.ToDate = DateTime.MinValue;
        }
        objaccount.WithdrawlRequestStatus = ddstatus.SelectedValue.ToString();
        DataTable dt = new DataTable();
        objaccount.UserId = Session["userid"].ToString();
        dt = objaccount.getWithdrawlRequest(objaccount);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void grdGetHelp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            if (lblstatus.Text == "Pending")
            {
                lblstatus.Text = "Pending";
                lblstatus.CssClass = "badge badge-warning";
            }
            else
                if (lblstatus.Text == "Approved")
                {
                    lblstatus.Text = "Approved";
                    lblstatus.CssClass = "badge badge-success";
                }
                else

                    if (lblstatus.Text == "Rejected")
                    {
                        lblstatus.Text = "Rejected";
                        lblstatus.CssClass = "badge badge-danger";
                    }
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
}