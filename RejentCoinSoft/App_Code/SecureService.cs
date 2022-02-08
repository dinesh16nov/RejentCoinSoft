using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLogicTier;

/// <summary>
/// Summary description for SecureService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SecureService : System.Web.Services.WebService {

    public SecureService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    
    [WebMethod]
    public void Login(String _UserId, String _UPassword, String _DeviceId)
    {
        PrintJson(new clsSecureService().Login(_UserId, _UPassword, _DeviceId));
    }
    [WebMethod]
    public void GetUserDetail(String _UserId, String _UPassword)
    {
        PrintJson(new clsSecureService().GetUserDetail(_UserId, _UPassword));
    }
    [WebMethod]
    public void GetUserName(String _UserId, String _UPassword,String NewUserId)
    {
        PrintJson(new clsSecureService().GetUserName(_UserId, _UPassword, NewUserId));
    }
    [WebMethod]
    public void GetUserBalance(String _UserId, String _UPassword)
    {
        PrintJson(new clsSecureService().GetUserBalance(_UserId, _UPassword));
    }
    [WebMethod]
    public void ChangePassword(String _UserId, String _UPassword,String NewPassword)
    {
        PrintJson(new clsSecureService().ChangePassword(_UserId, _UPassword, NewPassword));
    }
    [WebMethod]
    public void NewMessage(String _UserId, String _UPassword, String MessageTitle,String MessageDescription)
    {
        PrintJson(new clsSecureService().NewMessage(_UserId, _UPassword, MessageTitle, MessageDescription));
    }
    [WebMethod]
    public void getUserDashboard(String _UserId, String _UPassword)
    {
        PrintJson(new clsSecureService().GetUserDashboard(_UserId, _UPassword));
    }
    [WebMethod]
    public void GetUserDownline(String _UserId, String _UPassword,String StandingPosition)
    {
        PrintJson(new clsSecureService().GetUserDownline(_UserId, _UPassword,StandingPosition));
    }
    [WebMethod]
    public void GetUserDirectDownline(String _UserId, String _UPassword, String StandingPosition)
    {
        PrintJson(new clsSecureService().GetUserDirectDownline(_UserId, _UPassword, StandingPosition));
    }
    [WebMethod]
    public void GetUserDirectDownlineSponserWise(String _UserId, String _UPassword, String StandingPosition)
    {
        PrintJson(new clsSecureService().GetUserDirectDownlineSponserWise(_UserId, _UPassword, StandingPosition));
    }
    [WebMethod]
    public void GetUserDirectIncome(String _UserId, String _UPassword, String FromDate,String ToDate)
    {
        PrintJson(new clsSecureService().GetUserDirectIncome(_UserId, _UPassword, FromDate,ToDate));
    }
   
    [WebMethod]
    public void GetUserBinaryIncome(String _UserId, String _UPassword, String FromDate, String ToDate)
    {
        PrintJson(new clsSecureService().GetUserBinaryIncome(_UserId, _UPassword, FromDate, ToDate));
    }
   
   
   
    
   
   
   
    [WebMethod]
    public void GetUserDashboard(String _UserId, String _UPassword)
    {
        PrintJson(new clsSecureService().GetUserDashboard(_UserId, _UPassword));
    }
    [WebMethod]
    public void GetNews(String _UserId, String _UPassword)
    {
        PrintJson(new clsSecureService().GetNews(_UserId, _UPassword));
    }
    [WebMethod]
    public void GetDownlineCount(String _UserId, String _UPassword)
    {
        PrintJson(new clsSecureService().GetUserDownlineCount(_UserId, _UPassword));
    }
   
    [WebMethod]
    public void GetBankList(String _UserId)
    {
        PrintJson(new clsSecureService().GeBankList(_UserId));
    }
    [WebMethod]
    public void GetCountryList(String _UserId)
    {
        PrintJson(new clsSecureService().GeCountryList(_UserId));
    }
    [WebMethod]
    public void GetStateList(String _UserId, String _CountryId)
    {
        PrintJson(new clsSecureService().GeStateList(_UserId, _CountryId));
    }
    [WebMethod]
    public void GetCityList(String _UserId, String _StateId)
    {
        PrintJson(new clsSecureService().GeCityList(_UserId, _StateId));
    }
   
    [WebMethod]
    public void UpdateUserDetail(String UserId, String UPassword, String username, String mobile, String email, String gender, String address, String cityname, String stateid, String dateofbirth )
    {
        PrintJson(new clsSecureService().UpdateUserDetail(UserId, UPassword ,  username,  mobile,  email,  gender,  address,  cityname,  stateid,    dateofbirth   ));
    }
    [WebMethod]
    public void UserAdd(String userid, String password,  String username, String mobile, String email, String gender, String StandingPosition, String dateofbirth, String Newpassword)
    {
        PrintJson(new clsSecureService().UserAdd( userid,  password,  username,  mobile,  email,  gender,  StandingPosition,  dateofbirth,  Newpassword));
    }

    
    [WebMethod]
    public void UserTopup(String UserId, String UPassword,  String TopupUserId,String WalletType ,String Amount)
    {
        PrintJson(new clsSecureService().UserTopup(UserId, UPassword,  TopupUserId, WalletType, Amount));
    }

    [WebMethod]
    public void UserTopupReport(String _UserId, String UPassword, String FromDate, String ToDate)
    {
        PrintJson(new clsSecureService().UserTopupReport(_UserId, UPassword, FromDate, ToDate));
    }


    [WebMethod]
    public void getInbox(String _UserId, String UPassword, String FromDate, String ToDate)
    {
        PrintJson(new clsSecureService().getInbox(_UserId, UPassword, FromDate, ToDate));
    }

    [WebMethod]
    public void getSentbox(String _UserId, String UPassword, String FromDate, String ToDate)
    {
        PrintJson(new clsSecureService().getSentbox(_UserId, UPassword, FromDate, ToDate));
    }


    [WebMethod]
    public void getLevelIncomeReport(String _UserId, String UPassword,  String FromDate, String ToDate)
    {
        PrintJson(new clsSecureService().getLevelIncomeReport(_UserId, UPassword,  FromDate, ToDate));
    }
    [WebMethod]
    public void getTransactionReport(String _UserId, String UPassword, String FromDate, String ToDate)
    {
        PrintJson(new clsSecureService().getTransactionReport(_UserId, UPassword, FromDate, ToDate));
    }
    [WebMethod]
    public void getTransactionReportEWallet(String _UserId, String UPassword, String FromDate, String ToDate)
    {
        PrintJson(new clsSecureService().getTransactionReportEWallet(_UserId, UPassword, FromDate, ToDate));
    }
   
    protected void PrintJson(String jsonstr)
    {
        try
        {
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(jsonstr);
            HttpContext.Current.Response.End();
        }
        catch { }
    }

   
    
    [WebMethod]
    public void GetDownlineUserName(String _UserId, String _UPassword, String _DownlineUserId)
    {
        PrintJson(new clsSecureService().GetDownlineUserName(_UserId, _UPassword, _DownlineUserId));
    }
    [WebMethod]
    public void GetUpgradeUserName(String _UserId, String _UPassword, String _UpgradeUserId)
    {
        PrintJson(new clsSecureService().GetUpgradeUserName(_UserId, _UPassword, _UpgradeUserId));
    }
    [WebMethod]
    public void WalletTransfer(String UserId, String UPassword,  String amount, String TransferUserId, String Remark)
    {
        PrintJson(new clsSecureService().WalletTransferUser(UserId, UPassword, TransferUserId, amount, Remark));
    }
    [WebMethod]
    public void getWalletTransferReport(String _UserId, String UPassword, String ToUserId, String FromDate, String ToDate)
    {
        PrintJson(new clsSecureService().getWalletTransferReport(_UserId, UPassword,ToUserId, FromDate, ToDate));
    }
   
   
    [WebMethod]
    public void FundRequestAdd(String UserId, String UPassword, String AccountId, String paymentMode, String amount, String Transactionid, String ChequeNo, String MobileNoInBank, String Remark)
    {
        PrintJson(new clsSecureService().FundRequestAdd( UserId,  UPassword,  AccountId,  paymentMode,  amount,  Transactionid,  ChequeNo,  MobileNoInBank,  Remark));
    }
   
    [WebMethod]
    public void FundRequestReport(String _UserId, String UPassword, String ToUserId, String FromDate, String ToDate)
    {
        PrintJson(new clsSecureService().FundRequestReport(_UserId, UPassword, FromDate, ToDate));
    }
   
}
