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
    clsSetting objsetting = new clsSetting();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {
                //txtuserid.Text = Session["userid"].ToString();
                //txtuserid.Enabled = false;
                //loadusername();
                fillform();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }

    protected void txtuserid_TextChanged(object sender, EventArgs e)
    {
        if (ddwallettype.SelectedValue != "0")
        {
            if (ddwallettype.SelectedValue != "EWallet")
            {
                //loaddownlineusername();
                loadusername();
            }
            else
            {
                loadusername();
            }
        }
        else
        {
            txtuserid.Text = txtusername.Text = "";
            string popupScript = "toastr.error('Error', 'Please Select Wallet Type');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    void loaddownlineusername()
    {
        DataTable dt = new DataTable();
        objUser.SponserId = Session["userid"].ToString();
        objUser.UserId = txtuserid.Text;
        dt = objUser.getUserNameDownline(objUser);
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
    void loadusername()
    {
        DataTable dt = new DataTable();
        objUser.SponserId = Session["userid"].ToString();
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
    //protected void ddepin_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtamount.Text = ddepin.SelectedValue.ToString();
    //}
    //void loadepin()
    //{
    //    objepin.GenerateUserId = Session["userid"].ToString();
    //    objepin.PlanId = ddplan.SelectedValue.ToString();
    //    ddepin.Items.Clear();
    //    DataTable dt = new DataTable();
    //    dt = objepin.getEPinForReg(objepin);
    //    ddepin.DataSource = dt;
    //    ddepin.DataTextField = "epinno";
    //    ddepin.DataValueField = "amount";
    //    ddepin.DataBind();
    //    ListItem li = new ListItem("Select Epin", "0");
    //    ddepin.Items.Insert(0, li);
    //}
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        decimal minlimit = 0.00M;
        decimal maxlimit = 0.00M;
        if (ddwallettype.SelectedValue.ToString() == "MWallet" || ddwallettype.SelectedValue.ToString() == "EWallet")
        {
            minlimit = Convert.ToDecimal("10");
            maxlimit = Convert.ToDecimal("1000");
        }
        else
             if (ddwallettype.SelectedValue.ToString() == "Coin")
        {
            minlimit = Convert.ToDecimal("10") / Convert.ToDecimal(lblconversionrate.Text);
            maxlimit = Convert.ToDecimal("1000") / Convert.ToDecimal(lblconversionrate.Text);
        }

        string currency = "";
        decimal dcconversonrate = 0.00M;
        decimal dcconvertedamount = 0.00M;
        if (ddwallettype.SelectedValue.ToString() == "MWallet" || ddwallettype.SelectedValue.ToString() == "EWallet")
        {
            dcconversonrate = Convert.ToDecimal("1");
            currency = "Dollar";
        }
        else
        {

            dcconversonrate = Convert.ToDecimal(lblconversionrate.Text);
            currency = "Coins";
        }
        dcconvertedamount = Convert.ToDecimal(txtamount.Text) / dcconversonrate;


        if (dcconvertedamount >= minlimit)
        {
            if (Convert.ToDecimal(txtconvertedamount.Text) <= Convert.ToDecimal(txtbalance.Text))
            {
                if (dcconvertedamount <= maxlimit)
                {
                    objUser.UserId = Session["userid"].ToString();
                    DataTable dt = new DataTable();
                    dt = objUser.getEmailMobileVerifyStatus(objUser);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["emailverifystatus"].ToString() == "1" && dt.Rows[0]["mobileverifystatus"].ToString() == "1")
                        {
                            Random rnd = new Random();
                            string str_otpemail = rnd.Next(100000, 999999).ToString();
                            hdnOTP.Value = str_otpemail;
                            objUser.OTP = str_otpemail;
                            objUser.UserId = Session["userid"].ToString();
                            objUser.EmailSubject = "Rijent- User Re-Topup OTP";
                            objUser.EmailBody = @"Dear User OTP is " + str_otpemail;

                            objUser.OTP = str_otpemail;
                            objUser.UserId = Session["userid"].ToString();
                            string res2 = objUser.SendOTP(objUser);

                            string res = objUser.SendEmailVerification(objUser);
                            {
                                string popupScript = "toastr.success('Success', 'OTP has been Sent To Your Email.');";
                                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                                string popupScript2 = "showModalOTPAddress();";
                                ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                            }
                        }
                        else
                        {
                            string popupScript = "toastr.error('Error', 'please verify your email and mobile to update wallet address');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                        }

                    }
                    else
                    {
                        string popupScript = "toastr.error('Error', 'please verify your email and mobile to update wallet address');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }
                }
                else
                {
                    string popupScript = "toastr.error('Error', 'Topup Amount should be less than or equal to " + maxlimit.ToString() + " " + currency + "');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

                }
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Topup Amount should be less than or equal to balance amount');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Topup Amount should be greater than or equal to " + minlimit.ToString() + " " + currency + "');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    void usertopup() {
        decimal minlimit = 0.00M;
        decimal maxlimit = 0.00M;
        if (ddwallettype.SelectedValue.ToString() == "MWallet" || ddwallettype.SelectedValue.ToString() == "EWallet")
        {
            minlimit = Convert.ToDecimal("10");
            maxlimit = Convert.ToDecimal("1000");
        }
        else
             if (ddwallettype.SelectedValue.ToString() == "Coin")
        {
            minlimit = Convert.ToDecimal("10") / Convert.ToDecimal(lblconversionrate.Text);
            maxlimit = Convert.ToDecimal("1000") / Convert.ToDecimal(lblconversionrate.Text);
        }

        string currency = "";
        decimal dcconversonrate = 0.00M;
        decimal dcconvertedamount = 0.00M;
        if (ddwallettype.SelectedValue.ToString() == "MWallet" || ddwallettype.SelectedValue.ToString() == "EWallet")
        {
            dcconversonrate = Convert.ToDecimal("1");
            currency = "Dollar";
        }
        else
        {

            dcconversonrate = Convert.ToDecimal(lblconversionrate.Text);
            currency = "Coins";
        }
        dcconvertedamount = Convert.ToDecimal(txtamount.Text) / dcconversonrate;


        if (dcconvertedamount >= minlimit)
        {
            if (Convert.ToDecimal(txtconvertedamount.Text) <= Convert.ToDecimal(txtbalance.Text))
            {
                if (dcconvertedamount <= maxlimit)
                {

                    //objUser.PlanId = ddplan.SelectedValue.ToString();
                    objUser.UserId = txtuserid.Text;
                    objUser.WalletType = ddwallettype.SelectedValue.ToString();
                    objUser.Amount = Convert.ToDecimal(txtamount.Text);
                    objUser.MentionBy = Session["userid"].ToString();
                    string res = objUser.Insert_ReTopupUser(objUser);
                    if (res == "t")
                    {
                        string popupScript = "toastr.success('Success', 'Renewal Successfull');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                        txtuserid.Text = "";
                        txtusername.Text = "";
                        ddwallettype.SelectedValue = "0";
                        txtbalance.Text = txtamount.Text = "0";
                        //loadepin();
                        //txtamount.Text = "0";
                    }
                    else if (res == "b")
                    {
                        string popupScript = "toastr.error('Error', 'user does not have sufficient balance');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }
                    else if (res == "a")
                    {
                        string popupScript = "toastr.error('Error', 'amount sholud be greater tha or equal to last topup amount');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }
                    else
                             if (res == "f")
                    {
                        string popupScript = "toastr.error('Error', 'Please Upgrade for the first time for renewal');";
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
                    string popupScript = "toastr.error('Error', 'Topup Amount should be less than or equal to " + maxlimit.ToString() + " " + currency + "');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

                }
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Topup Amount should be less than or equal to balance amount');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Topup Amount should be greater than or equal to " + minlimit.ToString() + " " + currency + "');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("dashboard.aspx");
    }
    //protected void ddplan_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    loadepin();
    //}

    protected void ddwallettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtuserid.Text = txtusername.Text = "";
        if (ddwallettype.SelectedValue.ToString() != "0")
        {
            if (ddwallettype.SelectedValue.ToString() == "MWallet" || ddwallettype.SelectedValue.ToString() == "EWallet")
            {
                lblwallettype.Text = "USDT";
            }
            else
            {
                lblwallettype.Text = "Coin";
            }


            objUser.UserId = Session["userid"].ToString();
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
                else if (ddwallettype.SelectedValue.ToString() == "Coin")
                {
                    txtbalance.Text = dt.Rows[0]["coinbalance"].ToString();
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
        calculateamount();
        loadconvertedamount();
    }

    protected void txtamount_TextChanged(object sender, EventArgs e)
    {
        calculateamount();

        loadconvertedamount();
    }
    void calculateamount()
    {
        if (txtamount.Text != "")
        {
            if (ddwallettype.SelectedValue.ToString() == "MWallet" || ddwallettype.SelectedValue.ToString() == "Coin")
            {
                decimal dctrancharge = (Convert.ToDecimal(txtamount.Text) * 5) / 100;
                txttrancharge.Text = dctrancharge.ToString();
                txtfinalamount.Text = (Convert.ToDecimal(txtamount.Text) + dctrancharge).ToString();
            }
            else
            {
                txttrancharge.Text = "0";
                txtfinalamount.Text = txtamount.Text;
            }

        }
        else
        {
            txttrancharge.Text = "0";
            txtfinalamount.Text = "0";
        }
    }
    void fillform()
    {
        DataTable dt = new DataTable();
        dt = objsetting.GetSystemSettings();
        if (dt.Rows.Count > 0)
        {
            lblconversionrate.Text = dt.Rows[0]["qaurecointodollar"].ToString();
            //txtwalletaddress.Text = dt.Rows[0]["QauereWalletAddress"].ToString();
            //lbladdress.Text = dt.Rows[0]["QauereWalletAddress"].ToString();
            //ltimage.Text = @"<img src=""../admin/images/" + dt.Rows[0]["imagename"].ToString() + @""" style=""width:100%;"" />";
        }
    }
    void loadconvertedamount()
    {
        decimal dcconversonrate = 0.00M;
        if (ddwallettype.SelectedValue.ToString() == "MWallet" || ddwallettype.SelectedValue.ToString() == "EWallet")
        {
            dcconversonrate = Convert.ToDecimal("1");
        }
        else
        {

            dcconversonrate = Convert.ToDecimal(lblconversionrate.Text);
        }
        if (txtamount.Text != "")
        {
            txtconvertedamount.Text = Math.Round((Convert.ToDecimal(txtfinalamount.Text) / dcconversonrate), 2).ToString();
        }
        else
        {
            txtconvertedamount.Text = "";
        }
    }
    protected void btnOTPAddress_Click(object sender, EventArgs e)
    {
        if (hdnOTP.Value.ToString() == txtotpaddress.Text)
        {
            usertopup();
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