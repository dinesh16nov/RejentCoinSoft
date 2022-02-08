using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataTier;
using System.Data.SqlClient;

namespace BusinessLogicTier
{
    public class clsEPin
    {
        Data ObjData = new Data();
        public string EPinNo { get; set; }
        public string GenerateUserId { get; set; }
        public string UsedUserId { get; set; }
        public int NoOfEPins { get; set; }
        public string SMSStatus { get; set; }
        public string EPinStatus { get; set; }
        public string MentionBy { get; set; }
        public string PlanId { get; set; }
        public string PlanName { get; set; }
        public string AmountDollar { get; set; }
        public string ROIDays { get; set; }
        public string ROIAmount { get; set; }
        public string CappingAmountDollar { get; set; }
        public string CappingAmount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string RequestId { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string TransactionId { get; set; }
        public string PaymentGatewayRequest { get; set; }
        public string Response { get; set; }
        public string ResponseStatus { get; set; }

        public DataTable getEPin(clsEPin objEPin)
        {
            string str_query = "select em.*,pm.PlanName from EPinMaster  em  LEFT JOIN planmaster pm ON em.PlanId=pm.planid   where 1=1 ";
            if (objEPin.FromDate != DateTime.MinValue && objEPin.ToDate != DateTime.MinValue)
            {
                str_query += "  and em.mentiondate  >= '" + objEPin.FromDate + "'   and em.mentiondate   <= '" + objEPin.ToDate + "' ";
            }
            if (objEPin.EPinStatus != "0")
            {
                str_query += "  and em.epinstatus = '" + objEPin.EPinStatus + "' ";
            }
            if (objEPin.PlanId != "0")
            {
                str_query += "  and em.planid = '" + objEPin.PlanId + "' ";
            }
            if (objEPin.GenerateUserId != "")
            {
                str_query += "  and em.GenerateUserId = '" + objEPin.GenerateUserId + "' ";
            }
            if (objEPin.UsedUserId != "")
            {
                str_query += "  and em.UsedUserId = '" + objEPin.UsedUserId + "' ";
            }

            str_query += " order by em.mentiondate  desc";



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
        public DataTable getEPinSubadmin(clsEPin objEPin)
        {
            string str_query = "select em.*,pm.PlanName from EPinMaster  em  LEFT JOIN planmaster pm ON em.PlanId=pm.planid   where 1=1 and e.userid!='INDIA01' ";
            if (objEPin.FromDate != DateTime.MinValue && objEPin.ToDate != DateTime.MinValue)
            {
                str_query += "  and em.mentiondate  >= '" + objEPin.FromDate + "'   and em.mentiondate   <= '" + objEPin.ToDate + "' ";
            }
            if (objEPin.EPinStatus != "0")
            {
                str_query += "  and em.epinstatus = '" + objEPin.EPinStatus + "' ";
            }
            if (objEPin.PlanId != "0")
            {
                str_query += "  and em.planid = '" + objEPin.PlanId + "' ";
            }
            if (objEPin.GenerateUserId != "")
            {
                str_query += "  and em.GenerateUserId = '" + objEPin.GenerateUserId + "' ";
            }
            if (objEPin.UsedUserId != "")
            {
                str_query += "  and em.UsedUserId = '" + objEPin.UsedUserId + "' ";
            }

            str_query += " order by em.mentiondate  desc";

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
        public DataTable getEPinTransferReport(clsEPin objEPin)
        {
            string str_query = "select em.* from EPinTransferHistory  em   where 1=1 ";


            if (objEPin.FromDate != DateTime.MinValue && objEPin.ToDate != DateTime.MinValue)
            {
                str_query += "  and em.mentiondate  >= '" + objEPin.FromDate + "'   and em.mentiondate   <= '" + objEPin.ToDate + "' ";
            }


            if (objEPin.GenerateUserId != "")
            {
                str_query += "  and em.UserIdFrom = '" + objEPin.GenerateUserId + "' ";
            }

            if (objEPin.UsedUserId != "")
            {
                str_query += "  and em.UserIdTo = '" + objEPin.UsedUserId + "' ";
            }

            str_query += " order by em.mentiondate  desc";



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

        public DataTable getEPinTransferReportSubadmin(clsEPin objEPin)
        {
            string str_query = "select em.* from EPinTransferHistory  em   where 1=1 and userid!='INDIA01' ";


            if (objEPin.FromDate != DateTime.MinValue && objEPin.ToDate != DateTime.MinValue)
            {
                str_query += "  and em.mentiondate  >= '" + objEPin.FromDate + "'   and em.mentiondate   <= '" + objEPin.ToDate + "' ";
            }


            if (objEPin.GenerateUserId != "")
            {
                str_query += "  and em.UserIdFrom = '" + objEPin.GenerateUserId + "' ";
            }

            if (objEPin.UsedUserId != "")
            {
                str_query += "  and em.UserIdTo = '" + objEPin.UsedUserId + "' ";
            }

            str_query += " order by em.mentiondate  desc";



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

        public DataTable getEPinRequest(clsEPin objEPin)
        {
            string str_query = "select em.*,pm.planname from EPinRequest  em  left join PlanMaster pm on em.PlanId=pm.PlanId where 1=1 ";


            if (objEPin.FromDate != DateTime.MinValue && objEPin.ToDate != DateTime.MinValue)
            {
                str_query += "  and em.mentiondate  >= '" + objEPin.FromDate + "'   and em.mentiondate   <= '" + objEPin.ToDate + "' ";
            }



            if (objEPin.EPinStatus != "0")
            {
                str_query += "  and em.status = '" + objEPin.EPinStatus + "' ";
            }

            if (objEPin.GenerateUserId != "")
            {
                str_query += "  and em.UserId = '" + objEPin.GenerateUserId + "' ";
            }


            str_query += " order by em.mentiondate  desc";



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
        public DataTable getPlan()
        {
            string str_query = "SELECT *,planname+'('+convert(NVARCHAR,amount)+')' AS planname2 FROM PlanMaster ";



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
        public DataTable getPlanUser()
        {
            string str_query = "SELECT *,planname+'('+convert(NVARCHAR,amount)+')' AS planname2 FROM PlanMaster with (nolock) where amount>0 ";
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
        public DataTable getPlanJoining()
        {
            string str_query = "SELECT *,planname+'('+convert(NVARCHAR,amount)+')' AS planname2 FROM PlanMaster with (nolock) where Plantype='Joining' ";



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
        public DataTable getPlanTopup()
        {
            string str_query = "SELECT *,planname+'('+convert(NVARCHAR,amount)+')' AS planname2 FROM PlanMaster with (nolock) where Plantype='Topup' and status='1' ";



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
        public DataTable getPlanTopup2()
        {
            string str_query = "SELECT *,planname+'('+convert(NVARCHAR,amount)+')' AS planname2 FROM PlanMaster with (nolock) where Plantype='Topup' and amount>0  and status='1' ";



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
        public DataTable getPlanDetail(clsEPin objepin)
        {
            string str_query = "SELECT * FROM PlanMaster where planid="+objepin.PlanId+" ";
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
        public DataTable getEPinForReg(clsEPin objEPin)
        {
            string str_query = "select * from EPinMaster where  GenerateUserId = '" + objEPin.GenerateUserId + "' and EpinStatus='Active' and planid='"+objEPin.PlanId+"'  ";
            str_query += " order by mentiondate  desc";



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
        public DataTable getEPinFullDetail(clsEPin objEPin)
        {
            string str_query = "select * from EPinMaster where  epinno = '" + objEPin.EPinNo + "'  ";
            str_query += " order by mentiondate  desc";
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
        public DataTable getTotalAvailableEPin(clsEPin objEPin)
        {
            string str_query = "select count(*) from EPinMaster with (nolock) where  GenerateUserId = '" + objEPin.GenerateUserId + "' and planid="+objEPin.PlanId+"  and EpinStatus='Active'  ";

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
        public string Insert_Plan(clsEPin objEPin)
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
                s2 = "sp_add_PlanMaster";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@PlanName",objEPin.PlanName), 
                new SqlParameter("@Amount",objEPin.Amount), 
                new SqlParameter("@AmountDollar",objEPin.AmountDollar), 
                new SqlParameter("@ROIAmount",objEPin.ROIAmount),
                new SqlParameter("@ROIDays",objEPin.ROIDays),
                new SqlParameter("@CappingAmount",objEPin.CappingAmount),
                new SqlParameter("@CappingAmountDollar",objEPin.CappingAmountDollar),
                new SqlParameter("@MentionBy ",objEPin.MentionBy),
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
        public string Insert_EPin(clsEPin objEPin)
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
                s2 = "sp_add_EPinMaster";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@NoOfEPin",objEPin.NoOfEPins), 
                new SqlParameter("@GenerateUserId",objEPin.GenerateUserId), 
                new SqlParameter("@Amount",objEPin.Amount), 
                new SqlParameter("@MentionBy",objEPin.MentionBy),
                new SqlParameter("@PlanId",objEPin.PlanId),
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
        public string Insert_EPinUser(clsEPin objEPin)
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
                s2 = "sp_add_EPinMasterUser";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@NoOfEPin",objEPin.NoOfEPins), 
                new SqlParameter("@GenerateUserId",objEPin.GenerateUserId), 
                new SqlParameter("@Amount",objEPin.Amount), 
                new SqlParameter("@MentionBy",objEPin.MentionBy),
                new SqlParameter("@planid",objEPin.PlanId)
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

        public string Insert_EPinRequest(clsEPin objEPin)
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
                s2 = "sp_addEPinRequest";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@UserId",objEPin.GenerateUserId), 
                new SqlParameter("@NoOfPin",objEPin.NoOfEPins), 
                new SqlParameter("@Amount",objEPin.Amount), 
                new SqlParameter("@MentionBy",objEPin.MentionBy)
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
        public string Insert_EPinGenerateOnline(clsEPin objEPin)
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
                s2 = "sp_add_PaymentGatewayRequest";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@TransactionId",objEPin.TransactionId), 
                new SqlParameter("@UserId",objEPin.GenerateUserId), 
                new SqlParameter("@Amount",objEPin.TotalAmount), 
                new SqlParameter("@NoOfEPin",objEPin.NoOfEPins), 
                new SqlParameter("@EpinAmount",objEPin.Amount), 
                new SqlParameter("@Request",objEPin.PaymentGatewayRequest), 
                new SqlParameter("@MentionBy",objEPin.MentionBy)
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
        public string Update_EPinGenerateOnlineResponse(clsEPin objEPin)
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
                s2 = "sp_Update_PaymentGatewayRequest";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@TransactionId",objEPin.TransactionId), 
                new SqlParameter("@Response",objEPin.Response), 
                new SqlParameter("@ResponseStatus",objEPin.ResponseStatus), 
                new SqlParameter("@MentionBy",objEPin.MentionBy), 
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

        public string Approve_EPinRequest(clsEPin objEPin)
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
                s2 = "sp_Approve_EPinMaster";
                SqlParameter[] parameter = {
                new SqlParameter("@RequestId",objEPin.RequestId),                              
                new SqlParameter("@GenerateUserId",objEPin.GenerateUserId), 
                new SqlParameter("@NoOfEPin",objEPin.NoOfEPins), 
                new SqlParameter("@Amount",objEPin.Amount), 
                new SqlParameter("@MentionBy",objEPin.MentionBy)
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
    }
}
