using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataTier;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;
using System.IO;
using System.Net;
using System.Data.SqlClient;

namespace BusinessLogicTier
{
    public class clsMoneyTransfer
    {
        Data ObjData = new Data();
        public string UserId { get; set; }
        public string AmountTransferTo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        
        string apiBaseUrl = ConfigurationManager.AppSettings["apiBaseUrl"];
        string UMobileNo = ConfigurationManager.AppSettings["UMobileNo"];
        string Password = ConfigurationManager.AppSettings["Password"];
        public string CallGetDepositorApi(string SenderMobileNo = "", string UserId = "")
        {
            string apiUrl = apiBaseUrl + "GetSenderInfo";
            NameValueCollection postParams = new NameValueCollection();
            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);
            string Values = ConstructQueryString(postParams);
            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, "");
            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
        }
        public string CallGetBeniListApi(string SenderMobileNo = "", string UserId = "")
        {

            string apiUrl = apiBaseUrl + "GetBeniList";

            NameValueCollection postParams = new NameValueCollection();

            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);


            string Values = ConstructQueryString(postParams);

            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, "");
            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
        }
        public string CallDeleteBeneficiaryApi(string SenderMobileNo = "", string RecipientId = "", string UserId = "")
        {
            string apiUrl = apiBaseUrl + "DeleteBeneficiary";

            NameValueCollection postParams = new NameValueCollection();

            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);
            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("RecipientId", RecipientId);


            string Values = ConstructQueryString(postParams);

            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, "");
            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
        }
        public DataSet GetCommissionModule1New()
        {
            DataSet dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "GetCommissionModule1New";
                SqlParameter[] parameter = { };
                dt = ObjData.RunDataSetProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public DataTable Insert_REQUEST_RESPONSE(string username, string password, string RequestUrl, string Request, string Response, string UserId, string TransId)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_InsertRequestResponse";
                SqlParameter[] parameter = { 
                                            new SqlParameter("@username", username),
                                            new SqlParameter("@password", password),
                                            new SqlParameter("@TransId", TransId),
                                            new SqlParameter("@RequestUrl", RequestUrl),
                                            new SqlParameter("@Request", Request),
                                            new SqlParameter("@Response", Response),
                                            new SqlParameter("@UserId", UserId),
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
        public DataTable insertDMRCommission1(DataTable GridData)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "insertDMRCommission1New";
                SqlParameter[] parameter = { 
                                             new SqlParameter("@GridData", GridData),
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
        public DataTable updateDMRCommissionModule1(DataTable GridData)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "updateDMRCommissionModule1New";
                SqlParameter[] parameter = { 
                                            new SqlParameter("@GridData", GridData),
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
        public DataTable GetCharges(int UserId, decimal Amount)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_GetSurCharge";
                SqlParameter[] parameter = { 
                                           new SqlParameter("@UserId", UserId),
                                           new SqlParameter("@Amount", Amount),};
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public DataTable GetCharges(string UserId, decimal Amount)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_GetSurCharge";
                SqlParameter[] parameter = { 
                                          new SqlParameter("@UserId", UserId),
                                          new SqlParameter("@Amount", Amount),
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

        public DataTable ValidateMRTransfer(string UserId, int SenderId, string SenderMobileNo, int BeneficiaryId, string AccountNo, decimal Amount, string TransferType, string ReferenceId, string RequestUrl, string mentionby)
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
                                         new SqlParameter("@MentionBy", mentionby),
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

        public void UpdateMRTransferResponse(string UserId, string BeneficiaryId, string AccountNo, string PreviousTransId, string Response, string Type, string Oprater_Id, string VenderID, string mentionby)
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
                                         new SqlParameter("@MentionBy", mentionby),
                                           };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();

        }
        public DataTable GenerateTransId()
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_GenerateTransId";
                SqlParameter[] parameter = { };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public string GetMoneyTransferUrl(string SenderMobileNo = "", string BankAccount = "", string Amount = "", string Recipientid = "", string Channel = "", string IMEI = "", string UserId = "")
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
        public string CallMoneyTransferApi(string SenderMobileNo = "", string BankAccount = "", string Amount = "", string Recipientid = "", string Channel = "", string IMEI = "", string UserId = "", string TransId = "")
        {

            string apiUrl = apiBaseUrl + "SendMoney";

            NameValueCollection postParams = new NameValueCollection();

            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);
            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("BankAccount", BankAccount);
            postParams.Add("Amount", Amount);
            postParams.Add("Recipientid", Recipientid);
            postParams.Add("Channel", Channel);
            postParams.Add("IMEI", IMEI);

            string Values = ConstructQueryString(postParams);

            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, TransId);
            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
        }


        public string GetRefundUrl(string SenderMobileNo = "", string TransactionID = "", string IMEI = "", string UserId = "")
        {

            string apiUrl = apiBaseUrl + "Refund";

            NameValueCollection postParams = new NameValueCollection();
            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);

            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("TransactionID", TransactionID);
            postParams.Add("IMEI", IMEI);

            string Values = ConstructQueryString(postParams);


            return (apiUrl + '?' + Values);
        }
        public string CallRefundApi(string SenderMobileNo = "", string TransactionID = "", string IMEI = "", string UserId = "")
        {

            string apiUrl = apiBaseUrl + "Refund";

            NameValueCollection postParams = new NameValueCollection();
            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);
            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("TransactionID", TransactionID);
            postParams.Add("IMEI", IMEI);

            string Values = ConstructQueryString(postParams);

            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, "");
            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
        }
        public string VerifyRefund(string SenderMobileNo = "", string OTP = "", string TransactionID = "", string UserId = "")
        {

            string apiUrl = apiBaseUrl + "VerifyRefund";

            NameValueCollection postParams = new NameValueCollection();

            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);
            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("TransactionID", TransactionID);
            postParams.Add("OTP", OTP);

            string Values = ConstructQueryString(postParams);

            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, "");
            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
        }

        public string ResendOtp(string SenderMobileNo = "", string UserId = "")
        {

            string apiUrl = apiBaseUrl + "ResendOtp";

            NameValueCollection postParams = new NameValueCollection();

            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);
            postParams.Add("SenderMobileNo", SenderMobileNo);


            string Values = ConstructQueryString(postParams);

            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, "");
            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
        }
        public string VerifySender(string SenderMobileNo = "", string OTP = "", string UserId = "")
        {

            string apiUrl = apiBaseUrl + "VerifySender";

            NameValueCollection postParams = new NameValueCollection();

            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);
            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("OTP", OTP);

            string Values = ConstructQueryString(postParams);

            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, "");
            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
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
        public DataTable GetBankList(int BankId, string BankName)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_GetBankList";
                SqlParameter[] parameter = { 
                                           new SqlParameter("@BankId", BankId),
                                           new SqlParameter("@BankName", BankName),
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
        public string CallAddBeneficiariesApi(string SenderMobileNo = "", string name = "", string RMobileNo = "", string BankAccount = "", string BankCode_IFSC = "", string UserId = "")
        {

            string apiUrl = apiBaseUrl + "AddBeneficiary";

            NameValueCollection postParams = new NameValueCollection();

            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("name", name);
            postParams.Add("RMobileNo", RMobileNo);
            postParams.Add("BankAccount", BankAccount);
            postParams.Add("BankCode_IFSC", BankCode_IFSC);
            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("password", Password);

            string Values = ConstructQueryString(postParams);

            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, "");

            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
        }
        public DataTable CheckBeneficiary(string BeneficiaryName, string AccountNo, string IFSC, string SenderMobileNo)
        {
            DataTable dt = new DataTable();
            try
            {
                string s2 = "sp_CheckBeneficiary";
                SqlParameter[] parameter = { 
                                          new SqlParameter("@BeneficiaryName", BeneficiaryName),
                                          new SqlParameter("@AccountNo", AccountNo),
                                          new SqlParameter("@IFSC", IFSC),
                                          new SqlParameter("@SenderMobileNo", SenderMobileNo),
                                         };
            }
            catch
            {
                dt = null;
            }


            return dt;
        }
        public string CallAddDepositorApi(string SenderMobileNo = "", string SenderName = "", string UserId = "")
        {

            string apiUrl = apiBaseUrl + "CreateSender";

            NameValueCollection postParams = new NameValueCollection();

            postParams.Add("UMobileNo", UMobileNo);
            postParams.Add("Password", Password);
            postParams.Add("SenderMobileNo", SenderMobileNo);
            postParams.Add("SenderName", SenderName);


            string Values = ConstructQueryString(postParams);

            DataTable dt = Insert_REQUEST_RESPONSE(UMobileNo, Password, apiUrl, Values, "", UserId, "");
            return postData(apiUrl, postParams, Convert.ToInt32(dt.Rows[0][0].ToString()));
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

        public DataSet ReadDataFromJson(string jsonString)
        {
            var xd = new XmlDocument();
            jsonString = "{\"rootNode\":{" + jsonString.Trim().TrimStart('{').TrimEnd('}') + @"}}";
            xd = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(jsonString);
            var result = new DataSet();
            result.ReadXml(new XmlNodeReader(xd));
            return result;
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
        public static String ConstructQueryString(NameValueCollection parameters)
        {
            List<string> items = new List<string>();

            foreach (string name in parameters)
                items.Add(string.Concat(name, "=", System.Web.HttpUtility.UrlEncode(parameters[name])));

            return string.Join("&amp;", items.ToArray());
        }
        public DataTable getMoneyTransferReport(clsMoneyTransfer objmoneytransfer)
        {
            string str_query = "SELECT * FROM tbl_MRTransaction where  1=1 ";
            if (objmoneytransfer.FromDate != DateTime.MinValue && objmoneytransfer.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(DATE, creatd_date)   >= '" + objmoneytransfer.FromDate + "'   and convert(DATE, creatd_date)    <= '" + objmoneytransfer.ToDate + "' ";
            }
            if (objmoneytransfer.UserId != "")
            {
                str_query += "  and User_Id = '" + objmoneytransfer.UserId + "' ";
            }
            if (objmoneytransfer.AmountTransferTo != "")
            {
                str_query += "  and AmountTransfer_To = '" + objmoneytransfer.AmountTransferTo + "' ";
            }
            str_query += " order by creatd_date  desc";
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                dt = ObjData.RunDataTable(str_query);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
    }
}
