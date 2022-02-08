using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using BusinessLogicTier;

public partial class admin_EPinAdd : System.Web.UI.Page
{

    clsUser objUser = new clsUser();
    clsAccount objaccount = new clsAccount();
    clsSetting objsetting = new clsSetting();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (!IsPostBack)
            {

                loadbalance();
                loadtenure();
                loadwallettype();
                fillform();

            }
        }
        else
        {
            Server.Transfer("index.aspx");
        }
    }
    void loadwallettype()
    {
        ddwallettype.Items.Clear();
        DataTable dt = new DataTable();
        dt = objUser.getBTCWalletTypeActive();
        ddwallettype.DataSource = dt;
        ddwallettype.DataTextField = "wallettype";
        ddwallettype.DataValueField = "id";
        ddwallettype.DataBind();
        ListItem li = new ListItem("Select Wallet Type", "0");
        ddwallettype.Items.Insert(0, li);
    }
    void loadwallettaddress()
    {
        objUser.WalletTypeId = ddwallettype.SelectedValue.ToString();
        ddwalletaddress.Items.Clear();
        DataTable dt = new DataTable();
        dt = objUser.getBTCWalletAddressByType(objUser);
        ddwalletaddress.DataSource = dt;
        ddwalletaddress.DataTextField = "walletaddress";
        ddwalletaddress.DataValueField = "id";
        ddwalletaddress.DataBind();
        ListItem li = new ListItem("Select Wallet Address", "0");
        ddwalletaddress.Items.Insert(0, li);



    }
    void loadwallettaddressDetail()
    {
        objUser.WalletAddressId = ddwalletaddress.SelectedValue.ToString();

        DataTable dt = new DataTable();
        dt = objUser.getBTCWalletAddressDetail(objUser);
        if (dt.Rows.Count > 0)
        {
            ltimage.Text = @"<img src=""../admin/userimage/" + dt.Rows[0]["imagename"].ToString() + @""" style=""width:100%;"" />";
        }
        else
        {
            ltimage.Text = "";
        }



    }
    void fillform()
    {
        DataTable dt = new DataTable();
        dt = objsetting.GetSystemSettings();
        if (dt.Rows.Count > 0)
        {

            lblqauretodollar.Text = dt.Rows[0]["QaureCoinToDollar"].ToString();
        }
    }
    void loadtenure()
    {
        ddtenure.Items.Clear();
        DataTable dt = new DataTable();
        dt = objUser.getTenure();
        ddtenure.DataSource = dt;
        ddtenure.DataTextField = "Tenure";
        ddtenure.DataValueField = "Tenure";
        ddtenure.DataBind();
        ListItem li = new ListItem("Select Tenure", "0");
        ddtenure.Items.Insert(0, li);
    }

    void loadbalance()
    {
        objaccount.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objaccount.getUserWalletBalance(objaccount);
        //if (dt.Rows.Count > 0)
        //{
        //    lbluserbalance.Text = dt.Rows[0][0].ToString();
        //}
        //else
        //{
        //    lbluserbalance.Text = "0.00";
        //}
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtamount.Text != "")
        {
            if (Convert.ToDecimal(txtamountindollar.Text) >= 25.00M)
            {
                objUser.UserId = Session["userid"].ToString();
                objUser.Amount = Convert.ToDecimal(txtamount.Text);
                objUser.WalletAddressId = ddwalletaddress.SelectedValue.ToString();
                objUser.DollarAmount = Convert.ToDecimal(txtamountindollar.Text);
                objUser.QaureCoinToDollar = Convert.ToDecimal(lblqauretodollar.Text);
                objUser.Tenure = Convert.ToInt32(ddtenure.SelectedValue.ToString());
                objUser.Remark = txtremark.Text;
                objUser.OnlineTransactionId = txttransactionid.Text;
                objUser.MentionBy = Session["userid"].ToString();
                string rs = objUser.InsertStacking(objUser);
                if (rs == "t")
                {
                    string popupScript = "toastr.success('Success', 'Staking Request Added Successfully');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    txtremark.Text = "";
                    txtamount.Text=txtamountindollar.Text = "";
                    txttransactionid.Text = "";
                    ddtenure.SelectedValue =ddwallettype.SelectedValue= "0";
                    loadwallettaddress();
                    ltimage.Text = "";

                }
                else if (rs == "f")
                {
                    string popupScript = "toastr.error('Error', 'There is already a pending staking request');";
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
                string popupScript = "toastr.error('Error', 'Minimum Staking Amount is 25 $...!!!');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                
            }
        }
        else
        {
            Message.Show("Enter amount...!!!");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("dashboard.aspx");
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }


    protected void txtamount_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtamount.Text) > 0.00M)
        {
            decimal dcQuareToDollar = Convert.ToDecimal(lblqauretodollar.Text);
            txtamountindollar.Text = (Convert.ToDecimal(txtamount.Text) * dcQuareToDollar).ToString();
        }
    }

    protected void ddwallettype_SelectedIndexChanged(object sender, EventArgs e)
    {
        ltimage.Text = "";
        loadwallettaddress();
    }

    protected void ddwalletaddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadwallettaddressDetail();
    }
}