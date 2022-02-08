using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_CountryAdd : System.Web.UI.Page
{
    clsAccount objaccount = new clsAccount();
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
        dt = objaccount.getLevelAll();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objaccount.LevelNo = txtlevelnoedit.Text;
        objaccount.Income =Convert.ToDecimal(  txtincomeedit.Text);
        objaccount.JoiningPackage =Convert.ToDecimal(  txtjoiningpackageedit.Text);
        objaccount.MinDirect = Convert.ToInt32(txtmindirectsponseredit.Text);
        objaccount.Id = lbllevelid.Text;
        string res = objaccount.Update_Level(objaccount);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Level Edited Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            string popupScript2 = "Closepopup();";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            loaddata();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objaccount.LevelNo = txtlevelno.Text;
        objaccount.Income = Convert.ToDecimal(txtincome.Text);
        objaccount.JoiningPackage = Convert.ToDecimal(txtjoiningpackage.Text);
        objaccount.MentionBy = Session["rijentadmin45852_4"].ToString();
        objaccount.MinDirect = Convert.ToInt32(txtmindirectsponser.Text);
        string res = objaccount.Insert_Level(objaccount);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Level Added Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtmindirectsponser.Text=txtjoiningpackage.Text= txtlevelno.Text =txtincome.Text= "";
            loaddata();
        }
        else if (res == "f")
        {
            string popupScript = "toastr.error('Error', 'Level No Already Exists');";
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
            Label lbllevelno = (Label)GridView1.Rows[index].FindControl("lbllevelno");
            Label lblincome = (Label)GridView1.Rows[index].FindControl("lblincome");
            Label lblmindirectsponser = (Label)GridView1.Rows[index].FindControl("lblmindirectsponser");
            Label lbljoiningpackage = (Label)GridView1.Rows[index].FindControl("lbljoiningpackage");
            lbllevelid.Text = lblid.Text;
            txtlevelnoedit.Text = lbllevelno.Text;
            txtincomeedit.Text = lblincome.Text;
            txtjoiningpackageedit.Text = lbljoiningpackage.Text;
            txtmindirectsponseredit.Text = lblmindirectsponser.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
}