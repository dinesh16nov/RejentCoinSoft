using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_DownlineReport : System.Web.UI.Page
{
    clsState objState = new clsState();
    clsUser objUser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                txtuserid.Text = Session["userid"].ToString();
                txtuserid.Enabled = false;
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void loaduser()
    {
        objUser.UserId = txtuserid.Text;
        objUser.StandingPosition = "";
        objUser.BusinessType = ddbusinesstype.SelectedValue.ToString();
        if (txtfromdate.Text != "")
        {
            objUser.FromDate = Message.GetIndianDate(txtfromdate.Text);
        }
        else
        {
            objUser.FromDate = Convert.ToDateTime("01/01/1900");
        }
        if (txttodate.Text != "")
        {
            objUser.ToDate = Message.GetIndianDate(txttodate.Text);
        }
        else
        {
            objUser.ToDate = Convert.ToDateTime("01/01/1900");
        }

        DataTable dt = new DataTable();
        dt = objUser.getUserDownlineBusiness(objUser);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Session["dtdownlinetemp"] = dt;
        if (dt.Rows.Count > 0)
        {
            lblleftbusiness.Text = dt.Rows[0]["lbusiness"].ToString();
            lblrightbusiness.Text = dt.Rows[0]["rbusiness"].ToString();
            lblleftbusinessRetopup.Text = dt.Rows[0]["lbusinessRetopup"].ToString();
            lblrightbusinessRetopup.Text = dt.Rows[0]["rbusinessRetopup"].ToString();
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loaduser();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = Session["dtdownlinetemp"] as DataTable;
        GridView1.DataBind();
    }
}