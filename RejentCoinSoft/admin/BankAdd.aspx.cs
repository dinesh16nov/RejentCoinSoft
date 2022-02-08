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
    clsBank objbank = new clsBank();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
                loaddata();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void loaddata()
    {
        DataTable dt = new DataTable();
        dt = objbank.getBank();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objbank.BankName = txtbanknameedit.Text;
        objbank.BankId = lblbankid.Text;
        string res = objbank.Update_Bank(objbank);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Bank Edited Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            string popupScript2 = "Closepopup();";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            loaddata();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objbank.BankName = txtbankname.Text;
        objbank.MentionBy = Session["rijentadmin45852_4"].ToString();
        string res = objbank.Insert_Bank(objbank);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Bank Added Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtbankname.Text = "";
            loaddata();
        }
        else
            if (res == "f")
            {
                string popupScript = "toastr.error('Error', 'Bank already exists.');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknown error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            Label lblbankname = (Label)GridView1.Rows[index].FindControl("lblbankname");
            lblbankid.Text = lblid.Text;
            txtbanknameedit.Text = lblbankname.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
    }
}