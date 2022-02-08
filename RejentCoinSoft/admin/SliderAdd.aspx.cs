using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_BankAdd : System.Web.UI.Page
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
        dt = objnews.getSlider();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Stream fs = FileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        byte[] bytes = br.ReadBytes((Int32)fs.Length);

        if ((MimeType.GetMimeType(bytes, FileUpload1.FileName)) == "image/png" || (MimeType.GetMimeType(bytes, FileUpload1.FileName)) == "image/jpeg")
        {
            string str_imagename = "noimage.png";
            if (FileUpload1.HasFile)
            {
                str_imagename = "Product_" + Guid.NewGuid().ToString().Substring(0, 8) + "_" + FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath("GalleryImages/") + str_imagename);
            }
            objnews.Imagename = str_imagename;
            objnews.MentionBy = Session["rijentadmin45852_4"].ToString();
            string res = objnews.Insert_Slider(objnews);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Image Added Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

                loaddata();
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknown error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Invalid File');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            objnews.ImageId = lblid.Text;
            string res = objnews.Delete_Slider(objnews);
            loaddata();
        }
    }

    protected void chkActive_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((CheckBox)sender).Parent.Parent;
        CheckBox chkActive = (CheckBox)currentRow.FindControl("chkActive");
        Label lblid = (Label)currentRow.FindControl("lblid");


        if (chkActive.Checked == true)
        {
            objnews.NewsId = lblid.Text;
            string res = objnews.ActivateSlider(objnews);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Slider Status Updated Successfully');";
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
            string res = objnews.DeactivateSlider(objnews);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Slider Status Updated Successfully');";
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