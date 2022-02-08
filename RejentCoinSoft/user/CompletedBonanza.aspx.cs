using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_CompleteBonanza : System.Web.UI.Page
{
    clsState objState = new clsState();
    clsUser objUser = new clsUser();
    clsBonanza objBonanza = new clsBonanza();
    public string UserID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                UserID = Session["userid"].ToString();
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

        objBonanza.Test = DateTime.Now.ToString("M/d/yyyy");
        objBonanza.Test1 = DateTime.Now.Date.ToString();

        objBonanza.UserID = UserID;
        DataTable dt = new DataTable();
        dt = objBonanza.GetUserwiseBonanza(objBonanza);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loaduser();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}