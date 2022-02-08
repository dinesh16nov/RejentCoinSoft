using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class admin_UserReport : System.Web.UI.Page
{
    clsState objState = new clsState();
    clsUser objUser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
              //  loadcountry();
                loadcountryedit();
                if (Request.QueryString["wtype"] != null)
                {
                    ddwallettype.SelectedValue = Request.QueryString["wtype"].ToString();
                    loaduser();
                }
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }
    //void loadcountry()
    //{
    //    ddcountry.Items.Clear();
    //    DataTable dt = new DataTable();
    //    dt = objState.getCountry();
    //    ddcountry.DataSource = dt;
    //    ddcountry.DataTextField = "CountryName";
    //    ddcountry.DataValueField = "CountryID";
    //    ddcountry.DataBind();
    //    ListItem li = new ListItem("Select Country", "0");
    //    ddcountry.Items.Insert(0, li);
    //}
    //void loadstate()
    //{
    //    ddstate.Items.Clear();
    //    DataTable dt = new DataTable();
    //    objState.CountryId = ddcountry.SelectedValue.ToString();
    //    dt = objState.getState(objState);

    //    ddstate.DataSource = dt;
    //    ddstate.DataTextField = "StateName";
    //    ddstate.DataValueField = "StateID";
    //    ddstate.DataBind();
    //    ListItem li = new ListItem("Select State", "0");
    //    ddstate.Items.Insert(0, li);
    //}


    void loadcountryedit()
    {
        ddcountryedit.Items.Clear();
        DataTable dt = new DataTable();
        dt = objState.getCountry();
        ddcountryedit.DataSource = dt;
        ddcountryedit.DataTextField = "CountryName";
        ddcountryedit.DataValueField = "CountryID";
        ddcountryedit.DataBind();
        ListItem li = new ListItem("Select Country", "0");
        ddcountryedit.Items.Insert(0, li);
    }
    void loadstateedit()
    {
        ddstateedit.Items.Clear();
        DataTable dt = new DataTable();
        objState.CountryId = ddcountryedit.SelectedValue.ToString();
        dt = objState.getState(objState);

        ddstateedit.DataSource = dt;
        ddstateedit.DataTextField = "StateName";
        ddstateedit.DataValueField = "StateID";
        ddstateedit.DataBind();
        ListItem li = new ListItem("Select State", "0");
        ddstateedit.Items.Insert(0, li);
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edt")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lbluserid = (Label)GridView1.Rows[index].FindControl("lbluserid");
            lbluseridedit.Text = lbluserid.Text;
            objUser.UserId = lbluserid.Text;
            DataTable dt = new DataTable();
            dt = objUser.getUserDetail(objUser);
            if (dt.Rows.Count > 0)
            {
                txtnameedit.Text = dt.Rows[0]["username"].ToString();
                txtmobileedit.Text = dt.Rows[0]["mobile"].ToString();
                txtemailedit.Text = dt.Rows[0]["email"].ToString();
                ddgenderedit.SelectedValue = dt.Rows[0]["gender"].ToString();
                txtaddressedit.Text = dt.Rows[0]["address"].ToString();
                ddcountryedit.SelectedValue = dt.Rows[0]["countryid"].ToString();
                loadstateedit();
                ddstateedit.SelectedValue = dt.Rows[0]["stateid"].ToString();

                txtcitynamedit.Text = dt.Rows[0]["cityname"].ToString();

                txtareaname.Text = dt.Rows[0]["areaname"].ToString();
                txtpincodeedit.Text = dt.Rows[0]["pincode"].ToString();
                try
                {
                    txtdateofbirthedit.Text = Convert.ToDateTime(dt.Rows[0]["dateofbirth"].ToString()).ToString("dd/MM/yyyy");
                }
                catch { }
                //txtaccountholdername.Text = dt.Rows[0]["accountholdername"].ToString();
                //txtaccountno.Text = dt.Rows[0]["accountno"].ToString();
                //txtifsccode.Text = dt.Rows[0]["ifsccode"].ToString();
                //txtpan.Text = dt.Rows[0]["pannumber"].ToString();
                //try
                //{
                //    ddbank.SelectedValue = dt.Rows[0]["bankname"].ToString();
                //}
                //catch { }
                //txtbranchname.Text = dt.Rows[0]["branchname"].ToString();
                lblimagename.Text = dt.Rows[0]["imagename2"].ToString();
                //if (dt.Rows[0]["isdummy"].ToString() == "0")
                //{
                //    ck1.Checked = false;
                //}
                //else
                //{
                //    ck1.Checked = true;
                //}
                //if (dt.Rows[0]["IsDirectROI2"].ToString() == "0")
                //{
                //    ckdirectroi.Checked = false;
                //}
                //else
                //{
                //    ckdirectroi.Checked = true;
                //}
                //if (dt.Rows[0]["IsNormalROI2"].ToString() == "0")
                //{
                //    cknormalroi.Checked = false;
                //}
                //else
                //{
                //    cknormalroi.Checked = true;
                //}
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
    }
    //protected void ddcountry_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    loadstate();
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loaduser();
    }
    void loaduser()
    {
        objUser.UserName = txtname.Text;
        objUser.Mobile = txtmobile.Text;
        objUser.Email ="";
        objUser.CityName = "";
        objUser.AreaName = "0";
        //if (txtfromdate.Text != "")
        //{
        //    objUser.FromDate = Message.GetIndianDate(txtfromdate.Text);
        //}
        //else
        //{
            objUser.FromDate = DateTime.MinValue;
        //}
        //if (txttodate.Text != "")
        //{
        //    objUser.ToDate = Message.GetIndianDate(txttodate.Text);
        //}
        //else
        //{
            objUser.ToDate = DateTime.MinValue;
        //}
        objUser.UserId = txtuserid.Text;
        objUser.WalletAddress ="";
        objUser.WalletType =ddwallettype.SelectedValue.ToString();
        DataTable dt = new DataTable();
        dt = objUser.getUserReport2(objUser);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        ViewState["dirState"] = dt;
    }
    protected void ddcountryedit_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadstateedit();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string str_image = lblimagename.Text;
        if (FileUpload1.HasFiles)
        {
            str_image = Guid.NewGuid().ToString().Substring(0, 6) + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("userimage/") + str_image);
        }
        objUser.UserName = txtnameedit.Text;
        objUser.Mobile = txtmobileedit.Text;
        objUser.Email = txtemailedit.Text;
        objUser.Gender = ddgenderedit.SelectedValue.ToString();
        objUser.Address = txtaddressedit.Text;
        objUser.CityName = txtcitynamedit.Text;
        objUser.CountryId = ddcountryedit.SelectedValue.ToString();
        objUser.StateId = ddstateedit.SelectedValue.ToString();
        objUser.AreaName = txtareaname.Text;
        objUser.Pincode = txtpincodeedit.Text;
        objUser.DateOfBirth = Message.GetIndianDate(txtdateofbirthedit.Text);
        objUser.ImageName = str_image;
        objUser.UserId = lbluseridedit.Text;
        objUser.StateId = ddstateedit.SelectedValue.ToString();
        objUser.AccHolderName = "";
        objUser.AccNo = "";
        objUser.IFSCCode = "";
        objUser.PanCardNo = "";
        objUser.BankName = "0";
        objUser.BranchName = "";
        //if (ck1.Checked == true)
        //{
        //    objUser.IsDummyData = "1";
        //}
        //else
        //{
            objUser.IsDummyData = "0";
        //}
        //if (ckdirectroi.Checked == true)
        //{
        //    objUser.IsDirectROI = "1";
        //}
        //else
        //{
            objUser.IsDirectROI = "0";
        //}

        //if (cknormalroi.Checked == true)
        //{
        //    objUser.IsNormalROI = "1";
        //}
        //else
        //{
            objUser.IsNormalROI = "0";
        //}
        string res = objUser.Edit_User(objUser);
        if (res == "t")
        {
            loaduser();
            string popupScript = "toastr.success('Success', 'User Edited Successfully');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            string popupScript2 = "Closepopup();";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
        }
        else
        {
            string popupScript = "toastr.error('Success', 'unknown error occurred');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblactivestatus = (Label)e.Row.FindControl("lblactivestatus");
        //    if (lblactivestatus.Text == "Active")
        //    {
        //        lblactivestatus.CssClass = "label label-success";
        //    }
        //    else
        //        if (lblactivestatus.Text == "Deactive")
        //        {
        //            lblactivestatus.CssClass = "label label-danger";
        //        }
        //}
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        loaduser();
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=usereport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (System.IO.StringWriter sw = new System.IO.StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GridView1.AllowPaging = false;
            loaduser();

            GridView1.HeaderRow.BackColor = System.Drawing.Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtrslt = (DataTable)ViewState["dirState"];
        if (dtrslt.Rows.Count > 0)
        {
            if (Convert.ToString(ViewState["sortdr"]) == "Asc")
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                ViewState["sortdr"] = "Desc";
            }
            else
            {
                dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                ViewState["sortdr"] = "Asc";
            }
            GridView1.DataSource = dtrslt;
            GridView1.DataBind();


        }
    }
}