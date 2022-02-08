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
    public class clsState
    {
        Data ObjData = new Data();
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string StateId { get; set; }
        public string StateName { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public string Pincode { get; set; }
        public string MentionBy { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime HolidayDate { get; set; }
        public DataTable getCountry()
        {
            string str_query = "select * from CountryMaster order by CountryName";

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
        public DataTable getHoliday()
        {
            string str_query = "select * from Holidaymaster order by Holidaydate";

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
        public DataTable getStateAll()
        {
            string str_query = "select sm.*,cm.countryname from StateMaster sm left join countrymaster cm on sm.countryid=cm.countryid  order by StateName,cm.countryname";

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
        public DataTable getState(clsState objstate)
        {
            string str_query = "select sm.*,cm.countryname from StateMaster sm left join countrymaster cm on sm.countryid=cm.countryid where sm.countryid="+objstate.CountryId+" order by StateName,cm.countryname";

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
        public DataTable getCityAll()
        {
            string str_query = "select cm.*, sm.statename,cm2.countryname from citymaster cm  left join statemaster sm on cm.stateid=sm.stateid  left join countrymaster cm2 on sm.countryid=cm2.countryid   order by sm.statename,cm.cityname,cm2.countryname";

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
        public DataTable getCity(clsState objstate)
        {
            string str_query = "select cm.*, sm.statename from citymaster cm  left join statemaster sm on cm.stateid=sm.stateid where cm.StateId= '" + objstate.StateId + "'  order by sm.statename,cm.cityname";

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
        public DataTable getAreaAll()
        {
            string str_query = "select am.*, cm.cityname, sm.statename,cm2.countryname from areamaster am left join  citymaster cm  on cm.cityid=am.cityid left join statemaster sm on cm.stateid=sm.stateid  left join countrymaster cm2 on sm.countryid=cm2.countryid   order by cm2.countryname,sm.statename,cm.cityname,am.areaname";

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
        public DataTable getArea(clsState objstate)
        {
            string str_query = "select am.*, cm.cityname, sm.statename,cm2.countryname from areamaster am left join  citymaster cm  on cm.cityid=am.cityid left join statemaster sm on cm.stateid=sm.stateid  left join countrymaster cm2 on sm.countryid=cm2.countryid    where am.cityid= '" + objstate.CityId + "'  order by sm.statename,cm.cityname,am.areaname";

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
        public string Insert_Country(clsState objState)
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
                s2 = "sp_add_CountryMaster";
                SqlParameter[] parameter = {  
                new SqlParameter("@CountryName",objState.CountryName), 
                new SqlParameter("@MentionBy",objState.MentionBy)
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
        public string Update_Country(clsState objState)
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
                s2 = "update CountryMaster set countryname='" + objState.CountryName + "' where countryid='" + objState.CountryId + "'";

                ObjData.RunInsUpDelQueryTrans(s2, tr);
                res = "t";
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
        public string Insert_State(clsState objState)
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
                s2 = "sp_add_State";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@CountryId",objState.CountryId), 
                new SqlParameter("@StateName",objState.StateName), 
                new SqlParameter("@MentionBy",objState.MentionBy)
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

        public string Update_State(clsState objState)
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
                s2 = "update statemaster set statename='"+objState.StateName+"' where stateid='"+objState.StateId+"'";
              
                ObjData.RunInsUpDelQueryTrans(s2, tr);
                res = "t";
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


        public string Insert_City(clsState objState)
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
                s2 = "sp_add_City";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@StateId",objState.StateId), 
                new SqlParameter("@CityName",objState.CityName), 
                new SqlParameter("@MentionBy",objState.MentionBy)
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

        public string Update_City(clsState objState)
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
                s2 = "update citymaster set cityname='" + objState.CityName + "' where cityid='" + objState.CityId + "'";

                ObjData.RunInsUpDelQueryTrans(s2, tr);
                res = "t";
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
        public string Insert_Area(clsState objState)
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
                s2 = "sp_add_AreaMaster";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@CityId",objState.CityId), 
                new SqlParameter("@AreaName",objState.AreaName), 
                new SqlParameter("@Pincode",objState.Pincode), 
                new SqlParameter("@MentionBy",objState.MentionBy)
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
        public string Update_Area(clsState objState)
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
                s2 = "update areamaster set areaname='" + objState.AreaName + "',pincode='"+objState.Pincode+"' where areaid='" + objState.AreaId + "'";
                ObjData.RunInsUpDelQueryTrans(s2, tr);
                res = "t";
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

        public string Insert_Holiday(clsState objState)
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
                s2 = "sp_add_HolidayMaster";
                SqlParameter[] parameter = {  
                new SqlParameter("@Title",objState.Title), 
                new SqlParameter("@HolidayDate",objState.HolidayDate), 
                new SqlParameter("@MentionBy",objState.MentionBy)
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
        public string Edit_Holiday(clsState objState)
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
                s2 = "sp_edit_HolidayMaster";
                SqlParameter[] parameter = {  
                new SqlParameter("@Title",objState.Title), 
                new SqlParameter("@HolidayDate",objState.HolidayDate), 
                new SqlParameter("@id",objState.Id)
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
        public string Delete_Holiday(clsState objState)
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
                s2 = "sp_delete_HolidayMaster";
                SqlParameter[] parameter = {   
                new SqlParameter("@id",objState.Id)
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
