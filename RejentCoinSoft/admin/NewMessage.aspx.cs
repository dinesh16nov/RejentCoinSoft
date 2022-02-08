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

    clsSupport objsupport = new clsSupport();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {

            }
            else
            {
                Server.Transfer("index.aspx");
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objsupport.FromId = "admin";
        objsupport.ToId = txttoid.Text;

        objsupport.Messagetitle = txtmessagetitle.Text;
        objsupport.MessageDescription = txtdescription.Text;
        objsupport.MentionBy = Session["rijentadmin45852_4"].ToString();
        objsupport.ImageName = "";
        int rs = objsupport.SendMessageByAdmin(objsupport);
        if (rs == 1)
        {
            Message.Show("Message Sent Successfully...!!!");
            txtdescription.Text = "";
            txtmessagetitle.Text = "";
            txttoid.Text = "";
        }
        else
            if (rs == 2)
        {
            Message.Show("Message Not Sent. Invalid To Id...!!!");
        }
        else
        {
            Message.Show("unknown Error occurred...!!!");
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
}