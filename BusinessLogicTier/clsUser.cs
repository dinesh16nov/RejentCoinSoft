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
    public class clsUser
    {
        Data ObjData = new Data();
        public string UserId { get; set; }
        public string LevelNo { get; set; }
        public string PlanId { get; set; }
        public string Type { get; set; }
        public string SponserId { get; set; }
        public string NewSponserId { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string EmailSubject { get; set; }
        public string Data { get; set; }
        public string EmailBody { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public decimal CrAmount { get; set; }
        public decimal DrAmount { get; set; }
        public string TransactionType { get; set; }
        public string OTP { get; set; }
        public string PaytmMobileNo { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Password { get; set; }
        public string MentionBy { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityName { get; set; }
        public string EpinNo { get; set; }
        public String IsDummyData { get; set; }
        public String IsDirectROI { get; set; }
        public String IsNormalROI { get; set; }
        public int PoolNo { get; set; }
        public string StandingPosition { get; set; }
        public string BusinessType { get; set; }
        public string AreaName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDateExpiry { get; set; }
        public DateTime ToDateExpiry { get; set; }
        public string TransferUserId { get; set; }
        public int NoOfEpin { get; set; }
        public string ParentUserId { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public string AccHolderName { get; set; }
        public string AccNo { get; set; }
        public string BankName { get; set; }
        public string IPAddress { get; set; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public string PanCardNo { get; set; }
        public string Regtype { get; set; }
        public string Remark { get; set; }
        public decimal Amount { get; set; }
        public decimal MonthlyReturn { get; set; }
        public int Days { get; set; }
        public decimal Coins { get; set; }
        public decimal Limit { get; set; }
        public decimal ConversionRate { get; set; }
        public decimal ConvertedAmount { get; set; }
        public decimal DollarAmount { get; set; }
        public decimal QaureCoinToDollar { get; set; }
        public int Tenure { get; set; }
        public string PrevPackageId { get; set; }
        public decimal AdminCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public string Id { get; set; }
        public string BankAccountId { get; set; }
        public string PaymentMode { get; set; }
        public string TransactionId { get; set; }
        public string ReferenceId { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string OnlineTransactionId { get; set; }
        public string ChequeNo { get; set; }
        public string Status { get; set; }
        public string PackageId { get; set; }
        public string LandMark { get; set; }
        public DataTable dtData { get; set; }
        public string DepositWalletType { get; set; }
        public string WalletType { get; set; }
        public string WalletTypeId { get; set; }
        public string WalletAddressId { get; set; }
        public string WalletAddress { get; set; }
        public string ImageName { get; set; }
        public string TrustWalletAddress { get; set; }
        public decimal Deduction { get; set; }
        public decimal ConversionToDollar { get; set; }
        public decimal ConversionToQauere { get; set; }
        public decimal TransferAmount { get; set; }
        public string OperatorId { get; set; }
        public string OperatorType { get; set; }

        public string TopEntries { get; set; }

        public DataTable getUserReport(clsUser objUser)
        {
            string str_query = "SELECT isnull(ud.DailyDeduction,0) as DailyDeduction, ud.sponserid, ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.Address,ud.CityName,ud.MentionDate,ld.password,isnull(ud.balanceamount,0) as balanceamount,isnull(ud.coinbalance,0) as coinbalance,isnull(ud.rijentbalance,0) as rijentbalance,isnull(ud.ewalletbalance,0) as ewalletbalance,case when ud.activestatus ='1' then 'Active' else 'Deactive'  end as activestatus FROM userdetail ud with (nolock) left join Logindetail ld  with (nolock)  on ud.userid=ld.username and ld.role='user' where 1=1 ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and  convert(date, ud.MentionDate ) >= convert(date,'" + objUser.FromDate + "')   and convert(date, ud.MentionDate )  <= convert(date,'" + objUser.ToDate + "') ";
            }
            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.WalletAddress != "")
            {
                str_query += "  and ud.TrustWalletAddress = '" + objUser.WalletAddress + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }
            if (objUser.Email != "")
            {
                str_query += "  and ud.email = '" + objUser.Email + "' ";
            }
            if (objUser.CityName != "")
            {
                str_query += "  and ud.CityName = '" + objUser.CityName + "' ";
            }

            str_query += " order by ud.username  desc";

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

        public DataTable getUserReport2(clsUser objUser)
        {
            string str_query = "SELECT ud.sponserid, ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.Address,ud.CityName,ud.MentionDate,ld.password,isnull(ud.balanceamount,0) as balanceamount,isnull(ud.coinbalance,0) as coinbalance,isnull(ud.rijentbalance,0) as rijentbalance,isnull(ud.ewalletbalance,0) as ewalletbalance,case when ud.activestatus ='1' then 'Active' else 'Deactive'  end as activestatus FROM userdetail ud with (nolock) left join Logindetail ld  with (nolock)  on ud.userid=ld.username and ld.role='user' where 1=1 ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and  convert(date, ud.MentionDate ) >= convert(date,'" + objUser.FromDate + "')   and convert(date, ud.MentionDate )  <= convert(date,'" + objUser.ToDate + "') ";
            }
            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.WalletAddress != "")
            {
                str_query += "  and ud.TrustWalletAddress = '" + objUser.WalletAddress + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }
            if (objUser.Email != "")
            {
                str_query += "  and ud.email = '" + objUser.Email + "' ";
            }
            if (objUser.CityName != "")
            {
                str_query += "  and ud.CityName = '" + objUser.CityName + "' ";
            }

            if (objUser.WalletType == "MWallet")
            {
                str_query += "  and ud.balanceamount >0   order by ud.balanceamount  desc";
            }
            else if (objUser.WalletType == "EWallet")
            {
                str_query += "  and ud.ewalletbalance >0  order by ud.ewalletbalance  desc";
            }
            else if (objUser.WalletType == "Coin")
            {
                str_query += "  and ud.coinbalance >0  order by ud.coinbalance  desc";
            }
            else if (objUser.WalletType == "Rijent")
            {
                str_query += "  and ud.RijentBalance >0  order by ud.RijentBalance  desc";
            }

         //   str_query += " order by ud.username  desc";

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
        public DataTable getUserReportDummy(clsUser objUser)
        {
            string str_query = "SELECT ud.sponserid, ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.Address,ud.CityName,ud.MentionDate,ld.password,isnull(ud.balanceamount,0) as balanceamount,case when ud.activestatus ='1' then 'Active' else 'Deactive'  end as activestatus FROM userdetail ud with (nolock) left join Logindetail ld  with (nolock)  on ud.userid=ld.username and ld.role='user' where 1=1  and isnull(isdummydata,'0')='1' ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date,ud.MentionDate)  >= convert(date,'" + objUser.FromDate + "')   and convert(date,ud.MentionDate )  <= convert(date,'" + objUser.ToDate + "') ";
            }
            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }
            if (objUser.Email != "")
            {
                str_query += "  and ud.email = '" + objUser.Email + "' ";
            }
            if (objUser.CityName != "")
            {
                str_query += "  and ud.CityName = '" + objUser.CityName + "' ";
            }

            str_query += " order by ud.username  desc";

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
        public DataTable getUserReportSubadmin(clsUser objUser)
        {
            string str_query = "SELECT case when  ud.sponserid='INDIA01' then '*******' else ud.sponserid end as sponserid , ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.Address,ud.CityName,ud.MentionDate,ld.password,isnull(ud.balanceamount,0) as balanceamount,case when ud.activestatus ='1' then 'Active' else 'Deactive'  end as activestatus FROM userdetail ud with (nolock) left join Logindetail ld  with (nolock)  on ud.userid=ld.username where 1=1 and ud.userid!='INDIA01' ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date,ud.MentionDate ) >= convert(date,'" + objUser.FromDate + "')   and convert(date, ud.MentionDate)   <= convert(date,'" + objUser.ToDate + "') ";
            }
            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }
            if (objUser.Email != "")
            {
                str_query += "  and ud.email = '" + objUser.Email + "' ";
            }
            if (objUser.CityName != "")
            {
                str_query += "  and ud.CityName = '" + objUser.CityName + "' ";
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
        public DataTable getUserTopupReport(clsUser objUser)
        {
            string str_query = "SELECT top " + objUser.TopEntries + " up.*,ud.UserName,ud.Email,ud.Mobile FROM UserTopupDetail up WITH (nolock) LEFT JOIN userdetail ud WITH (nolock) ON up.UserId=ud.UserId where 1=1 ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, up.MentionDate ) >=  convert(date,'" + objUser.FromDate + "')   and  convert(date,up.MentionDate)   <=  convert(date,'" + objUser.ToDate + "') ";
            }
            if (objUser.FromDateExpiry != DateTime.MinValue && objUser.ToDateExpiry != DateTime.MinValue)
            {
                str_query += "  and convert(date, up.Expirydate ) >=  convert(date,'" + objUser.FromDateExpiry + "')   and  convert(date,up.Expirydate)   <=  convert(date,'" + objUser.ToDateExpiry + "') ";
            }
            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.MentionBy != "")
            {
                str_query += "  and up.mentionby = '" + objUser.MentionBy + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and up.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }
            if (objUser.Email != "")
            {
                str_query += "  and ud.email = '" + objUser.Email + "' ";
            }


            str_query += " order by up.id  desc";

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
        public DataTable getMyTopup(clsUser objUser)
        {
            string str_query = "SELECT id, 'Amount : '+ convert(NVARCHAR,convert(DECIMAL(18,2),amount))+ ' , Total Coin : '+convert(nvarchar,totalcoin) + ' ,Date :  '+ convert(nvarchar,mentiondate,103)+' '+ convert(NVARCHAR,mentiondate ,108) as amount2 FROM UserTopupDetail with (nolock) where 1=1 ";

            if (objUser.UserId != "")
            {
                str_query += "  and UserId = '" + objUser.UserId + "' ";
            }
            str_query += " order by id  desc";

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
        public DataTable getPremiumWalletReport(clsUser objUser)
        {
            string str_query = "SELECT pm.*,ud.username FROM PremiumWalletMaster pm WITH (nolock) LEFT JOIN UserDetail ud WITH (nolock) ON pm.userid=ud.userid where 1=1 ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, pm.MentionDate ) >=  convert(date,'" + objUser.FromDate + "')   and  convert(date,pm.MentionDate)   <=  convert(date,'" + objUser.ToDate + "') ";
            }
            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and pm.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }
            if (objUser.Email != "")
            {
                str_query += "  and ud.email = '" + objUser.Email + "' ";
            }


            str_query += " order by pm.id  desc";

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
        public DataTable getUserReportForCommission(clsUser objUser)
        {
            string str_query = "SELECT (select count(id) from userdetail ud3 with (nolock) where ud3.sponserid=ud.userid and ud3.activestatus='1' ) as directcount,ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.MentionDate,isnull(ud.balanceamount,0) as balanceamount, case when ud.activestatus='1' then 'Paid' else 'Unpaid' end as activestatus2,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber FROM userdetail ud with (nolock)  left join bankmaster bm with (nolock) on ud.bankname=bm.bankid   where 1=1 and isnull(ud.balanceamount,0)>=100 ";

            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
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
        public DataTable getUserReportForDirectIncomeRelease(clsUser objUser)
        {
            string str_query = @"SELECT sum(td.cramount)-sum(td.dramount) AS Balance,ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.MentionDate,case when ud.activestatus='1' then 'Paid' else 'Unpaid' end as activestatus2,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber 


 FROM transactiondetail td WITH (nolock)
 LEFT JOIN userdetail ud with (nolock) ON td.UserID=ud.UserId  left join bankmaster bm with (nolock) on ud.bankname=bm.bankid   
  WHERE td.transactionid IN  (SELECT td2.transactionid FROM transactiondetail td2 WITH (nolock) WHERE  td2.TransactionType ='DirectIncome')    ";

            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }


            str_query += " GROUP BY ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.MentionDate, ud.activestatus,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber  having sum(td.cramount)-sum(td.dramount)>=500  ";

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
        public DataTable getUserReportForROIIncomeRelease(clsUser objUser)
        {
            string str_query = @"SELECT sum(td.cramount)-sum(td.dramount) AS Balance,ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.MentionDate,case when ud.activestatus='1' then 'Paid' else 'Unpaid' end as activestatus2,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber 


 FROM transactiondetail td WITH (nolock)
 LEFT JOIN userdetail ud with (nolock) ON td.UserID=ud.UserId  left join bankmaster bm with (nolock) on ud.bankname=bm.bankid   
  WHERE td.transactionid IN  (SELECT td2.transactionid FROM transactiondetail td2 WITH (nolock) WHERE  td2.TransactionType in ('ROIIncome','TwiceDirect','JodiIncome'))    ";

            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }


            str_query += " GROUP BY ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.MentionDate, ud.activestatus,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber  having sum(td.cramount)-sum(td.dramount)>=500  ";

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
        public DataTable getUserReportForBinaryIncomeRelease(clsUser objUser)
        {
            string str_query = @"SELECT sum(td.cramount)-sum(td.dramount) AS Balance,ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.MentionDate,case when ud.activestatus='1' then 'Paid' else 'Unpaid' end as activestatus2,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber 
,isnull(sum(CASE WHEN td.TransactionType='MatchingIncome' THEN td.CrAmount ELSE 0 END),0)-isnull(sum(CASE WHEN td.TransactionType IN ('Admin Charge','MatchingIncome') and td.remark like '%Matching Income%' THEN td.DrAmount ELSE 0 END),0) AS BinaryIncome
,isnull(sum(CASE WHEN td.TransactionType='DirectIncome' THEN td.CrAmount ELSE 0 END),0)-isnull(sum(CASE WHEN td.TransactionType IN('Admin Charge','DirectIncome') and td.remark like '%Direct Income%' THEN td.DrAmount ELSE 0 END),0) AS DirectIncome

,isnull(sum(CASE WHEN td.TransactionType='TwiceBinaryIncome' THEN td.CrAmount ELSE 0 END),0)-isnull(sum(CASE WHEN td.TransactionType IN ('Admin Charge','TwiceBinaryIncome') and td.remark like '%Twice Binary Income%' THEN td.DrAmount ELSE 0 END),0) AS TwiceBinaryIncome

 FROM transactiondetail td WITH (nolock)
 LEFT JOIN userdetail ud with (nolock) ON td.UserID=ud.UserId  left join bankmaster bm with (nolock) on ud.bankname=bm.bankid   
  WHERE td.transactionid IN  (SELECT td2.transactionid FROM transactiondetail td2 WITH (nolock) WHERE  td2.TransactionType  in ('MatchingIncome','DirectIncome','TwiceBinaryIncome'))   ";

            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }


            str_query += " GROUP BY ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.MentionDate, ud.activestatus,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber having sum(td.cramount)-sum(td.dramount)>=500   ";

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
        public DataTable getContactRequestReport(clsUser objUser)
        {
            string str_query = "SELECT  * from ContactRequestDetail with (nolock)  where 1=1 ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date,MentionDate)  >= convert(date,'" + objUser.FromDate + "')   and convert(date,MentionDate)   <= convert(date,'" + objUser.ToDate + "') ";
            }

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

        public DataTable getOperatorByType(clsUser objUser)
        {
            string str_query = "SELECT  * from operatorcode with (nolock)  where type=" + objUser.OperatorType + " ";


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
        public DataTable getTenure()
        {
            string str_query = "SELECT  * from TenureMaster with (nolock)  order by tenure ";


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
        public DataTable getStakingPlan()
        {
            string str_query = "SELECT  *,PlanName+' ('+convert(nvarchar,Tenure)+' Months)' as PlanName2 from StakingPlanDetail with (nolock)  order by PlanId ";


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
            ObjData.EndConnection();return dt;
        }
        public DataTable getUserReportForTwiceBinaryIncomeRelease(clsUser objUser)
        {
            string str_query = @"SELECT sum(td.cramount)-sum(td.dramount) AS Balance,ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.MentionDate,case when ud.activestatus='1' then 'Paid' else 'Unpaid' end as activestatus2,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber 


 FROM transactiondetail td WITH (nolock)
 LEFT JOIN userdetail ud with (nolock) ON td.UserID=ud.UserId  left join bankmaster bm with (nolock) on ud.bankname=bm.bankid   
  WHERE td.transactionid IN  (SELECT td2.transactionid FROM transactiondetail td2 WITH (nolock) WHERE  td2.TransactionType ='TwiceBinaryIncome')  AND td.Remark LIKE '%Twice%'  ";

            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }


            str_query += " GROUP BY ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.MentionDate, ud.activestatus,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber having sum(td.cramount)-sum(td.dramount)>=500   ";

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
        public DataTable getUserCurrentPool(clsUser objUser)
        {
            string str_query = @"; WITH MyCTE
AS ( SELECT id,userid,username,   parentuserid,0 AS userlevel
FROM userdetail with (nolock) 
WHERE UserId ='" + objUser.UserId + @"'
UNION ALL
SELECT UserDetail.id,userdetail.userid,userdetail.username,  userdetail.parentuserid ,MyCTE.userlevel+1 
FROM userdetail with (nolock) 
INNER JOIN MyCTE ON userdetail.parentuserid = MyCTE.userid
WHERE userdetail.userid !='" + objUser.UserId + @"' )


SELECT TOP 1 p1.*,(SELECT count(MyCTE.id) FROM MyCTE   WHERE mycte.userid!='" + objUser.UserId + @"') as totalusers
,isnull( (SELECT sum(p2.totaljoining ) FROM PoolLevelMaster p2 WHERE (p2.LevelNo)<=p1.LevelNo+1 ),0)  AS totalcountnewlevel
,isnull((SELECT sum(p2.totaljoining ) FROM PoolLevelMaster p2 WHERE (p2.LevelNo)<=p1.LevelNo ),0)  AS totalcountcurrentlevel
FROM PoolLevelMaster p1 WHERE p1.TotalJoining<=
(SELECT count(MyCTE.id) FROM MyCTE   WHERE mycte.userid!='" + objUser.UserId + @"')
 ORDER BY p1.TotalJoining desc 
 option ( MaxRecursion 0 );";

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

        //        public DataTable getDashboardAdmin()
        //        {
        //            string str_query = @"SELECT count(userid) AS totaluser
        //,(SELECT count (userid) FROM UserDetail with (nolock) WHERE datepart(mm,mentiondate)=datepart(mm,[dbo].[getIndianDate]()) )  AS MonthUser
        //,(SELECT count (userid) FROM UserDetail with (nolock)  WHERE 
        //mentiondate >= dateadd(day, 1-datepart(dw, [dbo].[getIndianDate]()), CONVERT(date,[dbo].[getIndianDate]())) 
        //AND mentiondate <  dateadd(day, 8-datepart(dw, [dbo].[getIndianDate]()), CONVERT(date,[dbo].[getIndianDate]()))

        // )  AS WeekUser
        //,(SELECT count (userid) FROM UserDetail  with (nolock)  WHERE convert(DATE, mentiondate)=convert(DATE, [dbo].[getIndianDate]()))  AS Todayuser
        //FROM UserDetail  with (nolock) ";

        //            DataTable dt = null;
        //            ObjData.StartConnection();
        //            try
        //            {
        //                dt = ObjData.RunDataTable(str_query);
        //            }
        //            catch (Exception ex)
        //            {
        //                dt = null;
        //            }
        //            ObjData.EndConnection();
        //            return dt;
        //        }
        public DataTable getDashboardAdmin()
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getDashboardAdmin";
                SqlParameter[] parameter = {
                                               //new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }

        public DataTable getDashboardSubadmin()
        {
            string str_query = @"SELECT count(id) AS totaluser
,(SELECT count (id) FROM UserDetail WHERE datepart(mm,mentiondate)=datepart(mm,[dbo].[getIndianDate]()) and  userid!='INDIA01'  )  AS MonthUser
,(SELECT count (id) FROM UserDetail WHERE 
mentiondate >= dateadd(day, 1-datepart(dw, [dbo].[getIndianDate]()), CONVERT(date,[dbo].[getIndianDate]()) ) 
AND mentiondate <  dateadd(day, 8-datepart(dw, [dbo].[getIndianDate]()), CONVERT(date,[dbo].[getIndianDate]()))

 )  AS WeekUser
,(SELECT count (id) FROM UserDetail WHERE convert(DATE, mentiondate)=convert(DATE, [dbo].[getIndianDate]()))  AS Todayuser
FROM UserDetail where userid!='INDIA01' ";

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

        public DataTable getEmailMobileVerifyStatus(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getEmailMobileVerifyStatus";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public string Insert_ContactRequest(clsUser objUser)
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
                s2 = "sp_add_ContactRequestDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@Name",objUser.UserName),
                    new SqlParameter("@mobile",objUser.Mobile),
                    new SqlParameter("@email",objUser.Email),
                    new SqlParameter("@message",objUser.Remark),
                    new SqlParameter("@mentionby",objUser.MentionBy),
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
        public DataTable getFundRequestReport(clsUser objUser)
        {
            string str_query = "SELECT bw.WalletType, wr.*,ud.UserName,ud.SponserId,ud2.UserName AS Sponsername,ud.balanceamount  from FundRequestDetail wr with (nolock)  LEFT JOIN userdetail ud with (nolock)  ON wr.UserId=ud.UserId LEFT JOIN userdetail ud2 ON ud2.UserId=ud.SponserId LEFT JOIN bankmaster bm WITH (nolock) ON ud.BankName=bm.BankId LEFT JOIN btcwallettypedetail bw WITH (nolock) ON bw.id=wr.WalletTypeId where 1=1 ";
            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, wr.MentionDate ) >=  convert(date,'" + objUser.FromDate + "')   and  convert(date,wr.MentionDate )  <=  convert(date,'" + objUser.ToDate + "') ";
            }

            if (objUser.UserId != "")
            {
                str_query += "  and wr.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Status != "0")
            {
                str_query += "  and wr.status = '" + objUser.Status + "' ";
            }

            str_query += " order by wr.MentionDate  desc";

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
        public DataTable getStackingReport(clsUser objUser)
      {
            string str_query = "SELECT fd.*,ud.UserName,sd.planname FROM stackingdetail fd with (nolock) LEFT JOIN userdetail ud with (nolock) ON fd.UserId=ud.UserId left join stakingplandetail sd with (nolock) on sd.planid=fd.planid  where 1=1 AND fd.mentionby!='-1' ";
            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, fd.MentionDate)  >= convert(date,'" + objUser.FromDate + "' )  and convert(date,fd.MentionDate  ) <= convert(date,'" + objUser.ToDate + "') ";
            }

            if (objUser.UserId != "")
            {
                str_query += "  and fd.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Status != "0" && objUser.UserId == "")
            {
                str_query += "  and fd.status = '" + objUser.Status + "' ";
            }
            str_query += " order by fd.MentionDate  desc";

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
        public DataTable getBTCWalletTypeAll()
        {
            string str_query = "SELECT * from BTCWalletTypeDetail with (nolock) ";
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

        public DataTable getBTCWalletTypeActive()
        {
            string str_query = "SELECT * from BTCWalletTypeDetail with (nolock) where status=1 ";




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

        public DataTable getBTCWalletTypeActive2(clsUser objuser)
        {
            string str_query = "";
            if (objuser.WalletType == "EWallet")
            {
                str_query = "SELECT * from BTCWalletTypeDetail with (nolock) where status=1  ";
            }
            else
                if (objuser.WalletType == "Coin")
            {
                str_query = "SELECT * from BTCWalletTypeDetail with (nolock) where status=1  and wallettype ='RTC-OLD'";
            }
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
        public DataTable getBTCWalletAddressAll()
        {
            //string str_query = "SELECT ba.*,bw.WalletType FROM BTCWalletAddressDetail ba WITH (nolock) LEFT JOIN btcwallettypedetail bw WITH (nolock) ON ba.WalletTypeId=bw.id ";




            //DataTable dt = null;
            //ObjData.StartConnection();
            //try
            //{
            //    dt = ObjData.RunDataTable(str_query);
            //}
            //catch (Exception ex)
            //{
            //    dt = null;
            //}
            //ObjData.EndConnection();
            //return dt;

            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getBTCWalletAddress";
                SqlParameter[] parameter = {
                                               //new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }

        public DataTable getBTCWalletAddressByType(clsUser objuser)
        {
            //string str_query = "SELECT bw.ConversionToDollar,bw.ConversionToQauere,ba.*,bw.WalletType,isnull(ba.Walletaddress,'')+isnull(ba.AccountNo,'') as  Walletaddress2 FROM BTCWalletAddressDetail ba WITH (nolock) LEFT JOIN btcwallettypedetail bw WITH (nolock) ON ba.WalletTypeId=bw.id where ba.wallettypeid=" + objuser.WalletTypeId + " and ba.status=1 ";




            //DataTable dt = null;
            //ObjData.StartConnection();
            //try
            //{
            //    dt = ObjData.RunDataTable(str_query);
            //}
            //catch (Exception ex)
            //{
            //    dt = null;
            //}
            //ObjData.EndConnection();
            //return dt;
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getBTCWalletAddressByType";
                SqlParameter[] parameter = {
                                               new SqlParameter("@typeId",objuser.WalletTypeId ),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getBTCWalletAddressDetail(clsUser objuser)
        {
            string str_query = "SELECT ba.*,bw.WalletType FROM BTCWalletAddressDetail ba WITH (nolock) LEFT JOIN btcwallettypedetail bw WITH (nolock) ON ba.WalletTypeId=bw.id where ba.id=" + objuser.WalletAddressId + " and ba.status=1 ";




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
        public DataTable getBTCWalletAddressUser(clsUser objuser)
        {
            string str_query = "SELECT ba.*,bw.WalletType FROM UserBTCWalletAddressDetail ba WITH (nolock) LEFT JOIN btcwallettypedetail bw WITH (nolock) ON ba.WalletTypeId=bw.id where ba.userid='" + objuser.UserId + "' ";




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
        public DataTable getBTCWalletAddressUserByType(clsUser objuser)
        {
            string str_query = "SELECT ba.*,bw.conversionToDollar,bw.conversionToQauere,bw.WalletType FROM UserBTCWalletAddressDetail ba WITH (nolock) LEFT JOIN btcwallettypedetail bw WITH (nolock) ON ba.WalletTypeId=bw.id where ba.userid='" + objuser.UserId + "' and  ba.WalletTypeId=" + objuser.WalletTypeId + "  ";




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
        public DataTable getBTCWalletAddressActive()
        {
            string str_query = "SELECT ba.*,bw.WalletType FROM BTCWalletAddressDetail ba WITH (nolock) LEFT JOIN btcwallettypedetail bw WITH (nolock) ON ba.WalletTypeId=bw.id where ba.status=1 ";




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
        public DataTable getFundRequestReportPending(clsUser objUser)
        {
            string str_query = "SELECT fd.*,ud.UserName,cs.AccountNo+'('+cs.bankname+')' as accno2 FROM FundRequestDetail fd LEFT JOIN userdetail ud with (nolock) ON fd.UserId=ud.UserId left join CompanyAccountDetail cs on fd.bankaccountid=cs.id where 1=1 and fd.status='Pending' ";
            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and fd.MentionDate  >= '" + objUser.FromDate + "'   and fd.MentionDate   <= '" + objUser.ToDate + "' ";
            }

            if (objUser.UserId != "")
            {
                str_query += "  and fd.UserId = '" + objUser.UserId + "' ";
            }

            str_query += " order by fd.MentionDate  desc";

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
        public DataTable getFundRequestReportApproved(clsUser objUser)
        {
            string str_query = "SELECT fd.*,ud.UserName,cs.AccountNo+'('+cs.bankname+')' as accno2 FROM FundRequestDetail fd LEFT JOIN userdetail ud with (nolock) ON fd.UserId=ud.UserId left join CompanyAccountDetail cs on fd.bankaccountid=cs.id where 1=1 and fd.status='Approved' ";
            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and fd.MentionDate  >= '" + objUser.FromDate + "'   and fd.MentionDate   <= '" + objUser.ToDate + "' ";
            }

            if (objUser.UserId != "")
            {
                str_query += "  and fd.UserId = '" + objUser.UserId + "' ";
            }

            str_query += " order by fd.MentionDate  desc";

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
        public DataTable getFundRequestReportRejected(clsUser objUser)
        {
            string str_query = "SELECT fd.*,ud.UserName,cs.AccountNo+'('+cs.bankname+')' as accno2 FROM FundRequestDetail fd LEFT JOIN userdetail ud with (nolock) ON fd.UserId=ud.UserId left join CompanyAccountDetail cs on fd.bankaccountid=cs.id where 1=1 and fd.status='Rejected' ";
            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and fd.MentionDate  >= '" + objUser.FromDate + "'   and fd.MentionDate   <= '" + objUser.ToDate + "' ";
            }

            if (objUser.UserId != "")
            {
                str_query += "  and fd.UserId = '" + objUser.UserId + "' ";
            }

            str_query += " order by fd.MentionDate  desc";

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
        public DataTable getCallbackReport(clsUser objuser)
        {
            string str_query = "SELECT cd.*,ud.UserName FROM CallbackRequestDetail cd LEFT JOIN userdetail ud with (nolock)  ON cd.UserId=ud.UserId where 1=1  ";
            if (objuser.FromDate != DateTime.MinValue && objuser.ToDate != DateTime.MinValue)
            {
                str_query += "  and cd.mentiondate  >= '" + objuser.FromDate + "'   and cd.mentiondate   <= '" + objuser.ToDate + "' ";
            }
            if (objuser.UserId != "")
            {
                str_query += "  and cd.UserId = '" + objuser.UserId + "' ";
            }
            str_query += " order by cd.mentiondate  desc";
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
        public DataTable getUserNameForUpgrade(clsUser objUser)
        {
            string str_query = "SELECT ut.*,ud.Username,pm.packagename+'('+convert(NVARCHAR,pm.minpv)+'-'+convert(NVARCHAR,pm.maxpv)+')' AS packagename2 FROM UserTopupDetail ut with (nolock)  LEFT JOIN userdetail ud with (nolock) ON ut.UserId=ud.UserId LEFT JOIN packagemaster pm ON ut.PackageId=pm.PackageId where ut.UserId = '" + objUser.UserId + "' ";
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
        public DataTable getCallbackReportSUbadmin(clsUser objuser)
        {
            string str_query = "SELECT cd.*,ud.UserName FROM CallbackRequestDetail cd LEFT JOIN userdetail ud with (nolock)  ON cd.UserId=ud.UserId where 1=1 and cd.userid!='INDIA01' ";
            if (objuser.FromDate != DateTime.MinValue && objuser.ToDate != DateTime.MinValue)
            {
                str_query += "  and cd.mentiondate  >= '" + objuser.FromDate + "'   and cd.mentiondate   <= '" + objuser.ToDate + "' ";
            }
            if (objuser.UserId != "")
            {
                str_query += "  and cd.UserId = '" + objuser.UserId + "' ";
            }
            str_query += " order by cd.mentiondate  desc";
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
        public DataTable getUserName(clsUser objUser)
        {
            string str_query = "SELECT ud.TrustWalletAddress, ud.activestatus, ud.SponserId,ud2.UserName AS sponsername, ud.userid, ud.username,ud.mobile,isnull(ud.imagename,'default.png') as imagename,isnull((select sum (ut.amount) from usertopupdetail ut with (nolock) where ut.userid=ud.userid) ,0) as amount FROM userdetail ud with (nolock) LEFT JOIN userdetail ud2 WITH(nolock) ON ud.SponserId=ud2.UserId LEFT JOIN usertopupdetail ut WITH (nolock) ON ut.UserId=ud.UserId   where ud.UserId = '" + objUser.UserId + "' ";
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
//        public DataTable getUserNameDownline(clsUser objUser)
//        {
//            string str_query = "SELECT ud.SponserId,ud2.UserName AS sponsername, ud.userid, ud.username,ud.mobile,isnull(ud.imagename,'default.png') as imagename FROM userdetail ud with (nolock) LEFT JOIN userdetail ud2 WITH(nolock) ON ud.SponserId=ud2.UserId   where ud.UserId = '" + objUser.UserId + "' ";

//            str_query = @"; WITH MyCTE
//AS ( SELECT id,userid,username,   parentuserid,0 AS userlevel
//FROM userdetail with (nolock) 
//WHERE UserId ='" + objUser.SponserId + @"'
//UNION ALL
//SELECT UserDetail.id,userdetail.userid,userdetail.username,  userdetail.parentuserid ,MyCTE.userlevel+1 
//FROM userdetail with (nolock) 
//INNER JOIN MyCTE ON userdetail.parentuserid = MyCTE.userid
//WHERE userdetail.userid !='" + objUser.SponserId + @"' )
//SELECT ud.SponserId,ud2.UserName AS sponsername, ud.userid, ud.username,ud.mobile,isnull(ud.imagename,'default.png') as imagename FROM userdetail ud with (nolock) LEFT JOIN userdetail ud2 WITH(nolock) ON ud.SponserId=ud2.UserId   where ud.UserId = '" + objUser.UserId + @"' and ud.userid in (select userid from mycte) 
//option (maxrecursion 0)";

//            DataTable dt = null;
//            ObjData.StartConnection();
//            try
//            {
//                dt = ObjData.RunDataTable(str_query);
//            }
//            catch (Exception ex)
//            {
//                dt = null;
//            }
//            ObjData.EndConnection();
//            return dt;
//        }
        public DataTable getUserNameForTopup(clsUser objUser)
        {
            string str_query = "SELECT  ud.userid, ud.username,ud.mobile,ud.planid FROM userdetail ud with (nolock) where ud.UserId = '" + objUser.UserId + "' and ud.activestatus='0' ";
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
        public DataTable getUserNameForReTopup(clsUser objUser)
        {
            string str_query = "SELECT  ud.userid, ud.username,ud.mobile,ud.planid FROM userdetail ud with (nolock) where ud.UserId = '" + objUser.UserId + "' and ud.activestatus='1' ";
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
        public DataTable getUserNameSubadmin(clsUser objUser)
        {
            string str_query = "SELECT ud.SponserId,ud2.UserName AS sponsername, ud.userid, ud.username,ud.mobile,isnull(ud.imagename,'default.png') as imagename FROM userdetail ud with (nolock) LEFT JOIN userdetail ud2 WITH(nolock) ON ud.SponserId=ud2.UserId   where ud.UserId = '" + objUser.UserId + "' and ud.Userid!='INDIA01' ";
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

        public DataTable getTeamTopupCount(clsUser objUser)
        {
            string str_query = "SELECT count(id) as total FROM UserTopupDetail  with (nolock)  WHERE UserId IN (SELECT userid FROM UserDetail  with (nolock)  WHERE SponserId='" + objUser.UserId + "')";
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
        public DataTable getOffer()
        {
            string str_query = "SELECT * from offerdetail with (nolock) order  by mentiondate desc";
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
        public DataTable getWalletTransferUserName(clsUser objUser)
        {
            string str_query = "";

            str_query = @"; WITH MyCTE
AS ( SELECT id,userid,username,   ParentUserId,0 AS userlevel
FROM userdetail with (nolock) 
WHERE UserId ='" + objUser.UserId + @"'
UNION ALL
SELECT UserDetail.id,userdetail.userid,userdetail.username,  userdetail.ParentUserId ,MyCTE.userlevel+1 
FROM userdetail with (nolock) 
INNER JOIN MyCTE ON userdetail.parentuserid = MyCTE.userid
WHERE userdetail.userid !='" + objUser.UserId + @"' )
SELECT MyCTE.*
FROM MyCTE where mycte.userid='" + objUser.TransferUserId + "' ";



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
        public DataTable getUserNameWithBalance(clsUser objUser)
        {
            string str_query = "SELECT ud.userid, ud.username,ud.mobile,(select isnull(sum(td.cramount),0)-isnull(sum(td.dramount),0) from transactiondetail td with (nolock)  where td.userid=ud.userid) AS balance,isnull(ud.ewalletbalance,0) as ewalletbalance2 FROM userdetail ud with (nolock)  where ud.UserId = '" + objUser.UserId + "' ";
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



        public DataTable getTOtalDirect(clsUser objUser)
        {
            string str_query = "";
            str_query = @"select count(ud3.id) as totaluser from userdetail ud3  with (nolock)  where ud3.sponserid='" + objUser.UserId + @"' ";
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
        public DataTable getTotalusers()
        {
            string str_query = "";
            str_query = @"select count(ud3.id) as totaluser from userdetail ud3  with (nolock)   ";
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
        public DataSet get_DashboardUser(clsUser objuser)
        {
            string s2 = "";
            DataSet ds = new DataSet();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getUserDashboard";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                ds = ObjData.RunDataSetProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return ds;
        }
        public DataTable getUserSmartContractAddress(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getSmartContractWalletAddress";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getSelfBonanzaAchievementReport(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_getSelfBonanzaReport";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getTeamBonanzaAchievementReport(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_getTeamBonanzaReport";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }

        public DataTable getPendingSmartContractRequest(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getPendingSMartContractRequest";
                SqlParameter[] parameter = {
                                               //new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable get_UserBalance(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getUserBalance";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable get_RenewStatus(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getRenewStatus";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable get_CheckBalaneForWithdrawal(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_CheckBalanceForWithdrawal";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                                               new SqlParameter("@WalletType",objuser.WalletType),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable get_UserDetailNew(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_getUserDetail";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable get_UserBinaryData(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "getuserBinary";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId)
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getWelcomeLetter(clsUser objUser)
        {
            string str_query = "SELECT ud.nomineename,ud.nomineerelation, ud.accountno,ud.ifsccode,ud.branchname,bm.bankname, pm.PlanName, ud.NomineeName,ud.NomineeRelation, ld.password, ud.userid, ud.sponserid,ud.username,ud.mobile,ud.email,ud.address,convert(NVARCHAR,ud.mentiondate,103) AS mentiondate,ud.gender,convert(NVARCHAR,ud.dateofbirth,103) AS  dateofbirth,ud2.username as sponsername from userdetail ud with (nolock) left join userdetail ud2 with (nolock) on ud.sponserid=ud2.userid left join usertopupdetail ut with (nolock) on ut.userid=ud.userid left join logindetail ld on ud.userid=ld.username AND ld.Role='User' LEFT JOIN epinmaster em WITH (nolock) ON ut.EPinNo=em.EPinNo LEFT JOIN planmaster pm WITH (nolock) ON pm.PlanId=em.PlanId left join bankmaster bm with (nolock) on ud.bankname=bm.bankid where ud.userid='" + objUser.UserId + "'";
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
        //        public DataTable getUserDownline(clsUser objUser)
        //        {

        //            string str_userquery = "";
        //            if (objUser.StandingPosition == "Left")
        //            {
        //                str_userquery = @"declare @userid int;set @userid=(select userid from userdetail with (nolock) where parentuserid='" + objUser.UserId + "' and standingposition='Left')";
        //            }
        //            else if (objUser.StandingPosition == "Right")
        //            {
        //                str_userquery = @"declare @userid int;set @userid=(select userid from userdetail with (nolock) where parentuserid='" + objUser.UserId + "' and standingposition='Right')";
        //            }
        //            else
        //            {
        //                str_userquery = @"declare @userid int;set @userid='"+objUser.UserId+"'";
        //            }

        //            string str_query = "";
        //            str_query = str_userquery+ @"; WITH MyCTE
        //AS ( SELECT userid,username,   parentuserid,0 AS userlevel,standingposition,mobile
        //FROM userdetail with (nolock) 
        //WHERE UserId =@userid 
        //UNION ALL
        //SELECT userdetail.userid,userdetail.username,  userdetail.parentuserid ,MyCTE.userlevel+1 ,userdetail.standingposition,userdetail.mobile
        //FROM userdetail with (nolock) 
        //INNER JOIN MyCTE ON userdetail.parentuserid = MyCTE.userid
        //WHERE userdetail.userid !=@userid  )
        //SELECT MyCTE.*,ud.username as parentname,isnull(em.amount,0) as amount
        //,
        //ut.MentionDate AS topupdate
        //FROM MyCTE left join userdetail ud with (nolock)  on mycte.parentuserid=ud.userid
        //LEFT JOIN usertopupdetail ut WITH (nolock) ON mycte.UserId=ut.UserId
        //left join planmaster em with (nolock) on ut.planid=em.planid
        // where mycte.userid!='" + objUser.UserId + @"' order by mycte.userlevel
        //option (maxrecursion 0)";
        //            DataTable dt = null;
        //            ObjData.StartConnection();
        //            try
        //            {
        //                dt = ObjData.RunDataTable(str_query);
        //            }
        //            catch (Exception ex)
        //            {
        //                dt = null;
        //            }
        //            ObjData.EndConnection();
        //            return dt;
        //        }
        //        public DataTable getUserDirectDownline(clsUser objUser)
        //        {

        //            string str_userquery = "";
        //            if (objUser.StandingPosition == "Left")
        //            {
        //                str_userquery = @"declare @userid int;set @userid=(select userid from userdetail with (nolock) where parentuserid='" + objUser.UserId + "' and standingposition='Left')";
        //            }
        //            else if (objUser.StandingPosition == "Right")
        //            {
        //                str_userquery = @"declare @userid int;set @userid=(select userid from userdetail with (nolock) where parentuserid='" + objUser.UserId + "' and standingposition='Right')";
        //            }
        //            else
        //            {
        //                str_userquery = @"declare @userid int;set @userid='" + objUser.UserId + "'";
        //            }

        //            string str_query = "";
        //            //str_query = str_userquery + @"; WITH MyCTE
        //            //AS ( SELECT userid,username,   parentuserid,0 AS userlevel,standingposition,sponserid,mobile
        //            //FROM userdetail with (nolock) 
        //            //WHERE UserId =@userid 
        //            //UNION ALL
        //            //SELECT userdetail.userid,userdetail.username,  userdetail.parentuserid ,MyCTE.userlevel+1 ,userdetail.standingposition,userdetail.sponserid,userdetail.mobile
        //            //FROM userdetail with (nolock) 
        //            //INNER JOIN MyCTE ON userdetail.parentuserid = MyCTE.userid
        //            //WHERE userdetail.userid !=@userid  )
        //            //SELECT MyCTE.*,ud.username as parentname,isnull(em.amount,0) as amount
        //            //,
        //            //ut.MentionDate AS topupdate
        //            //FROM MyCTE left join userdetail ud with (nolock)  on mycte.parentuserid=ud.userid
        //            //LEFT JOIN usertopupdetail ut WITH (nolock) ON mycte.UserId=ut.UserId
        //            //left join planmaster em with (nolock) on ut.planid=em.planid
        //            // where mycte.userid!='" + objUser.UserId + @"' and mycte.sponserid='" + objUser.UserId + @"'   order by mycte.userlevel
        //            //option (maxrecursion 0)";

        //            str_query = str_userquery + @";with cte as(
        //		Select userid,LUserId,RUserId,0 AS userlevel FROM UserBinaryDetail WITH (nolock) 
        //		WHERE userid = @userid
        //		UNION ALL
        //		Select I.userid,I.LuserId, I.RUserId,c.userlevel+1 
        //		FROM UserBinaryDetail AS I  WITH (nolock)  ,cte as C WHERE I.userid IN (C.LUserId,C.RUserId) 
        //		)

        //SELECT cte.userid,ud.username,ud.parentuserid,ud.standingposition,ud.sponserid,ud.mobile,ud2.username as parentname
        //FROM cte  left join userdetail ud with (nolock) on cte.userid=ud.userid 
        //left join userdetail ud2 with (nolock)  on ud.parentuserid=ud2.userid where cte.userid!='" + objUser.UserId + @"' and ud.sponserid='" + objUser.UserId + @"'  
        //option (maxrecursion 0)";

        //            DataTable dt = null;
        //            ObjData.StartConnection();
        //            try
        //            {
        //                dt = ObjData.RunDataTable(str_query);
        //            }
        //            catch (Exception ex)
        //            {
        //                dt = null;
        //            }
        //            ObjData.EndConnection();
        //            return dt;
        //        }

        public DataTable getUserDashboardSummary(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_getUserDashboardSummary";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getUserDownline(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_getUserDownline";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                                               new SqlParameter("@StandingPosition",objuser.StandingPosition),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getUserDownlineBusiness(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_getUserDownlineBusiness";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                                               new SqlParameter("@StandingPosition",objuser.StandingPosition),
                                               new SqlParameter("@BusinessType",objuser.BusinessType),
                                               new SqlParameter("@FromDate",objuser.FromDate),
                                               new SqlParameter("@ToDate",objuser.ToDate),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getUserDownlineSponserWise(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_getUserDownlineSponserWise";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getUserLevelReport(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_getUserLevelReport";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                                               new SqlParameter("@LevelNo",objuser.LevelNo),
                                               new SqlParameter("@Status",objuser.Status),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getLevel(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_get_LevelNo";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getUserDirectDownline(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_getUserDirectDownline";
                SqlParameter[] parameter = {
                                               new SqlParameter("@userid",objuser.UserId),
                                               new SqlParameter("@StandingPosition",objuser.StandingPosition),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getUserNameDownline(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                s2 = "sp_getUserDownlineUserName";
                SqlParameter[] parameter = {
                                               new SqlParameter("@SponserId",objuser.SponserId),
                                               new SqlParameter("@userid",objuser.UserId)
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public DataTable getUserDownlineSubadmin(clsUser objUser)
        {
            string str_query = "";
            str_query = @"; WITH MyCTE
AS ( SELECT id,userid,username,   sponserid,0 AS userlevel
FROM userdetail with (nolock) 
WHERE UserId ='" + objUser.UserId + @"'
UNION ALL
SELECT UserDetail.id,userdetail.userid,userdetail.username,  userdetail.sponserid ,MyCTE.userlevel+1 
FROM userdetail with (nolock) 
INNER JOIN MyCTE ON userdetail.sponserid = MyCTE.userid
WHERE userdetail.userid !='" + objUser.UserId + @"' )
SELECT MyCTE.*,ud.username as parentname

FROM MyCTE left join userdetail ud with (nolock)  on mycte.sponserid=ud.userid where mycte.userid!='" + objUser.UserId + @"' and mycte.userid!='INDIA01' order by mycte.userlevel
option (maxrecursion 0)";
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

        public DataTable getDirectDownline(clsUser objUser)
        {
            string str_query = "";
            str_query = "SELECT ud.* FROM UserDetail ud  WHERE ud.sponserid='" + objUser.UserId + "' ";
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
        public DataTable getSingleLegDownlineCount(clsUser objUser)
        {
            string str_query = "";
            str_query = @"; WITH MyCTE
AS ( SELECT id,userid,username,   ParentUserId,1 AS userlevel
FROM userdetail with (nolock)
WHERE UserId ='" + objUser.UserId + @"'
UNION ALL
SELECT UserDetail.id,userdetail.userid,userdetail.username,  userdetail.ParentUserId ,MyCTE.userlevel+1 
FROM userdetail  with (nolock)
INNER JOIN MyCTE ON userdetail.parentuserid = MyCTE.userid
WHERE userdetail.userid !='" + objUser.UserId + @"' )
SELECT  count(id)
FROM MyCTE WHERE userid!='" + objUser.UserId + @"'
option (maxrecursion 0)";
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
        public DataTable FillSubNode(clsUser objuser)
        {
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {
                string qry = "SELECT ad.userid,ad.username,(select count(userid) from userdetail with (nolock)  where sponserid=ad.userid) as Subnode FROM userdetail ad with (nolock)  where ad.sponserid='" + objuser.UserId + "'   and ad.sponserid !=ad.userid ";
                dt = ObjData.RunDataTable(qry);
            }
            catch (Exception v)
            {
                dt = null;
            }
            finally
            {
                ObjData.EndConnection();
            }
            return dt;
        }
        public DataSet Find_UserDetail2(clsUser objuser)
        {

            string s = "";
            string s1 = "";
            DataSet ds = null;
            ObjData.StartConnection();

            try
            {
                s1 = "SELECT ad.userid,ad.UserName,(select count(userid) from userdetail  with (nolock) where sponserid=ad.userid) as Subnode FROM userdetail ad  with (nolock)  where ad.userid='" + objuser.UserId + "'";
                ds = ObjData.RunSelectQuery(s1);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }
        public DataTable getLoginReport(clsUser objUser)
        {
            string str_query = "SELECT ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.Address,ud.CityName,ud.MentionDate,ld.password,ld.status, case when ld.status='1' then 'Active' else 'Deactive' end as loginstatus FROM userdetail ud with (nolock)  left join Logindetail ld  with (nolock)  on ud.userid=ld.username and ld.role='User' where 1=1 ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date,ud.MentionDate)  >= convert(date,'" + objUser.FromDate + "')   and convert(date,ud.MentionDate )  <= convert(date,'" + objUser.ToDate + "') ";
            }
            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
            }
            str_query += " order by ud.username  desc";
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
        public DataTable getLoginReportSubadmin(clsUser objUser)
        {
            string str_query = "SELECT ud.userid, ud.username,ud.Mobile,ud.Email,ud.Gender,ud.Address,ud.CityName,ud.MentionDate,ld.password,ld.status, case when ld.status='1' then 'Active' else 'Deactive' end as loginstatus FROM userdetail ud with (nolock)  left join Logindetail ld  with (nolock)  on ud.userid=ld.username where 1=1 and ud.userid!='INDIA01' ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and ud.MentionDate  >= '" + objUser.FromDate + "'   and ud.MentionDate   <= '" + objUser.ToDate + "' ";
            }
            if (objUser.UserName != "")
            {
                str_query += "  and ud.username = '" + objUser.UserName + "' ";
            }
            if (objUser.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.Mobile != "")
            {
                str_query += "  and ud.mobile = '" + objUser.Mobile + "' ";
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
        public DataTable getUserDetail(clsUser objUser)
        {
            string str_query = "SELECT   isnull((  SELECT sum(pd.coins) FROM PremiumWalletMaster pd WITH (nolock) WHERE pd.UserId=ud.userid),0) as premiumbalance, isnull(IsDummyData,'0') as isdummy,isnull(IsDirectROI,'1') as IsDirectROI2,isnull(IsNormalROI,'1') as IsNormalROI2, convert(nvarchar,ud.mentiondate,103) as mentiondate2, ud.*,isnull(ud.imagename,'default.png') as imagename2,isnull( ud.stateid,0) as stateid,isnull( sm.countryid,0) as countryid,isnull(ewalletbalance,0) as ewalletbalance2,isnull(rwalletbalance,0) as rwalletbalance2,isnull(tradingwalletbalance,0) as tradingwalletbalance,isnull(IStakingApprive,0) as IStakingApprive2 FROM userdetail ud with (nolock)   left join statemaster sm with (nolock)  on ud.stateid=sm.stateid where ud.UserId = '" + objUser.UserId + "' ";
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
        public DataTable getUserDetailForCarryForward(clsUser objUser)
        {
            string str_query = "SELECT isnull(IsDummyData,'0') as isdummy,convert(nvarchar,ud.mentiondate,103) as mentiondate2, ud.userid,ud.username,ud.email,ud.mobile,isnull((SELECT sum (amount) FROM UserCarryForwardDetail uc WITH (nolock) WHERE uc.UserId=ud.userid AND uc.StandingPosition=1 ),0)+isnull((SELECT sum (lbusiness) FROM UserSummaryDetail uc WITH (nolock) WHERE uc.UserId=ud.userid  ),0) AS leftcarry ,isnull((SELECT sum (amount) FROM UserCarryForwardDetail uc WITH (nolock) WHERE uc.UserId=ud.userid AND uc.StandingPosition=2 ),0)+isnull((SELECT sum (rbusiness) FROM UserSummaryDetail uc WITH (nolock) WHERE uc.UserId=ud.userid  ),0) AS rightcarry FROM userdetail ud with (nolock)   where ud.UserId = '" + objUser.UserId + "' ";
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
        public DataTable getUserChild(clsUser objUser)
        {
            string str_query = "SELECT ud.activestatus, ud.SponserId,ud2.UserName AS sponsername, ud.userid, ud.username,ud.mobile,isnull(ud.imagename,'default.png') as imagename,isnull( (select sum (ut.amount) from usertopupdetail ut with (nolock) where ut.userid=ud.userid) ,0) as amount FROM userdetail ud with (nolock) LEFT JOIN userdetail ud2 WITH(nolock) ON ud.SponserId=ud2.UserId LEFT JOIN usertopupdetail ut WITH (nolock) ON ut.UserId=ud.UserId where isnull(ud.parentuserid,'-1')='" + objUser.ParentUserId + "'  and ud.StandingPosition='" + objUser.StandingPosition + "' ";
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
        public DataTable getRightDataPlanWise2(clsUser objUser)
        {
            string str_query = "";

            str_query = @"DECLARE @child NVARCHAR(100)

SELECT @child=userid FROM UserDetail with (nolock)  WHERE ParentUserId='" + objUser.UserId + @"' AND StandingPosition='Right'
; WITH MyCTE
AS ( SELECT id,userid,username,  StandingPosition, ParentUserId,1 AS userlevel,StandingPosition,regdate
FROM userdetail with (nolock) 
WHERE UserId =@child
UNION ALL
SELECT UserDetail.id,userdetail.userid, UserDetail.username,UserDetail.StandingPosition, userdetail.ParentUserId ,MyCTE.userlevel+1 ,userdetail.StandingPosition,userdetail.regdate
FROM userdetail with (nolock) 
INNER JOIN MyCTE ON userdetail.parentuserid = MyCTE.userid
WHERE userdetail.userid !=@child )
 
 SELECT count(id) AS totaluser
 
FROM MyCTE  
option (maxrecursion 0)
";

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
        public DataTable getLeftDataPlanWise2(clsUser objUser)
        {

            string str_query = "";
            str_query = @"DECLARE @child NVARCHAR(100)

SELECT @child=userid FROM UserDetail WHERE ParentUserId='" + objUser.UserId + @"' AND StandingPosition='Left'
; WITH MyCTE
AS ( SELECT id,userid,username,  StandingPosition, ParentUserId,1 AS userlevel,StandingPosition,regdate
FROM userdetail
WHERE UserId =@child
UNION ALL
SELECT UserDetail.id,userdetail.userid, UserDetail.username,UserDetail.StandingPosition, userdetail.ParentUserId ,MyCTE.userlevel+1 ,userdetail.StandingPosition,userdetail.regdate
FROM userdetail
INNER JOIN MyCTE ON userdetail.parentuserid = MyCTE.userid
WHERE userdetail.userid !=@child )
 
 SELECT count(id) AS totaluser
 
FROM MyCTE  
option (maxrecursion 0)
";

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
        public DataTable Insert_User(clsUser objUser)
        {
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataTable dt = new DataTable();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {

                s2 = "sp_add_UserDetailNew";
                SqlParameter[] parameter = {
                    new SqlParameter("@SponserId",objUser.SponserId),
                    new SqlParameter("@username",objUser.UserName),
                    new SqlParameter("@DateofBirth",objUser.DateOfBirth),
                    new SqlParameter("@Gender",objUser.Gender),
                    new SqlParameter("@Email",objUser.Email),
                    new SqlParameter("@Mobile",objUser.Mobile),
                    new SqlParameter("@Address",objUser.Address),
                    new SqlParameter("@CityName",objUser.CityName),
                    new SqlParameter("@AreaName",objUser.AreaName),
                    new SqlParameter("@Pincode",objUser.Pincode),
                    new SqlParameter("@Password",objUser.Password),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@RegType",objUser.Regtype),
                    new SqlParameter("@imagename",objUser.ImageName),
                    new SqlParameter("@Stateid",objUser.StateId),
                   // new SqlParameter("@planid",objUser.PlanId),
                    new SqlParameter("@landmark",objUser.LandMark),
                    new SqlParameter("@StandingPosition",objUser.StandingPosition),
                    new SqlParameter("@IsDummyData",objUser.IsDummyData),
                    //new SqlParameter("@EpinNo",objUser.EpinNo),
                    new SqlParameter("@OperatorType",objUser.OperatorType),
                    new SqlParameter("@OperatorId",objUser.OperatorId),
                    //new SqlParameter("@pannumber",objUser.PanCardNo),
                };
                dt = ObjData.RunDataTableProcedureTRans(s2, tr, parameter);
                res = dt.Rows[0][0].ToString();
                try
                {
                    if (res == "t")
                    {

                        string str_message = "Welcome! You are registered with Rejent Coin USERID - " + dtData.Rows[0]["userid"].ToString() + ", PASSWORD - " + objUser.Password + " and PIN - " + objUser.Password + ".Login to http://rejentcoin.com/user/index.aspx";

                        string url = "http://www.apihub.online/api/Services/transact?token=60414bb3673567377121878d4aa4e326&skey=SST&to=" + objUser.Mobile + "&sender=MALERT&smstext=" + str_message + "&smsformat=TEXT&templateid=1407159749004589939&format=json";
                        string Result = url.CallURL();
                        Insert_SendSMS(objUser.Mobile, Result, url);

                        ObjData.SendEmail("Team RIjent-Registration Details", str_message, objUser.Email);

                    }
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
            return dt;
        }
        public string Edit_User(clsUser objUser)
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

                s2 = "sp_edit_userdetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@username",objUser.UserName),
                    new SqlParameter("@DateofBirth",objUser.DateOfBirth),
                    new SqlParameter("@Gender",objUser.Gender),
                    new SqlParameter("@Email",objUser.Email),
                    new SqlParameter("@Mobile",objUser.Mobile),
                    new SqlParameter("@Address",objUser.Address),
                    new SqlParameter("@CityName",objUser.CityName),
                    new SqlParameter("@AreaName",objUser.AreaName),
                    new SqlParameter("@Pincode",objUser.Pincode),
                    new SqlParameter("@AccountHolderName",objUser.AccHolderName),
                    new SqlParameter("@AccountNo",objUser.AccNo),
                    new SqlParameter("@IFSCCode",objUser.IFSCCode),
                    new SqlParameter("@BankName",objUser.BankName),
                    new SqlParameter("@BranchName",objUser.BranchName),
                    new SqlParameter("@PanNumber",objUser.PanCardNo),
                    new SqlParameter("@imagename",objUser.ImageName),
                    new SqlParameter("@Stateid",objUser.StateId),
                    new SqlParameter("@IsDummyData",objUser.IsDummyData),
                    new SqlParameter("@IsDirectROI",objUser.IsDirectROI),
                    new SqlParameter("@IsNormalROI",objUser.IsNormalROI),
                    new SqlParameter("@userid",objUser.UserId),

                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                try
                {
                    //if (res != "f" && res != "s")
                    //{
                    //    // string url = "http://www.apihub.online/api/Services/transact?token=ce4f9f4c676718405d7033ddb36dee00&skey=SST&to=" + objUser.Mobile + "&sender=ETOPUP&smstext=" + "Dear Sir/Madam you are successfully registered on  securepaysystems.co.in. Your login details are-username:" + res + ", password:" + objUser.Password + "&smsformat=TEXT&format=json";
                    //    string url = "http://sms.sandhyasoftware.com/vendorsms/pushsms.aspx?user=TRCHBG&password=TRCHBG&msisdn=" + objUser.Mobile + "&sid=TRCHBG&msg=" + "Dear User you are successfully registered on Global Telesystems Groupenterprises.com. Your login details are-username:" + res + ", password:" + objUser.Password + "&fl=0&gwid=2";
                    //    string Result = url.CallURL();
                    //    Insert_SendSMS(objUser.Mobile, Result, url);
                    //}
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
        public string Insert_TopupUser(clsUser objUser)
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
                s2 = "sp_add_UserTopupDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@userid",objUser.UserId),
                    new SqlParameter("@Wallettype",objUser.WalletType),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string Insert_ReTopupUser(clsUser objUser)
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
                s2 = "sp_add_UserReTopupDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@userid",objUser.UserId),
                    new SqlParameter("@Wallettype",objUser.WalletType),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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

        public string Insert_TopupAdmin(clsUser objUser)
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
                s2 = "sp_add_UserTopupDetailAdmin";
                SqlParameter[] parameter = {
                    new SqlParameter("@userid",objUser.UserId),
                    new SqlParameter("@wallettype",objUser.WalletType),
                    new SqlParameter("@amount",objUser.Amount),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@sponserentryid",objUser.SponserId),
                    new SqlParameter("@IsDummyTopup",objUser.IsDummyData),
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
        public string Insert_ReTopupAdmin(clsUser objUser)
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
                s2 = "sp_add_UserReTopupDetailAdmin";
                SqlParameter[] parameter = {
                    new SqlParameter("@userid",objUser.UserId),
                    new SqlParameter("@planid",objUser.PlanId),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@sponseruserid",objUser.SponserId),
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
        public string Insert_BTCWalletType(clsUser objUser)
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
                s2 = "sp_add_BTCWalletTypeDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@WalletType",objUser.WalletType),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@ConversionToDollar",objUser.ConversionToDollar),
                    new SqlParameter("@ConversionToQauere",objUser.ConversionToQauere),
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
        public string Insert_BTCWalletAddress(clsUser objUser)
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
                s2 = "sp_add_BTCWalletAddressDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@WalletTypeId",objUser.WalletTypeId),
                    new SqlParameter("@WalletAddress",objUser.WalletAddress),
                    new SqlParameter("@ImageName",objUser.ImageName),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@AccountNo",objUser.AccNo),
                new SqlParameter("@AccountHolderName",objUser.AccHolderName),
                new SqlParameter("@BankName",objUser.BankName),
                new SqlParameter("@IFSCCode",objUser.IFSCCode),
                new SqlParameter("@BranchName",objUser.BranchName),
                new SqlParameter("@IPAddress",objUser.IPAddress),

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
        public string Edit_BTCWalletType(clsUser objUser)
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
                s2 = "sp_edit_BTCWalletTypeDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@Id",objUser.Id),
                    new SqlParameter("@WalletType",objUser.WalletType),
                    new SqlParameter("@ConversionToDollar",objUser.ConversionToDollar),
                    new SqlParameter("@ConversionToQauere",objUser.ConversionToQauere),
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

        public string Edit_BTCWalletAddress(clsUser objUser)
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
                s2 = "sp_edit_BTCWalletAddressDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@Id",objUser.Id),
                    new SqlParameter("@WalletAddress",objUser.WalletAddress),
                    new SqlParameter("@ImageName",objUser.ImageName),
                     new SqlParameter("@AccountNo",objUser.AccNo),
                new SqlParameter("@AccountHolderName",objUser.AccHolderName),
                new SqlParameter("@BankName",objUser.BankName),
                new SqlParameter("@IFSCCode",objUser.IFSCCode),
                new SqlParameter("@BranchName",objUser.BranchName),
                new SqlParameter("@IPAddress",objUser.IPAddress),
                new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string Active_BTCWalletType(clsUser objUser)
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
                s2 = "sp_ActiveBTCWalletType";
                SqlParameter[] parameter = {
                    new SqlParameter("@Id",objUser.Id),
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
        public string Deactive_BTCWalletType(clsUser objUser)
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
                s2 = "sp_DeactiveBTCWalletType";
                SqlParameter[] parameter = {
                    new SqlParameter("@Id",objUser.Id),
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

        public string Insert_SmartContractTransactionDetailResponse(clsUser objUser)
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
                s2 = "sp_InsertSmartContractTransactionDetailResponse";
                SqlParameter[] parameter = {
                    new SqlParameter("@TransactionId",objUser.TransactionId),
                    new SqlParameter("@ReferenceId",objUser.ReferenceId),
                    new SqlParameter("@Response",objUser.Response),
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
        public string Update_SmartContractTransaction(clsUser objUser)
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
                s2 = "sp_EditSmartContractCoinTransaction";
                SqlParameter[] parameter = {
                    new SqlParameter("@Id",objUser.Id),
                    new SqlParameter("@TransactionId",objUser.TransactionId),
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@cramount",objUser.CrAmount),
                    new SqlParameter("@dramount",objUser.DrAmount),
                    new SqlParameter("@transactiontype",objUser.TransactionType),
                    new SqlParameter("@Status",objUser.Status),
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
        public string Insert_UserBTCWalletAddress(clsUser objUser)
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
                s2 = "sp_add_UserBTCWalletAddressDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@WalletTypeId",objUser.WalletTypeId),
                    new SqlParameter("@WalletAddress",objUser.WalletAddress),
                    new SqlParameter("@ImageName",objUser.ImageName),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@UserId",objUser.UserId),
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

        public string Edit_UserBTCWalletAddress(clsUser objUser)
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
                s2 = "sp_edit_UserBTCWalletAddressDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@Id",objUser.Id),
                    new SqlParameter("@WalletAddress",objUser.WalletAddress),
                    new SqlParameter("@ImageName",objUser.ImageName),
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

        public string Active_BTCWalletAdrdess(clsUser objUser)
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
                s2 = "sp_ActiveBTCWalletAddress";
                SqlParameter[] parameter = {
                    new SqlParameter("@Id",objUser.Id),
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
        public string Deactive_BTCWalletAddress(clsUser objUser)
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
                s2 = "sp_DeactiveBTCWalletAddress";
                SqlParameter[] parameter = {
                    new SqlParameter("@Id",objUser.Id),
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

        public string EditUserPlan(clsUser objUser)
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
                s2 = "sp_edit_UserPlan";
                SqlParameter[] parameter = {
                    new SqlParameter("@userid",objUser.UserId),
                    new SqlParameter("@Sponseruserid",objUser.SponserId),
                    new SqlParameter("@planid",objUser.PlanId),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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



        public string User_Activate(clsUser objUser)
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
                s2 = "update logindetail set status='1' where username='" + objUser.UserId + "'";
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
        public string EPinTransfer(clsUser objUser)
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
                dt = ObjData.RunSelectQueryTTrans("select * from userdetail  with (nolock)  where userid='" + objUser.TransferUserId + "'", tr);
                if (dt.Rows.Count > 0)
                {
                    DataTable dtepin = new DataTable();
                    dtepin = ObjData.RunSelectQueryTTrans("SELECT * FROM epinmaster WHERE GenerateUserId='" + objUser.UserId + "' and planid=" + objUser.PlanId + "   AND EPinStatus='Active'", tr);
                    int totalpins = dtepin.Rows.Count;
                    if (totalpins >= objUser.NoOfEpin)
                    {
                        for (int c = 0; c < objUser.NoOfEpin; c++)
                        {
                            s2 = " declare @id int ; set @id=(select isnull(max(id),0)+1 from EPinTransferHistory) ; insert into EPinTransferHistory ( id, EPinNo  ,UserIdFrom  ,    UserIdTo  ,MentionBy ,mentionDate ) values (@id,'" + dtepin.Rows[c]["EPinNo"].ToString() + "','" + objUser.UserId + "','" + objUser.TransferUserId + "','" + objUser.MentionBy + "',[dbo].[getIndianDate]() ) ";
                            ObjData.RunInsUpDelQueryTrans(s2, tr);

                            s2 = "update EPinMaster set generateuserid='" + objUser.TransferUserId + "' where EpinNo='" + dtepin.Rows[c]["EPinNo"].ToString() + "'  ";
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
        public string ReleasePayout(clsUser objUser)
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

                s2 = "sp_Releasepayout";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string ReleaseDirect(clsUser objUser)
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

                s2 = "sp_ReleaseDirectIncome";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string ReleaseROIIncome(clsUser objUser)
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

                s2 = "sp_ReleaseROIIncome";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string UpdateDailyDeduction(clsUser objUser)
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

                s2 = "sp_add_DailyDeductionHistory";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@NewDeduction",objUser.Deduction),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string ReleaseBinaryIncome(clsUser objUser)
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

                s2 = "sp_ReleaseBinaryIncome";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string ReleaseTwiceBinaryIncome(clsUser objUser)
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

                s2 = "sp_ReleaseTwiceBinaryIncome";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public DataTable getFundTransferReport(clsUser objUser)
        {
            string str_query = "SELECT ft.transferamount,ft.transferuserid,ft.mentiondate, ft.userid, ud.username,ud2.username as transferusername FROM Fundtransferdetail ft left join userdetail ud  with (nolock) on ft.userid=ud.userid LEFT JOIN userdetail ud2  with (nolock) ON ft.transferuserid=ud2.userid where 1=1 ";


            if (objUser.FromDate != DateTime.MinValue && objUser.ToDate != DateTime.MinValue)
            {
                str_query += "  and ft.MentionDate  >= '" + objUser.FromDate + "'   and ft.MentionDate   <= '" + objUser.ToDate + "' ";
            }

            if (objUser.UserId != "")
            {
                str_query += "  and ft.UserId = '" + objUser.UserId + "' ";
            }
            if (objUser.TransferUserId != "")
            {
                str_query += "  and ft.transferuserid = '" + objUser.TransferUserId + "' ";
            }

            str_query += " order by ft.MentionDate  desc";

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
        public string FundTransferAdmin(clsUser objUser)
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

                s2 = "sp_add_FundTransferAdmin";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@WalletType",objUser.WalletType),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@Remark",objUser.Remark),
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
        public string Insert_CarryForward(clsUser objUser)
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

                s2 = "sp_add_UserCarryForwardDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@StandingPosition",objUser.StandingPosition),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string Insert_PremiumWallet(clsUser objUser)
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

                s2 = "sp_add_PremiumWalletMaster";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@ReturnPercent",objUser.MonthlyReturn),
                    new SqlParameter("@Days",objUser.Days),
                    new SqlParameter("@Coins",objUser.Coins),
                    new SqlParameter("@Limit",objUser.Limit),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string InsertUserUpgradeDetail(clsUser objUser)
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
                s2 = "sp_add_UserUpgradePlanDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@UserId",objUser.UserId),
                    new SqlParameter("@PrevPackageId",objUser.PrevPackageId),
                    new SqlParameter("@NewPackageID",objUser.PackageId),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string FundDebitAdmin(clsUser objUser)
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

                s2 = "sp_debit_FundTransferAdmin";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@WalletType",objUser.WalletType),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@Remark",objUser.Remark),
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
        public string ResetPassword(clsUser objUser)
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
                s2 = "sp_resetPassword";
                SqlParameter[] parameter = {
                    new SqlParameter("@UserId",objUser.UserId),
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
        public string WalletTransferAdmin(clsUser objUser)
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

                s2 = "sp_add_WalletTransferAdmin";
                SqlParameter[] parameter = {
                    new SqlParameter("@FromUserId",objUser.UserId),
                    new SqlParameter("@ToUserId",objUser.TransferUserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@Remark",objUser.Remark),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string FundTransfer(clsUser objUser)
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

                s2 = "sp_FundTransfer";
                SqlParameter[] parameter = {
                    new SqlParameter("@UserId",objUser.UserId),
                    new SqlParameter("@TransferUserid",objUser.TransferUserId),
                    new SqlParameter("@TransferAmount",objUser.TransferAmount),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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

        public string SponserEdit(clsUser objUser)
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
                s2 = "sp_editSponser";
                SqlParameter[] parameter = {
                    new SqlParameter("@UserId",objUser.UserId),
                    new SqlParameter("@OldSponserId",objUser.SponserId),
                    new SqlParameter("@NewSponserId",objUser.NewSponserId),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string WalletTransferUser(clsUser objUser)
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
                s2 = "sp_add_WalletTransferUser";
                SqlParameter[] parameter = {
                    new SqlParameter("@FromUserId",objUser.UserId),
                    new SqlParameter("@ToUserId",objUser.TransferUserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@Remark",objUser.Remark),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string MWalletToEWalletTransfer(clsUser objUser)
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
                s2 = "sp_add_MWalletToEWallet";
                SqlParameter[] parameter = {
                    new SqlParameter("@userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@Remark",objUser.Remark),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                      new SqlParameter("@ConvertedAmount",objUser.ConvertedAmount),
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
        public DataTable insert_WithdrawalIntiate(clsUser objuser)
        {
            string s2 = "";
            DataTable dt = new DataTable();
            ObjData.StartConnection();
            try
            {

                s2 = "sp_WithdrawlCoinInitiate";
                SqlParameter[] parameter = {
                                               new SqlParameter("@amount",objuser.Amount),
                                               new SqlParameter("@MentionBy",objuser.MentionBy),
                                               new SqlParameter("@userid",objuser.UserId),
                                               new SqlParameter("@WalletType",objuser.WalletType),
                };
                dt = ObjData.RunDataTableProcedure(s2, parameter);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ObjData.EndConnection();

            }
            return dt;
        }
        public string TWalletToMWalletTransfer(clsUser objUser)
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
                s2 = "sp_add_TWalletToMWallet";
                SqlParameter[] parameter = {
                    new SqlParameter("@userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@Remark",objUser.Remark),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string MWalletToRWalletTransfer(clsUser objUser)
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
                s2 = "sp_add_MWalletToRWallet";
                SqlParameter[] parameter = {
                    new SqlParameter("@userid",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@Remark",objUser.Remark),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                      new SqlParameter("@AdminCharge",objUser.AdminCharge),
                    new SqlParameter("@TotalAmount",objUser.TotalAmount),
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
        public string ReverseWalletTransfer(clsUser objUser)
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
                s2 = "sp_reverse_WalletTransfer";
                SqlParameter[] parameter = {
                    new SqlParameter("@id",objUser.Id),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string InsertFundRequest(clsUser objUser)
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
                s2 = "sp_add_FundRequestDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@UserId",objUser.UserId),
                    new SqlParameter("@Amount",objUser.Amount),
                    new SqlParameter("@ConversionRate",objUser.ConversionRate),
                    new SqlParameter("@ConvertedAmount",objUser.ConvertedAmount),
                    new SqlParameter("@wallettypeid",objUser.WalletTypeId),
                    new SqlParameter("@WalletAddressId",objUser.WalletAddressId),
                    new SqlParameter("@WalletAddress",objUser.WalletAddress),
                    new SqlParameter("@OnlineTransactionId",objUser.OnlineTransactionId),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@DepositWalletType",objUser.DepositWalletType),
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
        public string InsertStacking(clsUser objUser)
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
                s2 = "sp_add_StackingDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@UserId",objUser.UserId),
                    new SqlParameter("@Coins",objUser.Amount),
                    new SqlParameter("@PlanId",objUser.PlanId),
                    new SqlParameter("@TransactionHash",objUser.OnlineTransactionId),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@DollarAmount",objUser.DollarAmount),
                    new SqlParameter("@QaureCoinToDollar",objUser.QaureCoinToDollar),
                    new SqlParameter("@Type",objUser.Type),
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

        public string UpdateFundRequest(clsUser objUser)
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
                s2 = "sp_update_FundRequest";
                SqlParameter[] parameter = {
                    new SqlParameter("@id",objUser.Id),
                    new SqlParameter("@status",objUser.Status),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@Remark",objUser.Remark),
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
        public string UpdateStckingRequest(clsUser objUser)
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
                s2 = "sp_update_StackingRequest";
                SqlParameter[] parameter = {
                    new SqlParameter("@id",objUser.Id),
                    new SqlParameter("@status",objUser.Status),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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

        public string InsertSmartContractRequestResponse(clsUser objUser)
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
                s2 = "sp_add_SmartContractRequestResponse";
                SqlParameter[] parameter = {
                    new SqlParameter("@Request",objUser.Request),
                    new SqlParameter("@Response",objUser.Response),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
                    new SqlParameter("@TransactionId",objUser.TransactionId),
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
        public string Insert_AccountDetailEditRequest(clsUser objUser)
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
                s2 = "sp_add_UserAccountDetailRequest";
                SqlParameter[] parameter = {
                    new SqlParameter("@userid",objUser.UserId),
                    new SqlParameter("@AccountHolderName",objUser.AccHolderName),
                    new SqlParameter("@AccountNo",objUser.AccNo),
                    new SqlParameter("@IFSCCode",objUser.IFSCCode),
                    new SqlParameter("@BankName",objUser.BankName),
                    new SqlParameter("@BranchName",objUser.BranchName),
                    new SqlParameter("@PanNumber",objUser.PanCardNo),
                    new SqlParameter("@PassbookImagename",objUser.ImageName),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string Insert_Offer(clsUser objUser)
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
                s2 = "sp_add_offerdetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@imagename",objUser.ImageName),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string Delete_Offer(clsUser objUser)
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
                s2 = "sp_delete_offerdetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@id",objUser.Id),
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

        public string Insert_EmailVerification(clsUser objUser)
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
                s2 = "sp_EmailVerificationRequest";
                SqlParameter[] parameter = {
                    new SqlParameter("@UserId",objUser.UserId),
                    new SqlParameter("@Data",objUser.Data),
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
        public string Update_EmailVerificationStatus(clsUser objUser)
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
                s2 = "sp_VerifyEmail";
                SqlParameter[] parameter = {
                    new SqlParameter("@Data",objUser.Data),
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
        public string Update_MobileVerificationStatus(clsUser objUser)
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
                s2 = "sp_MobileVerification";
                SqlParameter[] parameter = {
                    new SqlParameter("@Userid",objUser.UserId),
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
        public string Update_TrustWalletAddress(clsUser objUser)
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
                s2 = "sp_edit_trustwalletaddress";
                SqlParameter[] parameter = {
                    new SqlParameter("@TrustWalletAddress",objUser.TrustWalletAddress),
                    new SqlParameter("@Userid",objUser.UserId),
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
        public string SendPassword(clsUser objUser)
        {

            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataTable dt = new DataTable();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "SELECT ud.userid,ud.mobile,ld.Password,ud.email FROM UserDetail ud WITH  (nolock)  LEFT JOIN logindetail ld WITH (nolock) ON ud.UserId=ld.Username  AND ld.role='user'  where ud.userid='" + objUser.UserId + "' ";
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {
                    objUser.Mobile = dt.Rows[0]["mobile"].ToString();
                    string password = dt.Rows[0]["password"].ToString();

                    string str_message = "Your Account User ID - " + objUser.UserId + ", Password - " + password + " and PIN - " + password + ".Login to " + "http://https://teamrijent.in/user" + " Thanks Team Rejent Coin";

                    //string url = "http://www.apihub.online/api/Services/transact?token=60414bb3673567377121878d4aa4e326&skey=SST&to=" + objUser.Mobile+"&sender=MALERT&smstext="+ str_message + "&smsformat=TEXT&templateid=1407161571275702878&format=json";
                    //string Result = url.CallURL();
                    //Insert_SendSMS(objUser.Mobile, Result, url);

                    ObjData.send_sms(objUser.Mobile, str_message, "1407159749010714374");
                    try
                    {
                        ObjData.SendEmail("Team Rijent Forget Password", str_message, dt.Rows[0]["email"].ToString());
                    }
                    catch { }


                    res = objUser.Mobile;
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
        public string SendOTP(clsUser objUser)
        {

            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataTable dt = new DataTable();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "SELECT ud.userid,ud.mobile,ud.email FROM UserDetail ud WITH  (nolock)    where ud.userid='" + objUser.UserId + "' ";
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {
                    objUser.Mobile = dt.Rows[0]["mobile"].ToString();

                    string str_message = "Your  One Time Password(OTP) is " + objUser.OTP + "";


                    ObjData.send_sms(objUser.Mobile, str_message, "1407159749010714374");
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
        public string SendEmailVerification(clsUser objUser)
        {

            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataTable dt = new DataTable();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "SELECT ud.userid,ud.mobile,ud.email FROM UserDetail ud WITH  (nolock)    where ud.userid='" + objUser.UserId + "' ";
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {
                    ObjData.SendEmail(objUser.EmailSubject, objUser.EmailBody, dt.Rows[0]["email"].ToString());


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
        public string SendEmailOTPAdmin(clsUser objUser)
        {

            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataTable dt = new DataTable();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "SELECT * FROM CompanySettingDetail ud WITH (nolock) ";
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {
                    ObjData.SendEmail(objUser.EmailSubject, objUser.EmailBody, dt.Rows[0]["CareEmail"].ToString());
                    Insert_SendSMS(dt.Rows[0]["CareEmail"].ToString(), "", objUser.EmailBody);


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
        public string SendEmailOTPAdminLogin(clsUser objUser)
        {

            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataTable dt = new DataTable();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "SELECT * FROM CompanySettingDetail ud WITH  (nolock)    ";
                dt = ObjData.RunSelectQueryTTrans(s2, tr);


                if (dt.Rows.Count > 0)
                {




                    ObjData.SendEmail(objUser.EmailSubject, objUser.EmailBody, dt.Rows[0]["OTPEmail"].ToString());
                   // Insert_SendSMS(dt.Rows[0]["OTPEmail"].ToString(), "", "Dear User OTP is");
                    Insert_SendSMS(dt.Rows[0]["OTPEmail"].ToString(), "", objUser.EmailBody);



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
        public string SendPasswordMail(clsUser objUser)
        {

            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataTable dt = new DataTable();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "SELECT ud.userid,ud.mobile,ud.email FROM UserDetail ud WITH  (nolock)    where ud.userid='" + objUser.UserId + "' ";
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {
                    ObjData.SendEmail(objUser.EmailSubject, objUser.EmailBody, dt.Rows[0]["email"].ToString());


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

        public string senddms()
        {
            string url = "http://www.apihub.online/api/Services/transact?token=ce4f9f4c676718405d7033ddb36dee00&skey=SST&to=8957737107&sender=ETOPUP&smstext=ttt&smsformat=TEXT&format=json";
            //ObjData.SendMsg("8957737107", "hello");
            string Result = url.CallURL();
            return Result;
        }
        public string User_Deactivate(clsUser objUser)
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
                s2 = "update logindetail set status='0' where username='" + objUser.UserId + "'";
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
        public string Update_UserProfile(clsUser objUser)
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
                s2 = "update UserDetail  set username='" + objUser.UserName + "', email='" + objUser.Email + "',dateofbirth='" + objUser.DateOfBirth.ToString("yyyy/MM/dd") + "',gender='" + objUser.Gender + "' ,mobile='" + objUser.Mobile + "', address='" + objUser.Address + "', CityName='" + objUser.CityName + "',areaName='" + objUser.AreaName + "' ,pincode='" + objUser.Pincode + "',imagename='" + objUser.ImageName + "',stateid='" + objUser.StateId + "',AccountHolderName='" + objUser.AccHolderName + "',AccountNo='" + objUser.AccNo + "',IFSCCode='" + objUser.IFSCCode + "',BankName='" + objUser.BankName + "',BranchName='" + objUser.BranchName + "',PanNumber='" + objUser.PanCardNo + "'  where UserId='" + objUser.UserId + "'   ";
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
        public string Update_UserProfile2(clsUser objUser)
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
                s2 = "update UserDetail  set username='" + objUser.UserName + "', email='" + objUser.Email + "',dateofbirth='" + objUser.DateOfBirth.ToString("yyyy/MM/dd") + "',gender='" + objUser.Gender + "' ,mobile='" + objUser.Mobile + "', address='" + objUser.Address + "',stateid='" + objUser.StateId + "', CityName='" + objUser.CityName + "',areaName='" + objUser.AreaName + "' ,pincode='" + objUser.Pincode + "',AccountHolderName='" + objUser.AccHolderName + "',AccountNo='" + objUser.AccNo + "',IFSCCode='" + objUser.IFSCCode + "',BankName='" + objUser.BankName + "',BranchName='" + objUser.BranchName + "',PanNumber='" + objUser.PanCardNo + "',NomineeName='" + objUser.NomineeName + "',NomineeRelation='" + objUser.NomineeRelation + "',imagename='" + objUser.ImageName + "',paytmmobileno ='" + objUser.PaytmMobileNo + "'  where UserId='" + objUser.UserId + "'   ";
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
        //public string Update_UserProfilenew(clsUser objUser)
        //{
        //    string res = "";
        //    string s2 = "";
        //    SqlConnection cn;
        //    SqlTransaction tr = null;
        //    DataSet ds = new DataSet();
        //    cn = ObjData.StartConnectionInTransaction();
        //    tr = cn.BeginTransaction(IsolationLevel.Serializable);
        //    try
        //    {
        //        s2 = "update UserDetail  set username='" + objUser.UserName + "', email='" + objUser.Email + "',mobile='" + objUser.Mobile + "', address='" + objUser.Address + "',stateid='" + objUser.StateId + "', CityName='" + objUser.CityName + "',imagename='" + objUser.ImageName + "'  where UserId='" + objUser.UserId + "'   ";
        //        ObjData.RunInsUpDelQueryTrans(s2, tr);
        //        res = "t";
        //        tr.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        res = "0";
        //        tr.Rollback();
        //    }
        //    finally
        //    {
        //        ObjData.EndConnection();
        //        tr.Dispose();
        //    }
        //    return res;
        //}
        public string Update_UserProfilenew(clsUser objUser)
        {
            //string res = "";
            //string s2 = "";
            //SqlConnection cn;
            //SqlTransaction tr = null;
            //DataSet ds = new DataSet();
            //cn = ObjData.StartConnectionInTransaction();
            //tr = cn.BeginTransaction(IsolationLevel.Serializable);
            //try
            //{
            //    s2 = "update UserDetail  set username='" + objUser.UserName + "', email='" + objUser.Email + "',mobile='" + objUser.Mobile + "', address='" + objUser.Address + "',stateid='" + objUser.StateId + "', CityName='" + objUser.CityName + "',imagename='" + objUser.ImageName + "'  where UserId='" + objUser.UserId + "'   ";
            //    ObjData.RunInsUpDelQueryTrans(s2, tr);
            //    res = "t";
            //    tr.Commit();
            //}
            //catch (Exception ex)
            //{
            //    res = "0";
            //    tr.Rollback();
            //}
            //finally
            //{
            //    ObjData.EndConnection();
            //    tr.Dispose();
            //}
            //return res;
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "sp_edit_userdetailnew2";
                SqlParameter[] parameter = {
                    new SqlParameter("@UserId",objUser.UserId),
                    new SqlParameter("@UserName",objUser.UserName),
                    new SqlParameter("@email",objUser.Email),
                    new SqlParameter("@mobile",objUser.Mobile),
                    new SqlParameter("@address",objUser.Address),
                    new SqlParameter("@stateid",objUser.StateId),
                    new SqlParameter("@cityname",objUser.CityName),
                    new SqlParameter("@ImageName",objUser.ImageName),
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

        public string Insert_SendSMS(string str_Mobile, string str_Result, string str_Message)
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
                s2 = "insert into SendSms(CreateDate,Mobile,Result,Message)  values ([dbo].[getIndianDate](),'" + str_Mobile + "','" + str_Result.Replace("'", "''") + "','" + str_Message.Replace("'", "''") + "') ";
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
        public string InsertCallbackRequest(clsUser objUser)
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
                s2 = "sp_add_CallbackRequestDetail";
                SqlParameter[] parameter = {
                    new SqlParameter("@UserId",objUser.UserId),
                    new SqlParameter("@MobileNo",objUser.Mobile),
                    new SqlParameter("@MentionBy",objUser.MentionBy),
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
        public string ValidatePassword(clsUser objUser)
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
                s2 = "sp_ValidatePassword";
                SqlParameter[] parameter = {
                    new SqlParameter("@username",objUser.UserId),
                    new SqlParameter("@password",objUser.Password),
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

        public string sendPromotionalMessage(string str_message)
        {
            string str_query = "select distinct mobile from userdetail with (nolock) WHERE Mobile IS NOT NULL AND len(mobile)=10 and activestatus='1'";

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

            decimal dccounter = Convert.ToDecimal(dt.Rows.Count) / Convert.ToDecimal("100");
            int counter = Convert.ToInt32(Math.Ceiling(dccounter));
            string str_mobile = "";
            for (int i = 1; i <= counter; i++)
            {
                str_mobile = "";
                int c = 1 * i;
                if (i < counter)
                {
                    for (; c <= 100 * i; c++)
                    {
                        str_mobile += dt.Rows[(c - 1)]["mobile"].ToString() + ",";
                    }
                }
                else
                {
                    for (; c <= dt.Rows.Count; c++)
                    {
                        str_mobile += dt.Rows[(c - 1)]["mobile"].ToString() + ",";
                    }
                }
                string url = "http://www.apihub.online/api/Services/transact?token=ce4f9f4c676718405d7033ddb36dee00&skey=SST&to=" + str_mobile + "&sender=ETOPUP&smstext=" + str_message + "&smsformat=TEXT&format=json";
                string Result = url.CallURL();
                Insert_SendSMS(str_mobile, Result, url);
            }
            return "t";
        }


        public DataTable getSmartContactAdd(clsUser objUser)
        {
            string str_query = "(SELECT  SmartContractAddress FROM UserDetail WITH (nolock) WHERE UserId='" + objUser.UserId + "')";
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
