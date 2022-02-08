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
            txtuserid.Text = Session["userid"].ToString();
            txtusername.Text = Session["username"].ToString();
            loadbalance();
            fillform();
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
            lblqauerecoinrate.Text = dt.Rows[0]["qaurecointodollar"].ToString();

        }
    }
    void loadbalance()
    {
        //objUser.UserId = Session["userid"].ToString();
        //DataTable dt = new DataTable();
        //dt = objUser.getUserDetail(objUser);
        //if (dt.Rows.Count > 0)
        //{
        //    lbluserbalance.Text = dt.Rows[0]["balanceamount"].ToString();
        //}
        //else
        //{
        //    lbluserbalance.Text = "0.00";
        //}


        objaccount.UserId = Session["userid"].ToString();
        DataTable dtbalnce = new DataTable();
        dtbalnce = objaccount.getAccountBalanceForGetHelp(objaccount);
        if (dtbalnce.Rows.Count > 0)
        {
            lbluserbalance.Text = dtbalnce.Rows[0][0].ToString();
        }
        else
        {
            lbluserbalance.Text = "0";
        }

    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtamount.Text) >= 10.00M)
        {
            if (Convert.ToDecimal(txtamount.Text) <= Convert.ToDecimal(lbluserbalance.Text))
            {
                if (Convert.ToDecimal(txtamount.Text) % 10 == 0)
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
                            str_remark = "Amount credited from E  Wallet To M Wallet";
                        }
                        objUser.UserId = Session["userid"].ToString();
                        objUser.Amount = Convert.ToDecimal(txtamount.Text);
                        objUser.ConvertedAmount = Convert.ToDecimal(txtconvertedcoin.Text);
                        objUser.Remark = str_remark;
                        objUser.MentionBy = Session["userid"].ToString();
                        string rs = objUser.MWalletToEWalletTransfer(objUser);
                        if (rs == "t")
                        {
                            //  Message.Show("");
                            string popupScript = "toastr.success('Success', 'Amount Transferred Successfully...!!!');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                            txtconvertedcoin.Text = "";
                            txtamount.Text = "";
                            txtremark.Text = "";
                            loadbalance();
                        }
                        else
                            if (rs == "f")
                        {
                            string popupScript = "toastr.error('Error', 'Invalid Transfer User Id');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                          //  Message.Show("Invalid Transfer User Id...!!!");
                        }
                        else
                                if (rs == "b")
                        {
                            string popupScript = "toastr.error('Error', 'Invalid User Id');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                           // Message.Show("User do not have sufficient Balance...!!!");
                        }
                        else
                                    if (rs == "b")
                        {
                            string popupScript = "toastr.error('Error', 'Invalid From User Id...!!!');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                           // Message.Show("");
                        }
                        else
                        {
                            string popupScript = "toastr.error('Error', 'Unknown Error Occurred...!!');";
                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                           // Message.Show("!");
                        }
                    }

                    else
                    {
                        string popupScript = "toastr.error('Error', 'Enter amount...!!!');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                      //  Message.Show("");
                    }
                }
                else
                {
                    string popupScript = "toastr.error('Error', 'Transfer Amount Must Be in multiple of 10...!!!');";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                  //  Message.Show("");
                }
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Transfer amount should be less than balance amount...!!!');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
               // Message.Show("");
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Transfer Amount Must Be Greater Than 10...!!!');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
          //  Message.Show("");
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
            decimal dcQuareToDollar = Convert.ToDecimal(lblqauerecoinrate.Text);
            txtconvertedcoin.Text = Math.Round( (Convert.ToDecimal(txtamount.Text) / dcQuareToDollar),2).ToString();
        }
    }
}