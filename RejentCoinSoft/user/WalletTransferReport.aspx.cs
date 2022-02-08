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
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                //txtuserid.Text = Session["userid"].ToString();
                //txtuserid.Enabled = false;
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "myReverse")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            objuser.Id = lblid.Text;
            objuser.MentionBy = Session["userid"].ToString();
            objuser.ReverseWalletTransfer(objuser);
            string popupScript = "toastr.success('Success', 'Wallet Transfer Reversed Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            loaduser();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loaduser();
    }
    void loaduser()
    {

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
        objaccount.UserId = Session["userid"].ToString();
        objaccount.TransferUserId = txtuserid.Text;
        DataTable dt = new DataTable();
        dt = objaccount.getWalletTransferReport(objaccount);
        GridView1.DataSource = dt;
        GridView1.DataBind();
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
            //LinkButton lbReverse = (LinkButton)e.Row.FindControl("lbReverse");
            if (lblstatus.Text == "Success")
            {
                lblstatus.CssClass = "label label-success";
                //lbReverse.Visible = true;
            }
            else
            if (lblstatus.Text == "Reversed")
            {
                lblstatus.CssClass = "label label-danger";
                //lbReverse.Visible = false;
            }
        }
    }
}