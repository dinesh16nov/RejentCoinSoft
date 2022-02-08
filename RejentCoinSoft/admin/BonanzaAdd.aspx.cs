using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_StateAdd : System.Web.UI.Page
{
    clsState objState = new clsState();
    clsBonanza objBonanza = new clsBonanza();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
                getBonanzaMaster();
                loadBonanza();
               // loadstate();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void getBonanzaMaster()
    {
        ddlbonanza.Items.Clear();
        DataTable dt = new DataTable();
        dt = objBonanza.GetBonanzaMaster();
        ddlbonanza.DataSource = dt;
        ddlbonanza.DataTextField = "BonanzaName";
        ddlbonanza.DataValueField = "ID";
        ddlbonanza.DataBind();
        ListItem li = new ListItem("Select Bonanza", "0");
        ddlbonanza.Items.Insert(0, li);
    }
    void loadBonanza()
    {
        DataTable dt = new DataTable();
        dt = objBonanza.getBonanzaAll();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        objBonanza.BonanzaID = ddlbonanza.SelectedValue.ToString();
        objBonanza.Designation = txtDesignation.Text;
        objBonanza.Matching_Business = txtmatching.Text;
        objBonanza.Direct_Business = txtDirect.Text;
        objBonanza.Sel_Steking = txtSelStaking.Text;
        objBonanza.Reward = txtreward.Text;
        objBonanza.MentionBy = Session["rijentadmin45852_4"].ToString();
        string res = objBonanza.Insert_Bonanza(objBonanza);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Bonanza Added Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtDesignation.Text = ""; ddlbonanza.SelectedValue = "0";
            loadBonanza();
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Unknow error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "mydel")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            objBonanza.TBBonanzaID = lblid.Text;
            string res = objBonanza.delete_Bonanza(objBonanza);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Bonanza Delete Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                txtDesignation.Text = ""; ddlbonanza.SelectedValue = "0";
                loadBonanza();
            }
           else if (res == "f")
            {
                string popupScript = "toastr.error('Error', 'Can not Delete Because its achieve by user');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                txtDesignation.Text = ""; ddlbonanza.SelectedValue = "0";
                loadBonanza();
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknow error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);

            }

        }
    }
}