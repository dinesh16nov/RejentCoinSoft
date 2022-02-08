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
    clsState objState = new clsState();
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
        dt = objState.getHoliday();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objState.Title = txttitleedit.Text;
        objState.HolidayDate = Message.GetIndianDate( txtdateedit.Text);
        objState.Id = lblholidayid.Text;
        string res = objState.Edit_Holiday(objState);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Holiday Details Edited Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            string popupScript2 = "Closepopup();";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            loaddata();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objState.Title = txttitle.Text;
        objState.HolidayDate = Message.GetIndianDate( txtdate.Text);
        objState.MentionBy = Session["rijentadmin45852_4"].ToString();
        string res = objState.Insert_Holiday(objState);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Holiday Added Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txttitle.Text =txtdate.Text= "";
            loaddata();
        }
        else if (res == "f")
        {
            string popupScript = "toastr.error('Error', 'Holiday Already Exists');";
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
            Label lbltitle = (Label)GridView1.Rows[index].FindControl("lbltitle");
            Label lbldate = (Label)GridView1.Rows[index].FindControl("lbldate");
            lblholidayid.Text = lblid.Text;
            txttitleedit.Text = lbltitle.Text;
            txtdateedit.Text = lbldate.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        else  if (e.CommandName == "mydel")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");          
            objState.Id = lblid.Text;
            string res = objState.Delete_Holiday(objState);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Holiday Details Deleted Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);              
                loaddata();
            }
        }
    }
}