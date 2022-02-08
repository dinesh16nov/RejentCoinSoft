using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Server.Transfer("index.aspx");
        //        string body = @"{
        //    ""tracking"": {
        //        ""slug"": ""dhl"",
        //        ""tracking_number"": ""RF123456789HK"",
        //        ""title"": ""Title Name"",
        //        ""smses"": [
        //            ""+18555072509"",
        //            ""+18555072501""
        //        ],
        //        ""emails"": [
        //            ""email@yourdomain.com"",
        //            ""another_email@yourdomain.com""
        //        ],
        //        ""order_id"": ""ID1234"",
        //        ""order_id_path"": ""http://www.aftership.com/order_id=1234"",
        //        ""custom_fields"": {
        //            ""product_name"": ""iPhone Case"",
        //            ""product_price"": ""USD19.99""
        //        }
        //    }
        //}";
        //        string url = "https://api.aftership.com/v4/trackings";
        //        var client = new RestClient(url);
        //        var request = new RestRequest(Method.POST);
        //        request.AddHeader("aftership-api-key", "ee7c89e6-af41-445e-9973-d7925ff2d46d");
        //        request.AddHeader("Content-Type", "application/json");
        //        request.AddParameter("application/json; charset=UTF-8", body, ParameterType.RequestBody);
        //        //request.AddParameter("xmlRequest", body);
        //        IRestResponse response = client.Execute(request);
        //        var content = response.Content.Replace("<", "").Replace(">", "");
        //  SaveLog(response.Content.Replace("<", "").Replace(">", ""));
    }
}