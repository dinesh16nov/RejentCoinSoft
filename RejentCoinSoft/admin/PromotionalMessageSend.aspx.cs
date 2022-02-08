using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_BankAdd : System.Web.UI.Page
{
    clsUser objuser = new clsUser();
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


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string res = objuser.sendPromotionalMessage(txtmessage.Text);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Message Sent Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Unknown error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
}