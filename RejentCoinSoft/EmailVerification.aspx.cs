using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;

public partial class EmailVerification : System.Web.UI.Page
{
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string str_data = "";
            if (Request.QueryString["d"] != null)
            {
                str_data = Request.QueryString["d"].ToString();
                objuser.Data = str_data;
                string res = objuser.Update_EmailVerificationStatus(objuser);
                if (res == "t")
                {
                    Response.Write("Email Successfully Verified");
                }
                else
                {
                    Response.Write("Unknown Error Occurred");
                }


            }
        }
    }
}