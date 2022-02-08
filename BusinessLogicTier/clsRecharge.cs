using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataTier;
using System.Data.SqlClient;
using ARA_StringHunt;
using System.Xml.Linq;
using Newtonsoft.Json;
using CyberPlatOpenSSL;
using System.Configuration;
using System.Web;

namespace BusinessLogicTier
{
    public class clsRecharge
    {
        Data ObjData = new Data();
        OpenSSL ssl = new OpenSSL();
        public string UserId { get; set; }
        public string RechargeMobile { get; set; }

        public string UserMobile { get; set; }
        public string OperatorCode { get; set; }
        public string OperatorName { get; set; }
        public decimal RechargeAmount { get; set; }
        public string IPAddress { get; set; }
        public string EntryBy { get; set; }
        public string UserType { get; set; }
        public string Rechargebile { get; set; }
        public string Name { get; set; }
        public string ReferenceId { get; set; }
        public string RechargeType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Status { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string DispalyValue1 { get; set; }
        public string DispalyValue2 { get; set; }
        public string DispalyValue3 { get; set; }
        public string DispalyValue4 { get; set; }
        public string Number { get; set; }
        public string CircleCode { get; set; }
        public string CircleName { get; set; }


        public string SessionNo = DateTime.Parse(DateTime.Now.ToString()).ToString("dddMMMddyyyyHHmmss");
        string keyPath = HttpContext.Current.Server.MapPath("~/keys/myprivatekey.pfx");

        public DataTable getRechargeCommission()
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = @"SELECT tb1.*
,tb2.[1] AS type1,tb2.[2] AS type2,tb2.[3] AS type3,tb2.[4] AS type4,tb2.[5] AS type5,tb2.[6] AS type6,tb2.[7] AS type7
,tb3.[1] AS changetype1,tb3.[2] AS changetype2,tb3.[3] AS changetype3,tb3.[4] AS changetype4,tb3.[5] AS changetype5,tb3.[6] AS changetype6,tb3.[7] AS changetype7
  FROM

(
select * from (
select LVL,oc.id as OperatorId ,OC.Operator,Commission from COMMISSIOIN_DISTRIBUTION_DETAIL CD  right outer  JOIN OperatorCode OC ON OC.ID=CD.OperatorId 

) as T 
Pivot
(
Max(Commission)
for Lvl in ([1],[2],[3],[4],[5],[6],[7])
  )As Pivot1
  ) tb1
  LEFT JOIN 
(
select * from (
select LVL,oc.id as OperatorId ,OC.Operator,cd.type from COMMISSIOIN_DISTRIBUTION_DETAIL CD  right outer  JOIN OperatorCode OC ON OC.ID=CD.OperatorId 

) as T 
Pivot
(
Max(type)
for Lvl in ([1],[2],[3],[4],[5],[6],[7])
  )As Pivot1)
  
  tb2 ON tb2.operatorid=tb1.operatorid
LEFT JOIN 
(

select * from (
select LVL,oc.id as OperatorId ,OC.operator,changetype from COMMISSIOIN_DISTRIBUTION_DETAIL CD  right outer  JOIN OperatorCode OC ON OC.ID=CD.OperatorId 

) as T 
Pivot
(
Max(changetype)
for Lvl in ([1],[2],[3],[4],[5],[6],[7])
  )As Pivot1
  )
  tb3 ON tb1.operatorid=tb3.operatorid  order by tb1.operatorid";
                dt = ObjData.RunDataTable(s2);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public DataTable getRetailerRechargeCommission()
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = @"SELECT tb1.*
,tb2.[1] AS type1
,tb3.[1] AS changetype1
  FROM

(
select * from (
select LVL,oc.id as OperatorId ,OC.Operator,Commission from RetailerCOMMISSIOIN_DISTRIBUTION_DETAIL CD  right outer  JOIN OperatorCode OC ON OC.ID=CD.OperatorId 

) as T 
Pivot
(
Max(Commission)
for Lvl in ([1])
  )As Pivot1
  ) tb1
  LEFT JOIN 
(
select * from (
select LVL,oc.id as OperatorId ,OC.Operator,cd.type from RetailerCOMMISSIOIN_DISTRIBUTION_DETAIL CD  right outer  JOIN OperatorCode OC ON OC.ID=CD.OperatorId 

) as T 
Pivot
(
Max(type)
for Lvl in ([1])
  )As Pivot1)
  
  tb2 ON tb2.operatorid=tb1.operatorid
LEFT JOIN 
(

select * from (
select LVL,oc.id as OperatorId ,OC.operator,changetype from RetailerCOMMISSIOIN_DISTRIBUTION_DETAIL CD  right outer  JOIN OperatorCode OC ON OC.ID=CD.OperatorId 

) as T 
Pivot
(
Max(changetype)
for Lvl in ([1])
  )As Pivot1
  )
  tb3 ON tb1.operatorid=tb3.operatorid  order by tb1.operatorid";
                dt = ObjData.RunDataTable(s2);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public DataTable getIReffOperator()
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = @"SELECT Operator,ltrim(rtrim(IReffOp)) as IReffOp FROM operatorcode WITH (nolock) WHERE IReffOp IS NOT null ORDER BY Operator";
                dt = ObjData.RunDataTable(s2);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public DataTable getNumberList()
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = @"SELECT * FROM numberlist WITH (nolock) ORDER BY Number";
                dt = ObjData.RunDataTable(s2);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public DataTable getIReffCircle()
        {
            DataTable dt = null;
            ObjData.StartConnection();
            ObjData.StartConnection();
            try
            {
                string s2 = @"SELECT DISTINCT circle,ltrim(rtrim(IReffCIrcle)) as IReffCIrcle  FROM userkhush.NumberList WITH (nolock) order by circle";
                dt = ObjData.RunDataTable(s2);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public string Insert_Number(clsRecharge objrecharge)
        {
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                s2 = "sp_add_NumberList";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@Number",objrecharge.Number), 
                new SqlParameter("@OperatorName",objrecharge.OperatorName), 
                new SqlParameter("@OperatorCode",objrecharge.OperatorCode), 
                new SqlParameter("@CircleName",objrecharge.CircleName), 
                new SqlParameter("@CircleCode",objrecharge.CircleCode)
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                tr.Commit();
            }
            catch (Exception ex)
            {
                res = "0";
                tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
                tr.Dispose();
            }
            return res;
        }


        public string Edit_Number(clsRecharge objrecharge)
        {
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                s2 = "sp_edit_NumberList";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@Number",objrecharge.Number), 
                new SqlParameter("@OperatorName",objrecharge.OperatorName), 
                new SqlParameter("@OperatorCode",objrecharge.OperatorCode), 
                new SqlParameter("@CircleName",objrecharge.CircleName), 
                new SqlParameter("@CircleCode",objrecharge.CircleCode)
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                tr.Commit();
            }
            catch (Exception ex)
            {
                res = "0";
                tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
                tr.Dispose();
            }
            return res;
        }

        public string Delete_Number(clsRecharge objrecharge)
        {
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                s2 = "sp_delete_NumberList";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@Number",objrecharge.Number), 
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                tr.Commit();
            }
            catch (Exception ex)
            {
                res = "0";
                tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
                tr.Dispose();
            }
            return res;
        }

