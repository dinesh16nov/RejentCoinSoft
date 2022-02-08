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
    clsBonanza objbonanza = new clsBonanza();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
                loadTbBonanza();
                loadBonanzaAchiever();


            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    void loadTbBonanza()
    {
        ddlbonanza.Items.Clear();
        DataTable dt = new DataTable();
        dt = objbonanza.GetTbBonanza();
        ddlbonanza.DataSource = dt;
        ddlbonanza.DataTextField = "BonanzaName";
        ddlbonanza.DataValueField = "ID";
        ddlbonanza.DataBind();
        ListItem li = new ListItem("Select Bonanza", "0");
        ddlbonanza.Items.Insert(0, li);
    }


    void loadBonanzaAchiever()
    {
        DataTable dt = new DataTable();
        dt = objbonanza.getBonanzaAchieverAll();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //objState.StateName = txtstatenameedit.Text;
        //objState.StateId = lblstateid.Text;
        //string res = objState.Update_State(objState);
        //if (res == "t")
        //{
        //    string popupScript = "toastr.success('Success', 'State Edited Successfully');";
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        //    string popupScript2 = "Closepopup();";
        //    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
        //    loadstate();
        //}
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {

        objbonanza.TBBonanzaID = ddlbonanza.SelectedValue.ToString();
        objbonanza.UserID = txtuser.Text;
        string res = objbonanza.Insert_BonanzaAchiever(objbonanza);
        if (res == "t")
        {
            string popupScript = "toastr.success('Success', 'Bananza Achiever insert Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            txtuser.Text = ""; ddlbonanza.SelectedValue = "0";
            loadBonanzaAchiever();
        }
        else if (res == "ff")
        {
            string popupScript = "toastr.error('Error', 'Bananza Achiever already exists');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
         else if (res == "f")
        {
            string popupScript = "toastr.error('Error', 'Invalid  UserID');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Unknow error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }

    }
}