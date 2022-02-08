using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class admin_UserReport : System.Web.UI.Page
{
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
                //txtuserid.Text = Session["userid"].ToString();
                //txtuserid.Enabled = false;
                loaduser();
            }
            else
            {
                Server.Transfer("logout.aspx");
            }
        }
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "myEdit")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            Label lblid = (Label)GridView1.Rows[index].FindControl("lblid");
            Label lblamount = (Label)GridView1.Rows[index].FindControl("lblamount");
            Label lbluserid = (Label)GridView1.Rows[index].FindControl("lbluserid");
            Label lbltranis = (Label)GridView1.Rows[index].FindControl("lbltranis");
            lblrequestid.Text = lblid.Text;
            txtuseridedit.Text = lbluserid.Text;
            txtamount.Text = lblamount.Text;
            txttransactionid.Text = lbltranis.Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loaduser();
    }
    void loaduser()
    {

        if (txtfromdate.Text != "")
        {
            objuser.FromDate = Message.GetIndianDate(txtfromdate.Text);
        }
        else
        {
            objuser.FromDate = DateTime.MinValue;
        }
        if (txttodate.Text != "")
        {
            objuser.ToDate = Message.GetIndianDate(txttodate.Text);
        }
        else
        {
            objuser.ToDate = DateTime.MinValue;
        }
        objuser.UserId = txtuserid.Text;
        objuser.Status = ddstatussearch.SelectedValue.ToString();
        DataTable dt = new DataTable();
        dt = objuser.getFundRequestReport(objuser);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbReverse = (LinkButton)e.Row.FindControl("lbReverse");
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");
            if (lblstatus.Text == "Pending")
            {
                lbReverse.Visible = true;
                lblstatus.CssClass = "label label-warning";
            }
            else
                if (lblstatus.Text == "Approved")
            {
                lbReverse.Visible = false;
                lblstatus.CssClass = "label label-success";
            }
            else
            if (lblstatus.Text == "Rejected")
            {
                lbReverse.Visible = false;
                lblstatus.CssClass = "label label-danger";
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ddstatus.SelectedValue.ToString() != "0")
        {
            objuser.Status = ddstatus.SelectedValue.ToString();
            objuser.Id = lblrequestid.Text;
            objuser.Remark = txtremark.Text;
            objuser.MentionBy = Session["rijentadmin45852_4"].ToString();
            string res = objuser.UpdateFundRequest(objuser);
            if (res == "t")
            {
                string popupScript = "toastr.success('Success', 'Bank Account Details Edited Successfully');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                string popupScript2 = "Closepopup();";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
                loaduser();
                txtremark.Text = "";
                ddstatus.SelectedValue = "0";
            }
            else
            {
                string popupScript = "toastr.error('Error', 'Unknown error occurred');";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
            }
        }
        else
        {
            string popupScript = "toastr.error('Error', 'Select Status');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), Guid.NewGuid().ToString(), popupScript, true);
        }
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
        Response.AddHeader("content-disposition", "attachment;filename=fundrequest.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //To Export all pages
            GridView1.AllowPaging = false;
            loaduser();

            GridView1.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = Color.White;
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
}