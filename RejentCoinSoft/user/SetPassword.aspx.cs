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
            if (Session["resetotp"] == null)
            {
                Server.Transfer("index.aspx");
            }
        }
    }
  
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtotp.Text == Session["resetotp"].ToString())
            {
                objlogin.username = Session["resetuserid"].ToString();
                objlogin.password = txtconfirmpassword.Text;
                string res = objlogin.SetPasswordLogin(objlogin);
                if (res == "t")
                {
                    Server.Transfer("Dashboard.aspx");
                }
            }
            else
            {
                Message.Show("Invalid OTP");
            }
        }
        catch (Exception ep)
        {
            Message.Show("Unknown Error occurred");
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
 
}