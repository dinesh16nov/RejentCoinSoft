using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;
using System.Web.UI.HtmlControls;

public partial class admin_Dashboard : System.Web.UI.Page
{
    clsUser objuser = new clsUser();
    clsAccount objaccount = new clsAccount();
    clsNews objnews = new clsNews();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userid"] != null)
        {
            //laoddata();
            //loadnews();
            loaddashboard();
         //   lblreferencelinkleft.Text = @"<a href='http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1' target='_blank'>http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1</a>";
         //   lblreferencelinkright.Text = @"<a href='http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2' target='_blank'>http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2</a>";

         //   lbllinkleft.Text = @"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1";
         //   lbllinkright.Text = @"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2";

         //   ltwhatsapplinkleft.Text=  @"<a href=""https://api.whatsapp.com/send?phone=91&text="+ HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1")+@""" target=""_blank"" style=""color:white;""> <i class=""fa fa-whatsapp""></i></a>";
         //ltwhatsapplinkright.Text= @"<a href=""https://api.whatsapp.com/send?phone=91&text=" + HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2") + @""" target=""_blank"" style=""color:white;""> <i class=""fa fa-whatsapp""></i></a>";



         // ltfacebookshareleft.Text= @"<a href=""http://www.facebook.com/sharer.php?u="+ HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=1") + @""" style=""color:white;"" target=""_blank""><i class=""fa fa-facebook""></i></a>";
         // ltfacebookshareright.Text= @"<a href=""http://www.facebook.com/sharer.php?u="+ HttpUtility.UrlEncode(@"http://teamrijent.in/register.aspx?sid=" + Session["userid"].ToString() + @"&p=2") + @""" style=""color:white;"" target=""_blank""><i class=""fa fa-facebook""></i></a>";

            //if (Session["userid"].ToString() == "789440")
            //{
            //    divroi.Visible = true;
            //}
            loadoffer();
        }
        else
        {
            Server.Transfer("logout.aspx");
        }
    }
    void loadoffer()
    {
        DataTable dt = new DataTable();
        dt = objnews.getAfterLoginOffer();
        if (dt.Rows.Count > 0)
        {
            //HttpCookie myCookie = new HttpCookie(dt.Rows[0]["imagename"].ToString());
            //myCookie.Value = dt.Rows[0]["imagename"].ToString();
            //HttpContext.Current.Response.Cookies.Add(myCookie);

            ltofferimage.Text = @"<img src=""../admin/userimage/" + dt.Rows[0]["imagename"].ToString() + @""" style=""width:100%;"" />";
            string popupScript2 = "showModalOffer('" + dt.Rows[0]["imagename"].ToString() + "');";
            ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);
        }
    }
    //void loadnews()
    //{
    //    DataTable dt = new DataTable();
    //    dt = objnews.getRecentNews();
    //    foreach (DataRow r in dt.Rows)
    //    {
    //        ltnews.Text += r["newsdetail"].ToString() + "<br/><hr/>";
    //    }
    //}

    //void laoddata()
    // {
    //     objuser.UserId = Session["userid"].ToString();
    //     DataTable dt = new DataTable();
    //     dt = objuser.getUserDetail(objuser);
    //     if (dt.Rows.Count > 0)
    //     {
    //         lbluserid.Text = dt.Rows[0]["userid"].ToString();
    //         lblusername.Text = dt.Rows[0]["username"].ToString();
    //         lbladdress.Text = dt.Rows[0]["address"].ToString();
    //         lblmobile.Text = dt.Rows[0]["mobile"].ToString();
    //         lblemail.Text = dt.Rows[0]["email"].ToString();
    //         lblaccountholdername.Text = dt.Rows[0]["accountholdername"].ToString();
    //         lblaccountno.Text = dt.Rows[0]["accountno"].ToString();
    //         lblbank.Text = dt.Rows[0]["branchname"].ToString();
    //         lblifsc.Text = dt.Rows[0]["ifsccode"].ToString();
    //         lblpan.Text = dt.Rows[0]["pannumber"].ToString();

    //     }

    // }
    void loaddashboard()
    {
        DataSet ds = new DataSet();
        objuser.UserId = Session["userid"].ToString();
        ds = objuser.get_DashboardUser(objuser);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (ds.Tables[0].Rows[0]["package"].ToString() != "")
                //{
                //    lblmypackage.Text = ds.Tables[0].Rows[0]["package"].ToString();
                //}
                //else
                //{
                //    lblmypackage.Text = "NA";
                //}
                //lblcurrentpool.Text= ds.Tables[0].Rows[0]["poolname"].ToString();
                // lbllevelicnome.Text = ds.Tables[0].Rows[0]["levelincome"].ToString();
                lblbalanceamount.Text = ds.Tables[0].Rows[0]["balanceamount"].ToString();
                lblewalletbalance.Text = ds.Tables[0].Rows[0]["ewalletbalance"].ToString();
                lblcoinbalance.Text = ds.Tables[0].Rows[0]["coinbalance"].ToString();
                lblcoinbalance2.Text = ds.Tables[0].Rows[0]["coinbalance"].ToString();
                lblrijentbalance.Text = ds.Tables[0].Rows[0]["rijentbalance"].ToString();
                lblbalanceamount2.Text = ds.Tables[0].Rows[0]["balanceamount"].ToString();
                lblredeemedbalance.Text = Math.Round( Convert.ToDecimal( ds.Tables[0].Rows[0]["MWalletBalanceRedeemed"].ToString()),2).ToString();

                Session["joiningdate"] = ds.Tables[0].Rows[0]["joiningdate"].ToString();
                Session["activationdate"] = ds.Tables[0].Rows[0]["activationdate"].ToString();

            }
        }
        //if (ds.Tables[1].Rows[0]["activestatus"].ToString() == "1")
        //{
        //    if (lblmypackage.Text == "499")
        //    {
        //        divroi.Visible = true;
        //    }
        //    else
        //    {
        //        divroi.Visible = false;
        //    }
        //}
        //else
        //{
        //    divroi.Visible = false;
        //}

        //GridView1.DataSource = ds.Tables[2];
        //GridView1.DataBind();
    }

    // void loadcountdata()
    // {
    //     DataTable dt = new DataTable();
    //     objuser.UserId = Session["userid"].ToString();
    //     dt = objuser.getUserDashboardSummary(objuser);
    //     if (dt.Rows.Count > 0)
    //     {
    //         lbltotalteam.Text = dt.Rows[0]["totalteam"].ToString();
    //         lblleftteam.Text = dt.Rows[0]["lcount"].ToString();
    //         lblrightteam.Text = dt.Rows[0]["rcount"].ToString();
    //         lblleftbusiness.Text = dt.Rows[0]["lbusiness"].ToString();
    //         lblleftbusinesstoday.Text = dt.Rows[0]["lbusinesstoday"].ToString();
    //         lblrightbusiness.Text = dt.Rows[0]["rbusiness"].ToString();
    //         lblrightbusinesstoday.Text = dt.Rows[0]["rbusinesstoday"].ToString();
    //     }
    //     else
    //     {
    //         lbltotalteam.Text = "0";
    //         lblleftteam.Text = "0";
    //         lblrightteam.Text = "0";
    //         lblleftbusiness.Text = "0";
    //         lblleftbusinesstoday.Text = "0";
    //         lblrightbusiness.Text = "0";
    //         lblrightbusinesstoday.Text = "0";
    //     }
    // }
    // protected void Timer1_Tick(object sender, EventArgs e)
    // {
    //     this.loadcountdata();
    //     Timer1.Enabled = false;
    //     imgLoader.Visible = false;
    //     imgLoader2.Visible = false;
    //     imgLoader3.Visible = false;
    //     imgLoader4.Visible = false;
    //     imgLoader5.Visible = false;
    //     imgLoader6.Visible = false;
    //     imgLoader7.Visible = false;

    //     lbltotalteam.Visible = true;
    //     lblleftteam.Visible = true;
    //     lblrightteam.Visible = true;
    //     lblleftbusiness.Visible = true;
    //     lblrightbusiness.Visible = true;
    //     lblleftbusinesstoday.Visible = true;
    //     lblrightbusinesstoday.Visible = true;
    // }

    protected void btnDeposit_Click(object sender, EventArgs e)
    {

    }

    protected void btnDepositApprove_Click(object sender, EventArgs e)
    {

    }

    protected void btnwithdrawal_Click(object sender, EventArgs e)
    {

    }

    protected void btnwithdrawalapprove_Click(object sender, EventArgs e)
    {

    }
}