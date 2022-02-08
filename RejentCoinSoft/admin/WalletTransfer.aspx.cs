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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rijentadmin45852_4"] != null)
        {

        }
        else
        {
            Server.Transfer("index.aspx");
        }
    }


    void loadtransferusername()
    {
        DataTable dt = new DataTable();
        objUser.UserId = txttransferuserid.Text;
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
        if (txttransferuserid.Text != "")
        {
            if (txtamount.Text != "")
            {
                string str_remark = "";
                if (txtremark.Text != "")
                {
                    str_remark = txtremark.Text;
                }
                else
                {
                    str_remark = "Amount credited by admin";
                }
                objUser.UserId =Session["rijentadmin45852_4"].ToString();
                objUser.TransferUserId = txttransferuserid.Text;
                objUser.Amount = Convert.ToDecimal(txtamount.Text);
                objUser.Remark = str_remark;
                objUser.MentionBy = Session["rijentadmin45852_4"].ToString();
                string rs = objUser.WalletTransferAdmin(objUser);
                if (rs == "t")
                {
                    Message.Show("Amount Transferred Successfully...!!!");
                    txttransferuserid.Text = "";
                    txttransferusername.Text = "";
                    txtamount.Text = "";
                    txtremark.Text = "";
                }
                else
                    if (rs == "f")
                    {
                        Message.Show("Invalid Transfer User Id...!!!");
                    }
                    else
                        if (rs == "n")
                        {
                            Message.Show("User do not have sufficient E-Pins...!!!");
                        }
                        else
                        {
                            Message.Show("Unknown Error Occurred...!!!");
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