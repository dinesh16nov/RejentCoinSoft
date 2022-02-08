using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;
using System.Web.UI.HtmlControls;
using RestSharp;
using System.Xml;
using Newtonsoft.Json;

public partial class admin_Dashboard : System.Web.UI.Page
{
    clsUser objuser = new clsUser();
    clsAccount objaccount = new clsAccount();
    clsNews objnews = new clsNews();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["userid"] != null)
        {
            //Response.Redirect("Dashboard.aspx");
            //laoddata();
            //loadnews();
            loaddashboard();
            //   lblreferencelinkleft.Text = @"<a href='http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1' target='_blank'>http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1</a>";
            //   lblreferencelinkright.Text = @"<a href='http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2' target='_blank'>http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2</a>";

            //   lbllinkleft.Text = @"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1";
            //   lbllinkright.Text = @"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2";

            //   ltwhatsapplinkleft.Text=  @"<a href=""https://api.whatsapp.com/send?phone=91&text="+ HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1")+@""" target=""_blank"" style=""color:white;""> <i class=""fa fa-whatsapp""></i></a>";
            //ltwhatsapplinkright.Text= @"<a href=""https://api.whatsapp.com/send?phone=91&text=" + HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2") + @""" target=""_blank"" style=""color:white;""> <i class=""fa fa-whatsapp""></i></a>";



            // ltfacebookshareleft.Text= @"<a href=""http://www.facebook.com/sharer.php?u="+ HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1") + @""" style=""color:white;"" target=""_blank""><i class=""fa fa-facebook""></i></a>";
            // ltfacebookshareright.Text= @"<a href=""http://www.facebook.com/sharer.php?u="+ HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2") + @""" style=""color:white;"" target=""_blank""><i class=""fa fa-facebook""></i></a>";

            //if (Session["userid"].ToString() == "789440")
            //{
            //    divroi.Visible = true;
            //}
            loadoffer();
        }
        else
        {
            Server.Transfer("logout.aspx");
        }
    }
    void loadoffer()
    {
        DataTable dt = new DataTable();
        dt = objnews.getAfterLoginOffer();
        if (dt.Rows.Count > 0)
        {
            //HttpCookie myCookie = new HttpCookie(dt.Rows[0]["imagename"].ToString());
            //myCookie.Value = dt.Rows[0]["imagename"].ToString();
            //HttpContext.Current.Response.Cookies.Add(myCookie);

            ltofferimage.Text = @"<img src=""../admin/userimage/" + dt.Rows[0]["imagename"].ToString() + @""" style=""width:100%;"" />";
            string popupScript2 = "showModalOffer('" + dt.Rows[0]["imagename"].ToString() + "');";
            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
        }
    }
    //void loadnews()
    //{
    //    DataTable dt = new DataTable();
    //    dt = objnews.getRecentNews();
    //    foreach (DataRow r in dt.Rows)
    //    {
    //        ltnews.Text += r["newsdetail"].ToString() + "<br/><hr/>";
    //    }
    //}

    //void laoddata()
    // {
    //     objuser.UserId = Session["userid"].ToString();
    //     DataTable dt = new DataTable();
    //     dt = objuser.getUserDetail(objuser);
    //     if (dt.Rows.Count > 0)
    //     {
    //         lbluserid.Text = dt.Rows[0]["userid"].ToString();
    //         lblusername.Text = dt.Rows[0]["username"].ToString();
    //         lbladdress.Text = dt.Rows[0]["address"].ToString();
    //         lblmobile.Text = dt.Rows[0]["mobile"].ToString();
    //         lblemail.Text = dt.Rows[0]["email"].ToString();
    //         lblaccountholdername.Text = dt.Rows[0]["accountholdername"].ToString();
    //         lblaccountno.Text = dt.Rows[0]["accountno"].ToString();
    //         lblbank.Text = dt.Rows[0]["branchname"].ToString();
    //         lblifsc.Text = dt.Rows[0]["ifsccode"].ToString();
    //         lblpan.Text = dt.Rows[0]["pannumber"].ToString();

    //     }

    // }
    void loaddashboard()
    {
        DataSet ds = new DataSet();
        objuser.UserId = Session["userid"].ToString();
        ds = objuser.get_DashboardUser(objuser);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                lblstakingbonus.Text = ds.Tables[0].Rows[0]["package"].ToString();

                lbldirectteam.Text = ds.Tables[0].Rows[0]["directteam"].ToString();
                lbltotalteam.Text = ds.Tables[0].Rows[0]["totalteam"].ToString();
                lblleftteam.Text = ds.Tables[0].Rows[0]["lcount"].ToString();
                lblrightteam.Text = ds.Tables[0].Rows[0]["rcount"].ToString();
                lbldirectincome.Text = ds.Tables[0].Rows[0]["directincome"].ToString();
                lblmatchingincome.Text = ds.Tables[0].Rows[0]["binaryincome"].ToString();
                lblcareerbonus.Text = ds.Tables[0].Rows[0]["careerbonus"].ToString();
                lblstakingbonus.Text = ds.Tables[0].Rows[0]["StakingBonus"].ToString();
                //lblleftbusinesstoday.Text = ds.Tables[0].Rows[0]["lbusinesstoday"].ToString();
                //lblrightbusinesstoday.Text = ds.Tables[0].Rows[0]["rbusinesstoday"].ToString();
                lbldirectbusiness.Text = ds.Tables[0].Rows[0]["DirectBusiness"].ToString();
                lblsponserbusiness.Text = ds.Tables[0].Rows[0]["sponserbusiness"].ToString();
                lblleftbusiness.Text = ds.Tables[0].Rows[0]["lbusiness"].ToString();
                lblrightbusiness.Text = ds.Tables[0].Rows[0]["rbusiness"].ToString();
                lblselfbusiness.Text = ds.Tables[0].Rows[0]["selfbusiness"].ToString();
                lbltotalbusienss.Text = ds.Tables[0].Rows[0]["totalbusiness"].ToString();
                //lblbalanceamount.Text = ds.Tables[0].Rows[0]["balanceamount"].ToString();
                //lblewalletbalance.Text = ds.Tables[0].Rows[0]["ewalletbalance"].ToString();
                Session["ewalletbalance"] = ds.Tables[0].Rows[0]["ewalletbalance"].ToString();
                ((Label)Master.FindControl("lblewalletbalance")).Text = ds.Tables[0].Rows[0]["ewalletbalance"].ToString();
                ((Label)Master.FindControl("lblewalletbalance2")).Text = ds.Tables[0].Rows[0]["ewalletbalance"].ToString();
                lblrijentbalance.Text = ds.Tables[0].Rows[0]["rijentbalance"].ToString();
                lblstakingwallet.Text = ds.Tables[0].Rows[0]["stakingbalance"].ToString();
                lblcoinbalance2.Text = ds.Tables[0].Rows[0]["coinbalance"].ToString();
                lblredeemrtc.Text = ds.Tables[0].Rows[0]["RedeenCoinBal"].ToString();
                //lblrijentbalance.Text = ds.Tables[0].Rows[0]["rijentbalance"].ToString();
                lblbalanceamount2.Text = ds.Tables[0].Rows[0]["balanceamount"].ToString();
                lblredeemedbalance.Text = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["MWalletBalanceRedeem2"].ToString()), 2).ToString();
                lblprevwithdrawlcoin.Text = ds.Tables[0].Rows[0]["todaywithdrawlCoin"].ToString();
                lblconversionrate.Text = ds.Tables[0].Rows[0]["conversionrate"].ToString();


                Session["joiningdate"] = ds.Tables[0].Rows[0]["joiningdate"].ToString();
                Session["activationdate"] = ds.Tables[0].Rows[0]["activationdate"].ToString();


                if (Session["IsPremiumWallet"].ToString() == "1")
                {
                    divPremium.Visible = true;
                    lblpremiumbalance.Text = ds.Tables[0].Rows[0]["PremiumWalletBalance"].ToString();
                }
                else
                {
                    divPremium.Visible = false;
                }
                if (ds.Tables[0].Rows[0]["IsWithdrawalApprove"].ToString() == "1")
                {
                    btnDeposit.Visible = true;
                    btnDepositApprove.Visible = false;

                    btnwithdrawal.Visible = true;
                    btnwithdrawalapprove.Visible = false;
                }
                else
                {
                    btnDeposit.Visible = false;
                    btnDepositApprove.Visible = true;

                    btnwithdrawal.Visible = false;
                    btnwithdrawalapprove.Visible = true;
                }
            }
        }
        //if (ds.Tables[1].Rows[0]["activestatus"].ToString() == "1")
        //{
        //    if (lblmypackage.Text == "499")
        //    {
        //        divroi.Visible = true;
        //    }
        //    else
        //    {
        //        divroi.Visible = false;
        //    }
        //}
        //else
        //{
        //    divroi.Visible = false;
        //}

        //GridView1.DataSource = ds.Tables[2];
        //GridView1.DataBind();
    }

    // void loadcountdata()
    // {
    //     DataTable dt = new DataTable();
    //     objuser.UserId = Session["userid"].ToString();
    //     dt = objuser.getUserDashboardSummary(objuser);
    //     if (dt.Rows.Count > 0)
    //     {
    //         lbltotalteam.Text = dt.Rows[0]["totalteam"].ToString();
    //         lblleftteam.Text = dt.Rows[0]["lcount"].ToString();
    //         lblrightteam.Text = dt.Rows[0]["rcount"].ToString();
    //         lblleftbusiness.Text = dt.Rows[0]["lbusiness"].ToString();
    //         lblleftbusinesstoday.Text = dt.Rows[0]["lbusinesstoday"].ToString();
    //         lblrightbusiness.Text = dt.Rows[0]["rbusiness"].ToString();
    //         lblrightbusinesstoday.Text = dt.Rows[0]["rbusinesstoday"].ToString();
    //     }
    //     else
    //     {
    //         lbltotalteam.Text = "0";
    //         lblleftteam.Text = "0";
    //         lblrightteam.Text = "0";
    //         lblleftbusiness.Text = "0";
    //         lblleftbusinesstoday.Text = "0";
    //         lblrightbusiness.Text = "0";
    //         lblrightbusinesstoday.Text = "0";
    //     }
    // }
    // protected void Timer1_Tick(object sender, EventArgs e)
    // {
    //     this.loadcountdata();
    //     Timer1.Enabled = false;
    //     imgLoader.Visible = false;
    //     imgLoader2.Visible = false;
    //     imgLoader3.Visible = false;
    //     imgLoader4.Visible = false;
    //     imgLoader5.Visible = false;
    //     imgLoader6.Visible = false;
    //     imgLoader7.Visible = false;

    //     lbltotalteam.Visible = true;
    //     lblleftteam.Visible = true;
    //     lblrightteam.Visible = true;
    //     lblleftbusiness.Visible = true;
    //     lblrightbusiness.Visible = true;
    //     lblleftbusinesstoday.Visible = true;
    //     lblrightbusinesstoday.Visible = true;
    // }

    protected void btnDeposit_Click(object sender, EventArgs e)
    {
        //if (Session["userid"].ToString() == "204793")
        //{

        objuser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objuser.getUserSmartContractAddress(objuser);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
            {
                string popupScript = "deposit('" + txtdepositamount.Text + "', '" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
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
        //}

    }
    public string GetIPAddress()
    {
        string ipaddress;
        ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipaddress == "" || ipaddress == null)
            ipaddress = Request.ServerVariables["REMOTE_ADDR"];
        return ipaddress;
    }
    protected void btnDepositApprove_Click(object sender, EventArgs e)
    {
        //if (Session["userid"].ToString() == "204793")
        //{
        //objuser.UserId = Session["userid"].ToString();
        //DataTable dt = new DataTable();
        //dt = objuser.getUserSmartContractAddress(objuser);
        //if (dt.Rows.Count > 0)
        //{
        //    if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
        //    {
        //        string popupScript = "approve('" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
        //        //string popupScript = "approve('" + txtdepositamount.Text + "', '" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
        //        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

        //    }
        //    else
        //    {
        //        string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
        //        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        //    }
        //}
        //else
        //{
        //    string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        //}

        objuser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objuser.getUserSmartContractAddress(objuser);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
            {
                string popupScript = "approve('" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
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
        //}

        //// Store integer 182
        //int intValue = Convert.ToInt32( txtdepositamount.Text);
        //// Convert integer 182 as a hex in a string variable
        //string hexValue = intValue.ToString("X");
        //// Convert the hex string back to the number
        //int intAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);


        //int i = 1;
        //string hex = i.ToString("X");
        //Message.Show(hex.ToString());
    }

    protected void btnwithdrawal_Click(object sender, EventArgs e)
    {

        string currencytype = "";
        decimal dcminlimint = 0.00M;
        decimal dcmaxlimit = 0.00M;
        decimal totalcoin = 0.00M;
        decimal dcRemainingLimit = 0.00M;

            decimal prevwithdrawal = Convert.ToDecimal(lblprevwithdrawlcoin.Text);

        if (Session["userid"].ToString() == "204793")
        {
            decimal prevwithdrawa = 0;
        }
        if (rbwallettype.SelectedValue.ToString() == "Coin")
        {
            if (rbwallettype.SelectedValue != "")
            {
                if (txtwithdrawal.Text != "")
                {

                    if (rbwallettype.SelectedValue.ToString() == "Coin")
                    {
                        //dcminlimint = 10M / Convert.ToDecimal(lblconversionrate.Text);
                        //dcmaxlimit = 1000M / Convert.ToDecimal(lblconversionrate.Text);
                        dcminlimint = 200M;
                        dcmaxlimit = 1000M;
                        totalcoin = Convert.ToDecimal(txtwithdrawal.Text);
                        currencytype = "RTC";
                        dcRemainingLimit = dcmaxlimit - (totalcoin + prevwithdrawal);
                    }
                    else
                    {
                        dcminlimint = 10M;
                        dcmaxlimit = 1000M;
                        totalcoin = Convert.ToDecimal(txtwithdrawal.Text) / Convert.ToDecimal(lblconversionrate.Text);
                        currencytype = "Dollar";
                        dcRemainingLimit = dcmaxlimit - ((totalcoin + prevwithdrawal) * Convert.ToDecimal(lblconversionrate.Text));
                    }



                    //objuser.UserId = Session["userid"].ToString();
                    //DataTable dt = new DataTable();
                    //dt = objuser.getUserSmartContractAddress(objuser);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
                    //    {
                    //        string popupScript = "withdraw('" + txtwithdrawal.Text + "', '" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
                    //        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    //    }
                    //    else
                    //    {
                    //        string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                    //        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    //    }
                    //}
                    //else
                    //{
                    //    string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                    //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    //}
                    if (Convert.ToDecimal(txtwithdrawal.Text) >= dcminlimint)
                    {
                        if (dcRemainingLimit >= 0)
                        {
                            DataTable dt = new DataTable();
                            objuser.UserId = Session["userid"].ToString();
                            objuser.WalletType = rbwallettype.SelectedValue.ToString();
                            dt = objuser.get_CheckBalaneForWithdrawal(objuser);
                            if (Convert.ToDecimal(txtwithdrawal.Text) <= Convert.ToDecimal(dt.Rows[0][0].ToString()))
                            {
                                Random rnd = new Random();
                                string str_otpemail = rnd.Next(100000, 999999).ToString();
                                hdn_OTPEmail.Value = str_otpemail;
                                objuser.OTP = str_otpemail;
                                objuser.UserId = Session["userid"].ToString();
                                objuser.EmailSubject = "Rijent- Withdrawal OTP";
                                objuser.EmailBody = @"Dear User OTP is " + str_otpemail;
                                string res = objuser.SendEmailVerification(objuser);
                                if (res == "t")
                                {

                                    string popupScript = "toastr.success('Success', 'OTP has been Sent To Your Email.');";
                                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                                    string popupScript2 = "showModal();";
                                    ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                                }
                                else
                                {
                                    string popupScript = "toastr.error('Error', 'Unknown Error Occurred');";
                                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                                }
                            }
                            else
                            {
                                string popupScript = "toastr.error('Error', 'User Does Not Have Sofficient Balance');";
                                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                            }

                        }
                        else
                        {
                            string popupScript = "toastr.error('Error', 'Maximum Withdrawal " + dcmaxlimit.ToString() + " " + currencytype + " In a Single Day');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                        }
                    }
                    else
                    {
                        string popupScript = "toastr.error('Error', 'Mininmum Withdrawal " + dcminlimint.ToString() + " " + currencytype + "');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }
                }
                else
                {
                    string popupScript = "toastr.error('Error', 'Enter Withdrawal Amount');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                }
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Select Wallet Type');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }

        else
        {
            string popupScript = "toastr.error('Error', 'Currently Service is Down');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        //}
    }

    protected void btnwithdrawalapprove_Click(object sender, EventArgs e)
    {
        if (rbwallettype.SelectedValue.ToString() == "Coin")
        {
            objuser.UserId = Session["userid"].ToString();
            DataTable dt = new DataTable();
            dt = objuser.getUserSmartContractAddress(objuser);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["SmartContractAddress"].ToString() != "")
                {
                    string popupScript = "approve('" + dt.Rows[0]["SmartContractAddress"].ToString() + "');";
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
        //else
        //{
        //    string popupScript = "toastr.error('Error', 'Service Temprairly Down');";
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

        //}
        else
        {
            string popupScript = "toastr.error('Error', 'Currently Service is Down');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (hdn_OTPEmail.Value.ToString() == txtemailotp.Text)
        {

            objuser.UserId = Session["userid"].ToString();
            objuser.MentionBy = Session["userid"].ToString();
            DataTable dtadd = new DataTable();
            dtadd = objuser.getSmartContactAdd(objuser);
            if (dtadd.Rows[0]["SmartContractAddress"].ToString() != "")
            {
                if (rbwallettype.SelectedValue != "")
                {
                    DataTable dtbal = new DataTable();
                  
                    objuser.WalletType = rbwallettype.SelectedValue.ToString();
                    objuser.Amount = Convert.ToDecimal(txtwithdrawal.Text);
                    dtbal = objuser.insert_WithdrawalIntiate(objuser);
                    if (dtbal.Rows.Count > 0)
                    {
                        if (dtbal.Rows[0][0].ToString() == "t")
                        {
                            //if (Convert.ToDecimal(txtwithdrawal.Text) <= Convert.ToDecimal(dtbal.Rows[0][0].ToString()))
                            //{
                            //objuser.UserId = Session["userid"].ToString();
                            //DataTable dt = new DataTable();
                            //dt = objuser.getUserSmartContractAddress(objuser);
                            //if (dt.Rows.Count > 0)
                            //{
                            if (dtbal.Rows[0]["SmartContractAddress"].ToString() != "")
                            {
                                //decimal dcamount = (Convert.ToDecimal(dtbal.Rows[0]["convertedamount"].ToString()) * 1000000000000000000);
                                decimal dcamount = (Convert.ToDecimal(dtbal.Rows[0]["convertedamount"].ToString()));
                                dcamount = Math.Round(dcamount, 2);

                                string str_adminprivatekey = dtbal.Rows[0]["AdminPrivateKey"].ToString();

                                string str_request = "{\"wallet_address\":\"" + dtbal.Rows[0]["SmartContractAddress"].ToString() + "\",\"amount\":\"" + dcamount.ToString() + "\",\"adminprivatekeynew\":\"" + str_adminprivatekey + "\"}";

                                var client = new RestClient("http://new.teamrijent.in:3004/update_withdrawal/" + dtbal.Rows[0]["transactionid"].ToString());
                                //var client = new RestClient("http://23.81.164.143:3005/update_withdrawal");
                                client.Timeout = -1;
                                var request = new RestRequest(Method.POST);
                                request.AddHeader("Content-Type", "application/json");
                                request.AddParameter("application/json", str_request, ParameterType.RequestBody);
                                IRestResponse response = client.Execute(request);
                                //Console.WriteLine(response.Content);
                                try
                                {
                                    objuser.TransactionId = dtbal.Rows[0]["transactionid"].ToString();
                                    objuser.Request = str_request;
                                    objuser.Response = response.Content;
                                    objuser.MentionBy = Session["userid"].ToString();
                                    objuser.InsertSmartContractRequestResponse(objuser);
                                }
                                catch { }

                                DataSet ds = new DataSet();
                                ds = ConvertJSONToDataSet(response.Content);
                                if (ds.Tables.Count > 0)
                                {
                                    if (ds.Tables[0].Columns.Contains("success"))
                                    {
                                        if (ds.Tables[0].Rows[0]["success"].ToString() == "true")
                                        {
                                            string popupScript = "withdraw('" + txtwithdrawal.Text + "', '" + dtbal.Rows[0]["SmartContractAddress"].ToString() + "','" + rbwallettype.SelectedValue.ToString() + "','" + dtbal.Rows[0]["transactionid"].ToString() + "','" + "new" + "');";
                                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                                            string popupScript2 = "Closepopup();";
                                            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                                        }
                                        else
                                        {
                                            string popupScript2 = "showModal();";
                                            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                                            string popupScript = "toastr.error('Error', 'Unknown Error Occurred');";
                                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                                        }
                                    }
                                    else
                                    {
                                        string popupScript2 = "showModal();";
                                        ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                                        string popupScript = "toastr.error('Error', 'Unknown Error Occurred');";
                                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                                    }
                                }
                                else
                                {
                                    string popupScript2 = "showModal();";
                                    ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                                    string popupScript = "toastr.error('Error', 'Unknown Error Occurred');";
                                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                                }

                            }
                            else
                            {
                                string popupScript2 = "showModal();";
                                ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                                string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                            }
                            //}
                            //else
                            //{
                            //    string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                            //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                            //}
                            //}
                            //else
                            //{
                            //    string popupScript = "toastr.error('Error', 'User Does Not Have Sufficient Balance');";
                            //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                            //}
                        }
                        else if (dtbal.Rows[0][0].ToString() == "b")
                        {
                            string popupScript2 = "showModal();";
                            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                            string popupScript = "toastr.error('Error', 'User Does Not Have Sufficient Balance');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                        }
                        else
                        {
                            string popupScript2 = "showModal();";
                            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                            string popupScript = "toastr.error('Error', 'Unknown Error Occurred');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                        }
                    }

                }
                else
                {
                    string popupScript2 = "showModal();";
                    ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                    string popupScript = "toastr.error('Error', 'Select Wallet Type');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                }


            }
            else
            {
                string popupScript2 = "showModal();";
                ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                string popupScript = "toastr.error('Error', 'Please Update Meta Mask Address');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

            }
        }
        else
        {
            string popupScript2 = "showModal();";
            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            string popupScript = "toastr.error('Error', 'Invalid OTP');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }

    DataSet ConvertJSONToDataSet(string Resp)
    {
        DataSet jsonDataSet = new DataSet();
        try
        {
            //Resp = Resp.Replace("{", "[{");
            //Resp = Resp.Replace("}", "}]");
            //DataSet myDataSet = JsonConvert.DeserializeObject<DataSet>(Resp);
            //return myDataSet;
            XmlDocument xd1 = new XmlDocument();
            xd1 = (XmlDocument)JsonConvert.DeserializeXmlNode(Resp, "root");

            jsonDataSet.ReadXml(new XmlNodeReader(xd1));
        }
        catch { }
        return jsonDataSet;
    }
    protected void rbwallettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbwallettype.SelectedValue == "MWallet")
        {
            lblwithdrawaltext.Text = "Enter Amount ($)";
        }
        else
        if (rbwallettype.SelectedValue == "Coin")
        {
            lblwithdrawaltext.Text = "Enter No Of RTC";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var client = new RestClient("http://api.teamrijent.in:3005/readfile");
        //var client = new RestClient("http://23.81.164.143:3005/readfile");
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        request.AddHeader("Content-Type", "application/json");
        //request.AddParameter("application/json", str_request, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);

        //lblreadfileresponse.Text = response.Content.ToString();

    }
}