        public int InsertRechargeCommission(string cmd)
        {
            int res = 0;
            ObjData.StartConnection();
            try
            {
                string s2 = "delete from COMMISSIOIN_DISTRIBUTION_DETAIL";
                ObjData.RunInsUpDelQuery(s2);
                ObjData.RunInsUpDelQuery(cmd);
                res = 1;
            }
            catch (Exception ex)
            {
                res = 0;
            }
            ObjData.EndConnection();
            return res;
        }


        public DataTable OperatorOpetion(string @OperatorCodeId)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "OpertorOption";
                SqlParameter[] parameter = { new SqlParameter("@OperatorCodeId", OperatorCodeId),
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

        public DataTable GetUserbal(string mobile)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_get_UserBal";
                SqlParameter[] parameter = { new SqlParameter("@mobile", mobile),
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
        public DataTable GetCheckValues(string Msg)
        {
            string str = Msg.Trim().Replace(",", " ").Replace(":", " ").Replace("<", " ").Replace(">", " ").Replace("/", " ").Replace("*", " ").Replace("  ", " ").Replace("  ", " ").Replace("|", " ").Replace("=", " ").Replace("\"", " ").Trim();
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_CheckTextResponse";
                SqlParameter[] parameter = { new SqlParameter("@Msg", str),
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
        public DataTable LastRechargeRecode(string Userid)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "LastTransactionIDRecode";
                SqlParameter[] parameter = { new SqlParameter("@Userid", Userid), };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public DataTable fillNumberList()
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "select nl.*,lo.PlanCode AS OperatorPlanCode,lc.PlanCode AS CirclePlanCode   from NumberList nl WITH (nolock)  LEFT JOIN lookupOpertorCode lo WITH (nolock) ON nl.operatorid=lo.OperatorCode LEFT JOIN LoopCircleCode lc WITH (nolock) ON nl.CircleCode=lc.Circleid";
                dt = ObjData.RunDataTable(s2);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }

        public DataTable GetAllOpertorSelectedByUser(string Userid)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = @"select convert(NVARCHAR(max),oc.Id)+'__'+isnull(oo.Option1Name,'0')+'__'+isnull(oo.Option2Name,'0')+'__'+isnull(oo.Option3Name,'0')+'__'+isnull(oo.Option4Name,'0')+'__'+isnull(oo.Displayalue1,'0')+'__'+isnull(oo.Displayalue2,'0')+'__'+isnull(oo.Displayalue3,'0')+'__'+isnull(oo.Displayalue4,'0') AS id
,oc.Operator,oc.OPID,oc.Type,oc.Length,oc.Minimum,oc.Maximum,oc.DisplayName,oc.DisplayNote,oc.EntryBy,oc.EtryDate,oc.AccountDisplay,oc.CustomerDisplay,oc.LocationDisplay,oc.LoctionId,oc.OperatorImage,
oc.StartsWith,oc.DisabledReasion,oc.IsDown,oc.BackupAPI,oc.PartialPay,oc.operatortype from OperatorCode oc 
LEFT JOIN OperatorOption oo ON oc.Id=oo.OperatorCodeId
order by oc.Operator";
                //string s2 = @"select oc.* from operatorcode order by oc.Operator";
                dt = ObjData.RunDataTable(s2);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public string checkvalidation(string TxtAmount, string TxtMobileNo, string DdlOpertor)
        {
            string Error = "Error";
            if (TxtMobileNo == "")
            {
                Error = "Please Enter Mobile No.";
            }
            else if (DdlOpertor == "Select Operator")
            {
                Error = "Please Select Operator.";

            }
            else if (TxtAmount == "")
            {
                Error = "Please Enter Amount";

            }
            else { return "success"; }
            return Error;
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
                else if (Type == "2")
                {
                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(new System.IO.StringReader(Resp));
                    reader.Read();

                    System.Data.DataSet ds = new System.Data.DataSet();
                    ds.ReadXml(reader, System.Data.XmlReadMode.Auto);
                    DataTable dt = ds.Tables[0];
                    return dt;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("status", typeof(string)));
                    dt.Columns.Add(new DataColumn("trans-no", typeof(string)));
                    dt.Columns.Add(new DataColumn("client-key", typeof(string)));
                    dt.Columns.Add(new DataColumn("rech-no", typeof(string)));
                    dt.Columns.Add(new DataColumn("amount", typeof(string)));
                    dt.Columns.Add(new DataColumn("opr-code", typeof(string)));
                    dt.Columns.Add(new DataColumn("success-operotor-id", typeof(string)));
                    dt.Columns.Add(new DataColumn("message", typeof(string)));
                    dt.Rows.Add(Resp.Split(',')[0].ToString(), Resp.Split(',')[1].ToString(), Resp.Split(',')[2].ToString(), Resp.Split(',')[3].ToString(), Resp.Split(',')[4].ToString(), Resp.Split(',')[5].ToString(), Resp.Split(',')[6].ToString(), Resp.Split(',')[7].ToString());
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

        public string checkvalidation(System.Web.UI.WebControls.TextBox TxtAmount, System.Web.UI.WebControls.TextBox TxtMobileNo, System.Web.UI.WebControls.DropDownList DdlOpertor)
        {
            string Error = "Error";
            if (TxtMobileNo.Text.Trim() == "")
            {
                Error = "Please Enter Mobile No.";
            }
            else if (DdlOpertor.SelectedItem.Text == "Select Operator")
            {
                Error = "Please Select Operator.";

            }
            else if (TxtAmount.Text.Trim() == "")
            {
                Error = "Please Enter Amount";

            }
            else { return "success"; }
            return Error;
        }
        public String InsertTransaction_Api_response(String TransactionId, int APIId, String URL, string Response)
        {
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                s2 = "sp_add_TRANSACTION_API_RESPONSES";
                SqlParameter[] parameter = {  
                new SqlParameter("@TransactionID", TransactionId),
                new SqlParameter("@APIId", APIId),
                new SqlParameter("@URL", URL),
                new SqlParameter("@Response", Response),
                };
                DataTable dtresult = new DataTable();
                dtresult = ObjData.RunDataTableProcedureTRans(s2, tr, parameter);
                res = dtresult.Rows[0][0].ToString();
                tr.Commit();
            }
            catch (Exception ex)
            {
                res = "Error: ";
                res += ex.Message;
                tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
                tr.Dispose();
            }
            return res;
        }


        private String _strRequest(string SDCode, string APCode, string OPCode, string SessionNo, string txtMobileNo, string account, string authenticator3, string amount)
        {
            ssl.CERTNo = ConfigurationManager.AppSettings["CERTNo"];
            StringBuilder _reqStr = new StringBuilder();
            #region Create Request
            _reqStr.Append("CERT=" + ssl.CERTNo + Environment.NewLine);
            _reqStr.Append("SD=" + SDCode + Environment.NewLine);
            _reqStr.Append("AP=" + APCode + Environment.NewLine);
            _reqStr.Append("OP=" + OPCode + Environment.NewLine);
            _reqStr.Append("SESSION=" + SessionNo + Environment.NewLine);
            _reqStr.Append("NUMBER=" + txtMobileNo + Environment.NewLine);
            _reqStr.Append("ACCOUNT=" + account + Environment.NewLine);
            _reqStr.Append("Authenticator3=" + authenticator3 + Environment.NewLine);
            _reqStr.Append("AMOUNT=" + amount + Environment.NewLine);
            _reqStr.Append("TERM_ID=" + APCode + Environment.NewLine);//Mostly value of TERM_ID=AP Code, but value may be vary.
            _reqStr.Append("COMMENT=test");
            #endregion
            return _reqStr.ToString();
        }
        public static DataTable convertStringToDataTable(string data)
        {
            DataTable dataTable = new DataTable();

            int StartIndex = data.IndexOf("BEGIN");
            int EndIndex = data.IndexOf("END");
            int length = EndIndex - StartIndex;
            data = data.Substring((StartIndex + 7), length - 7);
            data = data.Replace("\n", String.Empty);
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.Add(dataRow);
            foreach (string row in data.Split('\r'))
            {
                if (row != "")
                {
                    string[] keyValue = row.Split('=');
                    //if (!columnsAdded)
                    {
                        DataColumn dataColumn = new DataColumn(keyValue[0]);
                        dataTable.Columns.Add(dataColumn);
                    }
                    dataRow[keyValue[0]] = keyValue[1];
                    //}
                    //columnsAdded = true;
                    //dataTable.Rows.Add(dataRow);
                }
            }
            return dataTable;
        }
        public String InsertError(string ProcedureName, string ErrorRecieved, string BlockName, string ErrorCode = "", string Transaction_ID = "", string RStatus = "", string CStatus = "")
        {
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                s2 = "insertError";
                SqlParameter[] parameter = {  
               new SqlParameter("@ProcedureName", ProcedureName),
               new SqlParameter("@ErrorRecieved", ErrorRecieved),
               new SqlParameter("@BlockName", BlockName),
               new SqlParameter("@ErrorCode", ErrorCode),
               new SqlParameter("@Transaction_ID", Transaction_ID),
               new SqlParameter("@RStatus", RStatus),
               new SqlParameter("@CStatus", CStatus),
                };
                DataTable dtresult = new DataTable();
                dtresult = ObjData.RunDataTableProcedureTRans(s2, tr, parameter);
                res = dtresult.Rows[0][0].ToString();
                tr.Commit();
            }
            catch (Exception ex)
            {
                res = "Error: ";
                res += ex.Message;
                tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
                tr.Dispose();
            }
            return res;
        }
        public DataTable UpdateTransactionStatus(string url, string status, string Resp, string VenderId, string transactionid, string DeductionAmt, string UserId, string MobileNo, string msg, string LiveIdValue, int APIID)
        {

            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_UpdateTransactionStatus";
                SqlParameter[] parameter = {
                                               new SqlParameter("@Url", url),
                                               new SqlParameter("@Status", status),
                                               new SqlParameter("@Response", Resp.Trim()),
                                               new SqlParameter("@VenderId", VenderId),
                                               new SqlParameter("@TransactionID", dt.Rows[0][1].ToString()),
                                               new SqlParameter("@DeductionAmt", DeductionAmt),
                                               new SqlParameter("@UserId", UserId),
                                               new SqlParameter("@RechargeNo", MobileNo),
                                               new SqlParameter("@msg", msg),
                                               new SqlParameter("@LiveId", LiveIdValue),
                                                new SqlParameter("@APIID", APIID),
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
        public DataTable UpdateTransactionStatus1(string url, string status, string Resp, string VenderId, string transactionid, string DeductionAmt, string UserId, string MobileNo, string msg, string LiveIdValue, int APIID)
        {

            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_UpdateTransactionStatus";
                SqlParameter[] parameter = {
                                               new SqlParameter("@Url", url),
                                               new SqlParameter("@Status", status),
                                               new SqlParameter("@Response", Resp.Trim()),
                                               new SqlParameter("@VenderId", VenderId),
                                               new SqlParameter("@TransactionID", dt.Rows[0][1].ToString()),
                                               new SqlParameter("@DeductionAmt", DeductionAmt),
                                               new SqlParameter("@UserId", UserId),
                                               new SqlParameter("@RechargeNo", MobileNo),
                                               new SqlParameter("@msg", msg),
                                               new SqlParameter("@LiveId", LiveIdValue),
                                                new SqlParameter("@APIID", APIID),
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

        public string Recharge(string MobileNo, string Code, string Amount, string STD, string RechargeType, string UserId, out string TransactionID, out decimal Balance, out string Error1, string ip, out string RequestLiveID, string ApiRequestID = "")
        {
            int[] ErrorCode = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 
                                    27, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47,
                                    48, 50,51,52,53,54,55,56,57,81,82,83,84,85,86,87,88,89,224,333};

            //  Balance = 0;
            int APIID = 0;
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "Sp_Rechargeoperatortype";
                SqlParameter[] parameter = { 
                                                new SqlParameter("@RechargeNo", MobileNo.Trim()),
                                                new SqlParameter("@OpId", Code),
                                                new SqlParameter("@Amount", Amount.Trim()),
                                                new SqlParameter("@STD", STD),
                                                new SqlParameter("@RechargeType", RechargeType),
                                                new SqlParameter("@UserId", UserId),
                                                new SqlParameter("@ApiRequestID", ApiRequestID),
                                                new SqlParameter("@IP", ip),
                };
                ds = ObjData.RunDataSetProcedureTRans(s2, tr, parameter);
                DataTable dt = ds.Tables[0].Copy();
                string status = "1", Resp = "", LiveIdValue = "";
                if (dt.Rows[0][0].ToString() == "-1")
                {
                    Balance = 0;
                    TransactionID = "";
                    status = "0";
                    RequestLiveID = "";
                    Error1 = dt.Rows[0][1].ToString();
                    res = status;
                    return status;
                }
                else
                {
                    try
                    {
                        Balance = Convert.ToDecimal(dt.Rows[0]["Balance"].ToString());
                        string url = dt.Rows[0]["URL"].ToString();
                        string Type = dt.Rows[0]["Type"].ToString();
                        string StatusValue = dt.Rows[0]["StatusValue"].ToString();
                        string StatusName = dt.Rows[0]["StatusName"].ToString();
                        string VenderId = dt.Rows[0]["VenderId"].ToString();
                        string LiveId = dt.Rows[0]["LiveId"].ToString();
                        TransactionID = dt.Rows[0]["TransactionID"].ToString();
                        string DeductionAmt = dt.Rows[0]["DeductionAmt"].ToString();
                        string PartialPay = dt.Rows[0]["PartialPay"].ToString();
                        string ErrorMsg = dt.Rows[0]["ErrorMsg"].ToString();
                        APIID = Convert.ToInt32(dt.Rows[0]["Apiid"].ToString());
                        RequestLiveID = LiveId;
                        string flag = "0";
                        string msg = "";


                    lblRehit:
                        status = "1";
                        if (url.ToUpper().Contains("HTTP"))
                        {
                            if (url.ToUpper().Contains("HTTP") && APIID != 23)
                            {

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
                                                status = "0";
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
                                if (Type == "3" && status != "0")
                                {

                                    try
                                    {

                                        DataTable dtrespones = new DataTable();
                                        dtrespones = GetCheckValues(Resp);
                                        if (dtrespones.Rows.Count > 0)
                                        {
                                            if (dtrespones.Rows[0][0].ToString() == "No Match found")
                                            {
                                                status = "1";
                                            }
                                            else
                                            {
                                                status = dtrespones.Rows[0]["Status"].ToString();
                                                VenderId = dtrespones.Rows[0]["VendorID"].ToString();
                                                LiveIdValue = dtrespones.Rows[0]["OperatorId"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            status = "1";
                                        }
                                    }

                                    catch (SystemException ex)
                                    {

                                        InsertError("Block string match resend", ex.ToString(), "Last", "", TransactionID, "", "");
                                        status = "1";
                                    }
                                }

                                else if (status != "0")
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

                                                status = "2";
                                            }
                                            if (matchvalue == StsVal[1].Trim().ToUpper())
                                            {

                                                status = "0";
                                            }
                                        }
                                        if (columns.Contains(VenderId))
                                        {
                                            VenderId = dtResp.Rows[0][VenderId].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            VenderId = "";
                                        }
                                        if (columns.Contains(LiveId))
                                        {
                                            LiveIdValue = dtResp.Rows[0][LiveId].ToString().ToUpper();
                                        }
                                        if (columns.Contains(StsCol[0].Trim()))
                                        {
                                            string matchvalue = dtResp.Rows[0][StsCol[0].Trim()].ToString().ToUpper();
                                            if (matchvalue == StsVal[2].Trim().ToUpper())
                                            {

                                                status = "1";
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
                                                status = "0";

                                            }
                                            else if (StsCol.Length == 2)
                                            {
                                                if (dtResp.Columns.Contains(StsCol[StsCol.Length - 1]))
                                                {
                                                    status = "0";

                                                }

                                            }
                                        }


                                    }
                                    if (status == "")
                                    {
                                        status = "";
                                        status = "1";
                                    }
                                }
                                if (status == "0")
                                {

                                    if (ds.Tables.Count >= 2)
                                    {
                                        if (ds.Tables[1].Rows.Count > 0)
                                        {

                                            try
                                            {
                                                status = "1";

                                                InsertTransaction_Api_response(dt.Rows[0][1].ToString(), APIID, url, Resp.Trim());
                                            }
                                            catch (SystemException ex)
                                            {

                                                InsertError("Block 3", ex.ToString(), "Last", "", TransactionID, "", "");
                                            }
                                            url = ds.Tables[1].Rows[0]["URL"].ToString();
                                            StatusValue = ds.Tables[1].Rows[0]["StatusValue"].ToString();
                                            StatusName = ds.Tables[1].Rows[0]["StatusName"].ToString();
                                            ErrorMsg = ds.Tables[1].Rows[0]["ErrorMsg"].ToString();
                                            APIID = ds.Tables[1].Rows[0]["Apiid"].ToInt();
                                            VenderId = ds.Tables[1].Rows[0]["VenderId"].ToString();
                                            LiveId = ds.Tables[1].Rows[0]["LiveId"].ToString();
                                            Type = ds.Tables[1].Rows[0]["Type"].ToString();
                                            ds.Tables[1].Rows.RemoveAt(0);
                                            goto lblRehit;
                                        }
                                    }
                                }


                            }
                            else if (APIID == 23)
                            {
                                string CompleteResponse = string.Empty;
                                string CompleteRequest = string.Empty;
                                try
                                {
                                    string Request = string.Empty;


                                    string[] spliturl = dt.Rows[0][0].ToString().Split('|');
                                    int count = 0;
                                    foreach (string url1 in spliturl)
                                    {
                                        count += 1;
                                        string URL = url1.Trim();
                                        TransactionID = dt.Rows[0]["TransactionID"].ToString();
                                        if (Code == "TL" || Code == "TD")
                                            Request = _strRequest("326386", "331400", "331401", SessionNo, MobileNo, "2", "", Amount.ToString());
                                        else
                                            Request = _strRequest("326386", "331400", "331401", SessionNo, MobileNo, "", "", Amount.ToString());
                                        ssl.message = ssl.Sign_With_PFX(Request, keyPath, "gautam$3444");
                                        CompleteRequest += "Request:\r\n" + ssl.message + '|';
                                        ssl.htmlText = ssl.CallCryptoAPI(ssl.message, url1);
                                        Resp = "Response:\r\n" + ssl.htmlText;

                                        CompleteResponse += Resp + '|';
                                        DataTable ResPDt = convertStringToDataTable(Resp);
                                        if (ResPDt.Rows.Count > 0)
                                        {

                                            if (ResPDt.Rows[0]["ERROR"].ToString() == "0" || ResPDt.Rows[0]["ERROR"].ToString() == "36")
                                            {
                                                status = "2";
                                                //Sts = "SUCCESS";
                                            }
                                            else
                                            {
                                                bool has = ErrorCode.Contains(ResPDt.Rows[0]["ERROR"].ToString().ToInt());
                                                if (has == true && count < 3)
                                                {
                                                    status = "0";
                                                    break;
                                                    //if (has == true)
                                                    //{
                                                    //    DataTable dtPartial = new DataTable();
                                                    //    String Query = "Select PartialPay from OperatorCode where ID='" + Code + "'";
                                                    //    SqlDataAdapter da = new SqlDataAdapter(Query, Connection.ConnectionString);
                                                    //    da.Fill(dtPartial);
                                                    //    if (dtPartial.Rows.Count > 0)
                                                    //    {
                                                    //        if (dtPartial.Rows[0]["PartialPay"].ToString() == "N")
                                                    //        {
                                                    //            //LiveIdValue = ResPDt.Rows[0]["ERRMSG"].ToString();
                                                    //            status = "0";
                                                    //            //Sts = "FAILED";
                                                    //            break;
                                                    //        }
                                                    //        else if (dtPartial.Rows[0]["PartialPay"].ToString() == "Y" && count == 1)
                                                    //        {
                                                    //            status = "2";
                                                    //        }
                                                    //        else if (dtPartial.Rows[0]["PartialPay"].ToString() == "")
                                                    //        {
                                                    //            //LiveIdValue = ResPDt.Rows[0]["ERRMSG"].ToString();
                                                    //            status = "0";
                                                    //            //Sts = "FAILED";
                                                    //            break;
                                                    //        }
                                                    //        else
                                                    //        {
                                                    //            //LiveIdValue = ResPDt.Rows[0]["ERRMSG"].ToString();
                                                    //            status = "0";
                                                    //            //Sts = "FAILED";
                                                    //            break;
                                                    //        }
                                                    //    }
                                                    //}
                                                }
                                            }
                                        }
                                        if (ResPDt.Columns.Contains("TRANSID") && count == 2)
                                            VenderId = ResPDt.Rows[0]["TRANSID"].ToString();
                                        if (ResPDt.Columns.Contains("AUTHCODE") && count == 2)
                                            LiveIdValue = ResPDt.Rows[0]["AUTHCODE"].ToString();
                                        //}
                                        //else
                                        //{
                                        //    Sts = "FAILED";
                                        //    OperaterId = "Operator Disabled";
                                        //    System.Web.HttpContext.Current.Session["TRRANS"] = TransactionID;
                                        //}


                                    }
                                    CompleteResponse = CompleteResponse.Trim();
                                    CompleteResponse = CompleteResponse.Trim('|');
                                    CompleteRequest = CompleteRequest.Trim();
                                    CompleteRequest = CompleteRequest.Trim('|');

                                    Resp = "[" + CompleteRequest + "---" + CompleteResponse + "]";
                                }
                                catch (Exception ex)
                                {
                                    status = "0";
                                    Resp = "[" + CompleteRequest + "---" + CompleteResponse + "]";
                                    Balance = 0;
                                    RequestLiveID = "";
                                    TransactionID = "";
                                    Error1 = ex.ToString();
                                    //eko objeko = new eko();
                                    InsertError("Block 2", Error1, "Last", "", TransactionID, "", "");
                                }
                            }

                            else
                            {
                                status = "1";
                            }
                            if (msg.Contains("insufficient") == true)
                            {
                                Error1 = "System error found";
                            }
                            else
                            {
                                Error1 = msg;
                            }
                            //SqlParameter[] param1 = new SqlParameter[11];
                            //param1[0] = new SqlParameter("@Url", url);
                            //param1[1] = new SqlParameter("@Status", status);
                            //param1[2] = new SqlParameter("@Response", Resp.Trim());
                            //param1[3] = new SqlParameter("@VenderId", VenderId);
                            //param1[4] = new SqlParameter("@TransactionID", dt.Rows[0][1].ToString());
                            //param1[5] = new SqlParameter("@DeductionAmt", DeductionAmt);
                            //param1[6] = new SqlParameter("@UserId", UserId);
                            //param1[7] = new SqlParameter("@RechargeNo", MobileNo);
                            //param1[8] = new SqlParameter("@msg", msg);
                            //param1[9] = new SqlParameter("@LiveId", LiveIdValue);
                            //param1[10] = new SqlParameter("@APIID", APIID);
                            DataTable dttt = UpdateTransactionStatus(url, status, Resp.Trim(), VenderId, dt.Rows[0][1].ToString(), DeductionAmt, UserId, MobileNo, msg, LiveIdValue, APIID);
                            //string result = dttt.Rows[0][0].ToString();
                            res = status;
                            return status;
                        }

                        Error1 = status;
                        res = status;
                        return status;
                    }
                    catch (Exception ex)
                    {

                        Balance = 0;
                        RequestLiveID = "";
                        TransactionID = "";
                        Error1 = "Updation(04)";
                        //eko objeko = new eko();
                        InsertError("Block 1", ex.Message, "Last", "", TransactionID, "", "");
                        res = "Failed<font color='white'>:" + ex.Message + "</font>";
                        return "Failed<font color='white'>:" + ex.Message + "</font>";
                    }

                }
                tr.Commit();
            }
            catch (Exception ex)
            {
                Balance = 0;
                RequestLiveID = "";
                TransactionID = "";
                Error1 = "Updation(04)";
                res = ex.Message.ToString();
                tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
                tr.Dispose();
            }
            return res;
        }

        public string Recharge1(string MobileNo, string Code, string Amount, string STD, string RechargeType, string UserId, out string TransactionID, out decimal Balance, out string Error1, string ip, out string RequestLiveID, string option1 = "", string option2 = "", string option3 = "", string option4 = "", string ApiRequestID = "")
        {
            int[] ErrorCode = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 
                                    27, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47,
                                    48, 50,51,52,53,54,55,56,57,81,82,83,84,85,86,87,88,89,224,333};

            //  Balance = 0;
            ApiRequestID = "";
            int APIID = 0;
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "Sp_Rechargeoperatortype";
                SqlParameter[] parameter = { 
                                                new SqlParameter("@RechargeNo", MobileNo.Trim()),
                                                new SqlParameter("@OpId", Code),
                                                new SqlParameter("@Amount", Amount.Trim()),
                                                new SqlParameter("@STD", STD),
                                                new SqlParameter("@RechargeType", RechargeType),
                                                new SqlParameter("@UserId", UserId),
                                                new SqlParameter("@ApiRequestID", ApiRequestID),
                                                new SqlParameter("@IP", ip),
                                                new SqlParameter("@option1", option1),
                                                new SqlParameter("@option2", option2),
                                               new SqlParameter("@option3", option3),
                                               new SqlParameter("@option4", option4),
                };
                ds = ObjData.RunDataSetProcedureTRans(s2, tr, parameter);

                string status = "1", Resp = "", LiveIdValue = "";
                if (ds.Tables[0].Rows[0][0].ToString() == "-1")
                {
                    Balance = 0;
                    TransactionID = "";
                    status = "0";
                    RequestLiveID = "";
                    Error1 = ds.Tables[0].Rows[0][1].ToString();
                    return status;
                }
                else
                {
                    try
                    {
                        string CompleteResponse = string.Empty;
                        string CompleteRequest = string.Empty;
                        Balance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"].ToString());
                        string url = ds.Tables[0].Rows[0]["URL"].ToString();
                        string Type = ds.Tables[0].Rows[0]["Type"].ToString();
                        string StatusValue = ds.Tables[0].Rows[0]["StatusValue"].ToString();
                        string StatusName = ds.Tables[0].Rows[0]["StatusName"].ToString();
                        string VenderId = ds.Tables[0].Rows[0]["VenderId"].ToString();
                        string LiveId = ds.Tables[0].Rows[0]["LiveId"].ToString();
                        TransactionID = ds.Tables[0].Rows[0]["TransactionID"].ToString();
                        string DeductionAmt = ds.Tables[0].Rows[0]["DeductionAmt"].ToString();
                        string ErrorMsg = ds.Tables[0].Rows[0]["ErrorMsg"].ToString();
                        APIID = ds.Tables[0].Rows[0]["Apiid"].ToInt();
                        RequestLiveID = LiveId;
                        string flag = "0";
                        string msg = "";
                        if (url.ToUpper().Contains("HTTP"))
                        {

                            if (url.ToUpper().Contains("HTTP") && APIID != 23)
                            {


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
                                                status = "0";
                                                msg = errmsg[i];
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (status != "0")
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

                                                status = "2";
                                            }
                                        }
                                        if (columns.Contains(VenderId))
                                        {
                                            VenderId = dtResp.Rows[0][VenderId].ToString().ToUpper();
                                        }
                                        else
                                        {
                                            VenderId = "";
                                        }
                                        if (columns.Contains(LiveId))
                                        {
                                            LiveIdValue = dtResp.Rows[0][LiveId].ToString().ToUpper();
                                        }
                                        if (columns.Contains(StsCol[0].Trim()))
                                        {
                                            string matchvalue = dtResp.Rows[0][StsCol[0].Trim()].ToString().ToUpper();
                                            if (matchvalue == StsVal[2].Trim().ToUpper())
                                            {

                                                status = "1";
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
                                                status = "0";

                                            }
                                            else if (StsCol.Length == 2)
                                            {
                                                if (dtResp.Columns.Contains(StsCol[StsCol.Length - 1]))
                                                {
                                                    status = "0";

                                                }

                                            }
                                        }


                                    }
                                    if (status == "")
                                    {
                                        status = "";
                                        status = "1";
                                    }
                                }

                            }
                            else if (APIID == 23)
                            {
                                try
                                {
                                    string Request = string.Empty;


                                    string[] spliturl = ds.Tables[0].Rows[0][0].ToString().Split('|');
                                    int count = 0;
                                    foreach (string url1 in spliturl)
                                    {
                                        count += 1;
                                        string URL = url1.Trim();
                                        TransactionID = ds.Tables[0].Rows[0]["TransactionID"].ToString();
                                        if (Code == "RD" || Code == "TD")
                                            Request = _strRequest("326386", "331400", "331401", SessionNo, MobileNo, "2", "", Amount.ToString());
                                        else
                                            Request = _strRequest("326386", "331400", "331401", SessionNo, MobileNo, "", "", Amount.ToString());
                                        ssl.message = ssl.Sign_With_PFX(Request, keyPath, "gautam$3444");
                                        CompleteRequest += "Request:\r\n" + ssl.message + '|';
                                        ssl.htmlText = ssl.CallCryptoAPI(ssl.message, url1);
                                        Resp = "Response:\r\n" + ssl.htmlText;

                                        CompleteResponse += Resp + '|';
                                        DataTable ResPDt = convertStringToDataTable(Resp);
                                        if (ResPDt.Rows.Count > 0)
                                        {

                                            if (ResPDt.Rows[0]["ERROR"].ToString() == "0")
                                            {
                                                status = "2";
                                                //Sts = "SUCCESS";
                                            }
                                            else
                                            {
                                                bool has = ErrorCode.Contains(ResPDt.Rows[0]["ERROR"].ToString().ToInt());
                                                if (has == true && count < 3)
                                                {
                                                    status = "0";
                                                    break;
                                                    //if (has == true)
                                                    //{
                                                    //    DataTable dtPartial = new DataTable();
                                                    //    String Query = "Select PartialPay from OperatorCode where ID='" + Code + "'";
                                                    //    SqlDataAdapter da = new SqlDataAdapter(Query, Connection.ConnectionString);
                                                    //    da.Fill(dtPartial);
                                                    //    if (dtPartial.Rows.Count > 0)
                                                    //    {
                                                    //        if (dtPartial.Rows[0]["PartialPay"].ToString() == "N")
                                                    //        {
                                                    //            //LiveIdValue = ResPDt.Rows[0]["ERRMSG"].ToString();
                                                    //            status = "0";
                                                    //            //Sts = "FAILED";
                                                    //            break;
                                                    //        }
                                                    //        else if (dtPartial.Rows[0]["PartialPay"].ToString() == "Y" && count == 1)
                                                    //        {
                                                    //            status = "2";
                                                    //        }
                                                    //        else if (dtPartial.Rows[0]["PartialPay"].ToString() == "")
                                                    //        {
                                                    //            //LiveIdValue = ResPDt.Rows[0]["ERRMSG"].ToString();
                                                    //            status = "0";
                                                    //            //Sts = "FAILED";
                                                    //            break;
                                                    //        }
                                                    //        else
                                                    //        {
                                                    //            //LiveIdValue = ResPDt.Rows[0]["ERRMSG"].ToString();
                                                    //            status = "0";
                                                    //            //Sts = "FAILED";
                                                    //            break;
                                                    //        }
                                                    //    }
                                                    //}
                                                }
                                            }
                                        }
                                        if (ResPDt.Columns.Contains("TRANSID") && count == 2)
                                            VenderId = ResPDt.Rows[0]["TRANSID"].ToString();
                                        if (ResPDt.Columns.Contains("AUTHCODE") && count == 2)
                                            LiveIdValue = ResPDt.Rows[0]["AUTHCODE"].ToString();
                                        //}
                                        //else
                                        //{
                                        //    Sts = "FAILED";
                                        //    OperaterId = "Operator Disabled";
                                        //    System.Web.HttpContext.Current.Session["TRRANS"] = TransactionID;
                                        //}


                                    }
                                    CompleteResponse = CompleteResponse.Trim();
                                    CompleteResponse = CompleteResponse.Trim('|');
                                    CompleteRequest = CompleteRequest.Trim();
                                    CompleteRequest = CompleteRequest.Trim('|');
                                    Resp = "[" + CompleteRequest + "---" + CompleteResponse + "]";
                                }
                                catch (Exception ex)
                                {
                                    Resp = "[" + CompleteRequest + "---" + CompleteResponse + "]";
                                    status = "0";
                                    Balance = 0;
                                    RequestLiveID = "";
                                    TransactionID = "";
                                    Error1 = ex.ToString();

                                }
                            }

                            else
                            {
                                status = "1";
                            }
                            if (msg.Contains("insufficient") == true)
                            {
                                Error1 = "System error found";
                            }
                            else
                            {
                                Error1 = msg;
                            }
                            //SqlParameter[] param1 = new SqlParameter[11];
                            //param1[0] = new SqlParameter("@Url", url);
                            //param1[1] = new SqlParameter("@Status", status);
                            //param1[2] = new SqlParameter("@Response", Resp.Trim());
                            //param1[3] = new SqlParameter("@VenderId", VenderId);
                            //param1[4] = new SqlParameter("@TransactionID", ds.Tables[0].Rows[0][1].ToString());
                            //param1[5] = new SqlParameter("@DeductionAmt", DeductionAmt);
                            //param1[6] = new SqlParameter("@UserId", UserId);
                            //param1[7] = new SqlParameter("@RechargeNo", MobileNo);
                            //param1[8] = new SqlParameter("@msg", msg);
                            //param1[9] = new SqlParameter("@LiveId", LiveIdValue);
                            //param1[10] = new SqlParameter("@APIID", APIID);
                            DataTable dttt = UpdateTransactionStatus1(url, status, Resp.Trim(), VenderId, ds.Tables[0].Rows[0][1].ToString(), DeductionAmt, UserId, MobileNo, msg, LiveIdValue, APIID);
                            //string result = dttt.Rows[0][0].ToString();
                            return status;
                        } Error1 = status;
                        return status;
                    }
                    catch (Exception ex)
                    {
                        Balance = 0;
                        RequestLiveID = "";
                        TransactionID = "";
                        Error1 = ex.ToString();
                        return "Failed<font color='white'>1:" + ex.Message + "</font>";
                    }

                }

                tr.Commit();
            }
            catch (Exception ex)
            {
                Balance = 0;
                RequestLiveID = "";
                TransactionID = "";
                Error1 = "Updation(04)";
                res = ex.Message.ToString();
                tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
                tr.Dispose();
            }
            return res;
        }
        public DataTable RechargeNew(clsRecharge objrecharge)
        {
            string res = "";
            string s2 = "";
            SqlConnection cn;
            DataTable dtresult = new DataTable();
            ObjData.StartConnection();

            try
            {
                s2 = "sp_RechargeNew";
                SqlParameter[] parameter = {  
               new SqlParameter("@RechargeMobile", objrecharge.RechargeMobile) ,           
               new SqlParameter("@RechargeAmount", objrecharge.RechargeAmount) ,           
               new SqlParameter("@OperatorId", objrecharge.OperatorCode) ,           
               new SqlParameter("@UserMobile", objrecharge.UserMobile) ,           
               new SqlParameter("@IpAddress", objrecharge.IPAddress) ,           
               new SqlParameter("@EntryBy", objrecharge.EntryBy) ,           
               new SqlParameter("@RechargeType", objrecharge.RechargeType) ,           
               new SqlParameter("@optional1", objrecharge.Option1) ,           
               new SqlParameter("@optional2", objrecharge.Option2) ,           
               new SqlParameter("@optional3", objrecharge.Option3) ,           
               new SqlParameter("@optional4", objrecharge.Option4) ,           
               new SqlParameter("@DispalyValue1", objrecharge.DispalyValue1) ,           
               new SqlParameter("@DispalyValue2", objrecharge.DispalyValue2) ,           
               new SqlParameter("@DispalyValue3", objrecharge.DispalyValue3) ,           
               new SqlParameter("@DispalyValue4", objrecharge.DispalyValue4)   ,
               new SqlParameter("@UserType", objrecharge.UserType)   ,
               
                };

                dtresult = ObjData.RunDataTableProcedure(s2, parameter);
                string referenceid = dtresult.Rows[0]["referenceid"].ToString();
                string Resp = "";
               // string struseremail = dtresult.Rows[0]["email"].ToString();
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

            //    Resp = @"<NODES><STATUS>SUCCESS</STATUS><MOBILE>9005092800</MOBILE><AMOUNT>10</AMOUNT><RPID>18128125099800998</RPID><AGENTID>818350999</AGENTID><OPID>1072331478</OPID><BAL>980.56</BAL><MSG>Transaction successfully done!</MSG></NODES>";

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
                            if (StsVal.Length > 3)
                            {
                                if (matchvalue == StsVal[3].Trim().ToUpper())
                                {
                                    status = "Failed";
                                }
                                if (matchvalue == StsVal[4].Trim().ToUpper())
                                {
                                    if (matchvalue == "suspense")
                                    {
                                        status = "Pending";
                                    }
                                    else
                                    {
                                        status = "Failed";
                                    }
                                }
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
                        else
                            if (columns.Contains("message"))
                            {
                                msg = dtResp.Rows[0]["message"].ToString().ToUpper();
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
                    if (columns.Contains("txstatus_desc"))
                    {
                        if (dtResp.Rows[0]["txstatus_desc"].ToString().ToLower() == "pending")
                        {
                            status = "Pending";
                        }
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

                string str_messagesuccess = "";
                string str_img = "";
                if (status == "Failed")
                {
                    str_messagesuccess = "Recharge Request Failed. ";
                    str_img = "fail.png";
                }
                else
                {
                    str_messagesuccess = "Recharge Request Submitted Successfully. ";
                    str_img = "success.png";
                }

//                string str_body = @" <table style=""border:8px solid gainsboro;width:350px;"">
//        <tr>
//            <td><img src=""http://khushimobilejunction.com/images/logo.png"" style=""width:200px;"" /></td>
//        </tr>
//        <tr><td><h4 style=""padding:0px;margin:0px;"">" + str_messagesuccess + @"</h4></td></tr>
//         <tr><td><h3 style=""padding:0px;margin:0px;"">Rs. " + objrecharge.RechargeAmount.ToString() + @"<img src=""http://khushimobilejunction.com/images/" + str_img + @""" style=""height:15px;""  /></h3></td></tr>
//         <tr><td>Operator</td></tr>
//         <tr><td><h4 style=""padding:0px;margin:0px;"">" + objrecharge.OperatorName + @"<img src=""http://khushimobilejunction.com/Operatorimage/" + objrecharge.OperatorName + @".png""  /></h4></td></tr>
//         <tr><td>Mobile No</td></tr>
//         <tr><td><h4 style=""padding:0px;margin:0px;"">" + objrecharge.RechargeMobile + @"</h4></td></tr>
//          <tr><td>Date : " + Convert.ToDateTime(dtresult.Rows[0]["Trandate"].ToString()).ToString("dd/MM/yyyy hh:mm tt") + @"</td></tr>
//          <tr><td>Transaction Id : " + referenceid + @"</td></tr>
//          <tr><td><h4 style=""padding:0px;margin:0px;"">Your Updated Balance Amount  : " + dtresult.Rows[0]["newbalance"].ToString() + @"</h4></td></tr>
//    </table>";
               // ObjData.sendmail("Khushi Mobile Junction- Recharge", struseremail, str_body);
            }
            catch (Exception ex)
            {
                res = "Error: ";
                res += ex.Message;
                //tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
            }
            return dtresult;
        }
        public DataTable RechargeNewRetailer(clsRecharge objrecharge)
        {
            string res = "";
            string s2 = "";
            SqlConnection cn;
            DataTable dtresult = new DataTable();
            ObjData.StartConnection();

            try
            {
                s2 = "sp_RechargeNewRetailer";
                SqlParameter[] parameter = {  
               new SqlParameter("@RechargeMobile", objrecharge.RechargeMobile) ,           
               new SqlParameter("@RechargeAmount", objrecharge.RechargeAmount) ,           
               new SqlParameter("@OperatorId", objrecharge.OperatorCode) ,           
               new SqlParameter("@UserMobile", objrecharge.UserMobile) ,           
               new SqlParameter("@IpAddress", objrecharge.IPAddress) ,           
               new SqlParameter("@EntryBy", objrecharge.EntryBy) ,           
               new SqlParameter("@RechargeType", objrecharge.RechargeType) ,           
               new SqlParameter("@optional1", objrecharge.Option1) ,           
               new SqlParameter("@optional2", objrecharge.Option2) ,           
               new SqlParameter("@optional3", objrecharge.Option3) ,           
               new SqlParameter("@optional4", objrecharge.Option4) ,           
               new SqlParameter("@DispalyValue1", objrecharge.DispalyValue1) ,           
               new SqlParameter("@DispalyValue2", objrecharge.DispalyValue2) ,           
               new SqlParameter("@DispalyValue3", objrecharge.DispalyValue3) ,           
               new SqlParameter("@DispalyValue4", objrecharge.DispalyValue4) ,           
               new SqlParameter("@Usertype", objrecharge.UserType) ,           
                };

                dtresult = ObjData.RunDataTableProcedure(s2, parameter);
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

                //   Resp = @"<NODES><STATUS>FAILED</STATUS><MOBILE>8808852831</MOBILE><AMOUNT>20</AMOUNT><RPID></RPID><AGENTID>831105608</AGENTID><OPID></OPID><BAL>0</BAL><MSG>FAILED!! Invalid Choice of Oprater Number Belong To oprater-Vodafone</MSG></NODES>";

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
                    if (columns.Contains("txstatus_desc"))
                    {
                        if (dtResp.Rows[0]["txstatus_desc"].ToString().ToLower() == "pending")
                        {
                            status = "Pending";
                        }
                    }
                }



                s2 = "sp_update_RechargeRequestRetailer";
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
            catch (Exception ex)
            {
                res = "Error: ";
                res += ex.Message;
                //tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
            }
            return dtresult;
        }
        public DataTable InsertCallBackURL(string url)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_InsertCallbackUrl";
                SqlParameter[] parameter = { new SqlParameter("@Url", url),
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
        public DataTable GetRechargeUserType(string refId)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_RechargeUserType";
                SqlParameter[] parameter = {
                                               new SqlParameter("@ReferenceId", refId),
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
        public DataTable UpdateCallBackResponse(string refId, string LiveId, string status, string Message)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_update_Callback";
                SqlParameter[] parameter = {
                                               new SqlParameter("@ReferenceId", refId),
                                               new SqlParameter("@Liveid", LiveId),
                                               new SqlParameter("@status", status),
                                               new SqlParameter("@Message", Message),
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
        public DataTable UpdateCallBackResponseRetailer(string refId, string LiveId, string status, string Message)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_update_CallbackRetailer";
                SqlParameter[] parameter = {
                                               new SqlParameter("@ReferenceId", refId),
                                               new SqlParameter("@Liveid", LiveId),
                                               new SqlParameter("@status", status),
                                               new SqlParameter("@Message", Message),
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
        public DataTable UpdateRechargeStatusManual(string refId, string status, string entryby)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_UpdateStatusManual";
                SqlParameter[] parameter = {
                                               new SqlParameter("@ReferenceId", refId),
                                               new SqlParameter("@status", status),
                                               new SqlParameter("@EntryBy", entryby),
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
        public DataTable UpdateRechargeStatusManualRetailer(string refId, string status, string entryby)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_UpdateStatusManualRetailer";
                SqlParameter[] parameter = {
                                               new SqlParameter("@ReferenceId", refId),
                                               new SqlParameter("@status", status),
                                               new SqlParameter("@EntryBy", entryby),
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
        public DataTable UpdateDisputeStatus(string disputeid, string liveid, string remark, string status, string entryby)
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_UpdateDisputeStatus";
                SqlParameter[] parameter = {
                                               new SqlParameter("@DIsputeid", disputeid),
                                               new SqlParameter("@LiveId", liveid),
                                               new SqlParameter("@Remark", remark),
                                               new SqlParameter("@status", status),
                                               new SqlParameter("@EntryBy", entryby),
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


        public DataTable getRechargeReport(clsRecharge objrecharge)
        {
            string str_query = @"SELECT top 100 ud.Mobile,oc.Operator,  rq.UserMobile,ud.Username,rq.RechargeMobile,rq.RechargeAmount,
(SELECT isnull(sum(cramount),0)-isnull(sum(dramount),0) FROM  TransactionDetail td WITH (nolock) WHERE td.wallettype='MWallet' and id<=(SELECT isnull( max(id),0) FROM TransactionDetail td2 WHERE td2.TransactionId=rq.ReferenceId AND td2.userid=rq.UserMobile and td2.wallettype='MWallet') AND td.userid=rq.UserMobile) AS balanceamount
,rq.ReferenceId,rq.Status,rq.Message,rq.Entrydate FROM rechargerequest rq with (nolock) LEFT JOIN userdetail ud with (nolock) ON rq.UserMobile=ud.userid LEFT JOIN operatorcode oc WITH (nolock) ON oc.Id=rq.OperatorId where 1=1  ";


            if (objrecharge.FromDate != DateTime.MinValue && objrecharge.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(DATE, rq.entrydate  )  >= '" + objrecharge.FromDate.ToString("yyyy/MM/dd") + "'   and convert(DATE, rq.entrydate  )   <= '" + objrecharge.ToDate.ToString("yyyy/MM/dd") + "' ";
            }
            if (objrecharge.Name != "")
            {
                str_query += "  and ud.username like '%" + objrecharge.Name + "%' ";
            }
            if (objrecharge.UserMobile != "")
            {
                str_query += "  and ud.userid = '" + objrecharge.UserMobile + "' ";
            }
            if (objrecharge.RechargeMobile != "")
            {
                str_query += "  and rq.rechargemobile = '" + objrecharge.RechargeMobile + "' ";
            }
            if (objrecharge.ReferenceId != "")
            {
                str_query += "  and rq.ReferenceId = '" + objrecharge.ReferenceId + "' ";
            }
            if (objrecharge.ReferenceId != "")
            {
                str_query += "  and rq.ReferenceId = '" + objrecharge.ReferenceId + "' ";
            }
            //if (objrecharge.UserId != "")
            //{
            //    str_query += "  and rq.userid = '" + objrecharge.UserId + "' ";
            //}
             if (objrecharge.Status != "0")
            {
                str_query += "  and  rq.Status = '" + objrecharge.Status + "' ";
            }
           
            str_query += " order by rq.entrydate  desc";

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
        public DataTable getDIsputeReport(clsRecharge objRecharge)
        {
            string str_query = "SELECT dd.*,rq.UserMobile,rq.RechargeMobile,rq.RechargeAmount FROM DisputeDetail dd LEFT JOIN rechargerequest rq ON dd.ReferenceId=rq.ReferenceId where 1=1 ";


            if (objRecharge.FromDate != DateTime.MinValue && objRecharge.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(DATE, dd.entrydate  )  >= '" + objRecharge.FromDate.ToString("yyyy/MM/dd") + "'   and convert(DATE, dd.entrydate  )   <= '" + objRecharge.ToDate.ToString("yyyy/MM/dd") + "' ";
            }

            if (objRecharge.RechargeMobile != "")
            {
                str_query += "  and rq.RechargeMobile = '" + objRecharge.RechargeMobile + "' ";
            }
            if (objRecharge.UserMobile != "")
            {
                str_query += "  and rq.UserMobile = '" + objRecharge.UserMobile + "' ";
            }

            if (objRecharge.Status != "0")
            {
                str_query += "  and dd.status = '" + objRecharge.Status + "' ";
            }


            str_query += " order by dd.entrydate  desc";

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
