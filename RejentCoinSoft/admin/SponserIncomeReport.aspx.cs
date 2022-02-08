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
    clsUser objUser = new clsUser();
    clsBank objbank = new clsBank();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
                loadclosingperiod();
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
    void loadclosingperiod()
    {
        ddclosingperiod.Items.Clear();
        DataTable dt = new DataTable();
        dt = objclosing.getClosingPeriod();

        ddclosingperiod.DataSource = dt;
        ddclosingperiod.DataTextField = "closingperiod";
        ddclosingperiod.DataValueField = "id";
        ddclosingperiod.DataBind();
        ListItem li = new ListItem("Select Closing Period", "0");
        ddclosingperiod.Items.Insert(0, li);
    }
    void loaduser()
    {

        objaccount.UserId = txtuserid.Text;
        string[] arr = ddclosingperiod.SelectedItem.ToString().Split('-');
        objaccount.FromDate = Message.GetIndianDate(arr[0].ToString());
        objaccount.ToDate = Message.GetIndianDate(arr[1].ToString());
        DataTable dt = new DataTable();
        dt = objaccount.getSponserIncome(objaccount);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    void loadbank()
    {
        ddbank.Items.Clear();
        DataTable dt = new DataTable();
        dt = objbank.getBank();
        ddbank.DataSource = dt;
        ddbank.DataTextField = "BankName";
        ddbank.DataValueField = "BankID";
        ddbank.DataBind();
        ListItem li = new ListItem("Select Bank", "0");
        ddbank.Items.Insert(0, li);
    }
    void loaddata(string userid)
    {
        objUser.UserId = userid;
        DataTable dt = new DataTable();
        dt = objUser.getUserDetail(objUser);
        if (dt.Rows.Count > 0)
        {
            loadbank();
            txtuseridedit.Text = dt.Rows[0]["userid"].ToString();
            txtusernameedit.Text = dt.Rows[0]["username"].ToString();
            txtaccountholdername.Text = dt.Rows[0]["accountholdername"].ToString(); ;
            txtaccountno.Text = dt.Rows[0]["accountno"].ToString(); ;
            txtpan.Text = dt.Rows[0]["pannumber"].ToString(); ;
            txtifsccode.Text = dt.Rows[0]["ifsccode"].ToString(); ;
            txtbranchname.Text = dt.Rows[0]["branchname"].ToString(); ;
            ddbank.SelectedValue = dt.Rows[0]["bankname"].ToString(); ;
            txtpaytmmobileno.Text = dt.Rows[0]["PaytmMobileNo"].ToString();
        }
    }
    protected void lbView_Click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        Label lbluserid = (Label)gvRow.FindControl("lbluserid");
        loaddata(lbluserid.Text);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);

    }
    protected void btnApprove_click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        Label lbluserid = (Label)gvRow.FindControl("lbluserid");
        Label lblfromdate = (Label)gvRow.FindControl("lblfromdate");
        Label lbltodate = (Label)gvRow.FindControl("lbltodate");
        TextBox txttransactionid = (TextBox)gvRow.FindControl("txttransactionid");
        DropDownList ddmode = (DropDownList)gvRow.FindControl("ddmode");
        objaccount.PaymentMode = ddmode.SelectedValue.ToString();
        objaccount.OnlineTransactionId = txttransactionid.Text;
        objaccount.UserId = lbluserid.Text;
        objaccount.FromDate = Message.GetIndianDate(lblfromdate.Text);
        objaccount.ToDate = Message.GetIndianDate(lbltodate.Text);
        objaccount.Pay_SponserIncome(objaccount);
        loaduser();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            Label lbltransactionid = (Label)e.Row.FindControl("lbltransactionid");
            TextBox txttransactionid = (TextBox)e.Row.FindControl("txttransactionid");
            DropDownList ddmode = (DropDownList)e.Row.FindControl("ddmode");
            LinkButton btnApprove = (LinkButton)e.Row.FindControl("btnApprove");
            if (lblstatus.Text == "Unpaid")
            {
                lblstatus.CssClass = "label label-warning";
                btnApprove.Visible = true;
                ddmode.Visible = true;
                txttransactionid.Visible = true;
                lbltransactionid.Visible = false;
            }
            else
                if (lblstatus.Text == "Paid")
                {
                    lblstatus.CssClass = "label label-success";
                    btnApprove.Visible = false;
                    ddmode.Visible = false;
                    txttransactionid.Visible = false;
                    lbltransactionid.Visible = true;
                }

        }
    }
}