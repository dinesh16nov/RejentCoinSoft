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
    clsAccount objaccount = new clsAccount();
    clsClosing objclosing = new clsClosing();
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
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        loaduser();
    }

    void loaduser()
    {
        objaccount.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objaccount.getMyRenewal(objaccount);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //if (dt.Rows.Count > 0)
        //{
        //    GridView1.FooterRow.Cells[0].Text = "Total";
        //    GridView1.FooterRow.Cells[1].Text = dt.Compute("Sum(amount)", "").ToString();
        //    GridView1.FooterRow.Cells[2].Text = dt.Compute("Sum(totalcoin)", "").ToString();
        //    GridView1.FooterRow.Cells[3].Text = dt.Compute("Sum(totalminting)", "").ToString();
        //}
        int ind = 0;
        foreach (GridViewRow r in GridView1.Rows)
        {
            Literal ltimage = (Literal)r.FindControl("ltimage");
            if (ind < GridView1.Rows.Count - 1)
            {
                ltimage.Text = @"<img src=""assets/images/check.png"" style=""height:15px;"">";
            }
            else
            {
                ltimage.Text = @"<img src=""assets/images/cross.png"" style=""height:15px;"">";
            }
            ind++;
        }


    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

}