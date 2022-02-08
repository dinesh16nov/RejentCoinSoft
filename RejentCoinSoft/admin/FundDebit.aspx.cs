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
        if (rbWalletType.SelectedValue != null)
        {
            //Random rnd = new Random();
            //string str_otpemail = rnd.Next(100000, 999999).ToString();
            //hdnOTP.Value = str_otpemail;
            //objUser.OTP = str_otpemail;
            ////objUser.UserId = Session["userid"].ToString();
            //objUser.EmailSubject = "Rijent- Fund Debit OTP";
            //objUser.EmailBody = @"Dear User OTP is " + str_otpemail;

            ////objUser.OTP = str_otpemail;
            ////objUser.UserId = Session["userid"].ToString();
            ////string res2 = objUser.SendOTP(objUser);

            //string res = objUser.SendEmailOTPAdmin(objUser);
            //{
            //    string popupScript = "toastr.success('Success', 'OTP has been Sent To Your Email.');";
            //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            //    string popupScript2 = "showModalOTPAddress();";
            //    ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            //}
            funddebit();
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Select Wallet Type');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    void funddebit()
    {
        objUser.UserId = txtuserid.Text;
        objUser.Amount = Convert.ToDecimal(txtamount.Text);
        objUser.WalletType = rbWalletType.SelectedValue.ToString();
        objUser.MentionBy = Session["rijentadmin45852_4"].ToString();
        objUser.Remark = txtremark.Text;
        string res = objUser.FundDebitAdmin(objUser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Fund Debited Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
          txtcoinbalance.Text=txtexternalwalletbalance.Text=  txtremark.Text = txtpersonmobile.Text = txtpersonname.Text = txtpersonemail.Text = txtuserid.Text = txtamount.Text = "";
        }
        else
            if (res == "f")
        {
            string popupScript = "toastr.error('Error', 'User Does Not Exists');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Unknow error occurred');";
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
        dt = objUser.getUserDetail(objUser);
        if (dt.Rows.Count > 0)
        {
            txtpersonname.Text = dt.Rows[0]["username"].ToString();
            txtpersonemail.Text = dt.Rows[0]["email"].ToString();
            txtpersonmobile.Text = dt.Rows[0]["mobile"].ToString();
            txtinternalwalletbalance.Text = dt.Rows[0]["balanceamount"].ToString();
            txtexternalwalletbalance.Text = dt.Rows[0]["ewalletbalance2"].ToString();
            txtcoinbalance.Text = dt.Rows[0]["coinbalance"].ToString();
        }
        else
        {
            txtpersonname.Text = txtpersonmobile.Text = txtpersonemail.Text = txtinternalwalletbalance.Text = txtexternalwalletbalance.Text = "";

            string popupScript = "toastr.error('Error', 'No User Found');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    protected void btnOTPAddress_Click(object sender, EventArgs e)
    {
        if (hdnOTP.Value.ToString() == txtotpaddress.Text)
        {
            funddebit();
            string popupScript2 = "ClosepopupOTPAddress();";
            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
        }
        else
        {
            string popupScript2 = "showModalOTPAddress();";
            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            string popupScript = "toastr.error('Error', 'Invalid OTP');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
}