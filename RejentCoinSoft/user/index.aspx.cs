using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicTier;
using System.Data.SqlClient;
using System.Data;
using System.Net;

public partial class admin_index : System.Web.UI.Page
{
    clsLogin objlogin = new clsLogin();
    clsUser objuser = new clsUser();
    clsNews objnews = new clsNews();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadoffer();
        }
    }
    void loadoffer()
    {
        DataTable dt = new DataTable();
        dt = objnews.getBeforeLoginOffer();
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
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            objlogin.username = txtusername.Text;
            objlogin.password = txtpassword.Text;
            objlogin.IpAddress = GetIPAddress();

            DataTable dt = new DataTable();
            dt = objlogin.Chk_UserLoginDetails(objlogin);
            if (dt.Rows.Count > 0)
            {
                HttpContext.Current.Session["userid"] = txtusername.Text;
                HttpContext.Current.Session["username"] = dt.Rows[0]["username2"].ToString();
                HttpContext.Current.Session["useremail"] = dt.Rows[0]["email"].ToString();
                HttpContext.Current.Session["usermobile"] = dt.Rows[0]["mobile"].ToString();
                HttpContext.Current.Session["joiningdate"] = dt.Rows[0]["joiningdate"].ToString();
                HttpContext.Current.Session["activationdate"] = dt.Rows[0]["activationdate"].ToString();
                HttpContext.Current.Session["levelname"] = dt.Rows[0]["levelname"].ToString();
                HttpContext.Current.Session["IsPremiumWallet"] = dt.Rows[0]["IsPremiumWallet"].ToString();
                HttpContext.Current.Session["Loginflag"] = dt.Rows[0]["LoginFlag2"].ToString();
                HttpContext.Current.Session["lastactivationamount"] = dt.Rows[0]["lastactivationamount"].ToString();
                HttpContext.Current.Session["ewalletbalance"] = dt.Rows[0]["ewalletbalance"].ToString();

                if (dt.Rows[0]["LoginFlag2"].ToString() == "1")
                {
                    Server.Transfer("Dashboard.aspx");
                }
                else {
                    //string popupScript2 = "showModalOTP();";
                    //ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                    Random rnd = new Random();
                    string str_otpemail = rnd.Next(100000, 999999).ToString();
                    objuser.OTP = str_otpemail;
                    objuser.UserId = Session["userid"].ToString();
                    objuser.EmailSubject = "Rijent- Set Password OTP";
                    objuser.EmailBody = @"Dear User OTP is " + str_otpemail;
                    string res = objuser.SendEmailVerification(objuser);
                    if (res == "t")
                    { 
                        string popupScript = "toastr.success('Success', 'OTP has been Sent To Your Email.');";
                        ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                        string popupScript2 = "showModal();";
                        ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);

                        Session["resetuserid"] = txtusername.Text;
                        Session["resetotp"] = str_otpemail;
                        Server.Transfer("SetPassword.aspx");
                    }
                    else
                    {
                        string popupScript = "toastr.error('Error', 'Unknown Error Occurred');";
                        ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }


                 
                }
            }
            else
            {
                Message.Show("Invalid Login Details...!!!");
            }
        }
        catch (Exception ep)
        {
            Message.Show("Invalid Login Details");
        }
    }
    public string GetIPAddress()
    {
        string ipaddress;
        ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipaddress == "" || ipaddress == null)
            ipaddress = Request.ServerVariables["REMOTE_ADDR"];
        return ipaddress;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        objuser.UserId = txtuserid.Text;
        string res = objuser.SendPassword(objuser);
        if (res == "0")
        {
            Message.Show("Error Occurred");
        }
        else
            if (res == "f")
        {
            Message.Show("Invalid User Id");
        }
        else
        {
            Message.Show("Password sent to your registered email.");
        }
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        //lblmessage.Text = "sgdsgsd";

        string popupScript2 = "Closepopup();";
        ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);

    }

    protected void btnUpdatepassword_Click(object sender, EventArgs e)
    {

    }
}