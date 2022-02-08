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
    public class clsProduct
    {
        Data ObjData = new Data();
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductAmount { get; set; }
        public decimal JoiningPV { get; set; }
        public decimal RepurchasePV { get; set; }

        public string PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal CappingAmount { get; set; }
        public decimal MinPV { get; set; }
        public decimal MaxPV { get; set; }
        public string MentionBy { get; set; }
        public DataTable getProduct()
        {
            string str_query = "select * from ProductMaster order by ProductName";

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
        public DataTable getProductDetail(clsProduct objproduct)
        {
            string str_query = "select * from ProductMaster where productid="+objproduct.ProductId+" order by ProductName";

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
        public DataTable getPackage()
        {
            string str_query = "select *,packagename+'('+convert(NVARCHAR,minpv)+'-'+convert(NVARCHAR,maxpv)+')' AS packagename2 from PackageMaster order by minpv";

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
        public string Insert_Product(clsProduct objproduct)
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
                s2 = "sp_add_ProductMaster";
                SqlParameter[] parameter = {  
                new SqlParameter("@ProductName",objproduct.ProductName), 
                new SqlParameter("@ProductAmount",objproduct.ProductAmount), 
                new SqlParameter("@JoiningPV",objproduct.JoiningPV), 
                new SqlParameter("@RepurchasePV",objproduct.RepurchasePV), 
                new SqlParameter("@MentionBy",objproduct.MentionBy)
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
        public string Update_Product(clsProduct objproduct)
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
                s2 = "update ProductMaster set productname='" + objproduct.ProductName + "',Productamount='" + objproduct.ProductAmount + "',JoiningPV='" + objproduct.JoiningPV + "',Repurchasepv='" + objproduct.RepurchasePV + "' where productid='" + objproduct.ProductId + "'";
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

        public string Insert_Package(clsProduct objproduct)
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
                s2 = "sp_add_PackageMaster";
                SqlParameter[] parameter = {  
                new SqlParameter("@PackageName",objproduct.PackageName), 
                new SqlParameter("@BinaryCapping",objproduct.CappingAmount), 
                new SqlParameter("@MinPV",objproduct.MinPV), 
                new SqlParameter("@MaxPV",objproduct.MaxPV), 
                new SqlParameter("@MentionBy",objproduct.MentionBy)
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
        public string Update_Package(clsProduct objproduct)
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
                s2 = "update PackageMaster set Packagename='" + objproduct.PackageName + "',binarycapping='" + objproduct.CappingAmount + "',minPV='" + objproduct.MinPV + "',maxpv='" + objproduct.MaxPV + "' where Packageid='" + objproduct.PackageId + "'";
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
    }
}
