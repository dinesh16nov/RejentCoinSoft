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
            if (Session["userid"] != null)
            {
               
                txtuserid.Text = Session["userid"].ToString();
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

        double RightBisness = 0;
        double LeftBisness = 0;
        double MatchingBusiness = 0;
        double Amount = 0;

        foreach (DataRow dr in dt.Rows)
        {
            LeftBisness += Convert.ToDouble(dr["leftbusiness"]);
            RightBisness += Convert.ToDouble(dr["RightBusiness"]);
            MatchingBusiness += Convert.ToDouble(dr["matchingbusiness"]);
            Amount += Convert.ToDouble(dr["income"]);
        }

        GridView1.Columns[0].FooterText = "Total";
        GridView1.Columns[0].FooterStyle.Font.Bold = true;
        GridView1.Columns[2].FooterText = String.Format("{0:0.00}", LeftBisness);
        GridView1.Columns[2].FooterStyle.Font.Bold = true;
        GridView1.Columns[3].FooterText = String.Format("{0:0.00}", RightBisness);
        GridView1.Columns[3].FooterStyle.Font.Bold = true;
        GridView1.Columns[4].FooterText = String.Format("{0:0.00}", MatchingBusiness);
        GridView1.Columns[4].FooterStyle.Font.Bold = true;
        GridView1.Columns[5].FooterText = String.Format("{0:0.00}", Amount);
        GridView1.Columns[5].FooterStyle.Font.Bold = true;
        GridView1.DataBind();
        //if (dt.Rows.Count == 0)
        //{
        //    Message.Show("No Record Found");
        //}
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
}