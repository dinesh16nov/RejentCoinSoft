using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using BusinessLogicTier;
using System.IO;
using System.Drawing;

public partial class admin_UserReport : System.Web.UI.Page
{
    clsAccount objaccount = new clsAccount();
    clsUser objUser = new clsUser();
    clsBank objbank = new clsBank();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rijentadmin45852_4"] != null)
        {
            if (!IsPostBack)
            {
                loadgethelp();

            }
        }
        else
        {
            Server.Transfer("logout.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loadgethelp();
    }
    void loadgethelp()
    {
        if (txtfromdate.Text != "" && txttodate.Text != "")
        {
            objaccount.FromDate = Message.GetIndianDate(txtfromdate.Text);
            objaccount.ToDate = Message.GetIndianDate(txttodate.Text);
        }
        else
        {
            objaccount.FromDate = DateTime.MinValue;
            objaccount.ToDate = DateTime.MinValue;
        }
        objaccount.WithdrawlRequestStatus = ddstatus.SelectedValue.ToString();
        DataTable dt = new DataTable();
        objaccount.UserId = txtuserid.Text;
        dt = objaccount.getWithdrawlRequest(objaccount);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void grdGetHelp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            Label lbltransactionid=(Label)e.Row.FindControl("lbltransactionid");
            TextBox txttransactionid = (TextBox)e.Row.FindControl("txttransactionid");
            //DropDownList ddmode = (DropDownList)e.Row.FindControl("ddmode");
            LinkButton btnApprove = (LinkButton)e.Row.FindControl("btnApprove");
            LinkButton btnReject = (LinkButton)e.Row.FindControl("btnReject");
            if (lblstatus.Text == "Pending")
            {
                lblstatus.Text = "Pending";
                lblstatus.CssClass = "label label-warning";
                btnApprove.Visible = true;
                btnReject.Visible = true;
                //ddmode.Visible = true;
                txttransactionid.Visible = true;
                lbltransactionid.Visible = false;
            }
            else
                if (lblstatus.Text == "Approved")
                {
                    lblstatus.Text = "Approved";
                    lblstatus.CssClass = "label label-success";
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                    //ddmode.Visible = false;
                    txttransactionid.Visible = false;
                    lbltransactionid.Visible = true;
                }
                else

                    if (lblstatus.Text == "Rejected")
                    {
                        lblstatus.Text = "Rejected";
                        lblstatus.CssClass = "label label-danger";
                        btnApprove.Visible = false;
                        btnReject.Visible = false;
                        //ddmode.Visible = false;
                        txttransactionid.Visible = false;
                        lbltransactionid.Visible = false;
                    }

        }
    }
    protected void btnApprove_click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        Label lblgalleryid = (Label)gvRow.FindControl("lblId");
        Label lblamount = (Label)gvRow.FindControl("lblamount");
        Label lbluserid = (Label)gvRow.FindControl("lbluserid");
        Label lblId = (Label)gvRow.FindControl("lblId");
        TextBox txttransactionid = (TextBox)gvRow.FindControl("txttransactionid");
        //DropDownList ddpaymentmode = (DropDownList)gvRow.FindControl("ddmode");
        objaccount.Id = lblId.Text;
        objaccount.UserId = lbluserid.Text;
        objaccount.WithdrawlAmount = Convert.ToDecimal( lblamount.Text);
     
        objaccount.PaymentMode = "";
        objaccount.WithdrawlRequestId = lblgalleryid.Text;
        objaccount.MentionBy = Session["rijentadmin45852_4"].ToString();
        objaccount.OnlineTransactionId = txttransactionid.Text;
        objaccount.Approve_WithdrawlRequest(objaccount);
        loadgethelp();
    }
    protected void btnReject_click(object sender, EventArgs e)
    {
        GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
        Label lblgalleryid = (Label)gvRow.FindControl("lblId");
        objaccount.Id = lblgalleryid.Text;
        objaccount.MentionBy = Session["rijentadmin45852_4"].ToString();
        objaccount.Reject_WithdrawlRequest(objaccount);
        loadgethelp();
       
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
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
    protected void chckchanged(object sender, EventArgs e)
    {
        CheckBox chckheader = (CheckBox)GridView1.HeaderRow.FindControl("CheckBox1");
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chckrw = (CheckBox)row.FindControl("CheckBox2");
            if (chckheader.Checked == true)
            {
                chckrw.Checked = true;
            }
            else
            {
                chckrw.Checked = false;
            }
        }
    }
    protected void btnPayAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in GridView1.Rows)
        {
            CheckBox CheckBox2 = (CheckBox)r.FindControl("CheckBox2");
            if (CheckBox2.Checked == true)
            {
                Label lblgalleryid = (Label)r.FindControl("lblId");
                Label lblamount = (Label)r.FindControl("lblamount");
                Label lbluserid = (Label)r.FindControl("lbluserid");
                TextBox txttransactionid = (TextBox)r.FindControl("txttransactionid");
                DropDownList ddpaymentmode = (DropDownList)r.FindControl("ddmode");
                objaccount.UserId = lbluserid.Text;
                objaccount.WithdrawlAmount = Convert.ToDecimal(lblamount.Text);

                objaccount.PaymentMode = ddpaymentmode.SelectedValue.ToString();
                objaccount.WithdrawlRequestId = lblgalleryid.Text;
                objaccount.MentionBy = Session["rijentadmin45852_4"].ToString();
                objaccount.OnlineTransactionId = txttransactionid.Text;
                objaccount.Approve_WithdrawlRequest(objaccount);
            }
        }
        Message.Show("Withdrawal Request Approved Successfully.");
        loadgethelp();
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=withdrawalrequest.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //To Export all pages
            GridView1.AllowPaging = false;
            loadgethelp();

            GridView1.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }
            GridView1.RenderControl(hw);
            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}