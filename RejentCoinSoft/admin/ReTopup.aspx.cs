using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Retopup : System.Web.UI.Page
{
    clsState objState = new clsState();
    clsBonanza objbonanza = new clsBonanza();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
                loadTopupList();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void loadTopupList()
    {
        DataTable dt = new DataTable();
        dt = objbonanza.GetTopupList(objbonanza);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}