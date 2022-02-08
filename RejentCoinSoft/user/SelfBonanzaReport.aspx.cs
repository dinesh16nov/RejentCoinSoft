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
            
                loaduser();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void loaduser()
    {
        objUser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objUser.getSelfBonanzaAchievementReport(objUser);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //Session["dtdirectdownlinetemp"] = dt;
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
        //GridView1.PageIndex = e.NewPageIndex;
        
        //GridView1.DataSource = Session["dtdirectdownlinetemp"] as DataTable;
        //GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            if (lblstatus.Text == "Not Achieved")
            {
                lblstatus.CssClass = "label label-danger";
            }
            else if (lblstatus.Text == "Achieved")
            {
                lblstatus.CssClass = "label label-success";
            }


        }
    }
}