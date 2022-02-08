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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            txtuserid.Text = Session["userid"].ToString();
            txtusername.Text = Session["username"].ToString();
            loadbalance();
        }
        else
        {
            Server.Transfer("index.aspx");
        }
    }
    void loadbalance()
    {
        objaccount.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objaccount.getUserWalletBalance(objaccount);
        if (dt.Rows.Count > 0)
        {
            txtbalance.Text = dt.Rows[0]["coinbalance"].ToString();
            lbluserbalance.Text = dt.Rows[0]["coinbalance"].ToString();
        }
        else
        {
            txtbalance.Text = "0.00";
            lbluserbalance.Text = "0.00";
        }
    }

    void loadtransferusername()
    {
        DataTable dt = new DataTable();
        objUser.UserId = txttransferuserid.Text;
        objUser.TransferUserId = txttransferuserid.Text;
        dt = objUser.getUserName(objUser);
        if (dt.Rows.Count > 0)
        {
            txttransferusername.Text = dt.Rows[0]["username"].ToString();
        }
        else
        {
            txttransferusername.Text = "";
            txttransferuserid.Text = "";
            Message.Show("Invalid User Id...!!!");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if (Convert.ToDecimal(txtamount.Text) >= 500.00M)
        //{
        if (txttransferuserid.Text != "")
        {
            if (txtamount.Text != "")
            {
                if (Convert.ToDecimal(txtamount.Text) >= 10M)
                {
                    //if (Convert.ToDecimal(txtamount.Text) % 100 == 0)
                    //{
                        string str_remark = "";
                        if (txtremark.Text != "")
                        {
                            str_remark = txtremark.Text;
                        }
                        else
                        {
                            str_remark = "Amount credited by " + Session["userid"].ToString() + " to " + txttransferuserid.Text;
                        }
                        objUser.UserId = Session["userid"].ToString();
                        objUser.TransferUserId = txttransferuserid.Text;
                        objUser.Amount = Convert.ToDecimal(txtamount.Text);
                     
                        objUser.Remark = str_remark;
                        objUser.MentionBy = Session["userid"].ToString();
                        string rs = objUser.WalletTransferUser(objUser);
                        if (rs == "t")
                        {
                        string popupScript = "toastr.success('Success', 'Coin Transferred Successfully');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                        txttransferuserid.Text = "";
                            txttransferusername.Text = "";
                            txtamount.Text = "";
                            txtremark.Text = "";
                            loadbalance();
                        }
                        else
                            if (rs == "f")
                        {
                        string popupScript = "toastr.error('Error', 'Invalid Transfer User Id');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }
                        else
                                if (rs == "b")
                        {
                        string popupScript = "toastr.error('Error', 'User does not have sufficient balance');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }
                        else
                                    if (rs == "u")
                        {
                        string popupScript = "toastr.error('Error', 'Invalid From Uer id');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }
                        else
                        {
                        string popupScript = "toastr.error('Error', 'Unknown Error Occurred');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }
                    //}
                    //else
                    //{
                    //    Message.Show("Withdrwal Amount Must Be in multiple of 100...!!!");
                    //}
                }
                else
                {
                    Message.Show("Minimum Transfer amount 10...!!!");
                }
            }
            else
            {
                Message.Show("Enter amount...!!!");
            }
        }
        else
        {
            Message.Show("Enter transfer user id...!!!");
        }
        //}
        //else
        //{
        //    Message.Show("Withdrwal Amount Must Be Greater Than 500...!!!");
        //}
    }
    protected void txttransferuserid_TextChanged(object sender, EventArgs e)
    {
        loadtransferusername();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("dashboard.aspx");
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
}