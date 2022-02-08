using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;

public partial class user_WithdrawlRequstAdd : System.Web.UI.Page
{
    clsEPin objEPin = new clsEPin();
    clsUser objUser = new clsUser();
    clsAccount objaccount = new clsAccount();
    clsSetting objsetting = new clsSetting();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (!IsPostBack)
            {
                txtuserid.Text = Session["userid"].ToString();
                txtuserid.Enabled = false;
                loadsusername();
                // loadcurrentpool();
                loadnotification();
                fillform();
                showlimit();
                //   loadtematopupcount();
                // loadcurrentpool2();
                //loadwallettype();
            }
        }
        else
        {
            Server.Transfer("index.aspx");
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
    //void loadwallettype()
    //{
    //    ddwallettype.Items.Clear();
    //    DataTable dt = new DataTable();
    //    dt = objUser.getBTCWalletTypeActive();
    //    ddwallettype.DataSource = dt;
    //    ddwallettype.DataTextField = "wallettype";
    //    ddwallettype.DataValueField = "id";
    //    ddwallettype.DataBind();
    //    ListItem li = new ListItem("Select Wallet Type", "0");
    //    ddwallettype.Items.Insert(0, li);
    //}
    //void loadwallettaddress()
    //{
    //    objUser.UserId = Session["userid"].ToString();
    //    objUser.WalletTypeId = ddwallettype.SelectedValue.ToString();
    //    ddwalletaddress.Items.Clear();
    //    DataTable dt = new DataTable();
    //    dt = objUser.getBTCWalletAddressUserByType(objUser);
    //    ddwalletaddress.DataSource = dt;
    //    ddwalletaddress.DataTextField = "walletaddress";
    //    ddwalletaddress.DataValueField = "id";
    //    ddwalletaddress.DataBind();
    //    ListItem li = new ListItem("Select Wallet Address", "0");
    //    ddwalletaddress.Items.Insert(0, li);

    //    if (dt.Rows.Count > 0)
    //    {
    //        lblconversionrate.Text = dt.Rows[0]["ConversionToDollar"].ToString();
    //        txtconversionrate.Text = dt.Rows[0]["ConversionToDollar"].ToString();
    //    }
    //    else
    //    {
    //        lblconversionrate.Text = "0";
    //        txtconversionrate.Text = "0";
    //    }

    //}
    void loadcurrentpool()
    {

        //int currentpool = 0;
        //DataTable dt = new DataTable();
        //objUser.UserId = Session["userid"].ToString();
        //dt = objUser.getUserCurrentPool(objUser);
        //if (dt.Rows.Count > 0)
        //{
        //    currentpool = Convert.ToInt32( dt.Rows[0]["poolno"].ToString() );           
        //}
        //else
        //{
        //    currentpool = 0;
        //}
        //if (currentpool > 0)
        //{
        //    pnlwithdrawl.Visible = false;
        //    pnlnotelegible.Visible = false;
        //    pnlpool.Visible = true;
        //}
        //else
        //{
        //    pnlwithdrawl.Visible = true;
        //    pnlnotelegible.Visible = false;
        //    pnlpool.Visible = false;
        //}

    }

    void loadnotification()
    {
        //objUser.UserId = Session["userid"].ToString();
        //DataTable dt = new DataTable();
        //dt = objUser.getUserDetail(objUser);
        //if (dt.Rows[0]["activestatus"].ToString() == "0")
        //{
        //    Server.Transfer("Dashboard.aspx");
        //}
    }
    protected void txtuserid_TextChanged(object sender, EventArgs e)
    {
        loadsusername();
    }
    void loadsusername()
    {
        DataTable dt = new DataTable();
        objUser.UserId = txtuserid.Text;
        dt = objUser.getUserName(objUser);
        if (dt.Rows.Count > 0)
        {
            txtusername.Text = dt.Rows[0]["username"].ToString();
            txttrustwalletaddress.Text = dt.Rows[0]["TrustWalletAddress"].ToString();

            if (dt.Rows[0]["TrustWalletAddress"].ToString().Trim() == "")
            {
                string popupScript2 = "showModalNotification();";
                ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);

                
                Panel1.Visible = true;
                pnlwithdrawl.Visible = false;
            }
            else
            {
                Panel1.Visible = false;
                pnlwithdrawl.Visible = true;
            }

            objUser.UserId = txtuserid.Text;
            DataTable dtbalnce = new DataTable();
            //dtbalnce = objaccount.getAccountBalanceForGetHelp(objaccount);
            dtbalnce = objUser.get_UserBalance(objUser);
            if (dtbalnce.Rows.Count > 0)
            {
                txtbalance.Text = dtbalnce.Rows[0]["balanceamount"].ToString();
                txtcoinbalance.Text = dtbalnce.Rows[0]["coinbalance"].ToString();
            }
            else
            {
                txtbalance.Text = "0.00";
            }
        }
        else
        {
            txtusername.Text = "";
            txtuserid.Text = "";
            Message.Show("Invalid User Id...!!!");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        

            if (System.DateTime.Now.Day != DateTime.DaysInMonth(System.DateTime.Now.Year, System.DateTime.Now.Month))
            {

                if (System.DateTime.Now.Day != 1)
                {

                    decimal dcbalance = 0.00M;
                    decimal minlimit = 0.00M;
                    decimal maxlimit = 0.00M;
                    if (rbwithdrawlfrom.SelectedValue.ToString() == "MWallet")
                    {
                        minlimit = Convert.ToDecimal("10");
                        maxlimit = Convert.ToDecimal("1000");
                        dcbalance = Convert.ToDecimal(txtbalance.Text);
                    }
                    else
                         if (rbwithdrawlfrom.SelectedValue.ToString() == "Coin")
                    {
                        //minlimit = Convert.ToDecimal("10") / Convert.ToDecimal(lblconversionrate.Text);
                        //maxlimit = Convert.ToDecimal("1000") / Convert.ToDecimal(lblconversionrate.Text);
                        minlimit = Convert.ToDecimal("200");
                        maxlimit = Convert.ToDecimal("1000");
                        dcbalance = Convert.ToDecimal(txtcoinbalance.Text);
                    }
                    if (Convert.ToDecimal(txtamount.Text) >= minlimit)
                    {
                        if (Convert.ToDecimal(txtamount.Text) <= maxlimit)
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
                                    objUser.EmailSubject = "Rijent- Withdrawal OTP";
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
                            Message.Show("Withdrwal Amount Must Be Less Than " + maxlimit + "...!!!");
                        }

                    }
                    else
                    {
                        Message.Show("Withdrwal Amount Must Be Greater Than " + minlimit.ToString() + "...!!!");
                    }

                }
                else
                {
                    string popupScript = "toastr.error('Error', 'you can not add withdrawal request on first day of month');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                }
            } 
       
        


        //insertwithdrawalrequest();


    }


    void insertwithdrawalrequest()
    {
        int hour = 0;
        hour = System.DateTime.Now.Hour;
        //Message.Show(hour.ToString());
        //if (hour >= 11 && hour < 13)
        //{

        decimal dcbalance = 0.00M;
        decimal minlimit = 0.00M;
        decimal maxlimit = 0.00M;
        if (rbwithdrawlfrom.SelectedValue.ToString() == "MWallet")
        {
            minlimit = Convert.ToDecimal("10");
            maxlimit = Convert.ToDecimal("1000");
            dcbalance = Convert.ToDecimal(txtbalance.Text);
        }
        else
             if (rbwithdrawlfrom.SelectedValue.ToString() == "Coin")
        {
            //minlimit = Convert.ToDecimal("10")/Convert.ToDecimal(lblconversionrate.Text);
            //maxlimit = Convert.ToDecimal("1000") / Convert.ToDecimal(lblconversionrate.Text);
            minlimit = Convert.ToDecimal("200");
            maxlimit = Convert.ToDecimal("1000");
            dcbalance = Convert.ToDecimal(txtcoinbalance.Text);
        }

        if (txtuserid.Text != "")
        {
            if (txtusername.Text != "")
            {
                if (txtamount.Text != "")
                {
                    if (dcbalance >= Convert.ToDecimal(txtfinalamount.Text))
                    {
                        if (Convert.ToDecimal(txtamount.Text) >= minlimit)
                        {
                            //if (Convert.ToDecimal(txtamount.Text) % 10.00M == 0)
                            //{
                            if (Convert.ToDecimal(txtamount.Text) <= maxlimit)
                            {
                                //if (Convert.ToDecimal(txtamount.Text) % 200 == 0)
                                //{
                                objaccount.WithdrawlAmount = Convert.ToDecimal(txtamount.Text);
                                //objaccount.TransactionCharge = Convert.ToDecimal(txttransactioncharge.Text);
                                //objaccount.FinalAmount = Convert.ToDecimal(txtfinalamount.Text);
                                //objaccount.ConversionRate = Convert.ToDecimal(lblconversionrate.Text);
                                //objaccount.ConvertedAmount = Convert.ToDecimal(txtconvertedamount.Text);
                                //objaccount.WalletTypeId = ddwallettype.SelectedValue.ToString();
                                //objaccount.WalletAddressId = ddwalletaddress.SelectedValue.ToString();
                                //objaccount.WalletAddress = ddwalletaddress.SelectedItem.ToString();
                                //objaccount.TrustWalletAddress = txttrustwalletaddress.Text;
                                objaccount.WalletType = rbwithdrawlfrom.SelectedValue.ToString();
                                objaccount.MentionBy = Session["userid"].ToString();
                                objaccount.UserId = Session["userid"].ToString();
                                string rs = objaccount.Insert_WithdrawlRequest(objaccount);
                                if (rs == "t")
                                {
                                    Message.Show("Request Submitted Successfully...!!!");
                                    txtamount.Text = "";
                                    loadsusername();
                                    txttransactioncharge.Text = txtfinalamount.Text = "";
                                }
                                else if (rs == "f")
                                {
                                    Message.Show("Can not add withdrawl request. There is already a pending withdrwal request...!!!");
                                }
                                else if (rs == "m")
                                {
                                    Message.Show("please verify your email and mobile to continue withdrawal....!!!");
                                }
                                else if (rs == "b")
                                {
                                    Message.Show("user does not have sufficient balance....!!!");
                                }
                                else
                                {
                                    Message.Show("Unknown Error Occurred...!!!");
                                }
                                //}
                                //else
                                //{
                                //    Message.Show("Withdrwal Amount Must Be in multiple of 200...!!!");
                                //}
                            }
                            else
                            {
                                Message.Show("Withdrwal Amount Must Be Less Than " + maxlimit + "...!!!");
                            }
                            //}
                            //else
                            //{
                            //    Message.Show("Withdrwal Amount Must Be Multiple Of 10$...!!!");
                            //}
                        }
                        else
                        {
                            Message.Show("Withdrwal Amount Must Be Greater Than " + minlimit.ToString() + "...!!!");
                        }
                    }
                    else
                    {
                        Message.Show("Withdrawl Amount Must Be Lesss Than Or Equal Than Account Balance...!!!");
                    }
                }
                else
                {
                    Message.Show("Enter No of E-Pins...!!!");
                }
            }
            else
            {
                Message.Show("Enter User Name...!!!");
            }
        }
        else
        {
            Message.Show("Enter User Id...!!!");
        }
        //}
        //else
        //{
        //    Message.Show("Withdrawal request timing from 11 am to 1 pm...!!!");
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }

    protected void txtamount_TextChanged(object sender, EventArgs e)
    {
        loadamunt();
    }
    void loadamunt()
    {
        if (txtamount.Text != "")
        {
            decimal dctrancharge = 0.00M;
            decimal dcfinalamount = 0.00M;
            dctrancharge = (Convert.ToDecimal(txtamount.Text) * 5) / 100;
            dcfinalamount = Convert.ToDecimal(txtamount.Text) + dctrancharge;
            txttransactioncharge.Text = dctrancharge.ToString();
            txtfinalamount.Text = dcfinalamount.ToString();


            if (rbwithdrawlfrom.SelectedValue == "MWallet")
            {
                decimal converiosnrate = Convert.ToDecimal(lblconversionrate.Text);
                decimal convertedcoin = Math.Round((Convert.ToDecimal(txtamount.Text) / converiosnrate), 2);

                txtconvertedcoin.Text = convertedcoin.ToString();
            }
            else
            {
                txtconvertedcoin.Text = txtamount.Text;
            }


            //decimal dcconversionRate = 0.00M;
            //if (txtconversionrate.Text != "0")
            //{
            //    dcconversionRate = Convert.ToDecimal(lblconversionrate.Text);
            //}

            //txtconvertedamount.Text = (Convert.ToDecimal(txtamount.Text) * dcconversionRate).ToString();
        }
        else
        {
            txttransactioncharge.Text = "0";
            txtfinalamount.Text = "0";
        }
    }
    protected void ddwallettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //loadwallettaddress();

        //if (ddwallettype.SelectedValue.ToString() != "0")
        //{
        //    lblwallettype.Text = ddwallettype.SelectedItem.ToString();
        //}
        //else
        //{
        //    lblwallettype.Text = "";
        //}

    }

    protected void rbwithdrawlfrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadamunt();

        showlimit();
      

    }
    void showlimit()
    {
        decimal minlimit = 0.00M;
        decimal maxlimit = 0.00M;
        if (rbwithdrawlfrom.SelectedValue.ToString() == "MWallet")
        {
            lblminlimit.Text = "10$";
            lblmaximumlimit.Text = "1000$";
            lblfinalcurrency.Text = " in $";

        }
        else
             if (rbwithdrawlfrom.SelectedValue.ToString() == "Coin")
        {
            lblminlimit.Text = "200RTC";
            lblmaximumlimit.Text = "1000RTC";
            lblfinalcurrency.Text = " in RTC";
        }
    }

    protected void btnOTPAddress_Click(object sender, EventArgs e)
    {
        if (hdnOTP.Value.ToString() == txtotpaddress.Text)
        {
            insertwithdrawalrequest();
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