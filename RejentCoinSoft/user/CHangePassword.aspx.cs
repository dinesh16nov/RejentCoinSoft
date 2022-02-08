using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;

public partial class admin_CHangePassword : System.Web.UI.Page
{
    clsLogin objlogin = new clsLogin();
    clsUser objUser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
        }
        else
        {
            Server.Transfer("logout.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objUser.UserName = Session["userid"].ToString();
        Session["oldpassword"] = txtoldpassword.Text;
        Session["newpassword"] = txtuserpassword.Text;
        //string res = objUser.SendOTP(objUser);
        //if (res != "0" && res != "f")
        //{
        //    Session["userotp"] = res;
        //   
        //    string popupScript2 = "showModal();";
        //    ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
        //}
        //else
        //{
        //    Message.Show("Invalid Login Detail");
        //}

        changepassword();
        
    }
    void changepassword()
    {
        objlogin.username = Session["userid"].ToString();
        objlogin.password = Session["oldpassword"].ToString();
        objlogin.newpassword = Session["newpassword"].ToString();
        string res = objlogin.ChangeUserPassword(objlogin);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Password Updated Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtconfirmpassword.Text = txtoldpassword.Text = txtuserpassword.Text = "";
        }
        else if (res == "f")
        {
            string popupScript = "toastr.error('Error', 'Invalid Old Password.');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Unknown Error Occurred.');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (Session["userotp"].ToString() == txtotp.Text)
        {
            changepassword();
        }
        else
        {
            Message.Show("Invalid OTP");
            string popupScript2 = "showModal();";
            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
        }
    }
}