using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using ARA_StringHunt;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Configuration;
using System.Xml;
using System.Net;

namespace BusinessLogicTier
{
    public class clsSecureService
    {

        Data ObjData = new Data();
        string apiBaseUrl = ConfigurationManager.AppSettings["apiBaseUrl"];
        string UMobileNo = ConfigurationManager.AppSettings["UMobileNo"];
        string Password = ConfigurationManager.AppSettings["Password"];
        public static String APP_ID = "ROUNDPAYB2BAPP01APR20127943".EncodePassword().ToLower().Replace("-", "");
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public bool ValidateUMobile(String _UMobile, int length = 3)
        {
            try
            {
                int leng = _UMobile.Split((char)160).Length;
                if (_UMobile.Contains((char)160))
                {
                    string deckey = APP_ID;
                    string deckey2 = _UMobile.Split((char)160)[0];


                    if (_UMobile.Split((char)160).Length == length && _UMobile.Split((char)160)[0] == APP_ID && (_UMobile.Split((char)160)[1].Length == 15 || _UMobile.Split((char)160)[1].Length == 16))
                        return true;
                    else if (_UMobile.Split((char)160).Length == length && _UMobile.Split((char)160)[0] == APP_ID && (_UMobile.Split((char)160)[1].Length == 15 || _UMobile.Split((char)160)[1].Length == 16) && _UMobile.Split((char)160)[3].Length == 32)
                        return true;
                }
            }
            catch { }
            return false;
        }
        public String Login(String _userid, String _password, string _DeviceId)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_SecureLogin2";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@_LoginID", _userid.Split((char)160)[2]),
                   new SqlParameter("@_Password", _password),
                   new SqlParameter("@_IMEI",  _userid.Split((char)160)[1]),
                   new SqlParameter("@_DeviceId", _DeviceId),
                   new SqlParameter("@_AppId", _userid.Split((char)160)[0]),
                   new SqlParameter("@_EncPassword", Encrypt(_password)),            
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    String EncPassword = Encrypt(_password);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            jsonStr += ",\"OTP\":\"" + dt.Rows[0]["sOTP"].ToString() + "\"";
                            jsonStr += ",\"SessionID\":\"" + dt.Rows[0]["SessionID"].ToString() + "\"";
                            jsonStr += ",\"UserID\":\"" + dt.Rows[0]["userid"].ToString() + "\"";
                            jsonStr += ",\"UName\":\"" + dt.Rows[0]["Name"].ToString() + "\"";
                            jsonStr += ",\"UMail\":\"" + dt.Rows[0]["Email"].ToString() + "\"";
                            jsonStr += ",\"UMobile\":\"" + dt.Rows[0]["UMobile"].ToString() + "\"";
                            jsonStr += ",\"DeviceStatus\":\"" + dt.Rows[0]["DeviceStatus"].ToString() + "\"";
                            jsonStr += ",\"Key\":\"" + dt.Rows[0]["Key"].ToString() + "\"";
                            jsonStr += ",\"supportEmail\":\"" + dt.Rows[0]["supportEmail"].ToString() + "\"";
                            jsonStr += ",\"icon\":\"" + dt.Rows[0]["icon"].ToString() + "\"";
                            jsonStr += ",\"supportNumber\":\"" + dt.Rows[0]["supportNumber"].ToString() + "\"";
                            //jsonStr += "}]}";
                            jsonStr += "}";
                            //try
                            //{
                            //    if (dt.Rows[0]["Push"].ToString() == "Y" && dt.Rows[0]["DeviceStatus"].ToString() == "1")
                            //    {
                            //        PushNotification(_DeviceId);
                            //    }
                            //    //if (dt.Rows[0]["sOTP"].ToString() != "")
                            //    //{

                            //    //    objFormat.InvalidMessage(dt.Rows[0]["UMobile"].ToString().Trim(), "Login OTP " + dt.Rows[0]["OTP"].ToString() + " for app.", 0, "", dt.Rows[0]["WhiteLabelID"].ToString());
                            //    //    bal.Mail(dt.Rows[0]["EmailID"].ToString(), "Mrupay", "Login OTP " + dt.Rows[0]["OTP"].ToString() + " for app.", dt.Rows[0]["WhiteLabelID"].ToString(), dt.Rows[0]["Name"].ToString());

