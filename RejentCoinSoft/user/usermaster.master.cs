using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicTier;
using System.Data;

public partial class admin_MasterPage : System.Web.UI.MasterPage
{
    clsUser objuser = new clsUser();
    clsNews objnews = new clsNews();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Control myControl1 = FindControl("txtwallet");
        //if (myControl1 != null)
        //{
        //    myControl1.Controls.Add() = "";
        //    myControl1.CssClass = "";
        //}
        if (!IsPostBack)
        {
            if (Session["userid"] == null)
                Server.Transfer("logout.aspx");

            else
            {
                
                lbluseridmaster.Text = Session["username"].ToString() + "(" + Session["userid"].ToString() + ")";
                lbluseridmaster2.Text =  Session["userid"].ToString() ;
                lbljoiningdate.Text =  Session["joiningdate"].ToString() ;
                lblactivationdate.Text =  Session["activationdate"].ToString();
                lblactivationamount.Text =  Session["lastactivationamount"].ToString();
                lbllevelnamemaster.Text =  Session["levelname"].ToString();
                lblewalletbalance.Text =  Session["ewalletbalance"].ToString();
                lblewalletbalance2.Text =  Session["ewalletbalance"].ToString();

                lblreferencelinkleft.Text = @"<a style=""white-space: nowrap;"" href='http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1' target='_blank'>http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1</a>";
                lblreferencelinkright.Text = @"<a style=""white-space: nowrap;"" href='http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2' target='_blank'>http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2</a>";

                lbllinkleft.Text = @"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1";
                lbllinkright.Text = @"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2";

                ltwhatsapplinkleft.Text = @"<a href=""https://api.whatsapp.com/send?phone=91&text=" + HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1") + @""" target=""_blank"" style=""color:white;""> <i class=""fa fa-whatsapp""></i></a>";
                ltwhatsapplinkright.Text = @"<a href=""https://api.whatsapp.com/send?phone=91&text=" + HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2") + @""" target=""_blank"" style=""color:white;""> <i class=""fa fa-whatsapp""></i></a>";



                ltfacebookshareleft.Text = @"<a href=""http://www.facebook.com/sharer.php?u=" + HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1") + @""" style=""color:white;"" target=""_blank""><i class=""fa fa-facebook""></i></a>";
                ltfacebookshareright.Text = @"<a href=""http://www.facebook.com/sharer.php?u=" + HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2") + @""" style=""color:white;"" target=""_blank""><i class=""fa fa-facebook""></i></a>";

                if (Session["IsPremiumWallet"].ToString() == "1")
                {
                    lipremiumwallet.Visible = true;
                }
                else
                {
                    lipremiumwallet.Visible = false;
                }
                loadrenewstatus();
                loadnews();
                WalletColor1();

                //Response.ClearHeaders();
                //Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                //Response.AddHeader("Pragma", "no-cache");
            }
        }
    }
    void loadnews()
    {
        DataTable dt = new DataTable();
        dt = objnews.getRecentNews();
       
            foreach (DataRow r in dt.Rows)
            {
                ltnews.Text += r["newsdetail"].ToString() + @"  &nbsp;&nbsp;&nbsp;&nbsp;<i class=""fas fa-dot-circle""></i>&nbsp;&nbsp;&nbsp;&nbsp;";
            }
      

    }
    void WalletColor1()
    {

        DataTable dtadd = new DataTable();
        dtadd = objuser.getSmartContactAdd(objuser);
        if (dtadd.Rows[0]["SmartContractAddress"].ToString() != "")
        {
            add.Attributes["style"] = "visibility:visible; margin-right:55px";
            //lbladd1.Attributes["Text"] = dtadd.Rows[0]["SmartContractAddress"].ToString();
            lbladd1.Text = "Smart Contract Address: "+ dtadd.Rows[0]["SmartContractAddress"].ToString();
            licolor.Attributes["style"] = "background-color: #66ff66; color: #fff";
        }
        else
        {
            add.Attributes["style"] = "visibility:hidden";
            licolor.Attributes["style"] = "background-color: #d22d3d !important; color: #fff; ";
        }
            
    }
    void loadrenewstatus()
    {
        objuser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objuser.get_RenewStatus(objuser);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["renewstatus"].ToString() == "1")
            {
                btnRenew.Visible = true;
            }
            else
            {
                btnRenew.Visible = false;
            }
        }
        else
        {
            btnRenew.Visible = false;
        }
    }
    //protected void btnCallbackSubmit_Click(object sender, EventArgs e)
    //{
    //    if (txtcallbackmobile.Text != "")
    //    {
    //        objuser.UserId = Session["userid"].ToString();
    //        objuser.Mobile = txtcallbackmobile.Text;
    //        objuser.MentionBy = Session["userid"].ToString();
    //        string res = objuser.InsertCallbackRequest(objuser);
    //        if (res == "t")
    //        {
    //            txtcallbackmobile.Text = "";
    //            Message.Show("Request Added Successfully...");
    //        }
    //        else
    //        {
    //            Message.Show("Unknown Error Occurred...");
    //        }
    //    }
    //    else
    //    {
    //        Message.Show("Enter Mobile No");
    //    }
    //}

    protected void btnRenew_Click(object sender, EventArgs e)
    {
        Server.Transfer("UserRetopup.aspx");
    }
}
