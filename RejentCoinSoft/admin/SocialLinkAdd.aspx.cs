using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blue_Dashboard : System.Web.UI.Page
{
    clsNews objnews = new clsNews();
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
        dt = objnews.getlink();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtlinkedit.Text != "")
        {
            objnews.LinkType = ddtypeedit.SelectedValue.ToString() ;
            objnews.Link = txtlinkedit.Text.Trim();
            objnews.NewsId = lblidedit.Text;
            string res = objnews.Update_Link(objnews);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Link Edited Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

                loaddata();
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Enter Link.');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }

        string popupScript2 = "Closepopup();";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtlink.Text != "")
        {
            objnews.Link = txtlink.Text.Trim();
            objnews.LinkType = ddtype.SelectedValue.ToString();
            objnews.MentionBy = Session["rijentadmin45852_4"].ToString();
            string res = objnews.Insert_Link(objnews);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Link Added Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                txtlink.Text = "";
                loaddata();
            }
            else
                if (res == "f")
            {
                string popupScript = "toastr.error('Error', 'Link already exists.');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknown error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }

        }
        else
        {
            string popupScript = "toastr.error('Error', 'Enter Link');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "myedit")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            Label lbllinktype = (Label)GridView1.Rows[index].FindControl("lbltype");
            Label lbllink = (Label)GridView1.Rows[index].FindControl("lbllink");
            lblidedit.Text = lblid.Text;
            txtlinkedit.Text = lbllink.Text;
            ddtypeedit.SelectedValue= lbllinktype.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        if (e.CommandName == "mydel")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            objnews.NewsId = lblid.Text;
            objnews.Delete_SocialLink(objnews);
            loaddata();
            string popupScript = "toastr.success('Success', 'Link Deleted Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }

  

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblstatus = (Label)e.Row.FindControl("lblstatus");

        //    CheckBox chkActive = (CheckBox)e.Row.FindControl("chkActive");
        //    if (lblstatus.Text == "1")
        //    {
        //        chkActive.Checked = true;
        //    }
        //    else
        //    {
        //        chkActive.Checked = false;
        //    }

        //    //LinkButton lbactivate = (LinkButton)e.Row.FindControl("lbactivate");
        //    //LinkButton lbdeactivate = (LinkButton)e.Row.FindControl("lbdeactivate");

        //    //lbactivate.Visible = false;
        //    //lbdeactivate.Visible = false;

        //    //if (lblisactive.Text == "1")
        //    //{
        //    //    lbdeactivate.Visible = true;
        //    //}
        //    //else
        //    //{
        //    //    lbactivate.Visible = true;
        //    //}

        //}
    }
}