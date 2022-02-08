using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataTier;
using System.Data.SqlClient;
using ARA_StringHunt;

namespace BusinessLogicTier
{
    public class clsAccount
    {
        Data ObjData = new Data();
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string WithdrawlRequestId { get; set; }
        public string WithdrawlAccountType { get; set; }
        public decimal WithdrawlAmount { get; set; }
        public decimal TransactionCharge { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal ConversionRate { get; set; }
        public decimal ConvertedAmount { get; set; }
        public string WalletType { get; set; }
        public string WalletTypeId { get; set; }
        public string WalletAddressId { get; set; }
        public string WalletAddress { get; set; }
        public string TrustWalletAddress { get; set; }
        public string WithdrawlRequestStatus { get; set; }
        public string BusinessType { get; set; }
        public string TransactionId { get; set; }
        public string MentionBy { get; set; }
        public string ROIType { get; set; }
        public DataTable dtData { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ROIDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public DataTable DtLinks { get; set; }
        public string CommitmentRequestId { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
        public decimal CommitmentAmount { get; set; }
        public string CommitmentUserId { get; set; }
        public decimal CurrencyInRs { get; set; }
        public string CurrencyName { get; set; }
        public string TransferUserId { get; set; }
        public decimal ComissionPercent { get; set; }
        public string LevelNo { get; set; }
        public decimal Income { get; set; }
        public decimal JoiningPackage { get; set; }
        public decimal MinDirect { get; set; }
        public string PaymentMode { get; set; }
        public string OnlineTransactionId { get; set; }
        public string Id { get; set; }
        public string TopEntries { get; set; }
        public string TopupUserID { get; set; }
        public string JuniorSponserId { get; set; }


        public DataTable getCurrencyAll()
        {
            string str_query = "select * from currencymaster ";


            DataTable ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunDataTable(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }
        public DataTable getLevelAll()
        {
            string str_query = "select * from levelmaster with (nolock) order by levelno ";


            DataTable ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunDataTable(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }
        public DataTable getCompanyAccountDetail()
        {
            string str_query = "select *,AccountNo+'('+bankname+')' as accno2 from CompanyAccountDetail ";


            DataTable ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunDataTable(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }

        public DataTable getCompanyAccountDetailById(clsAccount objaccount)
        {
            string str_query = "select *,AccountNo+'('+bankname+')' as accno2 from  CompanyAccountDetail where id='" + objaccount.Id + "' ";


            DataTable ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunDataTable(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }

        public DataTable getLevel()
        {
            string str_query = "select * from LevelMaster ";


            DataTable ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunDataTable(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }

        public DataSet getClosingDate()
        {
            string str_query = "SELECT dateadd(dd, 1,max(closingday ) )from ClosingDate; select min(mentiondate) from CommitmentDetail    ";


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

        public DataSet getCommitmentDate()
        {
            string str_query = "SELECT dateadd(dd, 1,max(CommitmentDate) )from CommitmentDateDetail; SELECT min(growthdate) FROM commitmentdetail WHERE GrowthStatus=1   ";


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
        public DataTable getGrowthComission()
        {
            DataTable dt = null;
            ObjData.StartConnection();
            try
            {
                string s2 = "sp_GetSystemSettings";
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

        public DataTable getCommissionStatement(clsAccount objaccount)
        {
            string str_query = "SELECT cl.*,cd.Userid as CommitmentUserid, rm.RankName FROM closingledger cl LEFT JOIN commitmentdetail cd ON cl.CommitmentId=cd.id LEFT JOIN rankmaster rm ON cl.RankId=rm.id   where cl.start_date='" + objaccount.FromDate + "' and  cl.end_date='" + objaccount.ToDate + "' ";

            if (objaccount.UserId != "")
            {
                str_query += "  and cl.userid='" + objaccount.UserId + "'  ";
            }

            str_query += "  order by  cl.userid ";

            DataTable ds = null;
            ObjData.StartConnection();
            try
            {
                ds = ObjData.RunDataTable(str_query);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            ObjData.EndConnection();
            return ds;
        }

        public DataTable getAccountBalance(clsAccount objaccount)
        {
            string str_query = "SELECT isnull(Sum(cramount),0.00)- isnull(sum(dramount),0.00) FROM TransactionDetail  where userid='" + objaccount.UserId + "'    ";


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

        public DataTable getAccountBalanceForGetHelp(clsAccount objaccount)
        {
            string str_query = "SELECT isnull( isnull(Sum(td.cramount),0.00)- isnull(sum(td.dramount),0.00)-( SELECT isnull( sum(wr.FinalAmount),0) FROM  WithdrawlRequest wr WHERE wr.UserId=td.UserID AND wr.Status='Pending'),0) FROM TransactionDetail td   where td.userid='" + objaccount.UserId + "' and wallettype='MWallet' GROUP BY td.UserID    ";

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
        public DataTable getAccountBalanceForGetHelp2(clsAccount objaccount)
        {
            string str_query = "SELECT  isnull(Sum(td.cramount),0.00)- isnull(sum(td.dramount),0.00) FROM TransactionDetail td   where td.userid='" + objaccount.UserId + "' and wallettype='EWallet' GROUP BY td.UserID    ";

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

        public DataTable getUserWalletBalance(clsAccount objaccount)
        {
            string str_query = "select userid,isnull(balanceamount,0) as balanceamount,isnull(ewalletbalance,0) as ewalletbalance,isnull(coinbalance,0) as coinbalance from userdetail with (nolock)  where 1=1 ";

            if (objaccount.UserId != "")
            {
                str_query += "  and UserId = '" + objaccount.UserId + "' ";
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
        public DataTable getUserWalletBalanceForStaking(clsAccount objaccount)
        {
            string str_query = "select userid,isnull(balanceamount,0) as balanceamount,isnull(ewalletbalance,0)-isnull((SELECT sum(fd.coins) FROM StackingDetail fd WITH (nolock) WHERE fd.Status='Pending' AND fd.UserId=ud.userid),0) as ewalletbalance from userdetail ud with (nolock)  where 1=1 ";

            if (objaccount.UserId != "")
            {
                str_query += "  and UserId = '" + objaccount.UserId + "' ";
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

        public DataTable getUserWallet(clsAccount objaccount)
        {
            string str_query = "select td.*,ud.username from transactiondetail td left join userdetail ud on td.userid=ud.userid where 1=1 ";

            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by td.mentiondate  desc";



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

        public DataTable getDirectIncome(clsAccount objaccount)
        {
            string str_query = "select * from transactiondetail where   transactiontype = 'Direct Income' ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and mentiondate  >= '" + objaccount.FromDate + "'   and mentiondate   <= '" + objaccount.ToDate + "' ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and UserId = '" + objaccount.UserId + "' ";
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


        public DataTable getLevelIncome(clsAccount objaccount)
        {
            string str_query = "select  (SELECT count(id) FROM userdetail ud2 WHERE ud2.SponserId=cd.UserId) AS directsponser,  cd.PaymentMode,cd.OnlineTransactionId,  isnull(cd.paymentstatus,'Unpaid') as paymentstatus2,cd.*,cd.CommissionAmount-cd.TDS-cd.AdminDeduction AS finalamount,ud.username,ud.AccountHolderName,ud.AccountNo,ud.IFSCCode,ud.BankName,ud.BranchName,ud.PanNumber from ClosingDetail  cd left join userdetail ud on cd.userid=ud.userid where 1=1 and cd.CommissionAmount>0 ";

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and cd.fromdate  >= '" + objaccount.FromDate + "'   and cd.todate   <= '" + objaccount.ToDate + "' ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
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
        public DataTable getLevelIncomeSubadmin(clsAccount objaccount)
        {
            string str_query = "select  (SELECT count(id) FROM userdetail ud2 WHERE ud2.SponserId=cd.UserId) AS directsponser,  cd.PaymentMode,cd.OnlineTransactionId,  isnull(cd.paymentstatus,'Unpaid') as paymentstatus2,cd.*,cd.CommissionAmount-cd.TDS-cd.AdminDeduction AS finalamount,ud.username,ud.AccountHolderName,ud.AccountNo,ud.IFSCCode,ud.BankName,ud.BranchName,ud.PanNumber from ClosingDetail  cd left join userdetail ud on cd.userid=ud.userid where 1=1 and cd.CommissionAmount>0 and cd.userid!='INDIA01' ";

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and cd.fromdate  >= '" + objaccount.FromDate + "'   and cd.todate   <= '" + objaccount.ToDate + "' ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
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
        public DataTable getPrincipalCashbackDetail(clsAccount objaccount)
        {
            string str_query = "select cd.*,  ud.username,ud.mobile,bm.BankName,ud.BranchName,ud.AccountHolderName,ud.PanNumber,ud.AccountNo,ud.IFSCCode from PrincipalCashbackDetail  cd WITH (nolock) left join userdetail ud WITH (nolock) on cd.userid=ud.userid LEFT JOIN bankmaster bm WITH (nolock) ON ud.BankName=bm.BankId where 1=1 ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, cd.mentiondate ) >= convert(date,  '" + objaccount.FromDate + "' )  and convert(date, cd.mentiondate  ) <= convert(date, '" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
            }
            str_query += "   ORDER BY cd.closingdate desc ";

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
        public DataTable getROIDetail(clsAccount objaccount)
        {
            string str_query = "SELECT top "+objaccount.TopEntries+ " md.Amount,md.ClosingDate,md.Userid,md.TopupId,ut.amount AS topupamount,ut.totalcoin,ut.roidays FROM MintingDetail md WITH (nolock) LEFT JOIN usertopupdetail ut WITH (nolock) ON ut.id=md.TopupId where 1=1 ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, md.mentiondate ) >= convert(date,  '" + objaccount.FromDate + "' )  and convert(date, md.mentiondate  ) <= convert(date, '" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and md.userid = '" + objaccount.UserId + "' ";
            }
            str_query += "   ORDER BY md.id desc ";

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
        public DataTable getROIDetail2(clsAccount objaccount)
        {
            string str_query = "";

            if (objaccount.Id != "0")
            {
                str_query = "SELECT top " + objaccount.TopEntries + "  md.Amount,md.ClosingDate,md.Userid,md.TopupId,ut.amount AS topupamount,md.convertedAmount,ut.totalcoin,ut.roidays, CASE WHEN md.mentionby = '-1' THEN 'Old' ELSE 'New' END AS mintingtype ,CASE WHEN md.mentionby = '-1' THEN '' ELSE convert(NVARCHAR, md.closingdate,103) END AS closingdate2 FROM MintingDetail md WITH(nolock) LEFT JOIN usertopupdetail ut WITH(nolock) ON ut.id = md.TopupId where 1 = 1 ";
            }
            else
            {
                str_query = "SELECT top " + objaccount.TopEntries + " SUM(md.Amount) Amount,SUM(md.convertedAmount) convertedAmount , CAST(md.ClosingDate as date) as ClosingDate FROM MintingDetail md WITH(nolock) LEFT JOIN usertopupdetail ut WITH(nolock) ON ut.id = md.TopupId  where 1 = 1";
            }

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, md.mentiondate ) >= convert(date,  '" + objaccount.FromDate + "' )  and convert(date, md.mentiondate  ) <= convert(date, '" + objaccount.ToDate + "') ";
            }

            if (objaccount.UserId != "")
            {
                str_query += "  and md.userid = '" + objaccount.UserId + "' ";
            }
            if (objaccount.Id != "0")
            {
                str_query += "  and md.topupid = '" + objaccount.Id + "' ";
                str_query += " ORDER BY md.id desc ";
            }
            if (objaccount.Id == "0")
            {
                str_query += "group by md.closingdate order by md.closingdate desc";
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


        public DataTable getMyTopup(clsAccount objaccount)
        {
            string str_query = "SELECT top " + objaccount.TopEntries + " ut.userid,ut.topuptype,ut.Amount,ut.TotalCoin,ut.mentiondate,(SELECT sum(md.amount) FROM MintingDetail md WITH (nolock) WHERE md.TopupId=ut.id) AS totalminting FROM UserTopupDetail ut WITH (nolock)  where 1=1 ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, ut.mentiondate ) >= convert(date,  '" + objaccount.FromDate + "' )  and convert(date, ut.mentiondate  ) <= convert(date, '" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and ut.userid = '" + objaccount.UserId + "' ";
            }
            str_query += "   ORDER BY ut.mentiondate desc ";

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

        public DataTable getMyRenewal(clsAccount objaccount)
        {
            string str_query = "SELECT rd.*,ut.amount AS topupamount ,lm.levelname,ud.username FROM RenewDetail rd WITH (nolock) LEFT JOIN usertopupdetail ut WITH (nolock) ON rd.TopupId=ut.id LEFT JOIN levelmaster lm WITH (nolock) ON lm.levelno=rd.LevelNo left join userdetail ud with (nolock) on ud.userid=rd.userid where 1=1";
            if (objaccount.UserId != "")
            {
                str_query += "  and rd.userid = '" + objaccount.UserId + "' ";
            }
            str_query += "   ORDER BY rd.mentiondate ";

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
        public DataTable getTradingROIDetail(clsAccount objaccount)
        {
            string str_query = "select cd.*,case when cd.roitype='Normal' then 'Cashback Income' when cd.roitype= 'Jodi1' then 'Jode Income' when cd.roitype= 'Jodi2' then 'Twice Jodi Income' else cd.roitype end as Roitype2 ,isnull(cd.paymentstatus,'Due') as paymentstatus2,   ud.username,ud.mobile,bm.BankName,ud.BranchName,ud.AccountHolderName,ud.PanNumber,ud.AccountNo,ud.IFSCCode from TradingROIDetail  cd WITH (nolock) left join userdetail ud WITH (nolock) on cd.userid=ud.userid LEFT JOIN bankmaster bm WITH (nolock) ON ud.BankName=bm.BankId where 1=1 ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, cd.mentiondate ) >= convert(date,  '" + objaccount.FromDate + "' )  and convert(date, cd.mentiondate  ) <= convert(date, '" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
            }
            str_query += "   ORDER BY UD.USERNAME ";

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
        public DataTable getDirectROIDetail(clsAccount objaccount)
        {
            string str_query = "select cd.* ,da.LevelNo,  ud.username,ud.mobile,bm.BankName,ud.BranchName,ud.AccountHolderName,ud.PanNumber,ud.AccountNo,ud.IFSCCode from DirectROIDetail  cd WITH (nolock) left join userdetail ud WITH (nolock) on cd.userid=ud.userid LEFT JOIN bankmaster bm WITH (nolock) ON ud.BankName=bm.BankId LEFT JOIN directroiachievementdetail da WITH (nolock) ON cd.ROIAchievementId=da.id where 1=1 ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, cd.mentiondate ) >= convert(date,  '" + objaccount.FromDate + "' )  and convert(date, cd.mentiondate  ) <= convert(date, '" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
            }
            str_query += "   ORDER BY UD.USERNAME ";

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

        public DataTable getRoyaltyAchievementList(clsAccount objaccount)
        {
            string str_query = "select cd.* ,  ud.username,ud.mobile from RoyaltyAchievementDetail  cd WITH (nolock) left join userdetail ud WITH (nolock) on cd.userid=ud.userid where 1=1 ";
         
            str_query += "   ORDER BY UD.USERNAME ";

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
        public DataTable getLevelIncomeUser(clsAccount objaccount)
        {
            string str_query = "select top "+objaccount.TopEntries+ " cd.*,ud.username , utd.userid TopupUserID  from levelincomedetail  cd with (nolock)" +
                " left join userdetail ud with (nolock) on cd.userid=ud.userid  Inner join [UserTopupDetail] utd with (nolock) on Utd.id=cd.TopupId where 1=1  ";

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and   convert(date, cd.mentiondate)  >=  convert(date,'" + objaccount.FromDate + "' )  and  convert(date,cd.todate  ) <=  convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
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
        public DataTable getLevelAchievementList(clsAccount objaccount)
        {
            string str_query = "select top " + objaccount.TopEntries + " cd.*,ud.username from LevelAchievementDetail  cd with (nolock) left join userdetail ud with (nolock) on cd.userid=ud.userid where 1=1   ";

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and   convert(date, cd.mentiondate)  >=  convert(date,'" + objaccount.FromDate + "' )  and  convert(date,cd.todate  ) <=  convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
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
        public DataTable getDirectIncomeUser(clsAccount objaccount)
        {
            string str_query = "select top "+objaccount.TopEntries+" cd.*,ud.username,ud2.username as juniorusername from Directincomedetail  cd with (nolock) left join userdetail ud with (nolock) on cd.userid=ud.userid left join userdetail ud2 with (nolock) on ud2.userid=cd.junioruserid where 1=1  ";

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and   convert(date, cd.mentiondate)  >=  convert(date,'" + objaccount.FromDate + "' )  and  convert(date,cd.todate  ) <=  convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
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
        public DataTable getSponserMatchingIncomeReport(clsAccount objaccount)
        {
            string str_query = @"SELECT td.* ,  ud.UserName FROM TransactionDetail td WITH(nolock) LEFT JOIN userdetail ud WITH(nolock) ON td.UserID = ud.UserId where td.transactiontype = 'Sponser Matching Income'   ";

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, td.fromdate)  >= convert(date,'" + objaccount.FromDate + "' )  and convert(date,cd.todate  ) <= convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and td.userid = '" + objaccount.UserId + "' ";
            }
            str_query += " order by td.mentiondate  desc";



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
        public DataTable getPayoutReleaseReport(clsAccount objaccount)
        {
            string str_query = "SELECT td.*,ud.UserName FROM TransactionDetail td WITH (nolock) LEFT JOIN userdetail ud WITH (nolock) ON td.UserID=ud.UserId where td.remark like '%Release%'  ";

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, td.mentiondate)  >= convert(date, '" + objaccount.FromDate + "')   and convert(date, td.mentiondate  ) <= convert(date, '" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and td.userid = '" + objaccount.UserId + "' ";
            }
            str_query += " order by td.mentiondate  desc";



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
        public DataTable getSponserIncome(clsAccount objaccount)
        {
            string str_query = @"select cd.PaymentMode,cd.OnlineTransactionId, isnull(cd.paymentstatus,'Unpaid') as paymentstatus2,cd.FromDate,cd.ToDate,cd.UserId,convert(DATE,cd.Mentiondate) AS Mentiondate,
sum(cd.CommissionAmount) AS CommissionAmount,sum(cd.TDS) AS tds,sum(cd.AdminDeduction) AS AdminDeduction,
sum(cd.CommissionAmount)-sum(cd.TDS)-sum(cd.AdminDeduction) AS finalamount,ud.username,ud.AccountHolderName,ud.AccountNo,ud.IFSCCode,ud.BankName,ud.BranchName,ud.PanNumber from sponserClosingDetail  cd left join userdetail ud on cd.userid=ud.userid where 1=1 and cd.CommissionAmount>0
 
";
            //and cd.userid!='0'  

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, cd.fromdate ) =convert(date, '" + objaccount.FromDate + "')   and convert(date,cd.todate)   = convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
            }

            str_query += "  GROUP BY cd.FromDate,cd.ToDate,cd.UserId,cd.PaymentStatus, convert(DATE,cd.Mentiondate),ud.username,ud.AccountHolderName,ud.AccountNo,ud.IFSCCode,ud.BankName,ud.BranchName,ud.PanNumber, cd.PaymentMode,cd.OnlineTransactionId ";
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
        public DataTable getRewardincomeIncome(clsAccount objaccount)
        {
            string str_query = @"select cd.*,ud.username,ud.AccountHolderName,ud.AccountNo,ud.IFSCCode,ud.BankName,ud.BranchName,ud.PanNumber from rewardClosingDetail  cd left join userdetail ud on cd.userid=ud.userid where 1=1 ";
            //and cd.userid!='0'  

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, cd.fromdate ) =convert(date, '" + objaccount.FromDate + "')   and convert(date,cd.todate)   = convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
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
        public DataTable getSponserIncomeSubadmin(clsAccount objaccount)
        {
            string str_query = @"select cd.PaymentMode,cd.OnlineTransactionId, isnull(cd.paymentstatus,'Unpaid') as paymentstatus2,cd.FromDate,cd.ToDate,cd.UserId,convert(DATE,cd.Mentiondate) AS Mentiondate,
sum(cd.CommissionAmount) AS CommissionAmount,sum(cd.TDS) AS tds,sum(cd.AdminDeduction) AS AdminDeduction,
sum(cd.CommissionAmount)-sum(cd.TDS)-sum(cd.AdminDeduction) AS finalamount,ud.username,ud.AccountHolderName,ud.AccountNo,ud.IFSCCode,ud.BankName,ud.BranchName,ud.PanNumber from sponserClosingDetail  cd left join userdetail ud on cd.userid=ud.userid where 1=1 and cd.CommissionAmount>0 and cd.userid!='INDIA01'
 
";
            //and cd.userid!='0'  

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, cd.fromdate ) =convert(date, '" + objaccount.FromDate + "')   and convert(date,cd.todate)   = convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.userid = '" + objaccount.UserId + "' ";
            }

            str_query += "  GROUP BY cd.FromDate,cd.ToDate,cd.UserId,cd.PaymentStatus, convert(DATE,cd.Mentiondate),ud.username,ud.AccountHolderName,ud.AccountNo,ud.IFSCCode,ud.BankName,ud.BranchName,ud.PanNumber, cd.PaymentMode,cd.OnlineTransactionId ";
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

        public DataTable getGrowthReport(clsAccount objaccount)
        {
            string str_query = @"SELECT pm.Commission, pm.LevelNo,pm.TotalJoining,pm.TotalJoining-isnull((SELECT TOP 1 pm2.totaljoining FROM PoolLevelMaster pm2 WHERE pm2.LevelNo<pm.LevelNo ORDER BY pm2.LevelNo desc),0) AS joining
 ,cl.UserLevel, CASE WHEN cl.UserLevel IS NOT NULL THEN pm.TotalJoining-isnull((SELECT TOP 1 pm2.totaljoining FROM PoolLevelMaster pm2 WHERE pm2.LevelNo<pm.LevelNo ORDER BY pm2.LevelNo desc),0)  ELSE 0 END userjoining
 FROM PoolLevelMaster pm WITH (nolock) LEFT JOIN closingdetail cl WITH(nolock) ON pm.levelno=cl.UserLevel AND cl.UserId='" + objaccount.UserId + "' order by  pm.LevelNo ";


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

        public DataTable getWalletTransferReport(clsAccount objaccount)
        {
            string str_query = "select * from WalletTransfer where  1=1 ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and mentiondate  >= '" + objaccount.FromDate + "'   and mentiondate   <= '" + objaccount.ToDate + "' ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and FromUserId = '" + objaccount.UserId + "' ";
            }
            if (objaccount.TransferUserId != "")
            {
                str_query += "  and ToUserId = '" + objaccount.TransferUserId + "' ";
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
        public DataTable getFundTransferReport(clsAccount objaccount)
        {
            string str_query = "select td.*,ud.username from transactiondetail td with (nolock) left join userdetail ud with (nolock) on  ud.userid=td.userid where   td.transactiontype = 'Fund Transfer' ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, td.mentiondate ) >= convert(date,'" + objaccount.FromDate + "' )  and convert(date,td.mentiondate  ) <= convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }
            str_query += " order by td.mentiondate  desc";
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
        public DataTable getCarryForwardReport(clsAccount objaccount)
        {
            string str_query = "select td.*,case when td.standingposition=1 then 'Left' when td.standingposition=2 then 'Right' end as StandingPosition2 from UserCarryForwardDetail td with (nolock) where 1=1 ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, td.mentiondate ) >= convert(date,'" + objaccount.FromDate + "' )  and convert(date,td.mentiondate  ) <= convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }
            str_query += " order by td.mentiondate  desc";
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
        public DataTable getCommissionReleaseReport(clsAccount objaccount)
        {
            string str_query = "select td.*,ud.username,ud.mobile,ud.pannumber from transactiondetail td with (nolock) left join userdetail ud with (nolock) on td.userid=ud.userid where   td.transactiontype='PayoutRelease' ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and td.mentiondate  >= '" + objaccount.FromDate + "'   and td.mentiondate   <= '" + objaccount.ToDate + "' ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }
            str_query += " order by td.mentiondate  desc";
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
        public DataTable getFundDebitReport(clsAccount objaccount)
        {
            string str_query = "select td.*,ud.username from transactiondetail td with (nolock) left join userdetail ud with (nolock) on  ud.userid=td.userid where   td.transactiontype = 'Fund Debit' ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, td.mentiondate ) >= convert(date,'" + objaccount.FromDate + "' )  and convert(date,td.mentiondate  ) <= convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }
            str_query += " order by td.mentiondate  desc";
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
        public DataTable getRoyaltyIncomeReport(clsAccount objaccount)
        {
            string str_query = "select td.*,ud.username from transactiondetail td with (nolock) left join userdetail ud with (nolock) on  ud.userid=td.userid where   td.transactiontype = 'Royalty Income' ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and td.mentiondate  >= '" + objaccount.FromDate + "'   and td.mentiondate   <= '" + objaccount.ToDate + "' ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }
            str_query += " order by td.mentiondate  desc";
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
        public DataTable getBinaryIncome(clsAccount objaccount)
        {
            string str_query = "select top "+objaccount.TopEntries+" cd.*,ud.username,'Matching Income on date '+ convert(nvarchar, cd.closingdate,103) as remark from closingdetail cd with (nolock) left join userdetail ud with (nolock) on cd.userid=ud.userid where 1=1   ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, cd.closingdate ) >= convert(date,'" + objaccount.FromDate + "' )  and convert(date, cd.closingdate )  <= convert(date,'" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.UserId = '" + objaccount.UserId + "' ";
            }
            str_query += " order by cd.closingdate  desc";

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
        public DataTable getRechargeCashbakcIncome(clsAccount objaccount)
        {
            string str_query = "select cd.*,ud.username from RechargeCashbackDetail cd with (nolock) left join userdetail ud with (nolock) on cd.userid=ud.userid where 1=1   ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, cd.mentiondate)  >= convert(date, '" + objaccount.FromDate + "' )  and convert(date, cd.mentiondate)   <= convert(date, '" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.UserId = '" + objaccount.UserId + "' ";
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
        public DataTable getTwiceBinaryIncome(clsAccount objaccount)
        {
            string str_query = "select cd.*,ud.username,'Twice BInary Income on date '+ convert(nvarchar, cd.closingdate,103) as remark from TwiceBinaryIncomeDetail cd with (nolock) left join userdetail ud with (nolock) on cd.userid=ud.userid where 1=1   ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, cd.mentiondate)  >= convert(date, '" + objaccount.FromDate + "')   and convert(date, cd.mentiondate)   <= convert(date, '" + objaccount.ToDate + "') ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and cd.UserId = '" + objaccount.UserId + "' ";
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

        public DataTable getBinaryIncomeSummary(clsAccount objaccount)
        {
            string str_query = "SELECT sum( income) AS amount,ClosingDate FROM ClosingDetail WITH (nolock)  where 1=1   ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and ClosingDate  >= '" + objaccount.FromDate + "'   and ClosingDate   <= '" + objaccount.ToDate + "' ";
            }
            str_query += "  GROUP BY ClosingDate ORDER BY ClosingDate desc";
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
        public DataTable getROIIncomeSummary(clsAccount objaccount)
        {
            string str_query = "SELECT sum( Amount) AS amount, ROIType,ClosingDate FROM ROIDetail WITH (nolock)  where 1=1   ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and ClosingDate  >= '" + objaccount.FromDate + "'   and ClosingDate   <= '" + objaccount.ToDate + "' ";
            }
            if (objaccount.ROIType != "0")
            {
                str_query += " and  roitype= '" + objaccount.ROIType + "' ";
            }
            str_query += "  GROUP BY ClosingDate,roitype ORDER BY ClosingDate desc";
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
        public DataTable getTransactionReport(clsAccount objaccount)
        {

            //string str_tmp = "SELECT * INTO #tmpwallet FROM transactiondetail td with (nolock) where   td.wallettype ='MWallet'   ";
            //if (objaccount.UserId != "")
            //{
            //    str_tmp += "  and td.UserId = '" + objaccount.UserId + "' ";
            //}

            string str_query =  @"select top "+objaccount.TopEntries+" * from transactiondetail td with (nolock) where   1=1 and td.wallettype='MWallet' ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and td.mentiondate  >= '" + objaccount.FromDate + "'   and td.mentiondate   <= '" + objaccount.ToDate + "' ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by td.id  desc ";



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

        public DataTable getSmartContractDeposit(clsAccount objaccount)
        {
            string str_query = @"select top "+objaccount.TopEntries+" * from CoinTransactionDetail td with (nolock) where 1=1 and td.transactiontype='Deposit' ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, td.mentiondate ) >= convert(date,'" + objaccount.FromDate + "')   and convert(date,td.mentiondate )  <= convert(date,'" + objaccount.ToDate + "') ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by td.id  desc ";



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
        public DataTable getSmartContractWithdrawal(clsAccount objaccount)
        {
            string str_query = @"select top " + objaccount.TopEntries + " * from CoinTransactionDetail td with (nolock) where 1=1 and td.transactiontype='Withdrawal' ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, td.mentiondate ) >= convert(date,'" + objaccount.FromDate + "')   and convert(date,td.mentiondate )  <= convert(date,'" + objaccount.ToDate + "') ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by td.id  desc ";



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
        public DataTable getTransactionReportEWallet(clsAccount objaccount)
        {

            //string str_tmp = "SELECT * INTO #tmpwallet FROM TransactionDetail td with (nolock) where 1=1 and wallettype='EWallet'  ";
            //if (objaccount.UserId != "")
            //{
            //    str_tmp += "  and td.UserId = '" + objaccount.UserId + "' ";
            //}

            string str_query =  @"select top "+objaccount.TopEntries+" * from TransactionDetail td with (nolock) where td.wallettype='EWallet' and  1=1 ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and  convert(date, td.mentiondate ) >= convert(date,'" + objaccount.FromDate + "')   and convert(date,td.mentiondate)   <= convert(date,'" + objaccount.ToDate + "') ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by td.mentiondate  desc ";



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
        public DataTable getTransactionReportPremiumWallet(clsAccount objaccount)
        {

            //string str_tmp = "SELECT * INTO #tmpwallet FROM TransactionDetail td with (nolock) where 1=1 and wallettype='EWallet'  ";
            //if (objaccount.UserId != "")
            //{
            //    str_tmp += "  and td.UserId = '" + objaccount.UserId + "' ";
            //}

            string str_query = @"select top " + objaccount.TopEntries + " * from TransactionDetail td with (nolock) where td.wallettype='Premium' and  1=1 ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and  convert(date, td.mentiondate ) >= convert(date,'" + objaccount.FromDate + "')   and convert(date,td.mentiondate)   <= convert(date,'" + objaccount.ToDate + "') ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by td.mentiondate  desc ";



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
        public DataTable getTransactionReportCoinWallet(clsAccount objaccount)
        {

            //string str_tmp = "SELECT * INTO #tmpwallet FROM TransactionDetail td with (nolock) where 1=1 and wallettype='EWallet'  ";
            //if (objaccount.UserId != "")
            //{
            //    str_tmp += "  and td.UserId = '" + objaccount.UserId + "' ";
            //}

            string str_query = @"select top " + objaccount.TopEntries + " * from QauereCoinTransactionDetail td with (nolock) where   1=1 ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and  convert(date, td.mentiondate ) >= convert(date,'" + objaccount.FromDate + "')   and convert(date,td.mentiondate)   <= convert(date,'" + objaccount.ToDate + "') ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by td.mentiondate  desc ";



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
    

        public DataTable getIncomeReport(clsAccount objaccount)
        {



            string str_query = "";

            //if (objaccount.BusinessType == "Paid")
            //{
                str_query = @"SELECT ud.username,ud.userid,convert(DATE,td.MentionDate) AS mentiondate,isnull(pm.Amount,0) AS Amount,isnull(pm.CappingAmount  ,0) AS CappingAmount
,isnull(sum(CASE WHEN td.TransactionType='MatchingIncome' THEN td.CrAmount ELSE 0 END),0) AS BinaryIncome
,isnull(sum(CASE WHEN td.TransactionType='Sponser Matching Income' THEN td.CrAmount ELSE 0 END),0) AS sponsermatching
,isnull(sum(CASE WHEN td.TransactionType='ROIIncome' THEN td.CrAmount ELSE 0 END),0) AS ROIIncome
,isnull(sum(CASE WHEN td.TransactionType='DirectROIIncome' THEN td.CrAmount ELSE 0 END),0) AS directroiincome
,isnull(sum(CASE WHEN td.TransactionType in ('Sponser Matching Income','MatchingIncome','TwiceDirect','ROIIncome','DirectROIIncome') THEN td.CrAmount ELSE 0 END),0) AS TotalIncome
FROM transactiondetail td WITH (nolock) LEFT JOIN userdetail ud WITH (nolock) ON td.userid=ud.userid
LEFT JOIN usertopupdetail ut WITH (nolock) ON ut.UserId=ud.UserId
LEFT JOIN planmaster pm WITH (nolock) ON ut.PlanId=pm.PlanId where 1=1 ";
//            }
//           else  if (objaccount.BusinessType == "Unpaid")
//            {
//                str_query = @"SELECT ud.username,ud.userid,convert(DATE,td.MentionDate) AS mentiondate,pm.Amount,pm.CappingAmount  
//,isnull(sum(CASE WHEN td.TransactionType='MatchingIncome' THEN td.DrAmount ELSE 0 END),0) AS BinaryIncome
//,isnull(sum(CASE WHEN td.TransactionType='DirectIncome' THEN td.DrAmount ELSE 0 END),0) AS DirectIncome
//,isnull(sum(CASE WHEN td.TransactionType='TwiceBinaryIncome' THEN td.DrAmount ELSE 0 END),0) AS TwiceBinaryIncome
//,isnull(sum(CASE WHEN td.TransactionType='TwiceDirect' THEN td.DrAmount ELSE 0 END),0) AS TwiceDirect
//,isnull(sum(CASE WHEN td.TransactionType='ROIIncome' THEN td.DrAmount ELSE 0 END),0) AS ROIIncome
//,isnull(sum(CASE WHEN td.TransactionType='BoosterIncome' THEN td.DrAmount ELSE 0 END),0) AS BoosterIncome
//,isnull(sum(CASE WHEN td.TransactionType in ('BoosterIncome','MatchingIncome','DirectIncome','TwiceBinaryIncome','TwiceDirect','ROIIncome','JodiIncome') THEN td.CrAmount ELSE 0 END),0) AS TotalIncome
//FROM transactiondetail td WITH (nolock) LEFT JOIN userdetail ud WITH (nolock) ON td.userid=ud.userid
//LEFT JOIN usertopupdetail ut WITH (nolock) ON ut.UserId=ud.UserId
//LEFT JOIN epinmaster em WITH (nolock) ON ut.EPinNo=em.EPinNo
//LEFT JOIN planmaster pm WITH (nolock) ON em.PlanId=pm.PlanId where 1=1";
//            }

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date,td.mentiondate)  >=  convert(date,'" + objaccount.FromDate + "')   and  convert(date,td.mentiondate)   <=  convert(date,'" + objaccount.ToDate + "') ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += "GROUP BY ud.userid,ud.username,convert(DATE,td.MentionDate),pm.Amount,pm.CappingAmount ORDER BY convert(DATE,td.MentionDate)";



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
        public DataTable getIncomeReportAdmin(clsAccount objaccount)
        {



            string str_query = "";

            //if (objaccount.BusinessType == "Paid")
            //{
                str_query = @"SELECT ud.username,ud.userid,convert(DATE,td.MentionDate) AS mentiondate,pm.Amount,pm.CappingAmount  ,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber 
,isnull(sum(CASE WHEN td.TransactionType='MatchingIncome' THEN td.CrAmount ELSE 0 END),0)-isnull(sum(CASE WHEN td.TransactionType='Admin Charge' and td.remark like '%Matching Income%' THEN td.DrAmount ELSE 0 END),0) AS BinaryIncome
,isnull(sum(CASE WHEN td.TransactionType='Sponser Matching Income' THEN td.CrAmount ELSE 0 END),0)-isnull(sum(CASE WHEN td.TransactionType='Admin Charge' and td.remark like '%Sponser Matching Income%' THEN td.DrAmount ELSE 0 END),0) AS sponsermatching
,isnull(sum(CASE WHEN td.TransactionType='ROIIncome' THEN td.CrAmount ELSE 0 END),0)-isnull(sum(CASE WHEN td.TransactionType='Admin Charge' and td.remark like '%ROI Income%' THEN td.DrAmount ELSE 0 END),0) AS ROIIncome
,isnull(sum(CASE WHEN td.TransactionType='DirectROIIncome' THEN td.CrAmount ELSE 0 END),0)-isnull(sum(CASE WHEN td.TransactionType='Admin Charge' and td.remark like '%Direct ROI Income%' THEN td.DrAmount ELSE 0 END),0) AS Directroiincome
,isnull(sum(CASE WHEN td.TransactionType in ('MatchingIncome','Sponser Matching Income','DirectROIIncome','ROIIncome') THEN td.CrAmount ELSE 0 END),0)
-isnull(sum(CASE WHEN td.TransactionType='Admin Charge' and (td.remark like '%Matching Income%' OR td.remark like '%Sponser Matching Income%'OR td.remark like '%Direct ROI Income%'OR td.remark like '%ROI Income%') THEN td.DrAmount ELSE 0 END),0)
 AS TotalIncome
FROM transactiondetail td WITH (nolock) LEFT JOIN userdetail ud WITH (nolock) ON td.userid=ud.userid
LEFT JOIN usertopupdetail ut WITH (nolock) ON ut.UserId=ud.UserId
 left join bankmaster bm with (nolock) on ud.bankname=bm.bankid  
LEFT JOIN planmaster pm WITH (nolock) ON ut.PlanId=pm.PlanId where 1=1  ";
//            }
//            else if (objaccount.BusinessType == "Unpaid")
//            {
//                str_query = @"SELECT ud.username,ud.userid,convert(DATE,td.MentionDate) AS mentiondate,pm.Amount,pm.CappingAmount  ,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber 
//,isnull(sum(CASE WHEN td.TransactionType='MatchingIncome' THEN td.DrAmount ELSE 0 END),0) AS BinaryIncome
//,isnull(sum(CASE WHEN td.TransactionType='DirectIncome' THEN td.DrAmount ELSE 0 END),0) AS DirectIncome
//,isnull(sum(CASE WHEN td.TransactionType='TwiceBinaryIncome' THEN td.DrAmount ELSE 0 END),0) AS TwiceBinaryIncome
//,isnull(sum(CASE WHEN td.TransactionType='TwiceDirect' THEN td.DrAmount ELSE 0 END),0) AS TwiceDirect
//,isnull(sum(CASE WHEN td.TransactionType='ROIIncome' THEN td.DrAmount ELSE 0 END),0) AS ROIIncome
//,isnull(sum(CASE WHEN td.TransactionType='JodiIncome' THEN td.DrAmount ELSE 0 END),0) AS JodiIncome
//,isnull(sum(CASE WHEN td.TransactionType in ('JodiIncome','MatchingIncome','DirectIncome','TwiceBinaryIncome','TwiceDirect','ROIIncome','JodiIncome') THEN td.CrAmount ELSE 0 END),0) AS TotalIncome
//FROM transactiondetail td WITH (nolock) LEFT JOIN userdetail ud WITH (nolock) ON td.userid=ud.userid
//LEFT JOIN usertopupdetail ut WITH (nolock) ON ut.UserId=ud.UserId
//LEFT JOIN epinmaster em WITH (nolock) ON ut.EPinNo=em.EPinNo
// left join bankmaster bm with (nolock) on ud.bankname=bm.bankid  
//LEFT JOIN planmaster pm WITH (nolock) ON em.PlanId=pm.PlanId where 1=1";
//            }

            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date,td.mentiondate)  >=  convert(date,'" + objaccount.FromDate + "')   and  convert(date,td.mentiondate)   <=  convert(date,'" + objaccount.ToDate + "') ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and td.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += "  GROUP BY ud.userid,ud.username,convert(DATE,td.MentionDate),pm.Amount,pm.CappingAmount,AccountHolderName, AccountNo, IFSCCode, bm.BankName, BranchName, PanNumber  ORDER BY convert(DATE,td.MentionDate)";



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
        public DataTable getTransactionReportSubadmin(clsAccount objaccount)
        {
            string str_query = "select * from transactiondetail where   1=1 and userid!='INDIA01' ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and mentiondate  >= '" + objaccount.FromDate + "'   and mentiondate   <= '" + objaccount.ToDate + "' ";
            }


            if (objaccount.UserId != "")
            {
                str_query += "  and UserId = '" + objaccount.UserId + "' ";
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
        public DataTable getGrowthIncome(clsAccount objaccount)
        {
            string str_query = "select * from transactiondetail where   transactiontype = 'Growth Income' ";
            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and mentiondate  >= '" + objaccount.FromDate + "'   and mentiondate   <= '" + objaccount.ToDate + "' ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and UserId = '" + objaccount.UserId + "' ";
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
        public DataTable getAccountDetailEditRequest(clsAccount objaccount)
        {
            string str_query = "select wr.*,ud.UserName,bm.bankname as bankname2  from UserAccountDetailRequest wr with (nolock) LEFT JOIN userdetail ud  with (nolock)  ON wr.UserId=ud.UserId LEFT JOIN bankmaster bm WITH (nolock) ON wr.BankName=bm.BankId where 1=1  ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, wr.mentiondate ) >= convert(date,'" + objaccount.FromDate + "')   and convert(date,wr.mentiondate )  <= convert(date,'" + objaccount.ToDate + "') ";
            }



            if (objaccount.WithdrawlRequestStatus != "0")
            {
                str_query += "  and wr.status = '" + objaccount.WithdrawlRequestStatus + "' ";
            }

            if (objaccount.UserId != "")
            {
                str_query += "  and wr.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by wr.mentiondate  desc";



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
        public DataTable getWithdrawlRequest(clsAccount objaccount)
        {
            string str_query = "SELECT  wr.*,wr.convertedfinalamount-wr.convertedamount as convertedtransactioncharge,ud.UserName,ud.SponserId,ud2.UserName AS Sponsername,bm.BankName,ud.BranchName,ud.AccountHolderName,ud.PanNumber,ud.AccountNo,ud.IFSCCode,ud.balanceamount  from withdrawlrequest wr with (nolock)  LEFT JOIN userdetail ud with (nolock)  ON wr.UserId=ud.UserId LEFT JOIN userdetail ud2 ON ud2.UserId=ud.SponserId LEFT JOIN bankmaster bm WITH (nolock) ON ud.BankName=bm.BankId where 1=1  ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date, wr.mentiondate ) >= convert(date, '" + objaccount.FromDate + "')   and convert(date, wr.mentiondate  ) <= convert(date, '" + objaccount.ToDate + "') ";
            }



            if (objaccount.WithdrawlRequestStatus != "0")
            {
                str_query += "  and wr.status = '" + objaccount.WithdrawlRequestStatus + "' ";
            }

            if (objaccount.UserId != "")
            {
                str_query += "  and wr.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by wr.mentiondate  desc";



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
        public DataTable getWithdrawlReport(clsAccount objaccount)
        {
            string str_query = "select * from transactiondetail with (nolock) where 1=1 and wallettype='MWallet' and dramount>0 ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and convert(date,mentiondate ) >= convert(date,'" + objaccount.FromDate + "' )  and convert(date,mentiondate  ) <= convert(date,'" + objaccount.ToDate + "') ";
            }
            
            if (objaccount.UserId != "")
            {
                str_query += "  and UserId = '" + objaccount.UserId + "' ";
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
        public DataTable getWithdrawlRequestNew(clsAccount objaccount)
        {
            string str_query = "select wr.*,[dbo].[getIndianDate]() as todaydate,convert(DECIMAL(18,2),  (wr.Amount*10)/100) AS admincharge,convert(DECIMAL(18,2), wr.Amount-((wr.Amount*10)/100 ))AS finalamount2,ud.UserName,ud.email,ud.SponserId,ud2.UserName AS Sponsername,bm.BankName,ud.BranchName,ud.AccountHolderName,ud.PanNumber,ud.AccountNo,ud.IFSCCode,ud.balanceamount  from withdrawlrequest wr with (nolock)  LEFT JOIN userdetail ud with (nolock)  ON wr.UserId=ud.UserId LEFT JOIN userdetail ud2 ON ud2.UserId=ud.SponserId LEFT JOIN bankmaster bm WITH (nolock) ON ud.BankName=bm.BankId where 1=1  ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and wr.mentiondate  >= '" + objaccount.FromDate + "'   and wr.mentiondate   <= '" + objaccount.ToDate + "' ";
            }



            if (objaccount.WithdrawlRequestStatus != "0")
            {
                str_query += "  and wr.status = '" + objaccount.WithdrawlRequestStatus + "' ";
            }

            if (objaccount.UserId != "")
            {
                str_query += "  and wr.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by wr.mentiondate  desc";



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
        public DataTable getWithdrawlRequestSubadmin(clsAccount objaccount)
        {
            string str_query = "select wr.*,convert(DECIMAL(18,2),  (wr.Amount*15)/100) AS admincharge,convert(DECIMAL(18,2), wr.Amount-((wr.Amount*15)/100 ))AS finalamount,ud.UserName,ud.SponserId,ud2.UserName AS Sponsername from withdrawlrequest wr LEFT JOIN userdetail ud ON wr.UserId=ud.UserId LEFT JOIN userdetail ud2 ON ud2.UserId=ud.SponserId where 1=1  and wr.userid!='INDIA01' ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and wr.mentiondate  >= '" + objaccount.FromDate + "'   and wr.mentiondate   <= '" + objaccount.ToDate + "' ";
            }



            if (objaccount.WithdrawlRequestStatus != "0")
            {
                str_query += "  and wr.status = '" + objaccount.WithdrawlRequestStatus + "' ";
            }

            if (objaccount.UserId != "")
            {
                str_query += "  and wr.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by wr.mentiondate  desc";



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


        public DataTable getWithdrawlRequestForLink(clsAccount objaccount)
        {
            string str_query = "select wr.*,ud.UserName,ud.SponserId,ud2.UserName AS Sponsername from withdrawlrequest wr LEFT JOIN userdetail ud ON wr.UserId=ud.UserId LEFT JOIN userdetail ud2 ON ud2.UserId=ud.SponserId where 1=1 and wr.status = 'Pending'  and wr.userid !='" + objaccount.CommitmentUserId + "' ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and wr.mentiondate  >= '" + objaccount.FromDate + "'   and wr.mentiondate   <= '" + objaccount.ToDate + "' ";
            }

            if (objaccount.UserId != "")
            {
                str_query += "  and wr.UserId = '" + objaccount.UserId + "' ";
            }


            str_query += " order by wr.mentiondate  desc";



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



        //public DataTable getROIDetail(clsAccount objaccount)
        //{
        //    string str_query = "select rd.*,ud.username,pd.planname from roidetail rd left join userdetail ud on rd.userid=ud.userid  left join planmaster pd on ud.planid=pd.planid  where 1=1 and detail = 'Direct ROI' ";


        //    if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
        //    {
        //        str_query += "  and rd.roidate  >= '" + objaccount.FromDate + "'   and rd.roidate   <= '" + objaccount.ToDate + "' ";
        //    }

        //    if (objaccount.UserId != "")
        //    {
        //        str_query += "  and ud.UserId = '" + objaccount.UserId + "' ";
        //    }

        //    if (objaccount.UserName != "")
        //    {
        //        str_query += "  and ud.Username like '%" + objaccount.UserName + "%' ";
        //    }


        //    str_query += " order by ud.mentiondate  desc";



        //    DataTable dt = null;
        //    ObjData.StartConnection();
        //    try
        //    {
        //        dt = ObjData.RunDataTable(str_query);
        //    }
        //    catch (Exception ex)
        //    {
        //        dt = null;
        //    }
        //    ObjData.EndConnection();
        //    return dt;
        //}


        public DataTable getClosingStatementDetail(clsAccount objaccount)
        {
            string str_query = "select rd.*,ud.username from closingdetail rd left join userdetail ud on rd.userid=ud.userid    where 1=1 and rd.publishstatus='0'  ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and rd.closingdate  >= '" + objaccount.FromDate + "'   and rd.closingdate   <= '" + objaccount.ToDate + "' ";
            }

            if (objaccount.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objaccount.UserId + "' ";
            }

            if (objaccount.UserName != "")
            {
                str_query += "  and ud.Username like '%" + objaccount.UserName + "%' ";
            }


            str_query += " order by rd.closingdate  desc";



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

        public DataTable getClosingDetail(clsAccount objaccount)
        {
            string str_query = "select rd.*,ud.username from closingdetail rd left join userdetail ud on rd.userid=ud.userid    where 1=1  and rd.publishstatus='1'  ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and rd.closingdate  >= '" + objaccount.FromDate + "'   and rd.closingdate   <= '" + objaccount.ToDate + "' ";
            }

            if (objaccount.UserId != "")
            {
                str_query += "  and ud.UserId = '" + objaccount.UserId + "' ";
            }

            if (objaccount.UserName != "")
            {
                str_query += "  and ud.Username like '%" + objaccount.UserName + "%' ";
            }


            str_query += " order by rd.closingdate  desc";



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


        public DataTable getROIDetailSummary(clsAccount objaccount)
        {
            string str_query = "SELECT  sum(roiamount ) AS roiamount,roidate,max(mentiondate) AS mentiondate FROM ROIDetail  where 1=1 ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and roidate  >= '" + objaccount.FromDate + "'   and roidate   <= '" + objaccount.ToDate + "' ";
            }


            str_query += "     GROUP BY ROIDate    order by roidate  desc";



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


        public DataTable getHelpLink(clsAccount objaccount)
        {
            string str_query = "SELECT hd.*,ud.UserName AS ReceiverName FROM HelpLinkDetail hd LEFT JOIN userdetail ud ON ud.UserId=hd.ReceiverId WHERE hd.DonarId='" + objaccount.UserId + "' order by hd.mentiondate";

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


        public DataTable getFundCreditReport(clsAccount objaccount)
        {
            string str_query = "SELECT td.*,ud.UserName FROM TransactionDetail td LEFT JOIN userdetAil ud ON td.UserID=ud.UserId WHERE td.cramount>0 ";


            if (objaccount.FromDate != DateTime.MinValue && objaccount.ToDate != DateTime.MinValue)
            {
                str_query += "  and td.mentiondate  >= '" + objaccount.FromDate + "'   and td.mentiondate   <= '" + objaccount.ToDate + "' ";
            }
            if (objaccount.UserId != "")
            {
                str_query += "  and td.userid  = '" + objaccount.UserId + "'  ";
            }


            str_query += " order by td.mentiondate ";



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


        public DataTable getWalletReport(clsAccount objaccount)
        {
            string str_query = "SELECT isnull((SELECT isnull(sum(td.cramount),0)-isnull(sum(td.dramount),0)  FROM TransactionDetail td WHERE td.UserID=ud.UserId ),0) AS BalanceAmount, ud.SponserId, ud2.UserName AS sponsername , ud.Email,ud.username,ud.userid,pm.planamount  from userdetail ud   left join planmaster pm on ud.planid=pm.planid  LEFT JOIN userdetail ud2 ON ud.SponserId=ud2.UserId  where 1=1 ";
            if (objaccount.UserId != "")
            {
                str_query += " and  ud.userid='" + objaccount.UserId + "'";
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


        public string FundCredit(clsAccount objAccount)
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

                s2 = "SELECT * FROM userdetail WHERE userid='" + objAccount.UserId + "' ";
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {
                    s2 = "declare @id int; set @id=(select isnull(max(transactionid),0)+1 from  TransactionDetail);  insert into TransactionDetail (transactionid,cramount ,dramount ,userid ,transactiontype ,remark, mentionby,mentiondate)  values (@id," + objAccount.Amount + ",0,'" + objAccount.UserId + "','Admin Credit','" + objAccount.Remark + "','" + objAccount.MentionBy + "',[dbo].[getIndianDate]())";
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

        public string FundDebit(clsAccount objAccount)
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

                s2 = "SELECT * FROM userdetail WHERE userid='" + objAccount.UserId + "' ";
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {
                    s2 = "declare @id int; set @id=(select isnull(max(transactionid),0)+1 from  TransactionDetail);  insert into TransactionDetail (transactionid,dramount ,cramount ,userid ,transactiontype ,remark, mentionby,mentiondate)  values (@id," + objAccount.Amount + ",0,'" + objAccount.UserId + "','Admin Debit','" + objAccount.Remark + "','" + objAccount.MentionBy + "',[dbo].[getIndianDate]())";
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


        public string UpdateLevelMaster(clsAccount objAccount)
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
                s2 = "update levelmaster set comissionpercent='" + objAccount.ComissionPercent + "' where [level]='" + objAccount.LevelNo + "'";
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

        public string Generate_Growth(clsAccount objaccount)
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
                s2 = "sp_GenerateGrowth";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@ClosingDate",objaccount.ClosingDate),
                new SqlParameter("@MentionBy",objaccount.MentionBy)
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
        public string Insert_Level(clsAccount objaccount)
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
                s2 = "sp_add_LevelMaster";
                SqlParameter[] parameter = {
                new SqlParameter("@LevelNo",objaccount.LevelNo),
                new SqlParameter("@Income",objaccount.Income),
                new SqlParameter("@JoiningPackage",objaccount.JoiningPackage),
                new SqlParameter("@MentionBy",objaccount.MentionBy),
                new SqlParameter("@MinDirect",objaccount.MinDirect),
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
        public string Update_Level(clsAccount objaccount)
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
                s2 = "sp_edit_LevelMaster";
                SqlParameter[] parameter = {
                new SqlParameter("@LevelNo",objaccount.LevelNo),
                new SqlParameter("@Income",objaccount.Income),
                new SqlParameter("@JoiningPackage",objaccount.JoiningPackage),
                new SqlParameter("@MinDirect",objaccount.MinDirect),
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
        public string ROIpayment(clsAccount objaccount)
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
                s2 = "sp_ROIPayment";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@dtsave",objaccount.dtData),
                new SqlParameter("@MentionBy",objaccount.MentionBy)
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                if (res == "t")
                {
                    //decimal dccounter = Convert.ToDecimal(dtData.Rows.Count) / Convert.ToDecimal("100");
                    //int counter = Convert.ToInt32(Math.Ceiling(dccounter));
                    //string str_mobile = "";
                    //for (int i = 1; i <= counter; i++)
                    //{
                    //str_mobile = "";
                    //int c = 1 * i;
                    //if (i < counter)
                    //{
                    //    for (; c <= 100 * i; c++)
                    //    {
                    //        str_mobile = dtData.Rows[(c - 1)]["mobile"].ToString() + ",";
                    //    }
                    //}
                    //else
                    //{
                    //    for (; c <= dtData.Rows.Count; c++)
                    //    {
                    //        str_mobile = dtData.Rows[(c - 1)]["mobile"].ToString() + ",";
                    //    }
                    //}

                    //}
                    foreach (DataRow r in dtData.Rows)
                    {
                        string url = "http://www.apihub.online/api/Services/transact?token=537a87b8c53798f133c6e2a5294c83fd&skey=SST&to=" + r["mobile"].ToString() + "&sender=ETOPUP&smstext=" + "Dear User your ROI Income of amount " + r["amount"].ToString() + " for date " + Convert.ToDateTime(r["closingdate"].ToString()).ToString("dd/MM/yyyy") + " is credited in your bank account.SecurePaySystem&smsformat=TEXT&format=json";
                        string Result = url.CallURL();
                        Insert_SendSMS(r["mobile"].ToString(), Result, url);
                    }
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
        public string ROIpaymentNew(clsAccount objaccount)
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
                s2 = "sp_ROIPaymentNew";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@dtsave",objaccount.dtData),
                new SqlParameter("@MentionBy",objaccount.MentionBy)
                };
                res = ObjData.RunInsUpDelQueryTransProcScalar(s2, tr, parameter);
                if (res == "t")
                {
                    //decimal dccounter = Convert.ToDecimal(dtData.Rows.Count) / Convert.ToDecimal("100");
                    //int counter = Convert.ToInt32(Math.Ceiling(dccounter));
                    //string str_mobile = "";
                    //for (int i = 1; i <= counter; i++)
                    //{
                    //str_mobile = "";
                    //int c = 1 * i;
                    //if (i < counter)
                    //{
                    //    for (; c <= 100 * i; c++)
                    //    {
                    //        str_mobile = dtData.Rows[(c - 1)]["mobile"].ToString() + ",";
                    //    }
                    //}
                    //else
                    //{
                    //    for (; c <= dtData.Rows.Count; c++)
                    //    {
                    //        str_mobile = dtData.Rows[(c - 1)]["mobile"].ToString() + ",";
                    //    }
                    //}

                    //}
                    foreach (DataRow r in dtData.Rows)
                    {
                        string url = "http://www.apihub.online/api/Services/transact?token=537a87b8c53798f133c6e2a5294c83fd&skey=SST&to=" + r["mobile"].ToString() + "&sender=ETOPUP&smstext=" + "Dear User your ROI Income of amount " + r["amount"].ToString() + " for date " + Convert.ToDateTime(r["closingdate"].ToString()).ToString("dd/MM/yyyy") + " is credited in your bank account.SecurePaySystem&smsformat=TEXT&format=json";
                        string Result = url.CallURL();
                        Insert_SendSMS(r["mobile"].ToString(), Result, url);
                    }
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

        public string Growth_Comission_Set(clsAccount objAccount)
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

                s2 = "";
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

        public string Approve_AccountDetailEdit(clsAccount objaccount)
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
                s2 = "sp_ApproveAccountDetailEdit";
                SqlParameter[] parameter = {
                new SqlParameter("@ID",objaccount.Id),
                new SqlParameter("@MentionBy",objaccount.MentionBy),
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
        public string Reject_AccountDetailEdit(clsAccount objaccount)
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
                s2 = "sp_RejectAccountDetailEdit";
                SqlParameter[] parameter = {
                new SqlParameter("@ID",objaccount.Id),
                new SqlParameter("@MentionBy",objaccount.MentionBy),
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
        public string Insert_WithdrawlRequest(clsAccount objaccount)
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
                s2 = "sp_addWithdrawlRequest";
                SqlParameter[] parameter = {                                              
                new SqlParameter("@UserId",objaccount.UserId),
                new SqlParameter("@Amount",objaccount.WithdrawlAmount), 
                //new SqlParameter("@ConversionRate",objaccount.ConversionRate), 
                //new SqlParameter("@ConvertedAmount",objaccount.ConvertedAmount), 
                //new SqlParameter("@WalletTypeId",objaccount.WalletTypeId), 
                //new SqlParameter("@WalletAddressId",objaccount.WalletAddressId), 
                //new SqlParameter("@WalletAddress",objaccount.WalletAddress),
                new SqlParameter("@WalletType",objaccount.WalletType),
                new SqlParameter("@MentionBy",objaccount.MentionBy),
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
        public string Approve_WithdrawlRequest(clsAccount objaccount)
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
                s2 = "sp_approveWithdrawalRequest";
                SqlParameter[] parameter = {
                new SqlParameter("@Id",objaccount.Id),
                new SqlParameter("@OnlineTransactionId",objaccount.OnlineTransactionId), 
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
        public string Reject_WithdrawlRequest(clsAccount objaccount)
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
                s2 = "sp_rejectWithdrawalRequest";
                SqlParameter[] parameter = {
                new SqlParameter("@Id",objaccount.Id),
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

        //public string Approve_WithdrawlRequest(clsAccount objaccount)
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
        //        s2 = "select * from withdrawlrequest where id=" + objaccount.WithdrawlRequestId + "   and status='Pending' ";
        //        DataTable dt = new DataTable();
        //        dt = ObjData.RunSelectQueryTTrans(s2, tr);
        //        if (dt.Rows.Count > 0)
        //        {

        //            string strtransactionid = "0";
        //            s2 = "select isnull(max(transactionid),0)+1 from  TransactionDetail";
        //            DataTable dttran = new DataTable();
        //            dttran = ObjData.RunSelectQueryTTrans(s2, tr);
        //            strtransactionid = dttran.Rows[0][0].ToString();
        //            //decimal finalamount = 0.00M;
        //            //decimal admincharge = 0.00M;
        //            //admincharge = (objaccount.WithdrawlAmount * 10) / 100;
        //            //finalamount = objaccount.WithdrawlAmount - admincharge;

        //            s2 = " insert into TransactionDetail (transactionid,cramount,dramount,userid,transactiontype,remark,mentionby,mentiondate,wallettype)  values (" + strtransactionid + ",0," + objaccount.WithdrawlAmount.ToString() + ",'" + objaccount.UserId + "','Withdrawl','Withdrawl For User Id : " + objaccount.UserId + "','" + objaccount.MentionBy + "',[dbo].[getIndianDate](),'MWallet')";
        //            ObjData.RunInsUpDelQueryTrans(s2, tr);
        //            //s2 = " insert into TransactionDetail (transactionid,cramount,dramount,userid,transactiontype,remark,mentionby,mentiondate)  values (" + strtransactionid + ",0," + objaccount.TDS + ",'" + objaccount.UserId + "','TDS','TDS For User Id : " + objaccount.UserId + "','" + objaccount.MentionBy + "',[dbo].[getIndianDate]())";
        //            //ObjData.RunInsUpDelQueryTrans(s2, tr);
        //          //  s2 = " insert into TransactionDetail (transactionid,cramount,dramount,userid,transactiontype,remark,mentionby,mentiondate,wallettype)  values (" + strtransactionid + ",0," + admincharge.ToString() + ",'" + objaccount.UserId + "','Service Charge','Service Charge For User Id : " + objaccount.UserId + "','" + objaccount.MentionBy + "',[dbo].[getIndianDate](),'MWallet')";
        //           // ObjData.RunInsUpDelQueryTrans(s2, tr);
        //            s2 = "update withdrawlrequest set status='Approved' , approvedate=[dbo].[getIndianDate](),transactionid=" + strtransactionid + ",Paymentmode='" + objaccount.PaymentMode + "', OnlineTransactionId='" + OnlineTransactionId + "' where id=" + objaccount.WithdrawlRequestId + "  ";
        //            ObjData.RunInsUpDelQueryTrans(s2, tr);
        //            s2 = "update userdetail set balanceamount=isnull(balanceamount,0)-" + objaccount.WithdrawlAmount + "  where userid='" + objaccount.UserId + "'  ";
        //            ObjData.RunInsUpDelQueryTrans(s2, tr);

        //            res = "t";
        //        }
        //        else
        //        {
        //            res = "f";
        //        }


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
        //public string Reject_WithdrawlRequest(clsAccount objaccount)
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
        //        s2 = "select * from withdrawlrequest where id=" + objaccount.WithdrawlRequestId + "   and status='Pending' ";
        //        DataTable dt = new DataTable();
        //        dt = ObjData.RunSelectQueryTTrans(s2, tr);
        //        if (dt.Rows.Count > 0)
        //        {

        //            s2 = "update withdrawlrequest set status='Rejected' , approvedate=[dbo].[getIndianDate]() where id=" + objaccount.WithdrawlRequestId + "  ";
        //            ObjData.RunInsUpDelQueryTrans(s2, tr);

        //            res = "t";
        //        }
        //        else
        //        {
        //            res = "f";
        //        }


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
        public string Pay_SponserIncome(clsAccount objaccount)
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
                s2 = "SELECT * FROM SponserClosingDetail WHERE isnull(PaymentStatus,'Unpaid')='Unpaid' AND UserId='" + objaccount.UserId + "'   and convert(date, fromdate ) =convert(date, '" + objaccount.FromDate + "')   and convert(date,todate)   =  convert(date,'" + objaccount.ToDate + "')  ";
                DataTable dt = new DataTable();
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {
                    s2 = "update SponserClosingDetail set PaymentMode='" + objaccount.PaymentMode + "' ,PaymentStatus='Paid', approvedate=[dbo].[getIndianDate](),OnlineTransactionId='" + objaccount.OnlineTransactionId + "' where  isnull(PaymentStatus,'Unpaid')='Unpaid' AND UserId='" + objaccount.UserId + "'   and convert(date, fromdate ) =convert(date, '" + objaccount.FromDate + "')   and convert(date,todate)  =  convert(date, '" + objaccount.ToDate + "') ";
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
        public string Pay_LevelIncome(clsAccount objaccount)
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
                s2 = "SELECT * FROM ClosingDetail WHERE isnull(PaymentStatus,'Unpaid')='Unpaid' AND UserId='" + objaccount.UserId + "'   and convert(date, fromdate ) =convert(date, '" + objaccount.FromDate + "')   and convert(date,todate)   =  convert(date,'" + objaccount.ToDate + "')  ";
                DataTable dt = new DataTable();
                dt = ObjData.RunSelectQueryTTrans(s2, tr);
                if (dt.Rows.Count > 0)
                {
                    s2 = "update ClosingDetail set PaymentMode='" + objaccount.PaymentMode + "' ,PaymentStatus='Paid', approvedate=[dbo].[getIndianDate](),OnlineTransactionId='" + objaccount.OnlineTransactionId + "' where  isnull(PaymentStatus,'Unpaid')='Unpaid' AND UserId='" + objaccount.UserId + "'   and convert(date, fromdate ) =convert(date, '" + objaccount.FromDate + "')   and convert(date,todate)  =  convert(date, '" + objaccount.ToDate + "') ";
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

        public DataTable getDetailsByClosingDate(clsAccount objaccount)
        {
            string str_query = "SELECT top 50  md.Amount,md.ClosingDate,md.Userid,md.TopupId,ut.amount AS topupamount, md.convertedAmount,ut.totalcoin,ut.roidays, CASE WHEN md.mentionby = '-1' THEN 'Old' ELSE 'New' END AS mintingtype,CASE WHEN md.mentionby = '-1' THEN '' ELSE convert(NVARCHAR, md.closingdate,103) END AS closingdate2 FROM MintingDetail md WITH(nolock)LEFT JOIN usertopupdetail ut WITH(nolock) ON ut.id = md.TopupId where 1 = 1   and md.userid = " + objaccount.UserId + " and convert(date, md.ClosingDate)= convert(date,  '" + objaccount.FromDate + "' ) ORDER BY md.id desc ";

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
