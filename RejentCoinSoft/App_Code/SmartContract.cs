using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using DataTier;

/// <summary>
/// Summary description for cityservice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SmartContract : System.Web.Services.WebService
{

    public SmartContract()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string UpdateWalletAddress(string prefix, string userid)
    {
        string res = "";
        try
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
                Data objdata = new Data();
                conn.ConnectionString = objdata.getConnectionString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_add_UserSmartContractAddressDetail";
                    cmd.Parameters.AddWithValue("@Userid", userid);
                    cmd.Parameters.AddWithValue("@Address", prefix);
                    cmd.Parameters.AddWithValue("@MentionBy", userid);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    res = cmd.ExecuteScalar().ToString();

                    //SqlDataAdapter ad = new SqlDataAdapter();
                    //ad.SelectCommand = cmd;
                    //ad.Fill(dt);
                    //foreach (DataRow r in dt.Rows)
                    //{
                    //    customers.Add(string.Format("{0}-{1}~{2}~{3}~{4}", r["ProductName"], r["ProductId"], r["mrp"], r["dp"], r["gst"]));
                    //}
                    conn.Close();
                }
            }
        }
        catch (Exception ep)
        {
            res = ep.Message.ToString();
        }


        return res;
    }
    [WebMethod]
    public string Approve(string userid)
    {
        string res = "";
        try
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
                Data objdata = new Data();
                conn.ConnectionString = objdata.getConnectionString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_UpdateisWithdrawalApprove";
                    cmd.Parameters.AddWithValue("@Userid", userid);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    res = cmd.ExecuteScalar().ToString();

                    //SqlDataAdapter ad = new SqlDataAdapter();
                    //ad.SelectCommand = cmd;
                    //ad.Fill(dt);
                    //foreach (DataRow r in dt.Rows)
                    //{
                    //    customers.Add(string.Format("{0}-{1}~{2}~{3}~{4}", r["ProductName"], r["ProductId"], r["mrp"], r["dp"], r["gst"]));
                    //}
                    conn.Close();
                }
            }
        }
        catch (Exception ep)
        {
            res = ep.Message.ToString();
        }


        return res;
    }

    [WebMethod]
    public string ApproveStaking(string userid)
    {
        string res = "";
        try
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
                Data objdata = new Data();
                conn.ConnectionString = objdata.getConnectionString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_updateStakingApproveStatus";
                    cmd.Parameters.AddWithValue("@Userid", userid);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    res = cmd.ExecuteScalar().ToString();

                    //SqlDataAdapter ad = new SqlDataAdapter();
                    //ad.SelectCommand = cmd;
                    //ad.Fill(dt);
                    //foreach (DataRow r in dt.Rows)
                    //{
                    //    customers.Add(string.Format("{0}-{1}~{2}~{3}~{4}", r["ProductName"], r["ProductId"], r["mrp"], r["dp"], r["gst"]));
                    //}
                    conn.Close();
                }
            }
        }
        catch (Exception ep)
        {
            res = ep.Message.ToString();
        }


        return res;
    }

    [WebMethod]
    public string DepositCoin(string Amount, string userid, string FromWalletAddress, string ToWalletAddress, string ReferenceId)
    {
        string res = "";
        try
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
                Data objdata = new Data();
                conn.ConnectionString = objdata.getConnectionString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_DepositCoin";
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@Userid", userid);
                    cmd.Parameters.AddWithValue("@FromWalletAddress", FromWalletAddress);
                    cmd.Parameters.AddWithValue("@ToWalletAddress", ToWalletAddress);
                    cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                    cmd.Parameters.AddWithValue("@MentionBy", userid);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    res = cmd.ExecuteScalar().ToString();

                    //SqlDataAdapter ad = new SqlDataAdapter();
                    //ad.SelectCommand = cmd;
                    //ad.Fill(dt);
                    //foreach (DataRow r in dt.Rows)
                    //{
                    //    customers.Add(string.Format("{0}-{1}~{2}~{3}~{4}", r["ProductName"], r["ProductId"], r["mrp"], r["dp"], r["gst"]));
                    //}
                    conn.Close();
                    if (res == "Coin Deposited Successfully")
                    {
                        string str_body = @"<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
   <head>
      <meta charset=""UTF-8"">
      <meta content=""width=device-width, initial-scale=1"" name=""viewport"">
      <meta name=""x-apple-disable-message-reformatting"">
      <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
      <meta content=""telephone=no"" name=""format-detection"">
      <title></title>
   </head>
   <style type=""text/css"">
      #outlook a{padding:0}.ExternalClass{width:100%}.brt{border-top:1px solid #eaeaea}.verOTP{font-size:32px;color:#ed8e20;font-weight:600}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div{line-height:100%}.es-button{mso-style-priority:100!important;text-decoration:none!important}a[x-apple-data-detectors]{color:inherit!important;text-decoration:none!important;font-size:inherit!important;font-family:inherit!important;font-weight:inherit!important;line-height:inherit!important}.es-desk-hidden{display:none;float:left;overflow:hidden;width:0;max-height:0;line-height:0;mso-hide:all}[data-ogsb] .es-button{border-width:0!important;padding:15px 30px 15px 30px!important}s{text-decoration:line-through}html,body{width:100%;font-family:'open sans','helvetica neue',helvetica,arial,sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%}table{mso-table-lspace:0;mso-table-rspace:0;border-collapse:collapse;border-spacing:0}table td,html,body,.es-wrapper{padding:0;Margin:0}.es-content,.es-header,.es-footer{table-layout:fixed!important;width:100%}img{display:block;border:0;outline:0;text-decoration:none;-ms-interpolation-mode:bicubic}table tr{border-collapse:collapse}p,hr{Margin:0}h1,h2,h3,h4,h5{Margin:0;line-height:120%;mso-line-height-rule:exactly;font-family:'open sans','helvetica neue',helvetica,arial,sans-serif}p,ul li,ol li,a{-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly}.es-left{float:left}.es-right{float:right}.es-p5{padding:5px}.es-p5t{padding-top:5px}.es-p5b{padding-bottom:5px}.es-p5l{padding-left:5px}.es-p5r{padding-right:5px}.es-p10{padding:10px}.es-p10t{padding-top:10px}.es-p10b{padding-bottom:10px}.es-p10l{padding-left:10px}.es-p10r{padding-right:10px}.es-p15{padding:15px}.es-p15t{padding-top:15px}.es-p15b{padding-bottom:15px}.es-p15l{padding-left:15px}.es-p15r{padding-right:15px}.es-p20{padding:20px}.es-p20t{padding-top:20px}.es-p20b{padding-bottom:20px}.es-p20l{padding-left:20px}.es-p20r{padding-right:20px}.es-p25{padding:25px}.es-p25t{padding-top:25px}.es-p25b{padding-bottom:25px}.es-p25l{padding-left:25px}.es-p25r{padding-right:25px}.es-p30{padding:30px}.es-p30t{padding-top:30px}.es-p30b{padding-bottom:30px}.es-p30l{padding-left:30px}.es-p30r{padding-right:30px}.es-p35{padding:35px}.es-p35t{padding-top:35px}.es-p35b{padding-bottom:35px}.es-p35l{padding-left:35px}.es-p35r{padding-right:35px}.es-p40{padding:40px}.es-p40t{padding-top:40px}.es-p40b{padding-bottom:40px}.es-p40l{padding-left:40px}.es-p40r{padding-right:40px}.es-menu td{border:0}.es-menu td a img{display:inline-block!important}a{text-decoration:none}p,ul li,ol li{font-family:'open sans','helvetica neue',helvetica,arial,sans-serif;line-height:150%}ul li,ol li{Margin-bottom:15px}.es-menu td a{text-decoration:none;display:block;font-family:'open sans','helvetica neue',helvetica,arial,sans-serif}.es-wrapper{width:100%;height:100%;background-image:;background-repeat:repeat;background-position:center top}.es-wrapper-color{background-color:#eee}.es-header{background-color:transparent;background-image:;background-repeat:repeat;background-position:center top}.es-header-body{background-image:linear-gradient(to right,#333 0,#495057 50%,#333 100%)}.es-header-body p,.es-header-body ul li,.es-header-body ol li{color:#fff;font-size:14px}.es-header-body a{color:#fff;font-size:14px}.es-content-body{background-color:#fff}.es-content-body p,.es-content-body ul li,.es-content-body ol li{color:#333;font-size:16px}.es-content-body a{color:#ed8e20;font-size:16px}.es-footer{background-color:transparent;background-image:;background-repeat:repeat;background-position:center top}.es-footer-body{background-color:#fff}.es-footer-body p,.es-footer-body ul li,.es-footer-body ol li{color:#333;font-size:14px}.es-footer-body a{color:#333;font-size:14px}.es-infoblock,.es-infoblock p,.es-infoblock ul li,.es-infoblock ol li{line-height:120%;font-size:12px;color:#ccc}.es-infoblock a{font-size:12px;color:#ccc}h1{font-size:36px;font-style:normal;font-weight:bold;color:#333}h2{font-size:30px;font-style:normal;font-weight:bold;color:#333}h3{font-size:18px;font-style:normal;font-weight:normal;color:#333}.es-header-body h1 a,.es-content-body h1 a,.es-footer-body h1 a{font-size:36px}.es-header-body h2 a,.es-content-body h2 a,.es-footer-body h2 a{font-size:30px}.es-header-body h3 a,.es-content-body h3 a,.es-footer-body h3 a{font-size:18px}a.es-button, button.es-button {border-radius: 6px;font-size: 20px;font-family: 'open sans','helvetica neue',helvetica,arial,sans-serif;font-weight: normal;font-style: normal;color: #fff;width: auto;text-align: center;background: linear-gradient( 90deg,#ffbd39 0,#fa9531 100%);padding: 12px 25px;}es-button-border{border-style:solid solid solid solid;border-color:transparent transparent transparent transparent;background:#66b3b7;border-width:0;display:inline-block;border-radius:5px;width:auto}@media only screen and (max-width:600px){p,ul li,ol li,a{line-height:150%!important}h1,h2,h3,h1 a,h2 a,h3 a{line-height:120%!important}h1{font-size:32px!important;text-align:center}h2{font-size:26px!important;text-align:center}h3{font-size:20px!important;text-align:center}.es-header-body h1 a,.es-content-body h1 a,.es-footer-body h1 a{font-size:32px!important}.es-header-body h2 a,.es-content-body h2 a,.es-footer-body h2 a{font-size:26px!important}.es-header-body h3 a,.es-content-body h3 a,.es-footer-body h3 a{font-size:20px!important}.es-menu td a{font-size:16px!important}.es-header-body p,.es-header-body ul li,.es-header-body ol li,.es-header-body a{font-size:16px!important}.es-content-body p,.es-content-body ul li,.es-content-body ol li,.es-content-body a{font-size:16px!important}.es-footer-body p,.es-footer-body ul li,.es-footer-body ol li,.es-footer-body a{font-size:16px!important}.es-infoblock p,.es-infoblock ul li,.es-infoblock ol li,.es-infoblock a{font-size:12px!important}*[class=""gmail-fix""]{display:none!important}.es-m-txt-c,.es-m-txt-c h1,.es-m-txt-c h2,.es-m-txt-c h3{text-align:center!important}.es-m-txt-r,.es-m-txt-r h1,.es-m-txt-r h2,.es-m-txt-r h3{text-align:right!important}.es-m-txt-l,.es-m-txt-l h1,.es-m-txt-l h2,.es-m-txt-l h3{text-align:left!important}.es-m-txt-r img,.es-m-txt-c img,.es-m-txt-l img{display:inline!important}.es-button-border{display:inline-block!important}a.es-button,button.es-button{font-size:16px!important;display:inline-block!important;border-width:15px 30px 15px 30px!important}.es-btn-fw{border-width:10px 0!important;text-align:center!important}.es-adaptive table,.es-btn-fw,.es-btn-fw-brdr,.es-left,.es-right{width:100%!important}.es-content table,.es-header table,.es-footer table,.es-content,.es-footer,.es-header{width:100%!important;max-width:600px!important}.es-adapt-td{display:block!important;width:100%!important}.adapt-img{width:100%!important;height:auto!important}.es-m-p0{padding:0!important}.es-m-p0r{padding-right:0!important}.es-m-p0l{padding-left:0!important}.es-m-p0t{padding-top:0!important}.es-m-p0b{padding-bottom:0!important}.es-m-p20b{padding-bottom:20px!important}.es-mobile-hidden,.es-hidden{display:none!important}tr.es-desk-hidden,td.es-desk-hidden,table.es-desk-hidden{width:auto!important;overflow:visible!important;float:none!important;max-height:inherit!important;line-height:inherit!important}tr.es-desk-hidden{display:table-row!important}table.es-desk-hidden{display:table!important}td.es-desk-menu-hidden{display:table-cell!important}.es-menu td{width:1%!important}table.es-table-not-adapt,.esd-block-html table{width:auto!important}table.es-social{display:inline-block!important}table.es-social td{display:inline-block!important}}.es-p-default{padding-top:20px;padding-right:35px;padding-bottom:0;padding-left:35px}.es-p-all-default{padding:0}.emailTitle p{line-height:30px}
   </style>

   <body>
      <div class=""es-wrapper-color"">
         <table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"">
            <tbody>
               <tr>
                  <td class=""esd-email-paddings"" valign=""top"">
                     <table class=""es-content"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                        <tbody>
                           <tr></tr>
                           <tr>
                              <td class=""esd-stripe"" esd-custom-block-id=""7681"" align=""center"">
                                 <table class=""es-header-body"" style=""background-image: linear-gradient(to right, #333 0%, #495057 50%, #333 100%);"" width=""600"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#044767"" align=""center"">
                                    <tbody>
                                       <tr>
                                          <td class=""esd-structure es-p15t es-p15b es-p35r es-p35l"" align=""left"">
                                             <!--[if mso]>
                                             <table width=""530"" cellpadding=""0"" cellspacing=""0"">
                                                <tr>
                                                   <td width=""340"" valign=""top"">
                                                      <![endif]-->
                                                      <table class=""es-left"" cellspacing=""0"" cellpadding=""0"" align=""left"">
                                                         <tbody>
                                                            <tr>
                                                               <td class=""es-m-p0r es-m-p20b esd-container-frame"" width=""340"" valign=""top"" align=""center"">
                                                                  <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                                     <tbody>
                                                                        <tr>
                                                                           <td class=""esd-block-text es-m-txt-c"" align=""left"">
                                                                              <!--h1 style=""color: #ffffff; line-height: 100%;"">Beretun</h1-->
                                                                              <img src=""http://teamrijent.in/EmailTemplate/images/Rijentlogo.png"" width=""240"">
                                                                           </td>
                                                                        </tr>
                                                                     </tbody>
                                                                  </table>
                                                               </td>
                                                            </tr>
                                                         </tbody>
                                                      </table>
                                                      <table cellspacing=""0"" cellpadding=""0"" align=""right"">
                                                         <tbody>
                                                            <tr class=""es-hidden"">
                                                               <td class=""es-m-p20b esd-container-frame"" esd-custom-block-id=""7704"" width=""170"" align=""left"">
                                                                  <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                                     
                                                                  </table>
                                                               </td>
                                                            </tr>
                                                         </tbody>
                                                      </table>
                                                      <!--[if mso]>
                                                   </td>
                                                </tr>
                                             </table>
                                             <![endif]-->
                                          </td>
                                       </tr>
                                    </tbody>
                                 </table>
                              </td>
                           </tr>
                        </tbody>
                     </table>
                     <table class=""es-content"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                        <tbody>
                           <tr>
                              <td class=""esd-stripe"" align=""center"">
                                 <table class=""es-content-body"" width=""600"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#ffffff"" align=""center"">
                                    <tbody>
                                       <tr>
                                          <td class=""esd-structure es-p10t es-p35r es-p35l"" align=""left"">
                                             <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                <tbody>
                                                   <tr>
                                                      <td class=""esd-container-frame"" width=""530"" valign=""top"" align=""center"">
                                                         <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                            <tbody>
                                                               <tr>
                                                                  <td class=""esd-block-image es-p10t es-p25b es-p35r es-p35l"" align=""center"" style=""font-size:0""><a target=""_blank"" href=""https://teamrijent.in/""><img src=""http://teamrijent.in/EmailTemplate/images/success.gif"" alt="""" style=""display: block;"" width=""120""></a></td>
                                                               </tr>
                                                               <tr>
                                                                  <td class=""esd-block-text es-p10b"" align=""center"">
                                                                     <h2>Deposit Confirmed</h2>
                                                                  </td>
                                                               </tr><br>
                                                               <tr>
                                                                  <td class=""emailTitle esd-block-text es-p15t es-p20b"" align=""left"">
                                                                     <p style=""font-size: 16px; color:#000;"">You've received <b>" + Amount + @" RTC</b> in your Rijent account.</p>
                                                                      <p>Reference Id : <b>" + ReferenceId + @"</b></p>
                                                                      <p>IP Address : <b>" + GetIPAddress() + @"</b></p><br><br>
                                                                     <p>Only 30 second to participate our survey to help us become better </p><br>
                                                                     <p><span class=""es-button-border""><a href=""https://teamrijent.in/"" class=""es-button"" target=""_blank"">Participate Now</a></span></p><br><br>

                                                                     <p>If you don't recognize this activity, please contact us immediately at <a href=""https://teamrijent.in/"" target=""_blank"">https://teamrijent.in/</a> </p><br><br>
                                                                     <p><b>Rijent Coin Team</b><br>This is automated generated mail, please don't reply.</p>
                                                                  </td>
                                                               </tr><br>
                                                               <tr>
                                                                  <td class=""esd-block-image es-p15b"" align=""center"" style=""font-size:0""><a target=""_blank"" href=""""><img src=""http://teamrijent.in/EmailTemplate/images/play-store.png"" alt=""Beretun logo"" style=""display: block;"" title=""Beretun logo"" width=""180""></a><p><strong>Download Mobile App </strong></p></td>
                                                               </tr>
                                                            </tbody>
                                                         </table>
                                                      </td>
                                                   </tr>
                                                </tbody>
                                             </table>
                                          </td>
                                       </tr>
                                    </tbody>
                                 </table>
                              </td>
                           </tr>
                        </tbody>
                     </table>
                     <table cellpadding=""0"" cellspacing=""0"" class=""es-footer"" align=""center"">
                        <tbody>
                           <tr>
                              <td class=""esd-stripe"" esd-custom-block-id=""7684"" align=""center"">
                                 <table class=""es-footer-body"" width=""600"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                                    <tbody>
                                       <tr>
                                          <td class=""esd-structure es-p25t brt es-p20b es-p35r es-p35l"" align=""left"">
                                             <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                <tbody>
                                                   <tr>
                                                      <td class=""esd-container-frame"" width=""530"" valign=""top"" align=""center"">
                                                         <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                            <tbody>
                                                               
                                                               <tr>
                                                                  <td esdev-links-color=""#777777"" align=""left"" class=""esd-block-text es-m-txt-c es-p5b"">
                                                                     <p style=""text-align: center;"">Copyright  2021 <a href=""https://teamrijent.in/"" target=""_blank""><b>   Rijent Coin</b></a> All Rights Reserved.</p>
                                                                  </td>
                                                               </tr>
                                                            </tbody>
                                                         </table>
                                                      </td>
                                                   </tr>
                                                </tbody>
                                             </table>
                                          </td>
                                       </tr>
                                    </tbody>
                                 </table>
                              </td>
                           </tr>
                        </tbody>
                     </table>
                  </td>
               </tr>
            </tbody>
         </table>
      </div>
   </body>
</html>";

                        sendemail(userid, "Tean Rijent-Coin Deposited Successfully", str_body);
                    }
                }
            }
        }
        catch (Exception ep)
        {
            res = ep.Message.ToString();
        }


        return res;
    }
    public string GetIPAddress()
    {
        string ipaddress;
        ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipaddress == "" || ipaddress == null)
            ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        return ipaddress;
    }
    void sendemail(string userid, string str_subject, string str_body)
    {

        try
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
                Data objdata = new Data();
                conn.ConnectionString = objdata.getConnectionString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT ud.userid,ud.mobile,ud.email FROM UserDetail ud WITH  (nolock)    where ud.userid='" + userid + "' ";

                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataAdapter ad = new SqlDataAdapter();
                    ad.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    ad.Fill(dt);

                    conn.Close();
                    if (dt.Rows.Count > 0)
                    {
                        try
                        {
                            string str_email = dt.Rows[0]["email"].ToString();


                            String FROM = "alert@teamrijent.in";
                            String FROMNAME = "";

                            // Replace recipient@example.com with a "To" address. If your account 
                            // is still in the sandbox, this address must be verified.
                            String TO = str_email;

                            // Replace smtp_username with your Amazon SES SMTP user name.
                            String SMTP_USERNAME = "AKIASDA22VLVCLH5HUWG";

                            // Replace smtp_password with your Amazon SES SMTP password.
                            String SMTP_PASSWORD = "BNtHW5jHMiptjkk9Rrco33guoQBXR+6we1qcmgrS3qLx";

                            // (Optional) the name of a configuration set to use for this message.
                            // If you comment out this line, you also need to remove or comment out
                            // the "X-SES-CONFIGURATION-SET" header below.
                            //String CONFIGSET = "ConfigSet";

                            // If you're using Amazon SES in a region other than US West (Oregon), 
                            // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
                            // endpoint in the appropriate AWS Region.
                            String HOST = "email-smtp.ap-south-1.amazonaws.com";

                            // The port you will connect to on the Amazon SES SMTP endpoint. We
                            // are choosing port 587 because we will use STARTTLS to encrypt
                            // the connection.
                            int PORT = 587;

                            // The subject line of the email
                            String SUBJECT =
                               str_subject;

                            // The body of the email
                            String BODY = str_body;

                            // Create and build a new MailMessage object
                            MailMessage message = new MailMessage();
                            message.IsBodyHtml = true;
                            message.From = new MailAddress(FROM, FROMNAME);
                            message.To.Add(new MailAddress(TO));
                            message.Subject = SUBJECT;
                            message.Body = BODY;
                            // Comment or delete the next line if you are not using a configuration set
                            //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

                            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
                            {
                                // Pass SMTP credentials
                                client.Credentials =
                                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                                // Enable SSL encryption
                                client.EnableSsl = true;

                                // Try to send the message. Show status in console.
                                try
                                {
                                    // Console.WriteLine("Attempting to send email...");
                                    client.Send(message);
                                    // Console.WriteLine("Email sent!");
                                }
                                catch (Exception ex)
                                {
                                    //Console.WriteLine("The email was not sent.");
                                    //Console.WriteLine("Error message: " + ex.Message);
                                }
                            }
                        }
                        catch (Exception ep)
                        {


                        }
                    }
                }
            }
        }
        catch (Exception ep)
        {

        }
    }

    [WebMethod]
    public string WithdrawCoin(string Amount, string userid, string FromWalletAddress, string ToWalletAddress, string ReferenceId, string WalletType, string TransactionId, string AdminPrivateKey)
    {
        string res = "";
        try
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
                Data objdata = new Data();
                conn.ConnectionString = objdata.getConnectionString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_WithdrawlCoin";
                    //cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@Userid", userid);
                    cmd.Parameters.AddWithValue("@FromWalletAddress", FromWalletAddress);
                    cmd.Parameters.AddWithValue("@ToWalletAddress", ToWalletAddress);
                    cmd.Parameters.AddWithValue("@ReferenceId", ReferenceId);
                    cmd.Parameters.AddWithValue("@transactionid", TransactionId);
                    //cmd.Parameters.AddWithValue("@MentionBy", userid);
                    //cmd.Parameters.AddWithValue("@WalletType", userid);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    res = cmd.ExecuteScalar().ToString();

                    //SqlDataAdapter ad = new SqlDataAdapter();
                    //ad.SelectCommand = cmd;
                    //ad.Fill(dt);
                    //foreach (DataRow r in dt.Rows)
                    //{
                    //    customers.Add(string.Format("{0}-{1}~{2}~{3}~{4}", r["ProductName"], r["ProductId"], r["mrp"], r["dp"], r["gst"]));
                    //}
                    conn.Close();
                    if (res == "Coin Withdrawaled Successfully")
                    {
                        string str_body = @"<html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
   <head>
      <meta charset=""UTF-8"">
      <meta content=""width=device-width, initial-scale=1"" name=""viewport"">
      <meta name=""x-apple-disable-message-reformatting"">
      <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
      <meta content=""telephone=no"" name=""format-detection"">
      <title></title>
   </head>
   <style type=""text/css"">
      #outlook a{padding:0}.ExternalClass{width:100%}.brt{border-top:1px solid #eaeaea}.verOTP{font-size:32px;color:#ed8e20;font-weight:600}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div{line-height:100%}.es-button{mso-style-priority:100!important;text-decoration:none!important}a[x-apple-data-detectors]{color:inherit!important;text-decoration:none!important;font-size:inherit!important;font-family:inherit!important;font-weight:inherit!important;line-height:inherit!important}.es-desk-hidden{display:none;float:left;overflow:hidden;width:0;max-height:0;line-height:0;mso-hide:all}[data-ogsb] .es-button{border-width:0!important;padding:15px 30px 15px 30px!important}s{text-decoration:line-through}html,body{width:100%;font-family:'open sans','helvetica neue',helvetica,arial,sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%}table{mso-table-lspace:0;mso-table-rspace:0;border-collapse:collapse;border-spacing:0}table td,html,body,.es-wrapper{padding:0;Margin:0}.es-content,.es-header,.es-footer{table-layout:fixed!important;width:100%}img{display:block;border:0;outline:0;text-decoration:none;-ms-interpolation-mode:bicubic}table tr{border-collapse:collapse}p,hr{Margin:0}h1,h2,h3,h4,h5{Margin:0;line-height:120%;mso-line-height-rule:exactly;font-family:'open sans','helvetica neue',helvetica,arial,sans-serif}p,ul li,ol li,a{-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly}.es-left{float:left}.es-right{float:right}.es-p5{padding:5px}.es-p5t{padding-top:5px}.es-p5b{padding-bottom:5px}.es-p5l{padding-left:5px}.es-p5r{padding-right:5px}.es-p10{padding:10px}.es-p10t{padding-top:10px}.es-p10b{padding-bottom:10px}.es-p10l{padding-left:10px}.es-p10r{padding-right:10px}.es-p15{padding:15px}.es-p15t{padding-top:15px}.es-p15b{padding-bottom:15px}.es-p15l{padding-left:15px}.es-p15r{padding-right:15px}.es-p20{padding:20px}.es-p20t{padding-top:20px}.es-p20b{padding-bottom:20px}.es-p20l{padding-left:20px}.es-p20r{padding-right:20px}.es-p25{padding:25px}.es-p25t{padding-top:25px}.es-p25b{padding-bottom:25px}.es-p25l{padding-left:25px}.es-p25r{padding-right:25px}.es-p30{padding:30px}.es-p30t{padding-top:30px}.es-p30b{padding-bottom:30px}.es-p30l{padding-left:30px}.es-p30r{padding-right:30px}.es-p35{padding:35px}.es-p35t{padding-top:35px}.es-p35b{padding-bottom:35px}.es-p35l{padding-left:35px}.es-p35r{padding-right:35px}.es-p40{padding:40px}.es-p40t{padding-top:40px}.es-p40b{padding-bottom:40px}.es-p40l{padding-left:40px}.es-p40r{padding-right:40px}.es-menu td{border:0}.es-menu td a img{display:inline-block!important}a{text-decoration:none}p,ul li,ol li{font-family:'open sans','helvetica neue',helvetica,arial,sans-serif;line-height:150%}ul li,ol li{Margin-bottom:15px}.es-menu td a{text-decoration:none;display:block;font-family:'open sans','helvetica neue',helvetica,arial,sans-serif}.es-wrapper{width:100%;height:100%;background-image:;background-repeat:repeat;background-position:center top}.es-wrapper-color{background-color:#eee}.es-header{background-color:transparent;background-image:;background-repeat:repeat;background-position:center top}.es-header-body{background-image:linear-gradient(to right,#333 0,#495057 50%,#333 100%)}.es-header-body p,.es-header-body ul li,.es-header-body ol li{color:#fff;font-size:14px}.es-header-body a{color:#fff;font-size:14px}.es-content-body{background-color:#fff}.es-content-body p,.es-content-body ul li,.es-content-body ol li{color:#333;font-size:16px}.es-content-body a{color:#ed8e20;font-size:16px}.es-footer{background-color:transparent;background-image:;background-repeat:repeat;background-position:center top}.es-footer-body{background-color:#fff}.es-footer-body p,.es-footer-body ul li,.es-footer-body ol li{color:#333;font-size:14px}.es-footer-body a{color:#333;font-size:14px}.es-infoblock,.es-infoblock p,.es-infoblock ul li,.es-infoblock ol li{line-height:120%;font-size:12px;color:#ccc}.es-infoblock a{font-size:12px;color:#ccc}h1{font-size:36px;font-style:normal;font-weight:bold;color:#333}h2{font-size:30px;font-style:normal;font-weight:bold;color:#333}h3{font-size:18px;font-style:normal;font-weight:normal;color:#333}.es-header-body h1 a,.es-content-body h1 a,.es-footer-body h1 a{font-size:36px}.es-header-body h2 a,.es-content-body h2 a,.es-footer-body h2 a{font-size:30px}.es-header-body h3 a,.es-content-body h3 a,.es-footer-body h3 a{font-size:18px}a.es-button, button.es-button {border-radius: 6px;font-size: 20px;font-family: 'open sans','helvetica neue',helvetica,arial,sans-serif;font-weight: normal;font-style: normal;color: #fff;width: auto;text-align: center;background: linear-gradient( 90deg,#ffbd39 0,#fa9531 100%);padding: 12px 25px;}es-button-border{border-style:solid solid solid solid;border-color:transparent transparent transparent transparent;background:#66b3b7;border-width:0;display:inline-block;border-radius:5px;width:auto}@media only screen and (max-width:600px){p,ul li,ol li,a{line-height:150%!important}h1,h2,h3,h1 a,h2 a,h3 a{line-height:120%!important}h1{font-size:32px!important;text-align:center}h2{font-size:26px!important;text-align:center}h3{font-size:20px!important;text-align:center}.es-header-body h1 a,.es-content-body h1 a,.es-footer-body h1 a{font-size:32px!important}.es-header-body h2 a,.es-content-body h2 a,.es-footer-body h2 a{font-size:26px!important}.es-header-body h3 a,.es-content-body h3 a,.es-footer-body h3 a{font-size:20px!important}.es-menu td a{font-size:16px!important}.es-header-body p,.es-header-body ul li,.es-header-body ol li,.es-header-body a{font-size:16px!important}.es-content-body p,.es-content-body ul li,.es-content-body ol li,.es-content-body a{font-size:16px!important}.es-footer-body p,.es-footer-body ul li,.es-footer-body ol li,.es-footer-body a{font-size:16px!important}.es-infoblock p,.es-infoblock ul li,.es-infoblock ol li,.es-infoblock a{font-size:12px!important}*[class=""gmail-fix""]{display:none!important}.es-m-txt-c,.es-m-txt-c h1,.es-m-txt-c h2,.es-m-txt-c h3{text-align:center!important}.es-m-txt-r,.es-m-txt-r h1,.es-m-txt-r h2,.es-m-txt-r h3{text-align:right!important}.es-m-txt-l,.es-m-txt-l h1,.es-m-txt-l h2,.es-m-txt-l h3{text-align:left!important}.es-m-txt-r img,.es-m-txt-c img,.es-m-txt-l img{display:inline!important}.es-button-border{display:inline-block!important}a.es-button,button.es-button{font-size:16px!important;display:inline-block!important;border-width:15px 30px 15px 30px!important}.es-btn-fw{border-width:10px 0!important;text-align:center!important}.es-adaptive table,.es-btn-fw,.es-btn-fw-brdr,.es-left,.es-right{width:100%!important}.es-content table,.es-header table,.es-footer table,.es-content,.es-footer,.es-header{width:100%!important;max-width:600px!important}.es-adapt-td{display:block!important;width:100%!important}.adapt-img{width:100%!important;height:auto!important}.es-m-p0{padding:0!important}.es-m-p0r{padding-right:0!important}.es-m-p0l{padding-left:0!important}.es-m-p0t{padding-top:0!important}.es-m-p0b{padding-bottom:0!important}.es-m-p20b{padding-bottom:20px!important}.es-mobile-hidden,.es-hidden{display:none!important}tr.es-desk-hidden,td.es-desk-hidden,table.es-desk-hidden{width:auto!important;overflow:visible!important;float:none!important;max-height:inherit!important;line-height:inherit!important}tr.es-desk-hidden{display:table-row!important}table.es-desk-hidden{display:table!important}td.es-desk-menu-hidden{display:table-cell!important}.es-menu td{width:1%!important}table.es-table-not-adapt,.esd-block-html table{width:auto!important}table.es-social{display:inline-block!important}table.es-social td{display:inline-block!important}}.es-p-default{padding-top:20px;padding-right:35px;padding-bottom:0;padding-left:35px}.es-p-all-default{padding:0}.emailTitle p{line-height:30px}
   </style>

   <body>
      <div class=""es-wrapper-color"">
         <table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"">
            <tbody>
               <tr>
                  <td class=""esd-email-paddings"" valign=""top"">
                     <table class=""es-content"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                        <tbody>
                           <tr></tr>
                           <tr>
                              <td class=""esd-stripe"" esd-custom-block-id=""7681"" align=""center"">
                                 <table class=""es-header-body"" style=""background-image: linear-gradient(to right, #333 0%, #495057 50%, #333 100%);"" width=""600"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#044767"" align=""center"">
                                    <tbody>
                                       <tr>
                                          <td class=""esd-structure es-p15t es-p15b es-p35r es-p35l"" align=""left"">
                                             <!--[if mso]>
                                             <table width=""530"" cellpadding=""0"" cellspacing=""0"">
                                                <tr>
                                                   <td width=""340"" valign=""top"">
                                                      <![endif]-->
                                                      <table class=""es-left"" cellspacing=""0"" cellpadding=""0"" align=""left"">
                                                         <tbody>
                                                            <tr>
                                                               <td class=""es-m-p0r es-m-p20b esd-container-frame"" width=""340"" valign=""top"" align=""center"">
                                                                  <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                                     <tbody>
                                                                        <tr>
                                                                           <td class=""esd-block-text es-m-txt-c"" align=""left"">
                                                                              <!--h1 style=""color: #ffffff; line-height: 100%;"">Beretun</h1-->
                                                                              <img src=""http://teamrijent.in/EmailTemplate/images/Rijentlogo.png"" width=""240"">
                                                                           </td>
                                                                        </tr>
                                                                     </tbody>
                                                                  </table>
                                                               </td>
                                                            </tr>
                                                         </tbody>
                                                      </table>
                                                      <table cellspacing=""0"" cellpadding=""0"" align=""right"">
                                                         <tbody>
                                                            <tr class=""es-hidden"">
                                                               <td class=""es-m-p20b esd-container-frame"" esd-custom-block-id=""7704"" width=""170"" align=""left"">
                                                                  <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                                     
                                                                  </table>
                                                               </td>
                                                            </tr>
                                                         </tbody>
                                                      </table>
                                                      <!--[if mso]>
                                                   </td>
                                                </tr>
                                             </table>
                                             <![endif]-->
                                          </td>
                                       </tr>
                                    </tbody>
                                 </table>
                              </td>
                           </tr>
                        </tbody>
                     </table>
                     <table class=""es-content"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                        <tbody>
                           <tr>
                              <td class=""esd-stripe"" align=""center"">
                                 <table class=""es-content-body"" width=""600"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#ffffff"" align=""center"">
                                    <tbody>
                                       <tr>
                                          <td class=""esd-structure es-p10t es-p35r es-p35l"" align=""left"">
                                             <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                <tbody>
                                                   <tr>
                                                      <td class=""esd-container-frame"" width=""530"" valign=""top"" align=""center"">
                                                         <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                            <tbody>
                                                               <tr>
                                                                  <td class=""esd-block-image es-p10t es-p25b es-p35r es-p35l"" align=""center"" style=""font-size:0""><a target=""_blank"" href=""https://teamrijent.in/""><img src=""http://teamrijent.in/EmailTemplate/images/success.gif"" alt="""" style=""display: block;"" width=""120""></a></td>
                                                               </tr>
                                                               <tr>
                                                                  <td class=""esd-block-text es-p10b"" align=""center"">
                                                                     <h2>Withdrawled Confirmed</h2>
                                                                  </td>
                                                               </tr><br>
                                                               <tr>
                                                                  <td class=""emailTitle esd-block-text es-p15t es-p20b"" align=""left"">
                                                                     <p style=""font-size: 16px; color:#000;"">You've received <b>" + Amount + @" RTC</b> in your Rijent account.</p>
                                                                      <p>Reference Id : <b>" + ReferenceId + @"</b></p>
                                                                      <p>IP Address : <b>" + GetIPAddress() + @"</b></p><br><br>
                                                                     <p>Only 30 second to participate our survey to help us become better </p><br>
                                                                     <p><span class=""es-button-border""><a href=""https://teamrijent.in/"" class=""es-button"" target=""_blank"">Participate Now</a></span></p><br><br>

                                                                     <p>If you don't recognize this activity, please contact us immediately at <a href=""https://teamrijent.in/"" target=""_blank"">https://teamrijent.in/</a> </p><br><br>
                                                                     <p><b>Rijent Coin Team</b><br>This is automated generated mail, please don't reply.</p>
                                                                  </td>
                                                               </tr><br>
                                                               <tr>
                                                                  <td class=""esd-block-image es-p15b"" align=""center"" style=""font-size:0""><a target=""_blank"" href=""""><img src=""http://teamrijent.in/EmailTemplate/images/play-store.png"" alt=""Beretun logo"" style=""display: block;"" title=""Beretun logo"" width=""180""></a><p><strong>Download Mobile App </strong></p></td>
                                                               </tr>
                                                            </tbody>
                                                         </table>
                                                      </td>
                                                   </tr>
                                                </tbody>
                                             </table>
                                          </td>
                                       </tr>
                                    </tbody>
                                 </table>
                              </td>
                           </tr>
                        </tbody>
                     </table>
                     <table cellpadding=""0"" cellspacing=""0"" class=""es-footer"" align=""center"">
                        <tbody>
                           <tr>
                              <td class=""esd-stripe"" esd-custom-block-id=""7684"" align=""center"">
                                 <table class=""es-footer-body"" width=""600"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                                    <tbody>
                                       <tr>
                                          <td class=""esd-structure es-p25t brt es-p20b es-p35r es-p35l"" align=""left"">
                                             <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                <tbody>
                                                   <tr>
                                                      <td class=""esd-container-frame"" width=""530"" valign=""top"" align=""center"">
                                                         <table width=""100%"" cellspacing=""0"" cellpadding=""0"">
                                                            <tbody>
                                                               
                                                               <tr>
                                                                  <td esdev-links-color=""#777777"" align=""left"" class=""esd-block-text es-m-txt-c es-p5b"">
                                                                     <p style=""text-align: center;"">Copyright  2021 <a href=""https://teamrijent.in/"" target=""_blank""><b>   Rijent Coin</b></a> All Rights Reserved.</p>
                                                                  </td>
                                                               </tr>
                                                            </tbody>
                                                         </table>
                                                      </td>
                                                   </tr>
                                                </tbody>
                                             </table>
                                          </td>
                                       </tr>
                                    </tbody>
                                 </table>
                              </td>
                           </tr>
                        </tbody>
                     </table>
                  </td>
               </tr>
            </tbody>
         </table>
      </div>
   </body>
</html>";

                        sendemail(userid, "Tean Rijent-Coin Deposited Successfully", str_body);
                    }
                }
            }
        }
        catch (Exception ep)
        {
            res = ep.Message.ToString();
        }


        return res;
    }

    [WebMethod]
    public string WithdrawCoinFail(string userid, string TransactionId)
    {
        string res = "";
        try
        {
            using (SqlConnection conn = new SqlConnection())
            {
                //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
                Data objdata = new Data();
                conn.ConnectionString = objdata.getConnectionString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "sp_WithdrawlCoinFail";
                    cmd.Parameters.AddWithValue("@transactionid", TransactionId);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    res = cmd.ExecuteScalar().ToString();

                    //SqlDataAdapter ad = new SqlDataAdapter();
                    //ad.SelectCommand = cmd;
                    //ad.Fill(dt);
                    //foreach (DataRow r in dt.Rows)
                    //{
                    //    customers.Add(string.Format("{0}-{1}~{2}~{3}~{4}", r["ProductName"], r["ProductId"], r["mrp"], r["dp"], r["gst"]));
                    //}
                    conn.Close();

                }
            }
        }
        catch (Exception ep)
        {
            res = ep.Message.ToString();
        }


        return res;
    }

}