                            //    //}
                            //}
                            //catch (Exception ex)
                            //{
                            //    objB2BSecureServiceDL.B2B_Error_Log("B2CSecureService_BL", ex.Message, "SendingMail");
                            //}
                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }

        public String GetUserDetail(String _userid, String _password)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_UserDetailService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            jsonStr += ",\"UserId\":\"" + dt.Rows[0]["UserId"].ToString() + "\"";
                            jsonStr += ",\"SponserId\":\"" + dt.Rows[0]["SponserId"].ToString() + "\"";
                            jsonStr += ",\"UserName\":\"" + dt.Rows[0]["UserName"].ToString() + "\"";
                            jsonStr += ",\"DateOfBirth\":\"" + dt.Rows[0]["DateOfBirth"].ToString() + "\"";
                            jsonStr += ",\"Gender\":\"" + dt.Rows[0]["Gender"].ToString() + "\"";
                            jsonStr += ",\"Email\":\"" + dt.Rows[0]["Email"].ToString() + "\"";
                            jsonStr += ",\"Mobile\":\"" + dt.Rows[0]["Mobile"].ToString() + "\"";
                            jsonStr += ",\"NomineeName\":\"" + dt.Rows[0]["NomineeName"].ToString() + "\"";
                            jsonStr += ",\"NomineeRelation\":\"" + dt.Rows[0]["NomineeRelation"].ToString() + "\"";
                            jsonStr += ",\"Address\":\"" + dt.Rows[0]["Address"].ToString() + "\"";
                            jsonStr += ",\"CityName\":\"" + dt.Rows[0]["CityName"].ToString() + "\"";
                            jsonStr += ",\"AreaName\":\"" + dt.Rows[0]["AreaName"].ToString() + "\"";
                            jsonStr += ",\"Pincode\":\"" + dt.Rows[0]["Pincode"].ToString() + "\"";
                            jsonStr += ",\"AccountHolderName\":\"" + dt.Rows[0]["AccountHolderName"].ToString() + "\"";
                            jsonStr += ",\"AccountNo\":\"" + dt.Rows[0]["AccountNo"].ToString() + "\"";
                            jsonStr += ",\"IFSCCode\":\"" + dt.Rows[0]["IFSCCode"].ToString() + "\"";
                            jsonStr += ",\"BankName\":\"" + dt.Rows[0]["BankName"].ToString() + "\"";
                            jsonStr += ",\"BranchName\":\"" + dt.Rows[0]["BranchName"].ToString() + "\"";
                            jsonStr += ",\"PanNumber\":\"" + dt.Rows[0]["PanNumber"].ToString() + "\"";
                            jsonStr += ",\"RegDate\":\"" + dt.Rows[0]["RegDate"].ToString() + "\"";
                            jsonStr += ",\"ParentUserId\":\"" + dt.Rows[0]["ParentUserId"].ToString() + "\"";
                            jsonStr += ",\"ActiveStatus\":\"" + dt.Rows[0]["ActiveStatus"].ToString() + "\"";
                            jsonStr += ",\"BalanceAmount\":\"" + dt.Rows[0]["BalanceAmount"].ToString() + "\"";
                            jsonStr += ",\"StateId\":\"" + dt.Rows[0]["StateId"].ToString() + "\"";
                            jsonStr += ",\"CountryId\":\"" + dt.Rows[0]["CountryId"].ToString() + "\"";
                            jsonStr += ",\"SponserName\":\"" + dt.Rows[0]["SponserName"].ToString() + "\"";
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserName(String _userid, String _password,String NewUserId)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_UserNameService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                   new SqlParameter("@NewUserId",  NewUserId),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            jsonStr += ",\"UserId\":\"" + dt.Rows[0]["UserId"].ToString() + "\"";
                            jsonStr += ",\"SponserId\":\"" + dt.Rows[0]["SponserId"].ToString() + "\"";
                            jsonStr += ",\"UserName\":\"" + dt.Rows[0]["UserName"].ToString() + "\"";
                            jsonStr += ",\"Email\":\"" + dt.Rows[0]["Email"].ToString() + "\"";
                            jsonStr += ",\"Mobile\":\"" + dt.Rows[0]["Mobile"].ToString() + "\"";
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }

        public String GetDownlineUserName(String _userid, String _password, String _DownlineUserId)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_DownlineUserNameService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),         
                   new SqlParameter("@DownlineUserId",  _DownlineUserId),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += ",\"data\":[{";
                            jsonStr += "\"UserId\":\"" + dt.Rows[0]["UserId"].ToString() + "\"";
                            jsonStr += ",\"UserName\":\"" + dt.Rows[0]["UserName"].ToString() + "\"";
                            jsonStr += "}]}";
                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUpgradeUserName(String _userid, String _password, String _UpgradeUserId)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_UpgradeUserNameService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                   new SqlParameter("@UpgradeUserId",  _UpgradeUserId),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += ",\"data\":[{";
                            jsonStr += "\"UserId\":\"" + dt.Rows[0]["UserId"].ToString() + "\"";
                            jsonStr += ",\"UserName\":\"" + dt.Rows[0]["UserName"].ToString() + "\"";
                            jsonStr += "}]}";
                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }

        public String GetUserBalance(String _userid, String _password)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_UserBalanceService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            jsonStr += ",\"UserId\":\"" + dt.Rows[0]["UserId"].ToString() + "\"";
                            jsonStr += ",\"InternalWallet\":\"" + dt.Rows[0]["BalanceAmount"].ToString() + "\"";
                            jsonStr += ",\"ExeternalWallet\":\"" + dt.Rows[0]["EWalletBalance"].ToString() + "\"";
                            jsonStr += ",\"CoinWallet\":\"" + dt.Rows[0]["CoinBalance"].ToString() + "\"";
                            jsonStr += ",\"RijentWallet\":\"" + dt.Rows[0]["RijentBalance"].ToString() + "\"";
                            jsonStr += "}";
                            //jsonStr += "}]}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserDashboard(String _userid, String _password)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_UserDashboardService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            jsonStr += ",\"UserId\":\"" + dt.Rows[0]["UserId"].ToString() + "\"";
                            jsonStr += ",\"Package\":\"" + dt.Rows[0]["Package"].ToString() + "\"";
                            jsonStr += ",\"TotalTeam\":\"" + dt.Rows[0]["TotalTeam"].ToString() + "\"";
                            jsonStr += ",\"DirectTeam\":\"" + dt.Rows[0]["DirectTeam"].ToString() + "\"";
                            jsonStr += ",\"Balanceamount\":\"" + dt.Rows[0]["Balanceamount"].ToString() + "\"";
                            jsonStr += ",\"ewalletbalance\":\"" + dt.Rows[0]["ewalletbalance"].ToString() + "\"";
                            jsonStr += ",\"DirectIncome\":\"" + dt.Rows[0]["DirectIncome"].ToString() + "\"";
                            jsonStr += ",\"BInaryIncome\":\"" + dt.Rows[0]["BInaryIncome"].ToString() + "\"";
                            jsonStr += ",\"ROIIncome\":\"" + dt.Rows[0]["ROIIncome"].ToString() + "\"";
                            jsonStr += ",\"TotalIncome\":\"" + dt.Rows[0]["TotalIncome"].ToString() + "\"";
                            jsonStr += ",\"Lcount\":\"" + dt.Rows[0]["Lcount"].ToString() + "\"";
                            jsonStr += ",\"RCount\":\"" + dt.Rows[0]["RCount"].ToString() + "\"";
                            jsonStr += ",\"LBusiness\":\"" + dt.Rows[0]["LBusiness"].ToString() + "\"";
                            jsonStr += ",\"RBusiness\":\"" + dt.Rows[0]["RBusiness"].ToString() + "\"";
                            jsonStr += ",\"topupdate\":\"" + dt.Rows[0]["topupdate"].ToString() + "\"";
                            jsonStr += ",\"levelincome\":\"" + dt.Rows[0]["levelincome"].ToString() + "\"";
                            jsonStr += ",\"CoinBalance\":\"" + dt.Rows[0]["CoinBalance"].ToString() + "\"";
                            jsonStr += ",\"RijentBalance\":\"" + dt.Rows[0]["RijentBalance"].ToString() + "\"";
                            jsonStr += ",\"MWalletBalanceRedeemed\":\"" + dt.Rows[0]["MWalletBalanceRedeemed"].ToString() + "\"";
                            jsonStr += ",\"JoiningDate\":\"" + dt.Rows[0]["JoiningDate"].ToString() + "\"";
                            jsonStr += ",\"ActivationDate\":\"" + dt.Rows[0]["ActivationDate"].ToString() + "\"";
                            jsonStr += ",\"levelname\":\"" + dt.Rows[0]["levelname"].ToString() + "\"";
                            jsonStr += ",\"Careerbonus\":\"" + dt.Rows[0]["Careerbonus"].ToString() + "\"";
                            jsonStr += ",\"StakingBonus\":\"" + dt.Rows[0]["StakingBonus"].ToString() + "\"";
                            jsonStr += ",\"StakingWallet\":\"" + dt.Rows[0]["StakingWallet"].ToString() + "\"";
                            jsonStr += ",\"DirectBusiness\":\"" + dt.Rows[0]["DirectBusiness"].ToString() + "\"";
                            jsonStr += ",\"CoinBalanceDOllar\":\"" + dt.Rows[0]["CoinBalanceDOllar"].ToString() + "\"";
                            jsonStr += "}";
                            //jsonStr += "}]}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserDownline(String _userid, String _password,String StandingPosition)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_getUserDownlineService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                   new SqlParameter("@StandingPosition",  StandingPosition),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"Downline\"";
                            jsonStr += ",\"Downline\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserDirectDownline(String _userid, String _password, String StandingPosition)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_getUserDirectDownlineService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                   new SqlParameter("@StandingPosition",  StandingPosition),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"DirectDownline\"";
                            jsonStr += ",\"DirectDownline\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }

        public String GetUserDirectDownlineSponserWise(String _userid, String _password, String StandingPosition)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_getUserDownlineSponserWiseService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                   new SqlParameter("@StandingPosition",  StandingPosition),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"DirectDownline\"";
                            jsonStr += ",\"DirectDownline\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserDirectIncome(String _userid, String _password, String FromDate,String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetDirectIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"DirectIncome\"";
                            jsonStr += ",\"DirectIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserTwiceDirectIncome(String _userid, String _password, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetTwiceDirectIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"TwiceDirectIncome\"";
                            jsonStr += ",\"TwiceDirectIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserBinaryIncome(String _userid, String _password, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetBinaryIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"BinaryIncome\"";
                            jsonStr += ",\"BinaryIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserDirectCashbackIncome(String _userid, String _password, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetDirectCashbackIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"DirectCashbackIncome\"";
                            jsonStr += ",\"DirectCashbackIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserSponserMatchingIncome(String _userid, String _password, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetSponserMatchingIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"SponserMatchingIncome\"";
                            jsonStr += ",\"SponserMatchingIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserRechargeCashbackIncome(String _userid, String _password, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetRechargeCashbackIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"RechargeCashbackIncome\"";
                            jsonStr += ",\"RechargeCashbackIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserTwiceBinaryIncome(String _userid, String _password, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetTwiceBinaryIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"TwiceBinaryIncome\"";
                            jsonStr += ",\"TwiceBinaryIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserCashbackIncome(String _userid, String _password, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetCashbackIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"CashbackIncome\"";
                            jsonStr += ",\"CashbackIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }

        public String GetUserJodiIncome(String _userid, String _password, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetJodiIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"JodiIncome\"";
                            jsonStr += ",\"JodiIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserTwiceJodiIncome(String _userid, String _password, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetTwiceJodiIncomeReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),
                  new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"TwiceJodiIncome\"";
                            jsonStr += ",\"TwiceJodiIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
   
        public String GetNews(String _userid, String _password)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_NewsService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    //if (dt.Rows.Count > 0)
                    //{
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        string news = "";
                        foreach (DataRow r in dt.Rows)
                        {
                            news += r["newsdetail"].ToString() + " | ";
                        }
                        jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                        jsonStr += ",\"data\":[{";
                        jsonStr += "\"News\":\"" + news + "\"";
                        jsonStr += "}]}";

                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                    }
                    //}
                    //else
                    //{
                    //    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    //}
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetCompanyBankAccount(String _userid, String _password)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_CompanyBankAccountService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    //if (dt.Rows.Count > 0)
                    //{
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"Bank Account\"";
                        jsonStr += ",\"BankAccount\":";
                        jsonStr += JsonConvert.SerializeObject(dt);
                        jsonStr += "}";

                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                    }
                    //}
                    //else
                    //{
                    //    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    //}
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetCompanyBankAccountDetail(String _userid, String _password, String id)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_CompanyBankAccountDetailService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),         
                   new SqlParameter("@id", id),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    //if (dt.Rows.Count > 0)
                    //{
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                        jsonStr += ",\"data\":[{";
                        jsonStr += "\"AccountNo\":\"" + dt.Rows[0]["AccountNo"].ToString() + "\"";
                        jsonStr += "\"AccountHolderName\":\"" + dt.Rows[0]["AccountHolderName"].ToString() + "\"";
                        jsonStr += "\"BankName\":\"" + dt.Rows[0]["BankName"].ToString() + "\"";
                        jsonStr += "\"IFSCCode\":\"" + dt.Rows[0]["IFSCCode"].ToString() + "\"";
                        jsonStr += "\"BranchName\":\"" + dt.Rows[0]["BranchName"].ToString() + "\"";
                        jsonStr += "}]}";

                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                    }
                    //}
                    //else
                    //{
                    //    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    //}
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            try
            {
                //objB2BSecureServiceDL.tbl_B2BSServiceReqLog(" _u_mobile-" + _u_mobile + ", _password-" + _password, "Login");
            }
            catch { }
            return jsonStr;
        }
        public String GetUserDownlineCount(String _userid, String _password)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_UserDownlineCountService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _userid.Split((char)160)[2]),
                   new SqlParameter("@Password", _password),
                   new SqlParameter("@SessionId",  _userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _userid.Split((char)160)[1]),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["count"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            //jsonStr += "\"Count\":\"" + dt.Rows[0]["count"].ToString() + "\"";
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            
            return jsonStr;
        }

        public String GeBankList(String _userid)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_BankListService";
                        SqlParameter[] parameter = {    
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"Bank details\"";
                        jsonStr += ",\"Banks\":";
                        jsonStr += JsonConvert.SerializeObject(dt);
                        jsonStr += "}";
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
         
            return jsonStr;
        }
        public String GeCountryList(String _userid)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_CountryListService";
                        SqlParameter[] parameter = {    
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"Country details\"";
                        jsonStr += ",\"Countries\":";
                        jsonStr += JsonConvert.SerializeObject(dt);
                        jsonStr += "}";
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String GeStateList(String _userid, String _countryid)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_StateListService";
                        SqlParameter[] parameter = {    
                         new SqlParameter("@CountryId", _countryid)
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"State details\"";
                        jsonStr += ",\"States\":";
                        jsonStr += JsonConvert.SerializeObject(dt);
                        jsonStr += "}";
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String GeCityList(String _userid, String _stateid)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_CityListService";
                        SqlParameter[] parameter = {    
                         new SqlParameter("@StateId", _stateid)
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"City details\"";
                        jsonStr += ",\"Cities\":";
                        jsonStr += JsonConvert.SerializeObject(dt);
                        jsonStr += "}";
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String GePlanList(String _userid)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_PlanListService";
                        SqlParameter[] parameter = {
                        
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"Plandetails\"";
                        jsonStr += ",\"PlanList\":";
                        jsonStr += JsonConvert.SerializeObject(dt);
                        jsonStr += "}";
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String UpdateUserDetail(String userid, String password, String username, String mobile, String email, String gender, String address, String cityname, String stateid, String dateofbirth)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_edit_UserDetailService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@Username",  username),         
                   new SqlParameter("@mobile",  mobile),         
                   new SqlParameter("@email",  email),         
                   new SqlParameter("@dateofbirth",  dateofbirth),         
                   new SqlParameter("@gender",  gender),         
                   new SqlParameter("@address",  address),         
                   new SqlParameter("@cityname",  cityname),         
                   new SqlParameter("@stateid",  stateid),      
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String UserAdd(String userid, String password, String username, String mobile, String email, String gender, String StandingPosition,String dateofbirth, String Newpassword)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_UserDetailService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@userid", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@Username",  username),         
                   new SqlParameter("@mobile",  mobile),         
                   new SqlParameter("@email",  email),         
                   new SqlParameter("@dateofbirth",  dateofbirth),         
                   new SqlParameter("@gender",  gender),             
                   new SqlParameter("@NewPassword",  Newpassword), 
                   new SqlParameter("@StandingPosition",  StandingPosition),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            jsonStr += ",\"UserId\":\"" + dt.Rows[0]["newuserid"].ToString() + "\"";
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }


        public String GenerateEPin(String userid, String password, String NoOfEpin, String amount)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_EPinMasterService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@amount",  amount),       
                   new SqlParameter("@NoOfEpin",  NoOfEpin),       
                   new SqlParameter("@mentionby",  userid.Split((char)160)[2]),       
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += ",\"data\":[{";
                            jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}]}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String UserTopup(String userid, String password, String TopupUserId, String WalletType, String Amount)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_UserTopupDetailService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),
                   new SqlParameter("@TopupUserId",  TopupUserId),
                   new SqlParameter("@WalletType",  WalletType),
                   new SqlParameter("@Amount",  Amount),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            //jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String GenerateEPinOnline(String userid, String password, String TransactionId, String amount, String NoOfEpin, String EpinAmount, String Request)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_PaymentGatewayRequestService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@TransactionId",  TransactionId),       
                   new SqlParameter("@amount",  amount),       
                   new SqlParameter("@NoOfEpin",  NoOfEpin),       
                   new SqlParameter("@EpinAmount",  EpinAmount),   
                   new SqlParameter("@mentionby",  userid.Split((char)160)[2]),       
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += ",\"data\":[{";
                            jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}]}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String DisputeRequestAdd(String userid, String password, String ReferenceId)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_DisputeRequestService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@Referenceid",  ReferenceId)  
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += ",\"data\":[{";
                            jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}]}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String ChangePassword(String userid, String password, String NewPassword)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_ChangePasswordService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),
                   new SqlParameter("@NewPassword",  NewPassword)
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            //jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String NewMessage(String userid, String password, String MessageTitle, String MessageDescription)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_NewMessageService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),
                   new SqlParameter("@MessageTitle",  MessageTitle),
                   new SqlParameter("@MessageDescription",  MessageDescription),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            //jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String CallbackRequestAdd(String userid, String password, String MobileNo)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_CallbackRequestDetailService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@MobileNo",  MobileNo)  
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += ",\"data\":[{";
                            jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}]}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String FundRequestAdd(String userid, String password, String AccountId, String paymentMode, String amount, String Transactionid, String ChequeNo, String MobileNoInBank, String Remark)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_FundRequestService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@BankAccountId",  AccountId),       
                   new SqlParameter("@Amount", amount ),       
                   new SqlParameter("@Remark",  Remark)     ,
                   new SqlParameter("@PaymentMode",  paymentMode) ,    
                   new SqlParameter("@OnlineTransactionId",  Transactionid)     ,
                   new SqlParameter("@ChequeNo",  ChequeNo)     ,
                   new SqlParameter("@MobileNoInBank",  MobileNoInBank)     
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += ",\"data\":[{";
                            jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}]}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String FundRequestReport(String _UserId, String UPassword, String FromDate, String ToDate)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_getFundRequestService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),
                    new SqlParameter("@fromDate", FromDate),         
                    new SqlParameter("@ToDate",  ToDate),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"WalletTransfer\"";
                            jsonStr += ",\"WalletTransfer\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }


        public String WalletTransferUser(String userid, String password, String TransferUserId, String amount, String Remark)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_WalletTransferUserService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@amount",  amount),       
                   new SqlParameter("@ToUserId",  TransferUserId),       
                   new SqlParameter("@Remark",  Remark)     
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += ",\"data\":[{";
                            jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}]}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String getWalletTransferReport(String _UserId, String UPassword, String ToUserId, String FromDate, String ToDate)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetWalletTransferService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),           
                    new SqlParameter("@ToUserid",  ToUserId),         
                    new SqlParameter("@fromDate", FromDate),         
                    new SqlParameter("@ToDate",  ToDate),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"WalletTransfer\"";
                            jsonStr += ",\"WalletTransfer\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String WalletTransferReverse(String userid, String password, String id)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_WalletTransferReverseService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@id",  id)    
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += ",\"data\":[{";
                            jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}]}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }


        public String EPinTrasnfer(String userid, String password, String NoOfEpin, String TrasnferUserId,String PlanId)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_add_EPinTrasnferService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@TransferUserId",  TrasnferUserId),       
                   new SqlParameter("@NoOfEpin",  NoOfEpin),       
                   new SqlParameter("@mentionby",  userid.Split((char)160)[2]),       
                   new SqlParameter("@planid",  PlanId),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}";
                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String getEPinReport(String _UserId, String UPassword, String EPinStatus, String GenerateUserId, String UsedUserId, String FromDate, String ToDate)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetEPinReport";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),         
                    new SqlParameter("@epinstatus",  EPinStatus),         
                    new SqlParameter("@GenerateUserId",  GenerateUserId),         
                    new SqlParameter("@UsedUserId",  UsedUserId),         
                    new SqlParameter("@fromDate", FromDate),         
                    new SqlParameter("@ToDate",  ToDate),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"EPinReport\"";
                            jsonStr += ",\"EPinReport\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }


        public String getLevelIncomeReport(String _UserId, String UPassword, String FromDate, String ToDate)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetLevelIncomeReportService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]), 
                    new SqlParameter("@fromDate", FromDate),         
                    new SqlParameter("@ToDate",  ToDate),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"LevelIncome\"";
                            jsonStr += ",\"LevelIncome\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String UserTopupReport(String _UserId, String UPassword, String FromDate, String ToDate)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetUserTopupReportService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),
                    new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"UserTopupList\"";
                            jsonStr += ",\"UserTopupList\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String getInbox(String _UserId, String UPassword, String FromDate, String ToDate)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetInboxService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),
                    new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"Inbox\"";
                            jsonStr += ",\"Inbox\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String getSentbox(String _UserId, String UPassword, String FromDate, String ToDate)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetSentboxService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),
                    new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"Inbox\"";
                            jsonStr += ",\"Inbox\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }

        public String getTransactionReport(String _UserId, String UPassword, String FromDate, String ToDate)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetTransactionReportService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]), 
                    new SqlParameter("@fromDate", FromDate),         
                    new SqlParameter("@ToDate",  ToDate),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"TransactionReport\"";
                            jsonStr += ",\"TransactionReport\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password "+ _UserId.Split((char)160)[2] +" - "+ UPassword+ "\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
         
            return jsonStr;
        }

        public String getTransactionReportEWallet(String _UserId, String UPassword, String FromDate, String ToDate)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetTransactionReportEWalletService";
                        SqlParameter[] parameter = {
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),
                    new SqlParameter("@fromDate", FromDate),
                    new SqlParameter("@ToDate",  ToDate),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"TransactionReport\"";
                            jsonStr += ",\"TransactionReport\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }

            return jsonStr;
        }

        public String getDownlineReport(String _UserId, String UPassword)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_get_UserDownlineService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"DownlineReport\"";
                            jsonStr += ",\"DownlineReport\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }


        public String getEPinForReg(String _UserId, String UPassword,String PlanId)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetEPinForReg";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                    new SqlParameter("@Password", UPassword),
                    new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                    new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),
                    new SqlParameter("@PlanId",  PlanId),
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"EPinReport\"";
                            jsonStr += ",\"EPinReport\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";


                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No E-Pin Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }


        public String LoginVerification(string _u_mobile, string _Password, out int LoginFlag, out string UserId)
        {
            String jsonStr = "Invalid User!";
            LoginFlag = -1;
            UserId = "0";
            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    ObjData.StartConnection();
                    DataTable dt = new DataTable();
                    try
                    {
                        string s2 = "LoginVerificationService";
                        SqlParameter[] parameter = {              
                        new SqlParameter("@_LoginID", _u_mobile.Split((char)160)[2]),
                        new SqlParameter("@_SessionID",  _u_mobile.Split((char)160)[3]),
                        new SqlParameter("@_LoginIP", _u_mobile.Split((char)160)[1]),
                        new SqlParameter("@_Password", _Password),
                    };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch { }

                    if (dt.Rows.Count > 0)
                    {
                        LoginFlag = dt.Rows[0][0].ToString().ToInt();
                        UserId = dt.Rows[0]["UserID"].ToString();
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            return dt.Rows[0]["Msg"].ToString();
                        }
                        else
                        {
                            return dt.Rows[0]["Msg"].ToString();
                        }
                    }
                    else
                    {
                        jsonStr = "Invalid User!";
                    }
                }
                else
                {
                    jsonStr = "Invalid User!";
                }
            }
            catch { }
            return jsonStr;
        }
        public DataTable Insert_REQUEST_RESPONSE(string username, string password, string RequestUrl, string Request, string Response, string UserId, string TransId, string RequestMode = "Panel")
        {

            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                string s2 = "InsertRequestResponseService";
                SqlParameter[] parameter = { 
                                           new SqlParameter("@username", username),
                                           new SqlParameter("@password", password),
                                           new SqlParameter("@TransId", TransId),
                                           new SqlParameter("@RequestUrl", RequestUrl),
                                           new SqlParameter("@Request", Request),
                                           new SqlParameter("@Response", Response),
                                           new SqlParameter("@UserId", UserId),
                                           new SqlParameter("@RequestMode", RequestMode),
                                           };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;

        }
        public static String ConstructQueryString(NameValueCollection parameters)
        {
            List<string> items = new List<string>();

            foreach (string name in parameters)
                items.Add(string.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name])));

            return string.Join("&amp;", items.ToArray());
        }
        public String GetSender(String _u_mobile, String _Password, String _SenderMobileNo)
        {
            String jsonStr = "";
            int LoginFlag = 0; string UserId = "0";

            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    String msg = LoginVerification(_u_mobile.ToString(), _Password.ToString(), out LoginFlag, out UserId);
                    if (LoginFlag == 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + msg + "\"}";
                        return jsonStr;

                    }

                    string apiUrl = apiBaseUrl + "GetSenderInfo";

                    NameValueCollection postParams = new NameValueCollection();

                    postParams.Add("SenderMobileNo", _SenderMobileNo);
                    postParams.Add("UMobileNo", UMobileNo);
                    postParams.Add("Password", Password);

                    string Values = ConstructQueryString(postParams);
                    DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId.ToString(), "", "App");
                    string Response = postData(apiUrl, postParams, dt.Rows[0][0].ToString().ToInt());
                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Response);
                    jsonStr = JsonConvert.SerializeXmlNode(doc);

                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App request!\"}";
                }
            }
            catch { }
            return jsonStr;
        }
        public String GetBeneficiary(String _u_mobile, String _Password, String _SenderMobileNo)
        {
            String jsonStr = "";
            int LoginFlag = 0; string UserId = "0";

            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    String msg = LoginVerification(_u_mobile.ToString(), _Password.ToString(), out LoginFlag, out UserId);
                    if (LoginFlag == 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + msg + "\"}";
                        return jsonStr;
                    }

                    string apiUrl = apiBaseUrl + "GetBeniList";

                    NameValueCollection postParams = new NameValueCollection();

                    postParams.Add("SenderMobileNo", _SenderMobileNo);
                    postParams.Add("UMobileNo", UMobileNo);
                    postParams.Add("Password", Password);

                    string Values = ConstructQueryString(postParams);
                    DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId.ToString(), "", "App");
                    string Response = postData(apiUrl, postParams, dt.Rows[0][0].ToString().ToInt());
                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Response);
                    jsonStr = JsonConvert.SerializeXmlNode(doc);
                    jsonStr = jsonStr.Replace("\"BENEFICIARY\":{", "\"BENEFICIARY\":[{").Replace("}}}}", "}]}}}");
                    //if (jsonStr.Contains('[') == true)
                    //{

                    //}
                    //else
                    //{
                    //    int i = jsonStr.IndexOf("BENEFICIARY");
                    //}
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App request!\"}";
                }
            }
            catch { }
            return jsonStr;
        }
        public String CreateSender(String _u_mobile, String _Password, String _SenderMobileNo, String _SenderName)
        {
            String jsonStr = "";
            int LoginFlag = 0; string UserId = "0";

            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    String msg = LoginVerification(_u_mobile.ToString(), _Password.ToString(), out LoginFlag, out UserId);
                    if (LoginFlag == 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + msg + "\"}";
                        return jsonStr;

                    }
                    string apiUrl = apiBaseUrl + "CreateSender";

                    NameValueCollection postParams = new NameValueCollection();

                    postParams.Add("UMobileNo", UMobileNo);
                    postParams.Add("Password", Password);
                    postParams.Add("SenderMobileNo", _SenderMobileNo);
                    postParams.Add("SenderName", _SenderName);
                    string Values = ConstructQueryString(postParams);
                    DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId.ToString(), "", "App");
                    string Response = postData(apiUrl, postParams, dt.Rows[0][0].ToString().ToInt());
                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Response);

                    jsonStr = JsonConvert.SerializeXmlNode(doc);

                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App request!\"}";
                }
            }
            catch { }
            return jsonStr;
        }
        public String AddBeneficiary(String _u_mobile, String _Password, String _SenderMobileNo, String _BeneName, String _BeneMobileNo, String _BeneBankAccount, String _BeneBankCode_IFSC, int ValidateStatus, int BankId)
        {
            String jsonStr = "";
            int LoginFlag = 0; string UserId = "0";
            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    String msg = LoginVerification(_u_mobile.ToString(), _Password.ToString(), out LoginFlag, out UserId);
                    if (LoginFlag == 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + msg + "\"}";
                        return jsonStr;

                    }
                    string apiUrl = apiBaseUrl + "AddBeneficiary";

                    NameValueCollection postParams = new NameValueCollection();

                    postParams.Add("SenderMobileNo", _SenderMobileNo);
                    postParams.Add("name", _BeneName);
                    postParams.Add("RMobileNo", _BeneMobileNo);
                    postParams.Add("BankAccount", _BeneBankAccount);
                    postParams.Add("BankCode_IFSC", _BeneBankCode_IFSC);
                    postParams.Add("UMobileNo", UMobileNo);
                    postParams.Add("password", Password);

                    string Values = ConstructQueryString(postParams);
                    DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId.ToString(), "", "App");
                    string Response = postData(apiUrl, postParams, dt.Rows[0][0].ToString().ToInt());
                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Response);

                    jsonStr = JsonConvert.SerializeXmlNode(doc);

                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    DataSet ds = ConvertXMLToDataSet(Response);

                    if (ds.Tables["TABLE"].Rows.Count > 0)
                    {
                        if (ds.Tables["TABLE"].Rows[0]["RESPONSESTATUS"].ToString() == "1")
                        {
                            Insert_BENEFICIARY_MASTER(_SenderMobileNo.Trim(), _BeneName.Trim(), _BeneBankAccount.Trim(), _BeneBankCode_IFSC.Trim(), UserId, ValidateStatus, BankId, ds.Tables["TABLE"].Rows[0]["RECIPIENTID"].ToString());

                        }
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App request!\"}";
                }
            }
            catch { }
            return jsonStr;
        }
        public void Insert_BENEFICIARY_MASTER(string SenderMobileNo, string BeneficiaryName, string AccountNo, string Ifsc, string UserId, int ValidateStatus, int BankId, string BeneficiaryId)
        {
            DataTable dt = new DataTable();
            try
            {
                string s2 = "spInsertBENEFICIARY_MASTER";
                SqlParameter[] parameter = { 
                                         new SqlParameter("@SenderMobileNo", SenderMobileNo),
                                         new SqlParameter("@BeneficiaryName", BeneficiaryName),
                                         new SqlParameter("@AccountNo", AccountNo),
                                         new SqlParameter("@BankId", BankId),
                                         new SqlParameter("@UserId", UserId),
                                         new SqlParameter("@ValidateStatus", ValidateStatus),
                                         new SqlParameter("@Ifsc", Ifsc),
                                         new SqlParameter("@BeneficiaryId", BeneficiaryId),

                                           };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch
            {
                dt = null;
            }
        }

        public String VerifyBeneficiary(String _u_mobile, String _Password, String _SenderMobileNo, String _BankAccount, String _BackCode)
        {
            String jsonStr = "";
            int LoginFlag = 0; string UserId = "0";
            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    String msg = LoginVerification(_u_mobile.ToString(), _Password.ToString(), out LoginFlag, out UserId);
                    if (LoginFlag == 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + msg + "\"}";
                        return jsonStr;

                    }
                    string apiUrl = apiBaseUrl + "VerifyBeneficiary";

                    NameValueCollection postParams = new NameValueCollection();

                    postParams.Add("UMobileNo", UMobileNo);
                    postParams.Add("password", Password);
                    postParams.Add("SenderMobileNo", _SenderMobileNo);
                    postParams.Add("BankAccount", _BankAccount);
                    postParams.Add("BackCode", _BackCode);

                    string Values = ConstructQueryString(postParams);
                    DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId.ToString(), "", "App");
                    string Response = postData(apiUrl, postParams, dt.Rows[0][0].ToString().ToInt());
                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Response);
                    jsonStr = JsonConvert.SerializeXmlNode(doc);


                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App request!\"}";
                }
            }
            catch { }
            return jsonStr;
        }

        public String DeleteBeneficiary(String _u_mobile, String _Password, String _SenderMobileNo, String _RecipientId)
        {
            String jsonStr = "";
            int LoginFlag = 0; string UserId = "0";
            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    String msg = LoginVerification(_u_mobile.ToString(), _Password.ToString(), out LoginFlag, out UserId);
                    if (LoginFlag == 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + msg + "\"}";
                        return jsonStr;

                    }
                    string apiUrl = apiBaseUrl + "DeleteBeneficiary";

                    NameValueCollection postParams = new NameValueCollection();

                    postParams.Add("UMobileNo", UMobileNo);
                    postParams.Add("Password", Password);
                    postParams.Add("SenderMobileNo", _SenderMobileNo);
                    postParams.Add("RecipientId", _RecipientId);

                    string Values = ConstructQueryString(postParams);
                    DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId.ToString(), "", "App");
                    string Response = postData(apiUrl, postParams, dt.Rows[0][0].ToString().ToInt());
                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Response);
                    jsonStr = JsonConvert.SerializeXmlNode(doc);

                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App request!\"}";
                }
            }
            catch { }
            return jsonStr;
        }


        public string postData(string destinationUrl, NameValueCollection postParams, int Id)
        {
            using (var client = new WebClient())
            {
                var response = client.UploadValues(destinationUrl, postParams);
                var responseString = Encoding.Default.GetString(response);
                Update_REQUEST_RESPONSE(Id, responseString);
                return responseString;
            }
        }
        public void Update_REQUEST_RESPONSE(int Id, string Response)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_UpdateRequestResponse";
                SqlParameter[] parameter = { 
                                             new SqlParameter("@Id", Id),
                                             new SqlParameter("@Response", Response),
                                           };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();

        }


        public String GeOperatorList(String _userid)
        {
            String jsonStr = "";
            try
            {
                //if (ValidateUMobile(_userid))
                //{
                DataSet ds = null;
                ObjData.StartConnection();
                try
                {
                    string s2 = "sp_GetOperatorsAllTypeService";
                    SqlParameter[] parameter = {    
                };
                    ds = ObjData.RunDataSetProcedure(s2, parameter);
                }
                catch (Exception ex)
                {

                }
                ObjData.EndConnection();
                if (ds.Tables.Count > 0)
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"message\"";
                    if (ds.Tables.Count >= 1 && ds.Tables[0].Rows.Count > 0)
                    {
                        jsonStr += ",\"prepaidOperator\":";
                        jsonStr += JsonConvert.SerializeObject(ds.Tables[0]);
                    }
                    if (ds.Tables.Count >= 2 && ds.Tables[1].Rows.Count > 0)
                    {
                        jsonStr += ",\"postpaidOperator\":";
                        jsonStr += JsonConvert.SerializeObject(ds.Tables[1]);
                    }
                    if (ds.Tables.Count >= 3 && ds.Tables[2].Rows.Count > 0)
                    {
                        jsonStr += ",\"dthOperator\":";
                        jsonStr += JsonConvert.SerializeObject(ds.Tables[2]);
                    }
                    if (ds.Tables.Count >= 4 && ds.Tables[3].Rows.Count > 0)
                    {
                        jsonStr += ",\"landlineOperator\":";
                        jsonStr += JsonConvert.SerializeObject(ds.Tables[3]);
                    }
                    if (ds.Tables.Count >= 5 && ds.Tables[4].Rows.Count > 0)
                    {
                        jsonStr += ",\"electricityOperator\":";
                        jsonStr += JsonConvert.SerializeObject(ds.Tables[4]);


                    }
                    if (ds.Tables.Count >= 5 && ds.Tables[5].Rows.Count > 0)
                    {
                        jsonStr += ",\"gasOperator\":";
                        jsonStr += JsonConvert.SerializeObject(ds.Tables[5]);
                    }
                    if (ds.Tables.Count >= 5 && ds.Tables[6].Rows.Count > 0)
                    {
                        jsonStr += ",\"Insurance\":";
                        jsonStr += JsonConvert.SerializeObject(ds.Tables[6]);
                    }
                    jsonStr += "}";

                }

                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                }
                //}
                //else
                //{
                //    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                //}
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String GeNumberList(String _userid)
        {
            String jsonStr = "";
            try
            {
                //if (ValidateUMobile(_userid))
                //{
                DataTable dt = null;
                ObjData.StartConnection();
                try
                {
                    string s2 = "sp_getNumberListService";
                    SqlParameter[] parameter = {    
                };
                    dt = ObjData.RunDataTableProcedure(s2, parameter);
                }
                catch (Exception ex)
                {

                }
                ObjData.EndConnection();
                if (dt.Rows.Count > 0)
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"NumberList\"";
                    jsonStr += ",\"NumberList\":";
                    jsonStr += JsonConvert.SerializeObject(dt);
                    jsonStr += "}";
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                }
                //}
                //else
                //{
                //    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                //}
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String GeNumberListByNumber(String _userid, String _Number)
        {
            String jsonStr = "";
            try
            {
                //if (ValidateUMobile(_userid))
                //{
                DataTable dt = null;
                ObjData.StartConnection();
                try
                {
                    string s2 = "sp_getNumberListByNumberService";
                    SqlParameter[] parameter = {
                                                     new SqlParameter("@Number", _Number),
                };
                    dt = ObjData.RunDataTableProcedure(s2, parameter);
                }
                catch (Exception ex)
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + ex.Message + "\"}";
                }
                ObjData.EndConnection();
                if (dt.Rows.Count > 0)
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"NumberList\"";
                    jsonStr += ",\"NumberList\":";
                    jsonStr += JsonConvert.SerializeObject(dt);
                    jsonStr += "}";
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                }
                //}
                //else
                //{
                //    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                //}
            }
            catch (Exception ex)
            {
                jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + ex.Message + "\"}";
            }
            return jsonStr;
        }

        public String Recharge(String userid, String password, String RechargeMobile, String RechargeAmount, String OperatorId, String RechargeType)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(userid, 4))
                {
                    DataTable dtresult = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_RechargeService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", userid.Split((char)160)[2]),
                   new SqlParameter("@Password", password),
                   new SqlParameter("@SessionId",  userid.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  userid.Split((char)160)[1]),         
                   new SqlParameter("@RechargeMobile",  RechargeMobile),       
                   new SqlParameter("@RechargeAmount",  RechargeAmount),       
                   new SqlParameter("@OperatorId", OperatorId),       
                   new SqlParameter("@IpAddress",  userid.Split((char)160)[1]),       
                   new SqlParameter("@EntryBy",  userid.Split((char)160)[2]),       
                   new SqlParameter("@RechargeType",  RechargeType),     
                };
                        dtresult = ObjData.RunDataTableProcedure(s2, parameter);

                        if (dtresult.Rows[0][0].ToString() == "1")
                        {
                            string referenceid = dtresult.Rows[0]["referenceid"].ToString();
                            string Resp = "";
                            string ErrorMsg = dtresult.Rows[0]["errors"].ToString();
                            string url = dtresult.Rows[0]["url"].ToString(); ;
                            string msg = "";
                            string status = "";
                            string RechargeStatus = "";
                            string Type = dtresult.Rows[0]["Type"].ToString();
                            string StatusValue = dtresult.Rows[0]["StatusValue"].ToString();
                            string StatusName = dtresult.Rows[0]["StatusName"].ToString();
                            string VenderId = dtresult.Rows[0]["VenderId"].ToString();
                            string VenderIdColumn = dtresult.Rows[0]["VenderId"].ToString();
                            string VenderIdValue = "";
                            string LiveId = dtresult.Rows[0]["LiveId"].ToString();
                            string LiveIdValue = "";
                            string Error1 = "";
                            Resp = url.CallURL();

                            if (ErrorMsg != "")
                            {
                                string[] errmsg = ErrorMsg.Split(new string[] { "||" }, StringSplitOptions.None);
                                //string[] errmsg = ErrorMsg.Split('[]');
                                for (int i = 0; i < errmsg.Length; i++)
                                {
                                    if (errmsg[i].ToString().Trim() != "")
                                    {
                                        if (Resp.Contains(errmsg[i].ToString().Trim()) == true && errmsg[i] != "")
                                        {
                                            status = "Failed";
                                            msg = errmsg[i];
                                            if (msg.ToLower().Contains("insufficient") == true)
                                            {

                                                msg = "System error found";
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                            if (status != "Failed")
                            {
                                DataTable dtResp = GetResponseValues(Resp, Type);
                                DataColumnCollection columns = dtResp.Columns;
                                if (dtResp.Columns.Contains("ResultErr") == false)
                                {
                                    string[] StsCol = StatusName.Split('/');
                                    string[] StsVal = StatusValue.Split(',');
                                    if (dtResp.Columns.Contains(StsCol[0].Trim()))
                                    {
                                        string matchvalue = dtResp.Rows[0][StsCol[0].Trim()].ToString().ToUpper();
                                        if (matchvalue == StsVal[0].Trim().ToUpper())
                                        {
                                            status = "Success";
                                        }
                                        if (matchvalue == StsVal[1].Trim().ToUpper())
                                        {
                                            status = "Failed";
                                        }
                                    }
                                    if (columns.Contains(VenderIdColumn))
                                    {
                                        //Vendor ID means RP Id
                                        VenderId = dtResp.Rows[0][VenderIdColumn].ToString().ToUpper();
                                        VenderIdValue = dtResp.Rows[0][VenderIdColumn].ToString().ToUpper();
                                    }
                                    else
                                    {
                                        VenderId = "";
                                        VenderIdValue = "";
                                    }
                                    if (columns.Contains(LiveId))
                                    {
                                        //Live Id value
                                        LiveIdValue = dtResp.Rows[0][LiveId].ToString().ToUpper();
                                    }
                                    if (columns.Contains(StsCol[0].Trim()))
                                    {
                                        string matchvalue = dtResp.Rows[0][StsCol[0].Trim()].ToString().ToUpper();
                                        if (matchvalue == StsVal[2].Trim().ToUpper())
                                        {
                                            status = "Pending";
                                        }
                                    }
                                    if (columns.Contains("MSG"))
                                    {
                                        msg = dtResp.Rows[0]["MSG"].ToString().ToUpper();
                                        if (msg.ToLower().Contains("insufficient") == true)
                                        {
                                            Error1 = "System error found";
                                        }
                                        else
                                        {
                                            Error1 = msg;
                                        }
                                    }
                                    if (dtResp.Columns.Contains(StsCol[StsCol.Length - 1]))
                                    {
                                        if (dtResp.Rows[0][StsCol[StsCol.Length - 1].Trim()].ToString() == StsVal[1].Trim().ToUpper())
                                        {
                                            status = "Failed";
                                        }
                                        else if (StsCol.Length == 2)
                                        {
                                            if (dtResp.Columns.Contains(StsCol[StsCol.Length - 1]))
                                            {
                                                status = "Failed";

                                            }
                                        }
                                    }
                                }
                                if (status == "")
                                {
                                    status = "";
                                    status = "Pending";
                                }
                            }


                            s2 = "sp_update_RechargeRequest";
                            SqlParameter[] parameter2 = {  
               new SqlParameter("@ReferenceId", referenceid) ,           
               new SqlParameter("@response", Resp) ,           
               new SqlParameter("@VendorId", VenderIdValue) ,           
               new SqlParameter("@Liveid", LiveIdValue) ,           
               new SqlParameter("@status", status) ,           
               new SqlParameter("@Message", msg) ,           
                };

                            DataTable dtUpdateresponse = ObjData.RunDataTableProcedure(s2, parameter2);
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dtresult.Rows.Count > 0)
                    {
                        if (dtresult.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"" + dtresult.Rows[0][0].ToString() + "\",\"message\":\"" + dtresult.Rows[0]["Msg"].ToString() + "\"";
                            //jsonStr += ",\"data\":[{";
                            //jsonStr += "\"Message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"";
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dtresult.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid Username and password\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public DataTable GetResponseValues(string Resp, string Type)
        {
            try
            {
                if (Type == "1")
                {


                    Resp = Resp.Replace("{", "[{");
                    Resp = Resp.Replace("}", "}]");
                    DataTable dtValue = (DataTable)JsonConvert.DeserializeObject(Resp, (typeof(DataTable)));
                    return dtValue;

                }
                else
                {

                    XElement x = null;
                    if (Resp.Contains("<?xml"))
                    {
                        x = XElement.Parse(Resp);
                    }
                    else
                    {
                        x = XElement.Parse("<Root>" + Resp + "</Root>");
                    }
                    DataTable dt = new DataTable();
                    XElement setup = (from p in x.Descendants() select p).First();
                    foreach (XElement xe in setup.Descendants()) // build your DataTable
                        dt.Columns.Add(new DataColumn(xe.Name.ToString(), typeof(string))); // add columns to your dt

                    var all = from p in x.Descendants(setup.Name.ToString()) select p;
                    foreach (XElement xe in all)
                    {
                        DataRow dr = dt.NewRow();
                        foreach (XElement xe2 in xe.Descendants())
                            dr[xe2.Name.ToString()] = xe2.Value; //add in the values
                        dt.Rows.Add(dr);
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {
                DataTable dtt = new DataTable();
                dtt.Columns.Add("ResultErr");
                dtt.Rows.Add(ex.Message);
                return dtt;
            }
        }
        public String getRechargeReport(String _UserId, String UPassword, String RechargeMobile, String FromDate, String ToDate)
        {
            String jsonStr = "";

            try
            {
                if (ValidateUMobile(_UserId, 4))
                {
                    DataTable dt = null;
                    ObjData.StartConnection();
                    try
                    {
                        string s2 = "sp_GetRechargeReportService";
                        SqlParameter[] parameter = {              
                    new SqlParameter("@UserId", _UserId.Split((char)160)[2]),
                   new SqlParameter("@Password", UPassword),
                   new SqlParameter("@SessionId",  _UserId.Split((char)160)[3]),
                   new SqlParameter("@LoginIP",  _UserId.Split((char)160)[1]),         
                   new SqlParameter("@RechargeMobile",  RechargeMobile),         
                   new SqlParameter("@fromDate", FromDate),         
                   new SqlParameter("@ToDate",  ToDate),         
                };
                        dt = ObjData.RunDataTableProcedure(s2, parameter);
                    }
                    catch (Exception ex)
                    {

                    }
                    ObjData.EndConnection();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"message\":\"RechargeReport\"";
                            jsonStr += ",\"RechargeReport\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";

                        }
                        else
                        {
                            jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"No Record Found\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"message\":\"Invalid App Request\"}";
                }
            }
            catch (Exception ex)
            {
                //objB2BSecureServiceDL.B2B_Error_Log("SecureServiceLogin", ex.Message, "Login");
            }
            return jsonStr;
        }
        public String VerifySender(String _u_mobile, String _Password, String _SenderMobileNo, String _OTP, String _SenderName)
        {
            String jsonStr = "";
            int LoginFlag = 0; string UserId = "0";
            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    String msg = LoginVerification(_u_mobile.ToString(), _Password.ToString(), out LoginFlag, out UserId);
                    if (LoginFlag == 0)
                    {
                        jsonStr = "{\"DMR\":{\"TABLE\":{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"" + msg + "\"}}}";
                        return jsonStr;

                    }
                    string apiUrl = apiBaseUrl + "VerifySender";

                    NameValueCollection postParams = new NameValueCollection();

                    postParams.Add("UMobileNo", UMobileNo);
                    postParams.Add("Password", Password);
                    postParams.Add("SenderMobileNo", _SenderMobileNo);
                    postParams.Add("OTP", _OTP);


                    string Values = ConstructQueryString(postParams);
                    DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId.ToString(), "", "App");
                    string Response = postData(apiUrl, postParams, dt.Rows[0][0].ToString().ToInt());
                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Response);
                    jsonStr = JsonConvert.SerializeXmlNode(doc);

                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    DataSet ds = ConvertXMLToDataSet(Response);

                    if (ds.Tables["TABLE"].Rows.Count > 0)
                    {
                        if (ds.Tables["TABLE"].Rows[0]["RESPONSESTATUS"].ToString() == "1")
                        {
                            Insert_WALLET(UserId, _SenderMobileNo, _SenderName);
                        }
                    }
                }
                else
                {
                    jsonStr = "{\"DMR\":{\"TABLE\":{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"Invalid App request!\"}}}";
                }
            }
            catch { }
            return jsonStr;
        }
        public void Insert_WALLET(string UserId, string MobileNo, string Name)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_InsertWalletMaster";
                SqlParameter[] parameter = { 
                                             new SqlParameter("@MobileNo", MobileNo),
                                             new SqlParameter("@Name", Name),
                                             new SqlParameter("@UserId", UserId),
                                           };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();

        }

        public String ResendOtp(String _u_mobile, String _Password, String _SenderMobileNo)
        {
            String jsonStr = "";
            int LoginFlag = 0; string UserId = "0";
            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    String msg = LoginVerification(_u_mobile.ToString(), _Password.ToString(), out LoginFlag, out UserId);
                    if (LoginFlag == 0)
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"" + msg + "\"}";
                        return jsonStr;

                    }
                    string apiUrl = apiBaseUrl + "ResendOtp";

                    NameValueCollection postParams = new NameValueCollection();

                    postParams.Add("UMobileNo", UMobileNo);
                    postParams.Add("Password", Password);
                    postParams.Add("SenderMobileNo", _SenderMobileNo);

                    string Values = ConstructQueryString(postParams);
                    DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId.ToString(), "", "App");
                    string Response = postData(apiUrl, postParams, dt.Rows[0][0].ToString().ToInt());
                    if (Response.Contains("<?"))
                    {
                        Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Response);
                    jsonStr = JsonConvert.SerializeXmlNode(doc);

                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"Invalid App request!\"}";
                }
            }
            catch { }
            return jsonStr;
        }
        public DataTable DMRTransaction(String _LoginID, String _SessionID, String _LoginIP, String _Password, String _FromDate, String _ToDate, String _AccontNo)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "DMRTransactionService";
                SqlParameter[] parameter = { 
                                            new SqlParameter("@_LoginID", _LoginID),
                                            new SqlParameter("@_SessionID", _SessionID),
                                            new SqlParameter("@_LoginIP", _LoginIP),
                                            new SqlParameter("@_Password", _Password),
                                            new SqlParameter("@_FromDate", _FromDate),
                                            new SqlParameter("@_ToDate", _ToDate),
                                            new SqlParameter("@_AccontNo", _AccontNo),
                                           };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }

        public String DMRTransaction(String _u_mobile, String _Password, String _FromDate, String _ToDate, String _AccontNo)
        {
            String jsonStr = "";
            try
            {
                if (ValidateUMobile(_u_mobile, 4))
                {
                    DataTable dt = DMRTransaction(_u_mobile.Split((char)160)[2], _u_mobile.Split((char)160)[3], _u_mobile.Split((char)160)[1], _Password, _FromDate, _ToDate, _AccontNo);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            dt.Columns.RemoveAt(0);
                            jsonStr = "{\"RESPONSESTATUS\":\"1\",\"MESSAGE\":\"DMR Transactions List\"";
                            jsonStr += ",\"DMRTransactions\":";
                            jsonStr += JsonConvert.SerializeObject(dt);
                            jsonStr += "}";
                        }
                        else
                        {

                            jsonStr += "{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"" + dt.Rows[0]["Msg"].ToString() + "\"}";
                        }
                    }
                    else
                    {
                        jsonStr = "{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"no transaction found!\"}";
                    }
                }
                else
                {
                    jsonStr = "{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"Invalid App request!\"}";
                }
            }
            catch { }
            return jsonStr;
        }
        public String GetMoneyTransferUrl(String SenderMobileNo, String BankAccount, String Amount, String Recipientid, String Channel, String IMEI, String UserId)
        {

            string apiUrl = apiBaseUrl + "SendMoney";

            NameValueCollection postParams = new NameValueCollection();
            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("password", Password);

            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("BankAccount", BankAccount);
            postParams.Add("Amount", Amount);
            postParams.Add("Recipientid", Recipientid);
            postParams.Add("Channel", Channel);
            postParams.Add("IMEI", IMEI);

            string Values = ConstructQueryString(postParams);


            return (apiUrl + '?' + Values);
        }


        public DataTable ValidateMRTransfer(string UserId, int SenderId, string SenderMobileNo, int BeneficiaryId, string AccountNo, decimal Amount, string TransferType, string ReferenceId, string RequestUrl)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "spValidateMRTransfer";
                SqlParameter[] parameter = { 
                                       new SqlParameter("@UserId", UserId),
                                       new SqlParameter("@SenderId", SenderId),
                                       new SqlParameter("@SenderMobileNo", SenderMobileNo),
                                       new SqlParameter("@BeneficiaryId", BeneficiaryId),
                                       new SqlParameter("@AccountNo", AccountNo),
                                       new SqlParameter("@Amount", Amount),
                                       new SqlParameter("@TransferType", TransferType),
                                       new SqlParameter("@ReferenceId", ReferenceId),
                                       new SqlParameter("@RequestUrl", RequestUrl),
                                         new SqlParameter("@MentionBy", UserId),
                                           };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }

        public String SendMoney(String _u_mobile, String _Password, String _SenderMobileNo, String _BankAccount, String _Amount, String _Recipientid, String _Channel)
        {
            String jsonStr = "";
            int LoginFlag = 0; string UserId = "0";

            try
            {

                if (ValidateUMobile(_u_mobile, 4))
                {
                    string _IMEI = _u_mobile.Split((char)160)[1];
                    String msg = LoginVerification(_u_mobile.ToString(), _Password.ToString(), out LoginFlag, out UserId);
                    if (LoginFlag == 0)
                    {
                        jsonStr = "{\"DMR\":{\"TABLE\":{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"" + msg + "\"}}}";
                        return jsonStr;
                    }
                    string apiUrl = apiBaseUrl + "SendMoney";

                    string url = GetMoneyTransferUrl(_SenderMobileNo, _BankAccount, _Amount, _Recipientid, _Channel, _IMEI, UserId.ToString());

                    DataTable dt = ValidateMRTransfer(UserId, 0, _SenderMobileNo,
                     _Recipientid.ToInt(), _BankAccount, _Amount.ToDecimal(), _Channel, "", url);


                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0][0].ToString() == "1")
                        {

                            NameValueCollection postParams = new NameValueCollection();

                            postParams.Add("UMobileNo", UMobileNo);
                            postParams.Add("password", Password);
                            postParams.Add("SenderMobileNo", _SenderMobileNo);
                            postParams.Add("BankAccount", _BankAccount);
                            postParams.Add("Amount", _Amount);
                            postParams.Add("Recipientid", _Recipientid);
                            postParams.Add("Channel", _Channel);
                            postParams.Add("IMEI", _IMEI);

                            string Values = ConstructQueryString(postParams);
                            DataTable dt1 = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId.ToString(), "", "App");
                            string Response = postData(apiUrl, postParams, dt1.Rows[0][0].ToString().ToInt());
                            if (Response.Contains("<?"))
                            {
                                Response = Response.Substring(Response.IndexOf("?>") + 2).Trim();
                            }
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(Response);
                            jsonStr = JsonConvert.SerializeXmlNode(doc);

                            DataSet ds = ConvertXMLToDataSet(Response);
                            if (ds.Tables["TABLE"].Rows[0]["RESPONSESTATUS"].ToString() == "1")
                            {
                                if (ds.Tables["DMR"].Rows[0]["MESSAGE"].ToString().ToLower().Contains("insufficient balance") == true)
                                {
                                    jsonStr = "{\"DMR\":{\"TABLE\":{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"Technical Issue Found\"}}}";
                                }
                                else
                                {
                                    jsonStr = "{\"DMR\":{\"TABLE\":{\"RESPONSESTATUS\":\"1\",\"MESSAGE\":\"" + ds.Tables["DMR"].Rows[0]["MESSAGE"].ToString() + "\"}}}";

                                }
                            }
                            else
                            {
                                if (ds.Tables["DMR"].Rows[0]["MESSAGE"].ToString().ToLower().Contains("insufficient balance") == true)
                                {
                                    jsonStr = "{\"DMR\":{\"TABLE\":{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"Technical Issue Found\"}}}";

                                }
                                else
                                {
                                    jsonStr = "{\"DMR\":{\"TABLE\":{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"" + ds.Tables["DMR"].Rows[0]["MESSAGE"].ToString() + "\"}}}";
                                }
                            }
                            if (ds.Tables["DMR"].Rows[0]["bank_ref_num"].ToString() == "")
                                UpdateMRTransferResponse(UserId, _Recipientid, _BankAccount,
                         dt.Rows[0]["Transaction_ID"].ToString(), Response, ds.Tables["TABLE"].Rows[0]["RESPONSESTATUS"].ToString(), ds.Tables["DMR"].Rows[0]["tid"].ToString(), ds.Tables["DMR"].Rows[0]["tid"].ToString());
                            else
                                UpdateMRTransferResponse(UserId, _Recipientid, _BankAccount,
                              dt.Rows[0]["Transaction_ID"].ToString(), Response, ds.Tables["TABLE"].Rows[0]["RESPONSESTATUS"].ToString(), ds.Tables["DMR"].Rows[0]["bank_ref_num"].ToString(), ds.Tables["DMR"].Rows[0]["tid"].ToString());


                        }
                        else if (dt.Rows[0][0].ToString() == "-1")
                        {
                            jsonStr = "{\"DMR\":{\"TABLE\":{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"" + dt.Rows[0][1].ToString() + "\"}}}";
                        }

                    }
                }
                else
                {
                    jsonStr = "{\"DMR\":{\"TABLE\":{\"RESPONSESTATUS\":\"0\",\"MESSAGE\":\"Invalid App request!\"}}}";
                }
            }
            catch { }
            return jsonStr;
        }
        public void UpdateMRTransferResponse(string UserId, string BeneficiaryId, string AccountNo, string PreviousTransId, string Response, string Type, string Oprater_Id, string VenderID)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_UpdateMRTransferResponse";
                SqlParameter[] parameter = { 
                                       new SqlParameter("@UserId", UserId),
                                       new SqlParameter("@BeneficiaryId", BeneficiaryId),
                                       new SqlParameter("@AccountNo", AccountNo),
                                       new SqlParameter("@PreviousTransId", PreviousTransId),
                                       new SqlParameter("@Response", Response),
                                       new SqlParameter("@Type", Type),
                                       new SqlParameter("@Oprater_Id", Oprater_Id),
                                       new SqlParameter("@VenderID", VenderID),
                                         new SqlParameter("@MentionBy", UserId),
                                           };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();

        }

        public DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                // Load the XmlTextReader from the stream
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }
    }
}
