using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicTier;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

public partial class admin_index : System.Web.UI.Page
{
    clsLogin objlogin = new clsLogin();
    clsUser objuser = new clsUser();
   
    public class WebRequestModel
    {
        public string Response { get; set; }
        public string EncryptedData { get; set; }
    }
    public class decriptdata 
    {
        public string Password { get; set; }
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //try {
        objlogin.username = txtusername.Text;
        objlogin.password = txtpassword.Text;
        objlogin.IpAddress = GetIPAddress();
        DataTable dt = new DataTable();
        
        //string KeyPath = Path.Combine(HttpRuntime.AppDomainAppPath+""+ "/admin/EncriptFolder/icici_upi_public.txt");

        //var iCICRequestModel = new decriptdata
        //{
        //    Password=objlogin.password
        //};
        //var webRequest = PostJsonDataUsingHWRTLS(null, iCICRequestModel, null, KeyPath).Result;

        dt = objlogin.Chk_AdminLoginDetails(objlogin);
        if (dt != null)
        {


            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["loginflag"].ToString() == "1")
                {
                    //Session["rijentadmin45852_4"] = dt.Rows[0]["username"].ToString();
                    HttpContext.Current.Session["rijentadmin45852_4"] = dt.Rows[0]["username"].ToString();

                    //Server.Transfer("Dashboard.aspx");
                    Random rnd = new Random();
                    string str_otpemail = rnd.Next(100000, 999999).ToString();
                    objuser.OTP = str_otpemail;
                    //objuser.Email = dt.Rows[0]["EmailForOTP"].ToString();
                   objuser.EmailSubject = "Rijent- Login OTP";
                    objuser.EmailBody = @"Dear User OTP is " + str_otpemail;
                   // objuser.EmailBody = @"Dear User OTP is 0000";
                    string res = objuser.SendEmailOTPAdminLogin(objuser);
                    if (res == "t")
                    {
                        string popupScript = "toastr.success('Success', 'OTP has been Sent To Your Email.');";
                        ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                        //string popupScript2 = "showModal();";
                        //ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript2, true);

                        //Session["resetuserid"] = txtusername.Text;
                        Session["adminloginotp"] = str_otpemail;
                        Server.Transfer("AdminOTP.aspx");
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        string popupScript = "toastr.error('Error', 'Unknown Error Occurred');";
                        ScriptManager.RegisterStartupScript(uplMaster, uplMaster.GetType(), Guid.NewGuid().ToString(), popupScript, true);
                    }
                }
                else
                {
                    Message.Show("Invalid Login Details...!!!");
                }
            }
            else
            {
                Message.Show("Invalid Login Details...!!!");
            }
        }
        else
        {
            Message.Show("Invalid Login Details...!!!");
        }
        //}
        //catch (Exception ep){
        //    Message.Show("Invalid Lgin Details...!!!");
        //}

    }
    public string GetIPAddress()
    {
        string ipaddress;
        ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipaddress == "" || ipaddress == null)
            ipaddress = Request.ServerVariables["REMOTE_ADDR"];
        return ipaddress;
    }

    protected void btnUpdatepassword_Click(object sender, EventArgs e)
    {

    }
    //public string EncryptUsingPublicKey(byte[] data, string path)
    //{
    //    FileStream stream = null;
    //    try
    //    {
    //        IBufferedCipher cipher = CipherUtilities.GetCipher("RSA/ECB/PKCS1Padding");
    //        stream = new FileStream(path, FileMode.Open);
    //        X509CertificateParser certParser = new X509CertificateParser();
    //        Org.BouncyCastle.X509.X509Certificate certificate = certParser.ReadCertificate(stream);
    //        this.publicKey = (RsaKeyParameters)certificate.GetPublicKey();
    //        cipher.Init(true, publicKey);
    //        stream.Close();
    //        return Convert.ToBase64String(cipher.DoFinal(data));

    //    }
    //    catch (Exception ex)
    //    {
    //        return string.Empty;
    //    }
    //}

    //public async Task<WebRequestModel> PostJsonDataUsingHWRTLS(string URL, object PostData, IDictionary<string, string> headers, string KeyPath)
    //{
    //    var webRequest = new WebRequestModel
    //    {
    //        Response = string.Empty,
    //        EncryptedData = string.Empty
    //    };
    //    try
    //    {
    //       // ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
    //       // HttpWebRequest http = (HttpWebRequest)System.Net.WebRequest.Create(URL);
    //        var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(PostData));
    //       // http.Method = "POST";
    //       // http.ContentType = "text/plain";
    //      //  http.KeepAlive = false;
    //        //if (headers != null)
    //        //{
    //        //    foreach (var item in headers)
    //        //    {
    //        //        http.Headers.Add(item.Key, item.Value);
    //        //    }
    //        //}
    //        webRequest.EncryptedData = EncryptUsingPublicKey(data, KeyPath);
    //        //using (var streamWriter = new StreamWriter(http.GetRequestStream()))
    //        //{
    //        //    streamWriter.Write(webRequest.EncryptedData);
    //        //    streamWriter.Flush();
    //        //}
    //       // WebResponse response = http.GetResponse();

    //        //using (StreamReader sr = new StreamReader(response.GetResponseStream()))
    //        //{
    //        //    webRequest.Response = await sr.ReadToEndAsync().ConfigureAwait(false);
    //        //}
    //    }
    //    catch (UriFormatException ufx)
    //    {
    //        throw new Exception(ufx.Message);
    //    }
    //    catch (WebException wx)
    //    {
    //        if (wx.Response != null)
    //        {
    //            using (var ErrorResponse = wx.Response)
    //            {
    //                using (StreamReader sr = new StreamReader(ErrorResponse.GetResponseStream()))
    //                {
    //                    webRequest.Response = "";// await sr.ReadToEndAsync().ConfigureAwait(false);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            throw new Exception(wx.Message);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //    return webRequest;
    //}
}