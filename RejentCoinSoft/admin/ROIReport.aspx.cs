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
    clsAccount objaccount = new clsAccount();
    clsClosing objclosing = new clsClosing();
    clsUser objuser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["rijentadmin45852_4"] != null)
            {
                Session["topentries"] = "50";
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

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Session["topentries"] = "99999999";
        loaduser();
    }

    void loaduser()
    {
        objaccount.UserId = txtuserid.Text;
        if (txtfromdate.Text != "")
        {
            objaccount.FromDate = Message.GetIndianDate(txtfromdate.Text);
        }
        else
        {
            objaccount.FromDate = DateTime.MinValue;
        }
        if (txttodate.Text != "")
        {
            objaccount.ToDate = Message.GetIndianDate(txttodate.Text);
        }
        else
        {
            objaccount.ToDate = DateTime.MinValue;
        }
        objaccount.TopEntries = Session["topentries"].ToString();
        objaccount.Id = ddtopup.SelectedValue.ToString();
        DataTable dt = new DataTable();
        dt = objaccount.getROIDetail2(objaccount);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void ExportToExcel(object sender, EventArgs e)
    {
        GridView1.Columns[0].Visible = false;
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=ROIReport.xls");
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Dashboard.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        loaduser();
    }
    void loadtopuptype()
    {
        objuser.UserId = txtuserid.Text;
        ddtopup.Items.Clear();
        DataTable dt = new DataTable();
        dt = objuser.getMyTopup(objuser);
        ddtopup.DataSource = dt;
        ddtopup.DataTextField = "amount2";
        ddtopup.DataValueField = "id";
        ddtopup.DataBind();
        ListItem li = new ListItem("Select Amount", "0");
        ddtopup.Items.Insert(0, li);
    }
    protected void txtuserid_TextChanged(object sender, EventArgs e)
    {
        loadtopuptype();
    }
}