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
            if (Session["userid"] != null)
            {
                loaddata();
                loadwallettype();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void loadwallettype()
    {
        ddwallettype.Items.Clear();
        DataTable dt = new DataTable();
        dt = objuser.getBTCWalletTypeActive();
        ddwallettype.DataSource = dt;
        ddwallettype.DataTextField = "wallettype";
        ddwallettype.DataValueField = "id";
        ddwallettype.DataBind();
        ListItem li = new ListItem("Select Wallet Type", "0");
        ddwallettype.Items.Insert(0, li);
    }
    void loaddata()
    {
        objuser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objuser.getBTCWalletAddressUser(objuser);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string str_image = lblimagenameedit.Text;
        if (FileUpload2.HasFile)
        {
            str_image = Guid.NewGuid().ToString().Substring(0, 6) + FileUpload2.FileName;
            FileUpload2.SaveAs(Server.MapPath("../admin/userimage/") + str_image);
        }
        objuser.ImageName = str_image;

        objuser.WalletAddress = txtwalletaddressedit.Text;
        objuser.Id = lblidedit.Text;
        string res = objuser.Edit_UserBTCWalletAddress(objuser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Wallet Address Edited Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            string popupScript2 = "Closepopup();";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            loaddata();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string str_image = "default.png";
        if (FileUpload1.HasFile)
        {
            str_image = Guid.NewGuid().ToString().Substring(0, 6) + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("../admin/userimage/") + str_image);
        }
        objuser.ImageName = str_image;
        objuser.WalletTypeId = ddwallettype.SelectedValue.ToString();
        objuser.WalletAddress = txtwalletaddress.Text;
        objuser.MentionBy = Session["userid"].ToString();
        objuser.UserId = Session["userid"].ToString();
        string res = objuser.Insert_UserBTCWalletAddress(objuser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Wallet Address Added Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtwalletaddress.Text = "";
            loaddata();
        }
        else
            if (res == "f")
            {
                string popupScript = "toastr.error('Error', 'Wallet Address already exists.');";
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
            Label lblwalletaddress = (Label)GridView1.Rows[index].FindControl("lblwalletaddress");
            Label lblimagename = (Label)GridView1.Rows[index].FindControl("lblimagename");
            lblidedit.Text = lblid.Text;
            txtwalletaddressedit.Text = lblwalletaddress.Text;
            lblimagenameedit.Text = lblimagename.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     
    }
}