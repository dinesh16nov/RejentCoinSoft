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
using DataTier;

public partial class admin_EPinAdd : System.Web.UI.Page
{
    Data ObjData = new Data();
    clsUser objUser = new clsUser();
    clsAccount objaccount = new clsAccount();
    clsSetting objsetting = new clsSetting();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            if (!IsPostBack)
            {
                string UserID = Session["userid"].ToString();
                // loadbalance();
                txtoldStaking.Text = OldStakingBalance(UserID);
            }
        }
        else
        {
            Server.Transfer("index.aspx");
        }
    }
    public string OldStakingBalance(String UserID)
    {
        string Staking = "";
        try
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_GetOldStakingValue";
                SqlParameter[] parameter = {
                   new SqlParameter("@UserID",  UserID)
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
            }
            ObjData.EndConnection();
            Staking = dt.Rows[0][0].ToString();
        }
        catch (Exception ex)
        {    
        }
        return Staking;
    }
}