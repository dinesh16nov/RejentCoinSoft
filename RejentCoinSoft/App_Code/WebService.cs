using BusinessLogicTier;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    public static DataTable DtnumberDetail2 = new DataTable();
    clsRecharge obal = new clsRecharge();
    [WebMethod]

    public string getOpertorPripaid(string search)
    {
        DataTable DtnumberDetail = new DataTable();
        string opertor = "", circle = "", irffcircle = "";
        try
        {
            if (search.Length > 3 && search.Length < 5)
            {
                if (DtnumberDetail.Rows.Count < 1)
                {
                    DtnumberDetail = obal.fillNumberList();
                }
                string searchExpression = "Number = '" + search + "'";
                DataRow[] foundRows = DtnumberDetail.Select(searchExpression);
                if (foundRows.Length > 0)
                {
                    opertor = JsonConvert.SerializeObject(foundRows.CopyToDataTable());
                }
            }
            return opertor;
        }
        catch
        {
            return opertor;
        }
    }
    [WebMethod]
    public string GetopertorOption(string value)
    {
        string opertor = "";
        //if (value != "")
        //{
        //    try
        //    {
        //        bal_UserDetail obal_UserDetail = new bal_UserDetail();
        //        DataTable dt = obal.OperatorOpetion(value);

        //        if (dt.Rows.Count > 0)
        //        {
        //            opertor = JsonConvert.SerializeObject(dt);
        //        }
        //    }
        //    catch { }
        //}
        return opertor;
    }

    [WebMethod]
    public string RechargeReport()
    {
        //dal odal = new dal();
        string opertor = "";
        //DataTable Dt = new DataTable();
        //Dt = odal.GetDataByProcedure("ChartTable");
        //if (Dt.Rows.Count > 0)
        //{
        //    opertor = JsonConvert.SerializeObject(Dt);
        //}
        return opertor;
    }
    
}
