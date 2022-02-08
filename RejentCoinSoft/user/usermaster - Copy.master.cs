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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] == null)
                Server.Transfer("logout.aspx");

            else
            {
                lbluseridmaster.Text = Session["username"].ToString() + "(" + Session["userid"].ToString() + ")";
                lbluseridmaster2.Text = Session["username"].ToString() + "(" + Session["userid"].ToString() + ")";
                Response.ClearHeaders();
                Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                Response.AddHeader("Pragma", "no-cache");
            }
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
}
