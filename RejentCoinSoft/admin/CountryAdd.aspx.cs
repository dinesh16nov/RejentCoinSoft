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
        dt = objState.getCountry();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //objState.CountryName = txtcountrynameedit.Text;
        //objState.CountryId = lblcountryid.Text;
        //string res = objState.Update_Country(objState);
        //if (res == "t")
        //{
        //    string popupScript = "toastr.success('Success', 'Country Edited Successfully');";
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        //    string popupScript2 = "Closepopup();";
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
        //    loaddata();
        //}
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objState.CountryName = txtcountryname.Text;
        objState.MentionBy = Session["rijentadmin45852_4"].ToString();
        string res = objState.Insert_Country(objState);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Country Added Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtcountryname.Text = "";
            loaddata();
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Unknow error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            //int index = Convert.ToInt32(e.CommandArgument.ToString());
            //Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            //Label lblCountryname = (Label)GridView1.Rows[index].FindControl("lblCountryname");
            //lblcountryid.Text = lblid.Text;
            //txtcountrynameedit.Text = lblCountryname.Text;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}