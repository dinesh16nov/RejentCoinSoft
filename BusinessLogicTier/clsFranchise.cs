using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;
using System.Data;
using System.Data.SqlClient;
using ARA_StringHunt;

namespace BusinessLogicTier
{
    public class clsFranchise
    {
        Data ObjData = new Data();
        public string FranchiseId { get; set; }
        public string SponserId { get; set; }
        public string FranchiseName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PaytmMobileNo { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Password { get; set; }
        public string MentionBy { get; set; }
        public string RequestId { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityName { get; set; }
        public string EpinNo { get; set; }
        public int PoolNo { get; set; }
        public string AreaName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string TransferUserId { get; set; }
        public string ParentUserId { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public string AccHolderName { get; set; }
        public string AccNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public string PanCardNo { get; set; }
        public string Regtype { get; set; }
        public string Remark { get; set; }
        public decimal Amount { get; set; }
        public decimal AdminCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public string Id { get; set; }
        public string BankAccountId { get; set; }
        public string PaymentMode { get; set; }
        public string OnlineTransactionId { get; set; }
        public string ChequeNo { get; set; }
        public string Status { get; set; }
        public string PackageId { get; set; }
        public DataTable dtData { get; set; }
        public string WalletType { get; set; }
        public string ImageName { get; set; }
        public int NoOfEPins { get; set; }
        public string EPinStatus { get; set; }
        public string UserId { get; set; }
        public DataTable getFranchiseReport(clsFranchise objFranchise)
        {
            string str_query = "SELECT ud.Franchiseid, ud.Franchisename,ud.Mobile,ud.Email,ud.Address,ud.CityName,ud.MentionDate,ld.password FROM Franchisedetail ud with (nolock) left join Logindetail ld  with (nolock)  on ud.Franchiseid=ld.username where 1=1 ";
            if (objFranchise.FromDate != DateTime.MinValue && objFranchise.ToDate != DateTime.MinValue)
            {
                str_query += "  and ud.MentionDate  >= '" + objFranchise.FromDate + "'   and ud.MentionDate   <= '" + objFranchise.ToDate + "' ";
            }
            if (objFranchise.FranchiseName != "")
            {
                str_query += "  and ud.Franchisename = '" + objFranchise.FranchiseName + "' ";
            }
            if (objFranchise.FranchiseId != "")
            {
                str_query += "  and ud.FranchiseId = '" + objFranchise.FranchiseId + "' ";
            }
            if (objFranchise.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objFranchise.Mobile + "' ";
            }
            if (objFranchise.Email != "")
            {
                str_query += "  and ud.email = '" + objFranchise.Email + "' ";
            }
            if (objFranchise.CityName != "")
            {
                str_query += "  and ud.CityName = '" + objFranchise.CityName + "' ";
            }
            str_query += " order by ud.MentionDate  desc";

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
        public DataTable getFranchiseAll()
        {
            string str_query = "SELECT sm.StateName, ud.Franchiseid, ud.Franchisename,ud.Mobile,ud.Email,ud.Address,ud.CityName,ud.MentionDate,ld.password FROM Franchisedetail ud with (nolock) left join Logindetail ld  with (nolock)  on ud.Franchiseid=ld.username LEFT JOIN statemaster sm ON ud.StateId=sm.StateId where 1=1 ";

            str_query += " order by ud.MentionDate ";

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
        public DataTable getTotalAvailableEPin(clsFranchise objfranchise)
        {
            string str_query = "select count(*) from franchiseEPinMaster where  GenerateUserId = '" + objfranchise.FranchiseId + "' and EpinStatus='Active'  ";
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
        public DataTable getEPinTransferReport(clsFranchise objfranchise)
        {
            string str_query = "select em.* from franchiseEPinTransferHistory  em   where 1=1 ";


            if (objfranchise.FromDate != DateTime.MinValue && objfranchise.ToDate != DateTime.MinValue)
            {
                str_query += "  and em.mentiondate  >= '" + objfranchise.FromDate + "'   and em.mentiondate   <= '" + objfranchise.ToDate + "' ";
            }


            if (objfranchise.FranchiseId != "")
            {
                str_query += "  and em.UserIdFrom = '" + objfranchise.FranchiseId + "' ";
            }

            if (objfranchise.UserId != "")
            {
                str_query += "  and em.UserIdTo = '" + objfranchise.UserId + "' ";
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
        public DataTable getEPinRequestReport(clsFranchise objFranchise)
        {
            string str_query = "select em.* from FranchiseEPinRequest  em   where 1=1 ";


            if (objFranchise.FromDate != DateTime.MinValue && objFranchise.ToDate != DateTime.MinValue)
            {
                str_query += "  and em.mentiondate  >= '" + objFranchise.FromDate + "'   and em.mentiondate   <= '" + objFranchise.ToDate + "' ";
            }


            if (objFranchise.Status != "0")
            {
                str_query += "  and em.Status  = '" + objFranchise.Status + "' ";
            }

            if (objFranchise.FranchiseId != "")
            {
                str_query += "  and em.FranchiseId = '" + objFranchise.FranchiseId + "' ";
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
        public DataTable getEPin(clsFranchise objFranchise)
        {
            string str_query = "select em.* from FranchiseEPinMaster  em   where 1=1 ";


            if (objFranchise.FromDate != DateTime.MinValue && objFranchise.ToDate != DateTime.MinValue)
            {
                str_query += "  and em.mentiondate  >= '" + objFranchise.FromDate + "'   and em.mentiondate   <= '" + objFranchise.ToDate + "' ";
            }


            if (objFranchise.EPinStatus != "0")
            {
                str_query += "  and em.epinstatus = '" + objFranchise.EPinStatus + "' ";
            }

            if (objFranchise.FranchiseId != "")
            {
                str_query += "  and em.GenerateUserId = '" + objFranchise.FranchiseId + "' ";
            }

            if (objFranchise.UserId != "")
            {
                str_query += "  and em.UsedUserId = '" + objFranchise.UserId + "' ";
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
        public DataTable getFranchiseName(clsFranchise objfranchise)
        {
            string str_query = "SELECT ud.franchiseid, ud.franchisename,ud.mobile FROM franchisedetail ud with (nolock)   where ud.franchiseId = '" + objfranchise.FranchiseId + "' ";
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
        public string Insert_Franchise(clsFranchise objFranchise)
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

                s2 = "sp_add_FranchiseDetail";
                SqlParameter[] parameter = {              
                    new SqlParameter("@SponserId",objFranchise.SponserId), 
                    new SqlParameter("@FranchiseName",objFranchise.FranchiseName),
                    new SqlParameter("@Email",objFranchise.Email), 
                    new SqlParameter("@Mobile",objFranchise.Mobile), 
                    new SqlParameter("@Address",objFranchise.Address),
                    new SqlParameter("@CityName",objFranchise.CityName), 
                    new SqlParameter("@AreaName",objFranchise.AreaName), 
                    new SqlParameter("@Pincode",objFranchise.Pincode), 
                    new SqlParameter("@Password",objFranchise.Password), 
                    new SqlParameter("@MentionBy",objFranchise.MentionBy),
                    new SqlParameter("@Stateid",objFranchise.StateId),
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                try
                {
                    //// string url = "http://www.apihub.online/api/Services/transact?token=19b196731ec541fa39b1767016c265e7=SST&to=" + objFranchise.Mobile + "&sender=ETOPUP&smstext=" + "Dear User you are successfully registered on Ad Enterprises.com. Your login details are-username:" + res + ", password:" + objFranchise.Password + "&smsformat=TEXT&format=json";
                    string url = "http://www.apihub.online/api/Services/transact?token=19b196731ec541fa39b1767016c265e7&skey=SST&to=" + objFranchise.Mobile + "&sender=ETOPUP&smstext=" + "Dear Franchise you are successfully registered on Ad Enterprises.com. Your login details are-username:" + res + ", password:" + objFranchise.Password + "&smsformat=TEXT&format=json";
                    string Result = url.CallURL();
                    //Insert_SendSMS(objFranchise.Mobile, Result, url);
                }
                catch { }
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
        public string Insert_EPinRequest(clsFranchise objFranchise)
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

                s2 = "sp_add_FranchiseEPinRequest";
                SqlParameter[] parameter = {              
                    new SqlParameter("@FranchiseID",objFranchise.FranchiseId), 
                    new SqlParameter("@NoOfEPin",objFranchise.NoOfEPins),
                    new SqlParameter("@EPinAmount",objFranchise.Amount),
                    new SqlParameter("@MentionBy",objFranchise.MentionBy),
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
        public string EPinTransfer(clsFranchise objFranchise)
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
                DataTable dt = new DataTable();
                dt = ObjData.RunSelectQueryTTrans("select * from userdetail  with (nolock)  where userid='" + objFranchise.UserId + "'", tr);
                if (dt.Rows.Count > 0)
                {
                    DataTable dtepin = new DataTable();
                    dtepin = ObjData.RunSelectQueryTTrans("SELECT * FROM franchiseepinmaster WHERE GenerateUserId='" + objFranchise.FranchiseId + "'    AND EPinStatus='Active'", tr);
                    int totalpins = dtepin.Rows.Count;
                    if (totalpins >= objFranchise.NoOfEPins)
                    {
                        for (int c = 0; c < objFranchise.NoOfEPins; c++)
                        {
                            s2 = " declare @id int ; set @id=(select isnull(max(id),0)+1 from FranchiseEPinTransferHistory) ; insert into FranchiseEPinTransferHistory ( id, EPinNo  ,UserIdFrom  ,    UserIdTo  ,MentionBy ,mentionDate ) values (@id,'" + dtepin.Rows[c]["EPinNo"].ToString() + "','" + objFranchise.FranchiseId + "','" + objFranchise.UserId + "','" + objFranchise.MentionBy + "',[dbo].[getIndianDate]() ) ";
                            ObjData.RunInsUpDelQueryTrans(s2, tr);

                            s2 = " update  franchiseepinmaster set useduserid='" + objFranchise.UserId + "', EPinStatus='Used'  where EPinNo= '" + dtepin.Rows[c]["EPinNo"].ToString() + "' ";
                            ObjData.RunInsUpDelQueryTrans(s2, tr);

                            //s2 = "update EPinMaster set generateuserid='" + objFranchise.UserId + "' where EpinNo='" + dtepin.Rows[c]["EPinNo"].ToString() + "'  ";
                            s2 = @"declare @Id int;
SET @Id  =(SELECT isnull(max(Id),0)+1 FROM EPinMaster  );

insert into EPinMaster (id,EPinNo,GenerateUserId,UsedUserId,Amount,EPinStatus,MentionBy,MentionDate) values 
(@id,'" + dtepin.Rows[c]["EPinNo"].ToString() + "','" + objFranchise.UserId + "',null," + dtepin.Rows[c]["amount"].ToString() + ",'Active','" + objFranchise.FranchiseId + "',[dbo].[getIndianDate]())";
                            ObjData.RunInsUpDelQueryTrans(s2, tr);
                        }
                        res = "t";
                    }
                    else
                    {
                        res = "n";
                    }
                }
                else
                {
                    res = "f";
                }
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
        public string Reject_Request(clsFranchise objFranchise)
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
                s2 = "select * from FranchiseEPinRequest where id=" + objFranchise.RequestId + "   and status='Pending' ";
                DataTable dt = new DataTable();
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {

                    s2 = "update FranchiseEPinRequest set status='Rejected' , approvedate=[dbo].[getIndianDate]() where id=" + objFranchise.RequestId + "  ";
                    ObjData.RunInsUpDelQueryTrans(s2, tr);

                    res = "t";
                }
                else
                {
                    res = "f";
                }


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
        public string Approve_Request(clsFranchise objFranchise)
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

                s2 = "sp_apprve_FranchiseEPinRequest";
                SqlParameter[] parameter = {              
                    new SqlParameter("@requestId",objFranchise.RequestId), 
                    new SqlParameter("@MentionBy",objFranchise.MentionBy),
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
