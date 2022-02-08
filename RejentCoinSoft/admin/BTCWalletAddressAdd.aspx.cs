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
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
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
        DataTable dt = new DataTable();
        dt = objuser.getBTCWalletAddressAll();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Stream fs = FileUpload2.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        byte[] bytes = br.ReadBytes((Int32)fs.Length);

        if ((MimeType.GetMimeType(bytes, FileUpload2.FileName)) == "image/png" || (MimeType.GetMimeType(bytes, FileUpload2.FileName)) == "image/jpeg")
        {
            string str_image = lblimagenameedit.Text;
        if (FileUpload2.HasFile)
        {
            str_image = "walletaddress_"+Guid.NewGuid().ToString().Substring(0, 6) + FileUpload2.FileName;
            FileUpload2.SaveAs(Server.MapPath("userimage/") + str_image);
        }
        objuser.ImageName = str_image;

        objuser.WalletAddress = txtwalletaddressedit.Text;

        objuser.BankName = txtdepositbankedit.Text;
        objuser.AccHolderName = txtaccholdernameedit.Text;
        objuser.AccNo = txtaccountnoedit.Text;
        objuser.IFSCCode = txtifscedit.Text;
        objuser.BranchName = txtbranchnameedit.Text;
        objuser.IPAddress = GetIPAddress();
        objuser.MentionBy = Session["rijentadmin45852_4"].ToString();
        objuser.Id = lblidedit.Text;
        string res = objuser.Edit_BTCWalletAddress(objuser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Wallet Address Edited Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            string popupScript2 = "Closepopup();";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
            loaddata();
        }
    }
        else
        {
            string popupScript = "toastr.error('Error', 'Invalid File');";
    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    public string GetIPAddress()
    {
        string ipaddress;
        ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipaddress == "" || ipaddress == null)
            ipaddress = Request.ServerVariables["REMOTE_ADDR"];
        return ipaddress;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Stream fs = FileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        byte[] bytes = br.ReadBytes((Int32)fs.Length);

        if ((MimeType.GetMimeType(bytes, FileUpload1.FileName)) == "image/png" || (MimeType.GetMimeType(bytes, FileUpload1.FileName)) == "image/jpeg")
        {
            string str_image = "default.png";
        if (FileUpload1.HasFile)
        {
            str_image = "walletaddress_" + Guid.NewGuid().ToString().Substring(0, 6) + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("userimage/") + str_image);
        }
        objuser.ImageName = str_image;
        objuser.WalletTypeId = ddwallettype.SelectedValue.ToString();
        objuser.WalletAddress = txtwalletaddress.Text;
        objuser.MentionBy = Session["rijentadmin45852_4"].ToString();
        objuser.BankName = txtdepositbank.Text;
        objuser.AccHolderName = txtaccountholdername.Text;
        objuser.AccNo = txtdepositaccountno.Text;
        objuser.IFSCCode = txtifsccode.Text;
        objuser.BranchName = txtbranchname.Text;
        objuser.IPAddress= GetIPAddress();


        string res = objuser.Insert_BTCWalletAddress(objuser);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Wallet Address Added Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtwalletaddress.Text = "";
            txtdepositbank.Text = "";
            txtaccountholdername.Text = "";
            txtdepositaccountno.Text = "";
            txtifsccode.Text = "";
            txtbranchname.Text = "";
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
            Label lblwallettype = (Label)GridView1.Rows[index].FindControl("lblwallettype");
            Label lblwalletaddress = (Label)GridView1.Rows[index].FindControl("lblwalletaddress");
            Label lblimagename = (Label)GridView1.Rows[index].FindControl("lblimagename");

            Label lblaccountholdername = (Label)GridView1.Rows[index].FindControl("lblaccountholdername");
            Label lblaccountno = (Label)GridView1.Rows[index].FindControl("lblaccountno");
            Label lblbankname = (Label)GridView1.Rows[index].FindControl("lblbankname");
            Label lblifsccode = (Label)GridView1.Rows[index].FindControl("lblifsccode");
            Label lblbranchname = (Label)GridView1.Rows[index].FindControl("lblbranchname");

            lblidedit.Text = lblid.Text;
            txtwalletaddressedit.Text = lblwalletaddress.Text;
            lblimagenameedit.Text = lblimagename.Text;

            txtaccholdernameedit.Text = lblaccountholdername.Text;
            txtaccountnoedit.Text = lblaccountno.Text;
            txtdepositbankedit.Text = lblbankname.Text;
            txtifscedit.Text = lblifsccode.Text;
            txtbranchnameedit.Text = lblbranchname.Text;
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
            string res = objuser.Active_BTCWalletAdrdess(objuser);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Wallet Address Status Updated Successfully');";
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
            string res = objuser.Deactive_BTCWalletAddress(objuser);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Wallet Address Status Updated Successfully');";
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