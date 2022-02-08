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
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
                //txtuserid.Text = Session["userid"].ToString();
                //txtuserid.Enabled = false;
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
        if (e.CommandName == "myEdit")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            Label lblamount = (Label)GridView1.Rows[index].FindControl("lblamount");
            Label lbluserid = (Label)GridView1.Rows[index].FindControl("lbluserid");
            Label lbltransactionhash = (Label)GridView1.Rows[index].FindControl("lbltransactionhash");
            Label lbltenure = (Label)GridView1.Rows[index].FindControl("lbltenure");
            Label lblamountdollar = (Label)GridView1.Rows[index].FindControl("lblamountdollar");
            //Label lblwallettype = (Label)GridView1.Rows[index].FindControl("lblwallettype");
            //Label lblwalletaddress = (Label)GridView1.Rows[index].FindControl("lblwalletaddress");
            lblrequestid.Text = lblid.Text;
            txtuseridedit.Text = lbluserid.Text;
            txtamount.Text = lblamount.Text;
            txttransactionid.Text = lbltransactionhash.Text;
            txttenure.Text = lbltenure.Text;
            //txtwalletaddress.Text = lblwalletaddress.Text;
            txtamountdollar.Text = lblamountdollar.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        if (e.CommandName == "myReject")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            objuser.Status = "Rejected";
            objuser.Id = lblid.Text;
            objuser.MentionBy = Session["rijentadmin45852_4"].ToString();
            string res = objuser.UpdateStckingRequest(objuser);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Staking Request Edited Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                string popupScript2 = "Closepopup();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                loaduser();
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknow error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
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
            objuser.FromDate = Message.GetIndianDate(txtfromdate.Text);
        }
        else
        {
            objuser.FromDate = DateTime.MinValue;
        }
        if (txttodate.Text != "")
        {
            objuser.ToDate = Message.GetIndianDate(txttodate.Text);
        }
        else
        {
            objuser.ToDate = DateTime.MinValue;
        }
        objuser.UserId = txtuserid.Text;
        objuser.Status = ddstatussearch.SelectedValue.ToString();
        DataTable dt = new DataTable();
        dt = objuser.getStackingReport(objuser);
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
            LinkButton lbReverse = (LinkButton)e.Row.FindControl("lbReverse");
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            if (lblstatus.Text == "Pending")
            {
                lbReverse.Visible = true;
                lblstatus.CssClass = "label label-info";
            }
            else
                if (lblstatus.Text == "Approved")
            {
                lbReverse.Visible = false;
                lblstatus.CssClass = "label label-success";
            }
            else
            if (lblstatus.Text == "Rejected")
            {
                lbReverse.Visible = false;
                lblstatus.CssClass = "label label-danger";
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objuser.Status = ddstatus.SelectedValue.ToString();
        objuser.Id = lblrequestid.Text;
        objuser.MentionBy = Session["rijentadmin45852_4"].ToString();
        string res = objuser.UpdateStckingRequest(objuser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Staking Request Edited Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            string popupScript2 = "Closepopup();";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            loaduser();
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Unknow error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
}