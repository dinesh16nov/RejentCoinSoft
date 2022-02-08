using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicTier
{
    public class clsClosing
    {
        Data ObjData = new Data();
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string MentionBy { get; set; }
        public decimal ROIPercent { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public DataSet getStartDate()
        {
            string str_query = "SELECT dateadd(dd,1, max (closingdate)) as End_Date FROM ClosingDateDetail;SELECT convert(varchar,min(mentiondate),103) AS Start_Date FROM userdetail";
            DataSet ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunSelectQuery(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }
        public DataSet getROIStartDate()
        {
            string str_query = "SELECT dateadd(dd,1, max (closingdate)) as End_Date FROM ROiDateDetail;SELECT convert(varchar,min(mentiondate),103) AS Start_Date FROM userdetail";
            DataSet ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunSelectQuery(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }
        public DataSet getTradingROIStartDate()
        {
            string str_query = "SELECT dateadd(dd,1, max (closingdate)) as End_Date FROM TradingROiDateDetail;SELECT convert(varchar,min(mentiondate),103) AS Start_Date FROM userdetail";
            DataSet ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunSelectQuery(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }

        public DataSet getDirectROIStartDate()
        {
            string str_query = "SELECT dateadd(dd,1, max (closingdate)) as End_Date FROM DirectROIDateDetail;SELECT convert(varchar,min(mentiondate),103) AS Start_Date FROM userdetail";
            DataSet ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunSelectQuery(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }

        public DataTable getClosingPeriod()
        {
            string str_query = "select *, convert(nvarchar, fromdate,103)+'-'+convert(nvarchar, todate,103) as closingperiod from   ClosingDateDetail ";
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
        public DataTable getRewardClosingPeriod()
        {
            string str_query = "select *, convert(nvarchar, fromdate,103)+'-'+convert(nvarchar, todate,103) as closingperiod from   RewardClosingDateDetail ";
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
        public DataTable getClosingPeriodReverse()
        {
            string str_query = "SELECT top 1  *, convert(nvarchar, fromdate,103)+'-'+convert(nvarchar, todate,103) as closingperiod from   ClosingDateDetail ORDER BY  fromdate desc";
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
        public DataTable getClosingReport(clsClosing objclosing)
        {
            string str_query = "select cd.*,ud.username,ud.AccountHolderName,ud.AccountNo,ud.IFSCCode,ud.BankName,ud.BranchName,ud.PanNumber from ClosingDetail  cd left join userdetail ud on cd.userid=ud.userid where 1=1  ";

            if (objclosing.FromDate != DateTime.MinValue && objclosing.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert (date, cd.fromdate)  >= convert (date,'" + objclosing.FromDate + "')   and convert (date,cd.todate )  <= convert (date,'" + objclosing.ToDate + "' )";
            }
            if (objclosing.UserId != "")
            {
                str_query += "  and cd.userid = '" + objclosing.UserId + "' ";
            }
            str_query += " order by cd.userid  desc";

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
        public string GenerateClosing(clsClosing objclosing)
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
                s2 = "sp_generateclosing";
                SqlParameter[] parameter = {                                              
              //  new SqlParameter("@closingdate",objclosing.FromDate)
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                tr.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
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
        public string GenerateClosingROI(clsClosing objclosing)
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
                s2 = "sp_generateROI";
                SqlParameter[] parameter = {
                new SqlParameter("@closingdate",objclosing.FromDate),
                new SqlParameter("@ROIPercent",objclosing.ROIPercent),
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                tr.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
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
        public string GenerateClosingTradingROI(clsClosing objclosing)
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
                s2 = "sp_generateTradingROI";
                SqlParameter[] parameter = {
                new SqlParameter("@closingdate",objclosing.FromDate),
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                tr.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
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
        public string GenerateClosingDirectROI(clsClosing objclosing)
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
                s2 = "sp_generateDirectROI";
                SqlParameter[] parameter = {
                new SqlParameter("@closingdate",objclosing.FromDate)
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                tr.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
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
        public string ReverseClosing(clsClosing objclosing)
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
                s2 = "sp_reverseclosing";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@fromdate",objclosing.FromDate), 
                new SqlParameter("@todate",objclosing.ToDate)
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
