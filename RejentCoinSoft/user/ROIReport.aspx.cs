using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class admin_UserReport : System.Web.UI.Page
{
    clsAccount objaccount = new clsAccount();
    clsClosing objclosing = new clsClosing();
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                loadtopuptype();
                Session["topentries"] = "50";
                loaduser();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void loadtopuptype()
    {
        objuser.UserId = Session["userid"].ToString();
        ddtopup.Items.Clear();
        DataTable dt = new DataTable();
        dt = objuser.getMyTopup(objuser);
        ddtopup.DataSource = dt;
        ddtopup.DataTextField = "amount2";
        ddtopup.DataValueField = "id";
        ddtopup.DataBind();
        ListItem li = new ListItem("Select Amount", "0");
        ddtopup.Items.Insert(0, li);
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
        objaccount.UserId = Session["userid"].ToString();
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
        objaccount.Id = ddtopup.SelectedValue.ToString();
        objaccount.TopEntries = Session["topentries"].ToString();
        DataTable dt = new DataTable();
        dt = objaccount.getROIDetail2(objaccount);
        GridView1.DataSource = dt;

        double totalMettingCoin = 0;
        double totalMettingAmount = 0;

        foreach (DataRow dr in dt.Rows)
        {
            totalMettingCoin += Convert.ToDouble(dr["amount"]);
            totalMettingAmount += Convert.ToDouble(dr["convertedamount"]);
        }

        GridView1.Columns[0].FooterText = "Total";
        GridView1.Columns[0].FooterStyle.Font.Bold = true;
        //GridView1.Columns[1].FooterText = totalMettingCoin.ToString(); String.Format("{0:0.0000}", 123.456789012);
        GridView1.Columns[2].FooterText = String.Format("{0:0.00}", totalMettingCoin);
        GridView1.Columns[2].FooterStyle.Font.Bold = true;
        //GridView1.Columns[2].FooterText = totalMettingAmount.ToString();
        GridView1.Columns[3].FooterText = String.Format("{0:0.000000}", totalMettingAmount);
        GridView1.Columns[3].FooterStyle.Font.Bold = true;

        GridView1.DataBind();






    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void ViewDetails_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label closedate = (Label)grdrow.Cells[3].FindControl("lbldate");
            string closingDate = closedate.Text;
            DateTime date = DateTime.ParseExact(closingDate, "dd/MM/yyyy", null);
            DataTable dt = new DataTable();
            objaccount.FromDate = Message.GetIndianDate(closingDate);
            objaccount.UserId = Session["userid"].ToString();
            dt = objaccount.getDetailsByClosingDate(objaccount);
            GridView3.DataSource = dt;
            //GridView3.DataBind();

            double totalMettingCoin = 0;
            double totalMettingAmount = 0;

            foreach (DataRow dr in dt.Rows)
            {
                totalMettingCoin += Convert.ToDouble(dr["amount"]);
                totalMettingAmount += Convert.ToDouble(dr["convertedamount"]);
            }

            GridView3.Columns[0].FooterText = "Total";
            GridView3.Columns[0].FooterStyle.Font.Bold = true;
            //GridView3.Columns[1].FooterText = totalMettingCoin.ToString(); String.Format("{0:0.0000}", 123.456789012);
            GridView3.Columns[1].FooterText = String.Format("{0:0.00}", totalMettingCoin);
            GridView3.Columns[1].FooterStyle.Font.Bold = true;
            //GridView3.Columns[2].FooterText = totalMettingAmount.ToString();
            GridView3.Columns[2].FooterText = String.Format("{0:0.000000}", totalMettingAmount);
            GridView3.Columns[2].FooterStyle.Font.Bold = true;

            GridView3.DataBind();

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#divModalPopup').modal('show'); $('#divModalPopup').modal({backdrop: false});</script>", false);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }


}

