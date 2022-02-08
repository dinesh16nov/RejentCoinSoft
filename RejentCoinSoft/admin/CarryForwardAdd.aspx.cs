using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicTier;
using System.Data;

public partial class admin_FundTransfer : System.Web.UI.Page
{
    clsUser objUser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {

            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (rbstandingposition.SelectedValue != null)
        {
            objUser.UserId = txtuserid.Text;
            objUser.Amount = Convert.ToDecimal(txtamount.Text);
            objUser.StandingPosition = rbstandingposition.SelectedValue.ToString();
            objUser.MentionBy = Session["rijentadmin45852_4"].ToString();
            string res = objUser.Insert_CarryForward(objUser);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Carry Forward Added Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                txtpersonmobile.Text = txtpersonname.Text = txtpersonemail.Text = txtuserid.Text = txtamount.Text = "";
            }
            else
                if (res == "f")
            {
                string popupScript = "toastr.error('Error', 'User Does Not Exists');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknown error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Select Standing Position');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void txtuserid_TextChanged(object sender, EventArgs e)
    {
        objUser.UserId = txtuserid.Text;
        DataTable dt = new DataTable();
        dt = objUser.getUserDetailForCarryForward(objUser);
        if (dt.Rows.Count > 0)
        {
            txtpersonname.Text = dt.Rows[0]["username"].ToString();
            txtpersonemail.Text = dt.Rows[0]["email"].ToString();
            txtpersonmobile.Text = dt.Rows[0]["mobile"].ToString();
            txtleftcarryforward.Text= dt.Rows[0]["leftcarry"].ToString();
            txtrightcarryforward.Text= dt.Rows[0]["rightcarry"].ToString();
        }
        else
        {
            string popupScript = "toastr.error('Error', 'No User Found');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
}