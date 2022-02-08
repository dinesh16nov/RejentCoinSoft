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
        //if (rbWalletType.SelectedValue != null)
        //{
        objUser.UserId = txtuserid.Text;
        objUser.MonthlyReturn = Convert.ToDecimal(txtreturnpercent.Text);
        objUser.Days = Convert.ToInt32(txtdays.Text);
        objUser.Limit = Convert.ToDecimal(txtlimit.Text);
        objUser.Coins = Convert.ToDecimal(txtcoins.Text);

        objUser.MentionBy = Session["rijentadmin45852_4"].ToString();
        string res = objUser.Insert_PremiumWallet(objUser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Premium Wallet Added Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtpersonmobile.Text = txtpersonname.Text = txtpersonemail.Text = txtuserid.Text = txtreturnpercent.Text = txtcoins.Text = txtdays.Text = txtlimit.Text = "";
        }
        else
            if (res == "f")
        {
            string popupScript = "toastr.error('Error', 'Premium Wallet Already Exists');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Unknow error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        //}
        //else
        //{
        //    string popupScript = "toastr.error('Error', 'Select Wallet Type');";
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void txtuserid_TextChanged(object sender, EventArgs e)
    {
        objUser.UserId = txtuserid.Text;
        DataTable dt = new DataTable();
        dt = objUser.getUserDetail(objUser);
        if (dt.Rows.Count > 0)
        {
            txtpersonname.Text = dt.Rows[0]["username"].ToString();
            txtpersonemail.Text = dt.Rows[0]["email"].ToString();
            txtpersonmobile.Text = dt.Rows[0]["mobile"].ToString();
            txtbalance.Text = dt.Rows[0]["premiumbalance"].ToString();
        }
        else
        {
            txtpersonemail.Text = txtpersonmobile.Text = txtpersonname.Text = txtbalance.Text = txtuserid.Text = "";
            string popupScript = "toastr.error('Error', 'No User Found');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
}