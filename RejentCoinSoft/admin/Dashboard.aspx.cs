using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;

public partial class admin_Dashboard : System.Web.UI.Page
{
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rijentadmin45852_4"] != null)
        {
            loaddata();
        }
        else
        {
            Server.Transfer("logout.aspx");
        }
    }
    void loaddata()
    {
        DataTable dt = new DataTable();
        dt = objuser.getDashboardAdmin();
        if (dt.Rows.Count > 0)
        {
            lbltotaluser.Text = dt.Rows[0]["totaluser"].ToString();
            lblmonthuser.Text = dt.Rows[0]["MonthUser"].ToString();
            lblweekuser.Text = dt.Rows[0]["WeekUser"].ToString();
            lbltodayuser.Text = dt.Rows[0]["Todayuser"].ToString();
            lblpendingdeposit.Text = dt.Rows[0]["pendingdeposit"].ToString();
            lblpendingwithdrawal.Text = dt.Rows[0]["pendingwithdrawal"].ToString();

            lbltotaldepsit.Text = dt.Rows[0]["totaldeposit"].ToString();
            lbltotalwithdrawal.Text = dt.Rows[0]["totalwithdrawal"].ToString();
            lblbalanceamount.Text = dt.Rows[0]["balanceamount"].ToString();
            lblewalletbalance.Text = dt.Rows[0]["ewalletbalance"].ToString();
            lblcoinbalance.Text = dt.Rows[0]["coinbalance"].ToString();
            lblrijentbalance.Text = dt.Rows[0]["rijentbalance"].ToString();


            lbltodaytopup.Text = dt.Rows[0]["todaytopup"].ToString();
            lbltodaytopupamount.Text = dt.Rows[0]["todaytopupamount"].ToString();
            lbltodayretopupcount.Text = dt.Rows[0]["todayretopup"].ToString();
            lbltodayretopupamount.Text = dt.Rows[0]["todayretopupamount"].ToString();

            lbltodaydeposit.Text = dt.Rows[0]["todaydeposit"].ToString();
            lbltodaydepositamount.Text = dt.Rows[0]["todaydepositamount"].ToString();
            lbltodaywithdrawal.Text = dt.Rows[0]["todaywithdrawal"].ToString();
            lbltodaywithdrawalamount.Text = dt.Rows[0]["todaywithdrawalamount"].ToString();

            lblbinaryincome.Text = dt.Rows[0]["binaryincome"].ToString();
            lbldirectincome.Text = dt.Rows[0]["directincome"].ToString();
            lbllevelincome.Text = dt.Rows[0]["levelincome"].ToString();
            lblmintingincome.Text = dt.Rows[0]["mintingbonus"].ToString();
        }
    }

   
}