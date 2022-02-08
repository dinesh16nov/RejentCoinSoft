using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_UserEdit : System.Web.UI.Page
{
    clsState objState = new clsState();
    clsUser objUser = new clsUser();
    clsBank objbank = new clsBank();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userid"] != null)
            {

                loadbank();
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
        objUser.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objUser.getUserDetail(objUser);
        if (dt.Rows.Count > 0)
        {
           txtaccountholdername.Text = dt.Rows[0]["accountholdername"].ToString(); ;
            txtaccountno.Text = dt.Rows[0]["accountno"].ToString(); 
            txtpan.Text = dt.Rows[0]["pannumber"].ToString(); 
            txtifsccode.Text = dt.Rows[0]["ifsccode"].ToString(); 
            txtbranchname.Text = dt.Rows[0]["branchname"].ToString(); 
            ddbank.SelectedValue = dt.Rows[0]["bankname"].ToString();
           
        }
    }
    void loadbank()
    {
        ddbank.Items.Clear();
        DataTable dt = new DataTable();
        dt = objbank.getBank();
        ddbank.DataSource = dt;
        ddbank.DataTextField = "BankName";
        ddbank.DataValueField = "BankID";
        ddbank.DataBind();
        ListItem li = new ListItem("Select Bank", "0");
        ddbank.Items.Insert(0, li);
    }
   

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        updatedetails();
    }
    void updatedetails()
    {
        string str_image = "default.png";
        if (FileUpload1.HasFile)
        {
            str_image = Guid.NewGuid().ToString().Substring(0, 6) + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("../admin/userimage/") + str_image);
        }
        objUser.UserId = Session["userid"].ToString();
        objUser.AccHolderName = txtaccountholdername.Text;
        objUser.AccNo = txtaccountno.Text;
        objUser.IFSCCode = txtifsccode.Text;
        objUser.PanCardNo = txtpan.Text;
        objUser.BankName = ddbank.SelectedValue.ToString();
        objUser.BranchName = txtbranchname.Text;
        objUser.MentionBy = Session["userid"].ToString();
         objUser.ImageName = str_image;
        string res = objUser.Insert_AccountDetailEditRequest(objUser);
        if (res == "f")
        {
            string popupScript = "toastr.error('Error', 'Already Pending Request');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else
            if (res == "0")
        {
            string popupScript = "toastr.error('Error', 'Unknow error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else
        {
            txtaccountholdername.Text = txtaccountno.Text = txtbranchname.Text = txtifsccode.Text = txtpan.Text = "";
            string popupScript = "toastr.success('Success', 'Account Detail edit request submitted successfully.');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
     
    }

   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        //if (Session["userotp"].ToString() == txtotp.Text)
        //{
          
        //}
        //else
        //{
        //    Message.Show("Invalid OTP");
        //    string popupScript2 = "showModal();";
        //    ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
        //}
    }
}