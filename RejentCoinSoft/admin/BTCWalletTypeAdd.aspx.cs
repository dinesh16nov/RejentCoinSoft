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
    clsUser objuser = new clsUser();
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
        dt = objuser.getBTCWalletTypeAll();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objuser.WalletType = txtwallettypeedit.Text;
        objuser.ConversionToDollar = Convert.ToDecimal(txtconversiontodollaredit.Text);
        objuser.ConversionToQauere = Convert.ToDecimal(txtconversiontoqauereedit.Text);
        objuser.Id = lblidedit.Text;
        string res = objuser.Edit_BTCWalletType(objuser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Wallet Type Edited Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            string popupScript2 = "Closepopup();";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            loaddata();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objuser.WalletType = txtwallettype.Text;
        objuser.ConversionToDollar = Convert.ToDecimal( txtconversiontodollar.Text);
        objuser.ConversionToQauere = Convert.ToDecimal( txtconversiontoqauere.Text);
        objuser.MentionBy = Session["rijentadmin45852_4"].ToString();
        string res = objuser.Insert_BTCWalletType(objuser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Wallet Type Added Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtwallettype.Text = "";
            loaddata();
        }
        else
            if (res == "f")
            {
                string popupScript = "toastr.error('Error', 'Wallet Type already exists.');";
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
            Label lblwallettype = (Label)GridView1.Rows[index].FindControl("lblwallettype");
            Label lblconversion = (Label)GridView1.Rows[index].FindControl("lblconversion");
            Label lblconversiontoqauere = (Label)GridView1.Rows[index].FindControl("lblconversiontoqauere");
            lblidedit.Text = lblid.Text;
            txtwallettypeedit.Text = lblwallettype.Text;
            txtconversiontodollaredit.Text = lblconversion.Text;
            txtconversiontoqauereedit.Text = lblconversiontoqauere.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
    }

    protected void chkActive_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = (GridViewRow)((CheckBox)sender).Parent.Parent;
        CheckBox chkActive = (CheckBox)currentRow.FindControl("chkActive");
        Label lblid = (Label)currentRow.FindControl("lblid");


        if (chkActive.Checked == true)
        {
            objuser.Id = lblid.Text;
            string res = objuser.Active_BTCWalletType(objuser);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Wallet Type Status Updated Successfully');";
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
            objuser.Id = lblid.Text;
            string res = objuser.Deactive_BTCWalletType(objuser);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Wallet Type Status Updated Successfully');";
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