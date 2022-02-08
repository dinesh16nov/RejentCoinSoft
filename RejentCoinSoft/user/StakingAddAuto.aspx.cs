using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;


public partial class user_StakingAddAuto : System.Web.UI.Page
{
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                loaduser();
                loaduserdetail();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void loaduserdetail()
    {
        DataTable dt = new DataTable();
        objuser.UserId = Session["userid"].ToString();
        dt = objuser.getUserDetail(objuser);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["IStakingApprive2"].ToString() == "0")
            {
                btnapprove1.Visible = true;
                btnapprove2.Visible = true;
                btnapprove3.Visible = true;
                btnapprove4.Visible = true;
                btnapprove5.Visible = true;

                btnstaking1.Visible = false;
                btnstaking2.Visible = false;
                btnstaking3.Visible = false;
                btnstaking4.Visible = false;
                btnstaking5.Visible = false;

            }
            else
            {
                btnapprove1.Visible = false;
                btnapprove2.Visible = false;
                btnapprove3.Visible = false;
                btnapprove4.Visible = false;
                btnapprove5.Visible = false;

                btnstaking1.Visible = true;
                btnstaking2.Visible = true;
                btnstaking3.Visible = true;
                btnstaking4.Visible = true;
                btnstaking5.Visible = true;
            }
        }

    }

    protected void btnstaking1_Click(object sender, EventArgs e)
    {
        string popupScript = "deposit2(0," + txtstaking1.Text + ");";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
    }

    protected void btnstaking2_Click(object sender, EventArgs e)
    {
        string popupScript = "deposit2(1," + txtstaking2.Text + ");";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
    }

    protected void btnstaking3_Click(object sender, EventArgs e)
    {
        string popupScript = "deposit2(2," + txtstaking3.Text + ");";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
    }

    protected void btnstaking4_Click(object sender, EventArgs e)
    {
        //string popupScript = "deposit2(3," + txtstaking4.Text + ");";

        //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        Message.Show("This Product is Currently Not Available For You . Please Choose another Product.");
    }

    protected void btnstaking5_Click(object sender, EventArgs e)
    {
        //string popupScript = "deposit2(4," + txtstaking5.Text + ");";

        //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        Message.Show("This Product is Currently Not Available For You . Please Choose another Product.");
    }

    protected void btnapprove1_Click(object sender, EventArgs e)
    {
        objuser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objuser.getUserSmartContractAddress(objuser);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
            {
                string popupScript = "approveBusd('" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                //string popupScript = "approve('" + txtdepositamount.Text + "', '" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

            }
            else
            {
                string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }

    protected void btnapprove2_Click(object sender, EventArgs e)
    {
        objuser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objuser.getUserSmartContractAddress(objuser);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
            {
                string popupScript = "approveBusd('" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                //string popupScript = "approve('" + txtdepositamount.Text + "', '" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

            }
            else
            {
                string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }

    protected void btnapprove3_Click(object sender, EventArgs e)
    {
        objuser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objuser.getUserSmartContractAddress(objuser);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
            {
                string popupScript = "approveBusd('" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                //string popupScript = "approve('" + txtdepositamount.Text + "', '" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

            }
            else
            {
                string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }

    protected void btnapprove4_Click(object sender, EventArgs e)
    {
        objuser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objuser.getUserSmartContractAddress(objuser);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
            {
                string popupScript = "approveBusd('" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                //string popupScript = "approve('" + txtdepositamount.Text + "', '" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

            }
            else
            {
                string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }

    protected void btnapprove5_Click(object sender, EventArgs e)
    {
        objuser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objuser.getUserSmartContractAddress(objuser);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
            {
                string popupScript = "approveBusd('" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                //string popupScript = "approve('" + txtdepositamount.Text + "', '" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

            }
            else
            {
                string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string popupScript = "showmodal2();";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
    }
    void loaduser()
    {

        //if (txtfromdate.Text != "")
        //{
        //    objuser.FromDate = Message.GetIndianDate(txtfromdate.Text);
        //}
        //else
        //{
        objuser.FromDate = DateTime.MinValue;
        //}
        //if (txttodate.Text != "")
        //{
        //objuser.ToDate = Message.GetIndianDate(txttodate.Text);
        //}
        //else
        //{
        objuser.ToDate = DateTime.MinValue;
        //}
        objuser.UserId = Session["userid"].ToString();
        //DataTable dt = new DataTable();
        //dt = objuser.getStackingReport(objuser);
        //GridView1.DataSource = dt;
        //GridView1.DataBind();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            if (lblstatus.Text == "Pending")
            {
                lblstatus.CssClass = "label label-info";
            }
            else
                if (lblstatus.Text == "Approved")
            {

                lblstatus.CssClass = "label label-success";
            }
            else
            if (lblstatus.Text == "Rejected")
            {
                lblstatus.CssClass = "label label-danger";
            }
        }
    }
}