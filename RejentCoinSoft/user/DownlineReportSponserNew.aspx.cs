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

                loadlevel();
                loaduser();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void loadlevel()
    {
        objUser.UserId = txtuserid.Text;
        ddlevel.Items.Clear();
        DataTable dt = new DataTable();
        dt = objUser.getLevel(objUser);
        ddlevel.DataSource = dt;
        ddlevel.DataTextField = "Levelno";
        ddlevel.DataValueField = "levelno";
        ddlevel.DataBind();
        //ListItem li = new ListItem("Select Level", "0");
        //ddlevel.Items.Insert(0, li);
    }
    void loaduser()
    {
        objUser.UserId = txtuserid.Text;
        objUser.LevelNo = ddlevel.SelectedValue.ToString();
        objUser.Status = ddstatus.SelectedValue.ToString();
        DataTable dt = new DataTable();
        dt = objUser.getUserLevelReport(objUser);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Session["dtdownlinetemp"] = dt;
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            if (lblstatus.Text == "0")
            {
                lblstatus.Text = "Not Activated";
                lblstatus.CssClass = "label label-danger";
            }
            else if (lblstatus.Text == "1")
            {
                lblstatus.Text = "Activated";
                lblstatus.CssClass = "label label-success";
            }


        }
    }
}