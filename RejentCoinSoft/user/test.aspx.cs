using BusinessLogicTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class User_test : System.Web.UI.Page
{
    clsUser objUser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        loadbinary(Request.QueryString["SuperId"].ToString());
    }

    DataTable getleftdata(string str_id)
    {
        DataTable dt = new DataTable();
        objUser.UserId = str_id;
        dt = objUser.getLeftDataPlanWise2(objUser);
        return dt;
    }
    DataTable getRightdata(string str_id)
    {
        DataTable dt = new DataTable();
        objUser.UserId = str_id;
        dt = objUser.getRightDataPlanWise2(objUser);
        return dt;
    }

    void loadbinary(string str_superid)
    {
        objUser.UserId = str_superid;
        DataTable dt = new DataTable();
        dt = objUser.getUserName(objUser);
        if (dt.Rows.Count > 0)
        {
            string strimagemain = "";
            if (Convert.ToDecimal(dt.Rows[0]["activestatus"].ToString()) == Convert.ToDecimal("0"))
            {
                strimagemain = "0.png";
            }
            else
            {
                strimagemain = "35000.png";
            }
            lbluserid1new.Text = dt.Rows[0]["Userid"].ToString();
            lbluserid1.Text = "<a href='test.aspx?SuperId=" + dt.Rows[0]["Userid"].ToString() + @"' >" + dt.Rows[0]["Userid"].ToString() + @"</a>";
            lblusername1.Text = "<a href='test.aspx?SuperId=" + dt.Rows[0]["Userid"].ToString() + @"' >" + dt.Rows[0]["username"].ToString() +@"</a>";
            ltuser1.Text = @"<a href='test.aspx?SuperId=" + dt.Rows[0]["Userid"].ToString() + @"'  data-html=""true""   class='showpopover'  data-content=""" + getBinarydata(lbluserid1new.Text) + @""" rel=""popover"" data-placement=""bottom"" data-original-title=""Binary Details"" data-trigger=""hover"" ><img src=""binaryimage/" + strimagemain + @""" style=""height:70px;"" /></a>";


            //================ Second Child============
            DataTable dt2 = new DataTable();
            dt2 = loadchild(lbluserid1new.Text, "1");
            if (dt2.Rows.Count > 0)
            {

                string strimagemain2 = "";
                if (Convert.ToDecimal(dt2.Rows[0]["activestatus"].ToString()) == Convert.ToDecimal("0"))
                {
                    strimagemain2 = "0.png";
                }
                else
                {
                    strimagemain2 = "35000.png";
                }
                lbluserid2new.Text = dt2.Rows[0]["Userid"].ToString();
                lbluserid2.Text = "<a href='test.aspx?SuperId=" + dt2.Rows[0]["Userid"].ToString() + @"' >" + dt2.Rows[0]["Userid"].ToString() + "</a>";
                lblusername2.Text = "<a href='test.aspx?SuperId=" + dt2.Rows[0]["Userid"].ToString() + @"' >" + dt2.Rows[0]["username"].ToString() +  @"</a>";
                ltuser2.Text = @"<a href='test.aspx?SuperId=" + dt2.Rows[0]["Userid"].ToString() + @"'   data-html=""true""   class='showpopover'  data-content=""" + getBinarydata(lbluserid2new.Text) + @""" rel=""popover"" data-placement=""bottom"" data-original-title=""Binary Details"" data-trigger=""hover""  ><img src=""binaryimage/" + strimagemain2 + @""" style=""height:70px;"" /></a>";
            }
            else
            {
                ltuser2.Text = @"<img src=""binaryimage/na.png"" style=""height:70px;"" />";
                lbluserid2.Text = @"<a href=""../Register.aspx?sid=" + lbluserid1new.Text + @"&p=1"" target=""_blank"">New</a>";
            }


            //================ Second Child============


            //================ Third Child============

            DataTable dt3 = new DataTable();
            dt3 = loadchild(lbluserid1new.Text, "2");
            if (dt3.Rows.Count > 0)
            {
                string strimagemain2 = "";
                if (Convert.ToDecimal(dt3.Rows[0]["activestatus"].ToString()) == Convert.ToDecimal("0"))
                {
                    strimagemain2 = "0.png";
                }
                else
                {
                    strimagemain2 = "35000.png";
                }
                lbluserid3new.Text = dt3.Rows[0]["Userid"].ToString();
                lbluserid3.Text = "<a href='test.aspx?SuperId=" + dt3.Rows[0]["Userid"].ToString() + @"' >" + dt3.Rows[0]["Userid"].ToString() + "</a>";
                lblusername3.Text = "<a href='test.aspx?SuperId=" + dt3.Rows[0]["Userid"].ToString() + @"' >" + dt3.Rows[0]["username"].ToString() +  @"</a>";
                ltuser3.Text = @"<a href='test.aspx?SuperId=" + dt3.Rows[0]["Userid"].ToString() + @"'    data-html=""true""   class='showpopover'  data-content=""" + getBinarydata(lbluserid3new.Text) + @""" rel=""popover"" data-placement=""bottom"" data-original-title=""Binary Details"" data-trigger=""hover""  ><img src=""binaryimage/" + strimagemain2 + @""" style=""height:70px;"" /></a>";

            }
            else
            {
                ltuser3.Text = @"<img src=""binaryimage/na.png"" style=""height:70px;"" />";

                lbluserid3.Text = @"<a href=""../Register.aspx?sid=" + lbluserid1new.Text + @"&p=2"" target=""_blank"">New</a>";
            }


            //================ Third Child============

            //================ Fourth Child============

            DataTable dt4 = new DataTable();
            dt4 = loadchild(lbluserid2new.Text, "1");
            if (dt4.Rows.Count > 0)
            {
                string strimagemain2 = "";
                if (Convert.ToDecimal(dt4.Rows[0]["activestatus"].ToString()) == Convert.ToDecimal("0"))
                {
                    strimagemain2 = "0.png";
                }
                else
                {
                    strimagemain2 = "35000.png";
                }
                lbluserid4new.Text = dt4.Rows[0]["Userid"].ToString();
                lbluserid4.Text = "<a href='test.aspx?SuperId=" + dt4.Rows[0]["Userid"].ToString() + @"' >" + dt4.Rows[0]["Userid"].ToString() + @"</a>";
                lblusername4.Text = "<a href='test.aspx?SuperId=" + dt4.Rows[0]["Userid"].ToString() + @"' >" + dt4.Rows[0]["username"].ToString() +@"</a>";
                ltuser4.Text = @"<a href='test.aspx?SuperId=" + dt4.Rows[0]["Userid"].ToString() + @"'    data-html=""true""   class='showpopover'  data-content=""" + getBinarydata(lbluserid4new.Text) + @""" rel=""popover"" data-placement=""bottom"" data-original-title=""Binary Details"" data-trigger=""hover"" '  ><img src=""binaryimage/" + strimagemain2 + @""" style=""height:70px;"" /></a>";

            }
            else
            {
                ltuser4.Text = @"<img src=""binaryimage/na.png"" style=""height:70px;"" />";

                lbluserid4.Text = @"<a href=""../Register.aspx?sid=" + lbluserid2new.Text + @"&p=1"" target=""_blank"">New</a>";
            }


            //================ Fourth Child============


            //================ Fifth Child============

            DataTable dt5 = new DataTable();
            dt5 = loadchild(lbluserid2new.Text, "2");
            if (dt5.Rows.Count > 0)
            {
                string strimagemain2 = "";
                if (Convert.ToDecimal(dt5.Rows[0]["activestatus"].ToString()) == Convert.ToDecimal("0"))
                {
                    strimagemain2 = "0.png";
                }
                else
                {
                    strimagemain2 = "35000.png";
                }
                lbluserid5new.Text = dt5.Rows[0]["Userid"].ToString();
                lbluserid5.Text = "<a href='test.aspx?SuperId=" + dt5.Rows[0]["Userid"].ToString() + @"' >" + dt5.Rows[0]["Userid"].ToString() + @"</a>";
                lblusername5.Text = "<a href='test.aspx?SuperId=" + dt5.Rows[0]["Userid"].ToString() + @"' >" + dt5.Rows[0]["username"].ToString() +  @"</a>";
                ltuser5.Text = @"<a href='test.aspx?SuperId=" + dt5.Rows[0]["Userid"].ToString() + @"'   data-html=""true""   class='showpopover'  data-content=""" + getBinarydata(lbluserid5new.Text) + @""" rel=""popover"" data-placement=""bottom"" data-original-title=""Binary Details"" data-trigger=""hover""  ><img src=""binaryimage/" + strimagemain2 + @""" style=""height:70px;"" /></a>";


            }
            else
            {
                ltuser5.Text = @"<img src=""binaryimage/na.png"" style=""height:70px;"" />";

                lbluserid5.Text = @"<a href=""../Register.aspx?sid=" + lbluserid2new.Text + @"&p=2"" target=""_blank"">New</a>";
            }


            //================ Fifth Child============


            //================ Sixth Child============

            DataTable dt6 = new DataTable();
            dt6 = loadchild(lbluserid3new.Text, "1");
            if (dt6.Rows.Count > 0)
            {
                string strimagemain2 = "";
                if (Convert.ToDecimal(dt6.Rows[0]["activestatus"].ToString()) == Convert.ToDecimal("0"))
                {
                    strimagemain2 = "0.png";
                }
                else
                {
                    strimagemain2 = "35000.png";
                }
                lbluserid6new.Text = dt6.Rows[0]["Userid"].ToString();
                lbluserid6.Text = "<a href='test.aspx?SuperId=" + dt6.Rows[0]["Userid"].ToString() + @"' >" + dt6.Rows[0]["Userid"].ToString() + @"</a>";
                lblusername6.Text = "<a href='test.aspx?SuperId=" + dt6.Rows[0]["Userid"].ToString() + @"' >" + dt6.Rows[0]["username"].ToString() +  @"</a>";
                ltuser6.Text = @"<a href='test.aspx?SuperId=" + dt6.Rows[0]["Userid"].ToString() + @"'    data-html=""true""   class='showpopover'  data-content=""" + getBinarydata(lbluserid6new.Text) + @""" rel=""popover"" data-placement=""bottom"" data-original-title=""Binary Details"" data-trigger=""hover""  ><img src=""binaryimage/" + strimagemain2 + @""" style=""height:70px;"" /></a>";



            }
            else
            {
                ltuser6.Text = @"<img src=""binaryimage/na.png"" style=""height:70px;"" />";

                lbluserid6.Text = @"<a href=""../Register.aspx?sid=" + lbluserid3new.Text + @"&p=1"" target=""_blank"">New</a>";
            }


            //================ Sixth Child============


            //================ Seventh Child============

            DataTable dt7 = new DataTable();
            dt7 = loadchild(lbluserid3new.Text, "2");
            if (dt7.Rows.Count > 0)
            {
                string strimagemain2 = "";
                if (Convert.ToDecimal(dt7.Rows[0]["activestatus"].ToString()) == Convert.ToDecimal("0"))
                {
                    strimagemain2 = "0.png";
                }
                else
                {
                    strimagemain2 = "35000.png";
                }
                lbluserid7new.Text = dt7.Rows[0]["Userid"].ToString();
                lbluserid7.Text = "<a href='test.aspx?SuperId=" + dt7.Rows[0]["Userid"].ToString() + @"' >" + dt7.Rows[0]["Userid"].ToString() + @"</a>";
                lblusername7.Text = "<a href='test.aspx?SuperId=" + dt7.Rows[0]["Userid"].ToString() + @"' >" + dt7.Rows[0]["username"].ToString() +  @"</a>";
                ltuser7.Text = @"<a href='test.aspx?SuperId=" + dt7.Rows[0]["Userid"].ToString() + @"'   data-html=""true""   class='showpopover'  data-content=""" + getBinarydata(lbluserid7new.Text) + @""" rel=""popover"" data-placement=""bottom"" data-original-title=""Binary Details"" data-trigger=""hover""  ><img src=""binaryimage/" + strimagemain2 + @""" style=""height:70px;"" /></a>";
            }
            else
            {
                ltuser7.Text = @"<img src=""binaryimage/na.png"" style=""height:70px;"" />";

                lbluserid7.Text = @"<a href=""../Register.aspx?sid=" + lbluserid3new.Text + @"&p=2"" target=""_blank"">New</a>";
            }
            //================ Seventh Child============
        }
        else
        {
            //divdata.Visible = false;
            Message.Show("Invalid User Id...!!!");
        }

    }

    DataTable loadchild(string str_parentid, string str_position)
    {
        if (str_parentid == "")
        {
            str_parentid = "-2";
        }
        objUser.ParentUserId = str_parentid;

        objUser.StandingPosition = str_position;
        DataTable dt = new DataTable();
        dt = objUser.getUserChild(objUser);
        return dt;
    }
    string getBinarydata(string userid)
    {
        DataTable dt = new DataTable();
        objUser.UserId = userid;
        dt = objUser.get_UserBinaryData(objUser);
        string str_data = "";
        if (dt.Rows.Count > 0)
        {

            decimal dcLeftBusiness = Convert.ToDecimal(dt.Rows[0]["Lbusiness"].ToString());
            decimal dcRightBusiness = Convert.ToDecimal(dt.Rows[0]["Rbusiness"].ToString());
            decimal dcMatchBusiness = 0.00M;
            decimal dcLeftBalance = 0.00M;
            decimal dcRightBalance = 0.00M;

            if (dcLeftBusiness >= dcRightBusiness)
            {
                dcMatchBusiness = dcRightBusiness;
                dcLeftBalance = dcLeftBusiness - dcMatchBusiness;
            }
            else
            {
                dcMatchBusiness = dcLeftBusiness;
                dcRightBalance = dcRightBusiness - dcMatchBusiness;
            }


            str_data = @"
 <table id='SalaryTable' class='table table-bordered table-hover' style='width:250px;' >
                                               <tbody> 
 <tr role='row' class='odd'>
                                                      
                                                        <td>User Id </td>
                                                        <td>  " + userid + @"</td>
                                                    </tr>
                              <tr role='row' class='odd'>
                                                      
                                                        <td>User Name </td>
                                                        <td>  " + dt.Rows[0]["username"].ToString() + @"</td>
                                                    </tr>    
 <tr role='row' class='odd'>
                                                      
                                                        <td>Joining Date  </td>
                                                        <td>  " + dt.Rows[0]["mentiondate"].ToString() + @"</td>
                                                    </tr>
                                                     <tr role='row' class='odd'>
                                                      
                                                        <td>Sponsor Id </td>
                                                        <td>  " + dt.Rows[0]["sponserid"].ToString() + @"</td>
                                                    </tr>
                                                    <tr role='row' class='odd'>
                                                      
                                                        <td>Upline Id </td>
                                                        <td>  " + dt.Rows[0]["parentuserid"].ToString() + @"</td>
                                                    </tr>
 <tr role='row' class='odd'>
                                                      
                                                        <td>Topup Amount  </td>
                                                        <td>  " + dt.Rows[0]["planamount"].ToString() + @"</td>
                                                    </tr>
 <tr role='row' class='odd'>
                                                      
                                                        <td>Topup Date </td>
                                                        <td>  " + dt.Rows[0]["topupdate"].ToString() + @"</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                              
                                              

                    <table id='SalaryTable' class='table table-bordered table-hover' style='width:250px;' >
                                                <thead>
                                                    <tr role='row'>
                                                        <th >Business Detail</th>
                                                        <th  >Left Side</th>
                                                        <th  >Right Side</th>
                                                      
                                                    </tr>
                                                </thead>
                                              
                                                <tbody>  <tr role='row' class='even'>
                                                        <td >Count</td>
                                                        <td> " + dt.Rows[0]["lcount"].ToString() + @"</td>
                                                        <td> " + dt.Rows[0]["rcount"].ToString() + @"</td>
                                                    </tr>
                                                    <tr role='row' class='odd'>
                                                        <td >Business</td>
                                                        <td>
                                                          " + dt.Rows[0]["Lbusiness"].ToString() + @"</td>
                                                        <td>  " + dt.Rows[0]["Rbusiness"].ToString() + @"</td>
                                                    </tr>
                                                  
                                                    
                                                   
                                                </tbody>
                                            </table>";
        }
        return str_data;
    }
}