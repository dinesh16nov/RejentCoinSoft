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
    public class clsLogin
    {
        Data ObjData = new Data();

        public string username { get; set; }
        public string password { get; set; }
        public string pin { get; set; }
        public string IpAddress { get; set; }
        public string newpassword { get; set; }
        //public DataTable Chk_AdminLoginDetails(clsLogin objlogin)
        //{
        //    string str_query = "";
        //    DataTable dt = null;
        //    ObjData.StartConnection();
        //    try
        //    {
        //        str_query = "select *,(select top 1 CareEmail from CompanySettingDetail with (nolock) ) as adminemail from LoginDetail  with (nolock)  where username=@username and password=@password and role='Administrator' and status='1'  ";
        //        SqlParameter[] parameter = {   
        //        new SqlParameter("@username", objlogin.username),
        //        new SqlParameter("@password", objlogin.password)
        //        };

        //        dt = ObjData.RunDataTableParam(str_query, parameter);

        //        ObjData.SendEmail("Team Rijent-New Login Attempt FOr admin", "New Login attempt for login . Ip Address : "+objlogin.IpAddress, dt.Rows[0]["adminemail"].ToString());
        //        ObjData.SendEmail("Team Rijent-New Login Attempt FOr admin", "New Login attempt for login . Ip Address : "+objlogin.IpAddress, dt.Rows[0]["adminemail"].ToString());


        //    }
        //    catch (Exception ex)
        //    {
        //        dt = null;
        //    }
        //    ObjData.EndConnection();
        //    return dt;
        //}




        public DataTable Chk_AdminLoginDetails(clsLogin objlogin)
        {
            string str_query = "sp_TransactionRc";
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                SqlParameter[] parameter = {
                new SqlParameter("@username", objlogin.username),
                new SqlParameter("@password", objlogin.password),
                new SqlParameter("@ipaddress", objlogin.IpAddress),
                };

                dt = ObjData.RunDataTableProcedure(str_query, parameter);
                if (dt != null)
                {

                ObjData.SendEmail("Team Rijent-New Login Attempt FOr admin", "New Login attempt for login . Ip Address : " + objlogin.IpAddress, dt.Rows[0]["adminemail"].ToString());
                }
                     

            }
            catch (Exception ex)
            {
                dt = null;
                //throw ex;
            }

            ObjData.EndConnection();
            return dt;
        }
        public DataTable Chk_SubadminLoginDetails(clsLogin objlogin)
        {
            string str_query = "";
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                str_query = "select * from LoginDetail with (nolock)  where username=@username and password=@password and role='Subadmin' and status='1'  ";
                SqlParameter[] parameter = {   
                new SqlParameter("@username", objlogin.username),
                new SqlParameter("@password", objlogin.password)
                };

                dt = ObjData.RunDataTableParam(str_query, parameter);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }

        public DataTable Chk_UserLoginDetails(clsLogin objlogin)
        {

            string str_query = "sp_UserLogin";
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                SqlParameter[] parameter = {   
                new SqlParameter("@username", objlogin.username),
                new SqlParameter("@password", objlogin.password),
                new SqlParameter("@ipaddress", objlogin.IpAddress),
                };

                dt = ObjData.RunDataTableProcedure(str_query, parameter);

            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public DataTable Chk_FranchiseLoginDetails(clsLogin objlogin)
        {

            string str_query = "sp_FranchiseLogin";
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                SqlParameter[] parameter = {   
                new SqlParameter("@username", objlogin.username),
                new SqlParameter("@password", objlogin.password)
                };

                dt = ObjData.RunDataTableProcedure(str_query, parameter);

            }
            catch (Exception ex)
            {
                dt = null;
            }
            ObjData.EndConnection();
            return dt;
        }
        public string ChangeAdminPassword(clsLogin objlogin)
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
                s2 = "sp_ChangeAdminPassword";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@Username",objlogin.username), 
                new SqlParameter("@Oldpassword",objlogin.password), 
                new SqlParameter("@NewPassword",objlogin.newpassword)
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

        public string SetPasswordLogin(clsLogin objlogin)
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
                s2 = "SetPasswordLogin";
                SqlParameter[] parameter = {
                new SqlParameter("@Username",objlogin.username),
                new SqlParameter("@password",objlogin.password),
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
        public string ChangeUserPassword(clsLogin objlogin)
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
                s2 = "sp_ChangeUserPassword";
                SqlParameter[] parameter = {
                   new SqlParameter("@Username",objlogin.username),
                new SqlParameter("@Oldpassword",objlogin.password),
                new SqlParameter("@NewPassword",objlogin.newpassword)
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

        //public int ChangeAdminPassword(clsLogin objlogin)
        //{
        //    int i = 0;
        //    string s2 = "";
        //    SqlConnection cn;
        //    SqlTransaction tr = null;
        //    DataSet ds = new DataSet();
        //    cn = ObjData.StartConnectionInTransaction();
        //    tr = cn.BeginTransaction(IsolationLevel.Serializable);

        //    try
        //    {

        //        ds = ObjData.RunSelectQueryTrans("select * from LoginDetail where username='" + objlogin.username + "' and password ='" + objlogin.password + "' and  role='Administrator' ", tr);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            s2 = " update LoginDetail set password='" + objlogin.newpassword + "' where username='" + objlogin.username + "' and password ='" + objlogin.password + "' ";
        //            ObjData.RunInsUpDelQueryTrans(s2, tr);
        //            i = 1;
        //        }
        //        else
        //        {
        //            i = 2;
        //        }

        //        tr.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        i = 0;
        //        tr.Rollback();
        //    }
        //    finally
        //    {
        //        ObjData.EndConnection();
        //        tr.Dispose();
        //    }
        //    return i;
        //}

        //public int ChangeUserPassword(clsLogin objlogin)
        //{
        //    int i = 0;
        //    string s2 = "";
        //    SqlConnection cn;
        //    SqlTransaction tr = null;
        //    DataSet ds = new DataSet();
        //    cn = ObjData.StartConnectionInTransaction();
        //    tr = cn.BeginTransaction(IsolationLevel.Serializable);

        //    try
        //    {

        //        ds = ObjData.RunSelectQueryTrans("select * from LoginDetailsetPRoc with (nolock) where username='" + objlogin.username + "' and password ='" + objlogin.password + "' and  role='User' ", tr);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            s2 = " update LoginDetail set password='" + objlogin.newpassword + "' where username='" + objlogin.username + "' and password ='" + objlogin.password + "' ";
        //            ObjData.RunInsUpDelQueryTrans(s2, tr);
        //            i = 1;
        //        }
        //        else
        //        {
        //            i = 2;
        //        }

        //        tr.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        i = 0;
        //        tr.Rollback();
        //    }
        //    finally
        //    {
        //        ObjData.EndConnection();
        //        tr.Dispose();
        //    }
        //    return i;
        //}

    }
}
