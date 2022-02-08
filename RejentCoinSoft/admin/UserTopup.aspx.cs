using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_UserTopup : System.Web.UI.Page
{
    clsUser objUser = new clsUser();
    clsEPin objepin = new clsEPin();
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

    protected void txtuserid_TextChanged(object sender, EventArgs e)
    {
        loadusername();
    }
    void loadusername()
    {
        DataTable dt = new DataTable();
        objUser.UserId = txtuserid.Text;
        dt = objUser.getUserName(objUser);
        if (dt.Rows.Count > 0)
        {
            txtusername.Text = dt.Rows[0]["username"].ToString();
            //ddplan.SelectedValue = dt.Rows[0]["planid"].ToString(); 
        }
        else
        {
            txtusername.Text = "";
            txtuserid.Text = "";
            //ddplan.SelectedValue = "0";
            string popupScript = "toastr.error('Error', 'Invalid User Id');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objUser.WalletType = ddwallettype.SelectedValue.ToString();
        objUser.UserId = txtuserid.Text;
        objUser.SponserId = txtsponserid.Text;
        objUser.Amount = Convert.ToDecimal(txtamount.Text);
        objUser.MentionBy = Session["rijentadmin45852_4"].ToString();

        if (ck1.Checked == true)
        {
            objUser.IsDummyData = "1";
        }
        else
        {
            objUser.IsDummyData = "0";
        }

        string res = objUser.Insert_TopupAdmin(objUser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'User Upgraded Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtuserid.Text = txtsponserid.Text = txtsponsername.Text = txtusername.Text = "";

            txtamount.Text = txtbalance.Text = ddwallettype.SelectedValue = "0";

        }
        else
                if (res == "f")
        {
            string popupScript = "toastr.error('Error', 'User Already Topped Up');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else
                if (res == "b")
        {
            string popupScript = "toastr.error('Error', 'User does not have sufficient balance');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Unknown error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("dashboard.aspx");
    }
    void loadsponsername()
    {
        DataTable dt = new DataTable();
        objUser.UserId = txtsponserid.Text;
        dt = objUser.getUserName(objUser);
        if (dt.Rows.Count > 0)
        {
            txtsponsername.Text = dt.Rows[0]["username"].ToString();
        }
        else
        {
            txtsponsername.Text = "";
            txtsponserid.Text = "";
            string popupScript = "toastr.error('Error', 'Invalid Sponser Id');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    protected void txtsponserid_TextChanged(object sender, EventArgs e)
    {
        loadsponsername();
    }
    protected void ddwallettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddwallettype.SelectedValue.ToString() != "0")
        {
            objUser.UserId = txtsponserid.Text;
            DataTable dt = new DataTable();
            dt = objUser.get_UserBalance(objUser);
            if (dt.Rows.Count > 0)
            {
                if (ddwallettype.SelectedValue.ToString() == "MWallet")
                {
                    txtbalance.Text = dt.Rows[0]["balanceamount"].ToString();
                }
                else if (ddwallettype.SelectedValue.ToString() == "EWallet")
                {
                    txtbalance.Text = dt.Rows[0]["ewalletbalance"].ToString();
                }
                else
                {
                    txtbalance.Text = "0";
                }
            }
        }
        else
        {
            txtbalance.Text = "0";
        }
    }
}