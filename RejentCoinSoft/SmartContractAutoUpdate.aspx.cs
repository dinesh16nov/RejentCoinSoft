using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicTier;
using RestSharp;
using System.Xml;
using Newtonsoft.Json;

public partial class SmartContractAutoUpdate : System.Web.UI.Page
{
    clsUser objuser = new clsUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ProcessData();
        }

    }

    void ProcessData()
    {
        DataTable dt = new DataTable();
        dt = objuser.getPendingSmartContractRequest(objuser);
        foreach (DataRow dr in dt.Rows)
        {
            string str_response = "";
            string str_status = "Pending";

            var client = new RestClient("http://new.teamrijent.in:3004/tx_details/"+ dr["transactionid"].ToString() + "?tx_id=" + dr["referenceid"].ToString() + "");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            try
            {
                str_response = response.Content.ToString();
                objuser.TransactionId = dr["transactionid"].ToString();
                objuser.ReferenceId = dr["referenceid"].ToString();
                objuser.Response = str_response;

                string res = objuser.Insert_SmartContractTransactionDetailResponse(objuser);
            }
            catch { }


            //str_response = @"{""success"":true,""message"":""tx detail"",""data"":{""blockHash"":""0x96d39bf3b8bb21a4467939f9bf84bfdf3743765ac161a167f8e06bdd1458d34f"",""blockNumber"":12276235,""contractAddress"":null,""cumulativeGasUsed"":40522380,""from"":""0x9788be3b5ae1f1b1bf6698fcddb95043279ed9db"",""gasUsed"":21264,""logs"":[],""logsBloom"":""0x00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"",""status"":true,""to"":""0x719338647f7f17ff7cdd70e253a377bfb63caa85"",""transactionHash"":""0x881a7b6633f10f90bbc801f4d85fa48c7ecb4c1ee656da136a05cc71b5ad9bf6"",""transactionIndex"":310,""type"":""0x0""}}";

            DataSet ds = ConvertJSONToDataSet(str_response);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Columns.Contains("success"))
                {
                    if (ds.Tables[0].Rows[0]["success"].ToString() == "true")
                    {
                        if (ds.Tables.Count > 2)
                        {
                            if (ds.Tables[2].Columns.Contains("status"))
                            {
                                if (ds.Tables[2].Rows[0]["status"].ToString() == "true")
                                {
                                    str_status = ds.Tables[2].Rows[0]["status"].ToString();
                                }

                            }
                        }

                    }
                }
            }


            try
            {
                objuser.Id = dr["id"].ToString();
                objuser.TransactionId = dr["TransactionId"].ToString();
                objuser.UserId = dr["userid"].ToString();
                objuser.CrAmount = Convert.ToDecimal(dr["cramount"].ToString());
                objuser.DrAmount = Convert.ToDecimal(dr["DrAmount"].ToString());
                objuser.TransactionType = dr["TransactionType"].ToString();
                objuser.Status = str_status;
                string res = objuser.Update_SmartContractTransaction(objuser);
            }
            catch { }


        }
    }
    DataSet ConvertJSONToDataSet(string Resp)
    {
        DataSet jsonDataSet = new DataSet();
        try
        {
            //Resp = Resp.Replace("{", "[{");
            //Resp = Resp.Replace("}", "}]");
            //DataSet myDataSet = JsonConvert.DeserializeObject<DataSet>(Resp);
            //return myDataSet;
            XmlDocument xd1 = new XmlDocument();
            xd1 = (XmlDocument)JsonConvert.DeserializeXmlNode(Resp, "root");

            jsonDataSet.ReadXml(new XmlNodeReader(xd1));
        }
        catch { }
        return jsonDataSet;
    }
}