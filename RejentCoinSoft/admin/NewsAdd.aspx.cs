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
        dt = objnews.getNews();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtnewsedit.Text != "")
        {
            objnews.NewsDetail = txtnewsedit.Text.Trim().Replace("<p>", "").Replace("</p>", "");
            objnews.NewsId = lblnewsid.Text;
            string res = objnews.Update_News(objnews);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'News Edited Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

                loaddata();
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Enter News.');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }

        string popupScript2 = "Closepopup();";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtnews.Text != "")
        {



            objnews.NewsDetail = txtnews.Text.Trim().Replace("<p>","").Replace("</p>","");
            objnews.MentionBy = Session["rijentadmin45852_4"].ToString();
            string res = objnews.Insert_News(objnews);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'News Added Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                txtnews.Text = "";
                loaddata();
            }
            else
                if (res == "f")
            {
                string popupScript = "toastr.error('Error', 'News already exists.');";
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
            string popupScript = "toastr.error('Error', 'Enter News');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "myedit")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            Label lblbankname = (Label)GridView1.Rows[index].FindControl("lblnews");
            lblnewsid.Text = lblid.Text;
            txtnewsedit.Text = lblbankname.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
        if (e.CommandName == "mydel")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            objnews.NewsId = lblid.Text;
            objnews.Delete_News(objnews);
            loaddata();
            string popupScript = "toastr.success('Success', 'News Deleted Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }

    protected void chkActive_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((CheckBox)sender).Parent.Parent;
        CheckBox chkActive = (CheckBox)currentRow.FindControl("chkActive");
        Label lblid = (Label)currentRow.FindControl("lblid");


        if (chkActive.Checked == true)
        {
            objnews.NewsId = lblid.Text;
            string res = objnews.ActivateNews(objnews);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'News Status Updated Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                //loaddata();
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknown error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
            loaddata();
        }
        else
        {
            objnews.NewsId = lblid.Text;
            string res = objnews.DeactivateNews(objnews);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'News Status Updated Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                loaddata();
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknown error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
            loaddata();

        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");

            CheckBox chkActive = (CheckBox)e.Row.FindControl("chkActive");
            if (lblstatus.Text == "1")
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }

            //LinkButton lbactivate = (LinkButton)e.Row.FindControl("lbactivate");
            //LinkButton lbdeactivate = (LinkButton)e.Row.FindControl("lbdeactivate");

            //lbactivate.Visible = false;
            //lbdeactivate.Visible = false;

            //if (lblisactive.Text == "1")
            //{
            //    lbdeactivate.Visible = true;
            //}
            //else
            //{
            //    lbactivate.Visible = true;
            //}

        }
    }
}