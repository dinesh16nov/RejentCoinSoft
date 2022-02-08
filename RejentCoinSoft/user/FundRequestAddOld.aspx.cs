using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using System.Configuration;
using BusinessLogicTier;

public partial class admin_EPinAdd : System.Web.UI.Page
{

    clsUser objUser = new clsUser();
    clsAccount objaccount = new clsAccount();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (!IsPostBack)
            {
                txtuserid.Text = Session["userid"].ToString();
                txtusername.Text = Session["username"].ToString();
                loadbalance();
                loadbankaccount();
            }
        }
        else
        {
            Server.Transfer("index.aspx");
        }
    }
    void loadbankaccount()
    {
        ddbankaccountno.Items.Clear();
        DataTable dt = new DataTable();
        dt = objaccount.getCompanyAccountDetail();
        ddbankaccountno.DataSource = dt;
        ddbankaccountno.DataTextField = "accno2";
        ddbankaccountno.DataValueField = "id";
        ddbankaccountno.DataBind();
        ListItem li = new ListItem("Select Bank Account", "0");
        ddbankaccountno.Items.Insert(0, li);

    }
    void loadaccountdetail()
    {
        objaccount.Id = ddbankaccountno.SelectedValue.ToString();
        DataTable dt = new DataTable();
        dt = objaccount.getCompanyAccountDetailById(objaccount);
        if (dt.Rows.Count > 0)
        {
            txtdepositaccountno.Text = dt.Rows[0]["accountno"].ToString();
            txtaccountholdername.Text = dt.Rows[0]["AccountHolderName"].ToString();
            txtdepositbank.Text = dt.Rows[0]["BankName"].ToString();
            txtifsccode.Text = dt.Rows[0]["IFSCCode"].ToString();
            txtbranchname.Text = dt.Rows[0]["BranchName"].ToString();
        }
        else
        {
            txtdepositaccountno.Text = "";
            txtaccountholdername.Text = "";
            txtdepositbank.Text = "";
            txtifsccode.Text = "";
            txtbranchname.Text = "";
        }

    }
    void loadbalance()
    {
        objaccount.UserId = Session["userid"].ToString();
        DataTable dt = new DataTable();
        dt = objaccount.getUserWalletBalance(objaccount);
        //if (dt.Rows.Count > 0)
        //{
        //    lbluserbalance.Text = dt.Rows[0][0].ToString();
        //}
        //else
        //{
        //    lbluserbalance.Text = "0.00";
        //}
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtamount.Text != "")
        {
            objUser.UserId = Session["userid"].ToString();
            objUser.BankAccountId = ddbankaccountno.SelectedValue.ToString();
            objUser.Amount = Convert.ToDecimal(txtamount.Text);
            objUser.Remark = txtremark.Text;
            objUser.PaymentMode = ddpaymentmode.SelectedValue.ToString();
            objUser.OnlineTransactionId = txttransactionid.Text;
            objUser.ChequeNo = txtchequeno.Text;
            objUser.Mobile = txtmobilenoinbank.Text;
            objUser.MentionBy = Session["userid"].ToString();
            string rs = objUser.InsertFundRequest(objUser);
            if (rs == "t")
            {
                Message.Show("Fund Request Added  Successfully...!!!");
                ddbankaccountno.SelectedValue = "0";
                txtremark.Text = "";
                txtamount.Text = "";
                ddpaymentmode.SelectedValue = "0";
                txtchequeno.Text = "";
                txttransactionid.Text = "";
                txtmobilenoinbank.Text = "";
                txtdepositaccountno.Text = "";
                txtaccountholdername.Text = "";
                txtdepositbank.Text = "";
                txtifsccode.Text = "";
                txtbranchname.Text = "";
            }
            else
            {
                Message.Show("Unknown Error Occurred...!!!");
            }
        }
        else
        {
            Message.Show("Enter amount...!!!");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("dashboard.aspx");
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void ddbankaccountno_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadaccountdetail();
    }
}