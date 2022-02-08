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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (!IsPostBack)
            {
                txtuserid.Text = Session["userid"].ToString();
                txtuserid.Enabled = false;
                loadsusername();

                loadwallettype();
            }
        }
        else
        {
            Server.Transfer("index.aspx");
        }
    }
    void loadwallettype()
    {
        objUser.WalletType = rbdepositwallet.SelectedValue.ToString();
        ddwallettype.Items.Clear();
        DataTable dt = new DataTable();
        dt = objUser.getBTCWalletTypeActive2(objUser);
        ddwallettype.DataSource = dt;
        ddwallettype.DataTextField = "wallettype";
        ddwallettype.DataValueField = "id";
        ddwallettype.DataBind();
        ListItem li = new ListItem("Select Wallet Type", "0");
        ddwallettype.Items.Insert(0, li);
    }
    void loadwallettaddress()
    {
        objUser.UserId = Session["userid"].ToString();
        objUser.WalletTypeId = ddwallettype.SelectedValue.ToString();
        ddwalletaddress.Items.Clear();
        DataTable dt = new DataTable();
        dt = objUser.getBTCWalletAddressByType(objUser);
        ddwalletaddress.DataSource = dt;
        ddwalletaddress.DataTextField = "Walletaddress2";
        ddwalletaddress.DataValueField = "id";
        ddwalletaddress.DataBind();
        //ListItem li = new ListItem("Select Wallet Address", "0");
        //ddwalletaddress.Items.Insert(0, li);

        if (dt.Rows.Count > 0)
        {
            lblconversionrate.Text = dt.Rows[0]["ConversionToDollar"].ToString();
            //txtconversiontoqauere.Text = dt.Rows[0]["conversiontoqauere"].ToString();
            lblconversiontoqauere.Text = dt.Rows[0]["conversiontoqauere"].ToString();
            loadwallettaddressDetail();
        }
        else
        {
            lblconversionrate.Text = "0";
            //  txtconversiontoqauere.Text = "0";
            lblconversiontoqauere.Text = "0";
        }

    }
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

        decimal minlimit = 0.00M;
        decimal maxlimit = 0.00M;
        if (rbdepositwallet.SelectedValue.ToString() == "EWallet")
        {
            minlimit = Convert.ToDecimal("10");
            maxlimit = Convert.ToDecimal("5000");
        }
        else
             if (rbdepositwallet.SelectedValue.ToString() == "Coin")
        {
            minlimit = Convert.ToDecimal("10") / Convert.ToDecimal(lblconversionrate.Text);
            maxlimit = Convert.ToDecimal("5000") / Convert.ToDecimal(lblconversionrate.Text);
        }

        int hour = 0;
        hour = System.DateTime.Now.Hour;
        //Message.Show(hour.ToString());
        //if (hour >= 11 && hour < 13)
        //{
        if (txtuserid.Text != "")
        {
            if (txtusername.Text != "")
            {
                if (txtamount.Text != "")
                {

                    if (Convert.ToDecimal(txtconvertedamount.Text) >= minlimit)
                    {
                        //if (Convert.ToDecimal(txtamount.Text) % 10.00M == 0)
                        //{
                        if (Convert.ToDecimal(txtconvertedamount.Text) <= maxlimit)
                        {
                            //if (Convert.ToDecimal(txtamount.Text) % 200 == 0)
                            //{
                            objUser.Amount = Convert.ToDecimal(txtamount.Text);

                            objUser.ConversionRate = Convert.ToDecimal(lblconversiontoqauere.Text);
                            objUser.ConvertedAmount = Convert.ToDecimal("0");
                            objUser.WalletTypeId = ddwallettype.SelectedValue.ToString();
                            objUser.WalletAddressId = ddwalletaddress.SelectedValue.ToString();
                            objUser.WalletAddress = ddwalletaddress.SelectedItem.ToString();
                            objUser.OnlineTransactionId = txtonlinetransactionid.Text;
                            objUser.MentionBy = Session["userid"].ToString();
                            objUser.UserId = Session["userid"].ToString();
                            objUser.DepositWalletType = rbdepositwallet.SelectedValue.ToString();
                            string rs = objUser.InsertFundRequest(objUser);
                            if (rs == "t")
                            {
                                string popupScript = "toastr.success('Success', 'Fund Request Added Successfully');";
                                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                                txtamount.Text = "";
                                loadsusername();
                                txtonlinetransactionid.Text = lblconversionrate.Text = "";
                            }
                            else if (rs == "f")
                            {
                                string popupScript = "toastr.error('Error', 'You can not add fund request there is already a pending fund request');";
                                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                            }
                            else if (rs == "o")
                            {
                                string popupScript = "toastr.error('Error', 'Transation Id already exists');";
                                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                            }
                            else
                            {
                                string popupScript = "toastr.error('Error', 'Unknown error occurred');";
                                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                            }
                            //}
                            //else
                            //{
                            //    Message.Show("Withdrwal Amount Must Be in multiple of 200...!!!");
                            //}
                        }
                        else
                        {
                            string popupScript = "toastr.error('Error', 'Fund Request Amount Must Be Less Than "+ maxlimit.ToString() + "...!!!');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

                        }
                        //}
                        //else
                        //{
                        //    string popupScript = "toastr.error('Error', 'Fund Request Amount Must Be Multiple Of 10$...!!!');";
                        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

                        //}
                    }
                    else
                    {
                        string popupScript = "toastr.error('Error', 'Fund Amount Must Be Greater Than "+minlimit.ToString()+"$...!!!');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

                    }

                }
                else
                {
                    string popupScript = "toastr.error('Error', 'Enter Amount...!!!');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

                }
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Enter User Name...!!!');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Enter User Id...!!!');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

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
        //if (txtamount.Text != "")
        //{

        //    decimal dcconversionRate = 0.00M;
        //    if (txtconversiontoqauere.Text != "0")
        //    {
        //        dcconversionRate = Convert.ToDecimal(lblconversiontoqauere.Text);
        //    }

        //    txtconvertedamount.Text = (Convert.ToDecimal(txtamount.Text) * dcconversionRate).ToString();
        //}
        //else
        //{

        //}
    }

    protected void ddwallettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadwallettaddress();

        if (ddwallettype.SelectedValue.ToString() != "0")
        {
            lblwallettype.Text = ddwallettype.SelectedItem.ToString();
            //  lblwallettype2.Text = ddwallettype.SelectedItem.ToString();
        }
        else
        {
            lblwallettype.Text = "";
            //  lblwallettype2.Text = "";
        }

        txtamount.Text = "";
        calculateAmount();

    }
    void loadwallettaddressDetail()
    {
        objUser.WalletAddressId = ddwalletaddress.SelectedValue.ToString();

        DataTable dt = new DataTable();
        dt = objUser.getBTCWalletAddressDetail(objUser);
        if (dt.Rows.Count > 0)
        {
            ltimage.Text = @"<img src=""../admin/userimage/" + dt.Rows[0]["imagename"].ToString() + @""" style=""width:100%;"" />";
            lbladdress.Text = ddwalletaddress.SelectedItem.ToString();

            ltcopybutton.Text = @"<a onclick=""copyaddress('" + ddwalletaddress.SelectedItem.ToString() + @"')"" class=""btn btn-primary btn-sm""'><i class=""fa fa-copy""></i></a>";

            txtdepositaccountno.Text = dt.Rows[0]["accountno"].ToString();
            txtaccountholdername.Text = dt.Rows[0]["AccountHolderName"].ToString();
            txtdepositbank.Text = dt.Rows[0]["BankName"].ToString();
            txtifsccode.Text = dt.Rows[0]["IFSCCode"].ToString();
            txtbranchname.Text = dt.Rows[0]["BranchName"].ToString();

            if (dt.Rows[0]["accountno"].ToString() == "")
            {
                pnlAccountDetail.Visible = false;
            }
            else
            {
                pnlAccountDetail.Visible = true;
            }

        }
        else
        {
            ltimage.Text = "";
            lbladdress.Text = "";

            txtdepositaccountno.Text = "";
            txtaccountholdername.Text = "";
            txtdepositbank.Text = "";
            txtifsccode.Text = "";
            txtbranchname.Text = "";
            pnlAccountDetail.Visible = false;
        }



    }
    protected void ddwalletaddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadwallettaddressDetail();
    }

    protected void rbdepositwallet_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadwallettype();
        calculateAmount();

        if (rbdepositwallet.SelectedValue.ToString() == "EWallet")
        {
            lbldepositwallet.Text = "USDT";
        }
        else if (rbdepositwallet.SelectedValue.ToString() == "Coin")
        {
            lbldepositwallet.Text = "RTC";
        }

    }

    protected void txtamount_TextChanged1(object sender, EventArgs e)
    {
        calculateAmount();
    }
    void calculateAmount()
    {
        if (txtamount.Text != "")
        {

            if (rbdepositwallet.SelectedValue == "EWallet")
            {
                decimal dcconversionrate = Convert.ToDecimal(lblconversionrate.Text);
                decimal dcconvertedamount = dcconversionrate * Convert.ToDecimal(txtamount.Text);

                txtconvertedamount.Text = dcconvertedamount.ToString();
            }
            else if (rbdepositwallet.SelectedValue == "Coin")
            {
                txtconvertedamount.Text = txtamount.Text;
            }


        }
        else
        {
            txtconvertedamount.Text = "";
        }
    }
}