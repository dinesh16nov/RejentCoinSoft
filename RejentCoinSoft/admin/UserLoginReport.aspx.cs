using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class admin_UserReport : System.Web.UI.Page
{
    clsState objState = new clsState();
    clsUser objUser = new clsUser();
    clsLogin objlogin = new clsLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
               
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
   
    void loaduser()
    {
        objUser.UserName = txtname.Text;
        objUser.Mobile = txtmobile.Text;
        objUser.UserId = txtuserid.Text;
        
        if (txtfromdate.Text != "")
        {
            objUser.FromDate = Message.GetIndianDate(txtfromdate.Text);
        }
        else
        {
            objUser.FromDate = DateTime.MinValue;
        }
        if (txttodate.Text != "")
        {
            objUser.ToDate = Message.GetIndianDate(txttodate.Text);
        }
        else
        {
            objUser.ToDate = DateTime.MinValue;
        }
        DataTable dt = new DataTable();
        dt = objUser.getLoginReport(objUser);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "myactive")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lbluserid = (Label)GridView1.Rows[index].FindControl("lbluserid");
            objUser.UserId = lbluserid.Text;
            objUser.User_Activate(objUser);
            loaduser();
           
        }
        else
            if (e.CommandName == "mydeactive")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label lbluserid = (Label)GridView1.Rows[index].FindControl("lbluserid");
                objUser.UserId = lbluserid.Text;
                objUser.User_Deactivate(objUser);
                loaduser();

            }
        else if (e.CommandName == "mylogin")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lbluserid = (Label)GridView1.Rows[index].FindControl("lbluserid");
            Label lblpassword = (Label)GridView1.Rows[index].FindControl("lblpassword");
            objlogin.username = lbluserid.Text;
            objlogin.password = lblpassword.Text;

            objlogin.IpAddress = GetIPAddress();

            DataTable dt = new DataTable();
            dt = objlogin.Chk_UserLoginDetails(objlogin);
            if (dt.Rows.Count > 0)
            {
                //Session["userid"] = lbluserid.Text;
                //Session["username"] = dt.Rows[0]["username2"].ToString();
                //Session["useremail"] = dt.Rows[0]["email"].ToString();
                //Session["usermobile"] = dt.Rows[0]["mobile"].ToString();

                HttpContext.Current.Session["userid"] = lbluserid.Text;
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
                    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page),
                  "click", @"<script>window.open('../user/Dashboard.aspx','_newtab');</script>", false);
                }
                else
                {
                    //string popupScript2 = "showModalOTP();";
                    //ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                    Random rnd = new Random();
                    string str_otpemail = rnd.Next(100000, 999999).ToString();
                    objUser.OTP = str_otpemail;
                    objUser.UserId = HttpContext.Current.Session["userid"].ToString();
                    objUser.EmailSubject = "Rijent- Set Password OTP";
                    objUser.EmailBody = @"Dear User OTP is " + str_otpemail;
                    string res = objUser.SendEmailVerification(objUser);
                    if (res == "t")
                    {
                        string popupScript = "toastr.success('Success', 'OTP has been Sent To Your Email.');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                        string popupScript2 = "showModal();";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);

                        HttpContext.Current.Session["resetuserid"] = lbluserid.Text;
                        HttpContext.Current.Session["resetotp"] = str_otpemail;

                        ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page),
                    "click", @"<script>window.open('../user/SetPassword.aspx','_newtab');</script>", false);
                      
                    }
                    else
                    {
                        string popupScript = "toastr.error('Error', 'Unknown Error Occurred');";
                        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }


                   
                }
            }
            else
            {
                Message.Show("Invalid Login Details...!!!");
            }
            

        }
        else if (e.CommandName == "myreset")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lbluserid = (Label)GridView1.Rows[index].FindControl("lbluserid");
            objUser.UserId = lbluserid.Text;
            objUser.ResetPassword(objUser);

            loaduser();

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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loaduser();
    }
 
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbactive = (LinkButton)e.Row.FindControl("lbactive");
            LinkButton llbdeactive = (LinkButton)e.Row.FindControl("llbdeactive");
            Label lblloginstatus = (Label)e.Row.FindControl("lblloginstatus");
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            if (lblloginstatus.Text == "1")
            {
                lbactive.Visible = false;
                lblstatus.CssClass = "label label-success"; 
                llbdeactive.Visible = true;
            }
            else
            {
                lbactive.Visible = true;
                lblstatus.CssClass = "label label-danger";
                llbdeactive.Visible = false;
            }
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        loaduser();
    }
}