using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;

public partial class admin_NewMessage : System.Web.UI.Page
{
    clsLogin objLogin = new clsLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rijentadmin45852_4"] != null)
        {

        }
        else
        {
            Server.Transfer("logout.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objLogin.username = Session["rijentadmin45852_4"].ToString();
        objLogin.password = txtoldpassword.Text;
        objLogin.newpassword = txtnewpassword.Text;
        string res = objLogin.ChangeAdminPassword(objLogin);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Password Changed Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtconfirmpassword.Text = txtnewpassword.Text = txtoldpassword.Text = "";
        }
        else
            if (res == "f")
            {
                string popupScript = "toastr.error('Error', 'wrong old password');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknow error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
    }
}