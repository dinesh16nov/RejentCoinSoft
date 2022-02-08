using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for cityservice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class cityservice : System.Web.Services.WebService {

    public class UserEntity
    {
        public string Day
        {
            get;
            set;
        }
        public int Users
        {
            get;
            set;
        }
    }


    [WebMethod]
    public List<UserEntity> getuserDataDayWise()
    {
        List<UserEntity> users = new List<UserEntity>();
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ToString()))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_getLastSevenDaysUsers";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        users.Add(new UserEntity
                        {
                            Day = dr["day"].ToString(),
                            Users = Convert.ToInt32(dr["users"].ToString()),
                        });
                    }
                }
            }
        }
        return users;
    }  



    public cityservice () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public string[] GetCity(string prefix)
    {
        List<string> customers = new List<string>();
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select cm.cityname+', '+sm.statename as cityname,cm.cityid from citymaster cm left join statemaster sm on cm.stateid=sm.stateid where cm.cityname like @SearchText + '%' order by cm.cityname";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                ad.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    customers.Add(string.Format("{0}-{1}", r["cityname"], r["cityid"]));
                }
                conn.Close();
            }
        }

        return customers.ToArray();
    }
    [WebMethod]
    public string[] GetCityArea(string prefix)
    {
        List<string> customers = new List<string>();
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select am.areaname+', '+ cm.cityname+', '+sm.statename as cityname,cm.cityid,am.areaid from areamaster am left join citymaster cm  on am.cityid=cm.cityid left join statemaster sm on cm.stateid=sm.stateid where cm.cityname like @SearchText + '%' order by cm.cityname";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                ad.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    customers.Add(string.Format("{0}-{1}~{2}", r["cityname"], r["areaid"], r["cityid"]));
                }
                conn.Close();
            }
        }

        return customers.ToArray();
    }
    [WebMethod]
    public string[] GetCategory(string prefix)
    {
        List<string> customers = new List<string>();
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select isnull(sm2.subcategorysecondid,0) as subcategorysecondid,sm2.subcategorysecondname,sm.subcategoryid,sm.subcategoryname,cm.categoryname,cm.CategoryId, cm.CategoryName+', '+sm.SubcategoryName+  (CASE when isnull (sm2.SubcategorySecondName,'')!='' THEN ', '+sm2.SubcategorySecondName ELSE '' end ) AS name from subcategorysecondmaster sm2 FULL outer join  SubcategoryMaster sm  on sm2.subcategoryid=sm.subcategoryid  FULL outer join categoryMaster cm on sm.Categoryid=cm.categoryid  where cm.categoryname like @SearchText + '%' or sm.Subcategoryname  like @SearchText + '%' or  sm2.subcategorysecondname like @SearchText + '%' order by cm.categoryname,sm.Subcategoryname,sm2.subcategorysecondname";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                ad.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    customers.Add(string.Format("{0}-{1}~{2}~{3}", r["name"], r["categoryid"], r["subcategoryid"], r["subcategorysecondid"]));
                }
                conn.Close();
            }
        }

        return customers.ToArray();
    }

    [WebMethod]
    public string[] GetCategoryOnly(string prefix)
    {
        List<string> customers = new List<string>();
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select cm.CategoryId, cm.CategoryName AS name from  categoryMaster cm   where cm.categoryname like @SearchText + '%' order by cm.categoryname";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                ad.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    customers.Add(string.Format("{0}-{1}", r["name"], r["categoryid"]));
                }
                conn.Close();
            }
        }

        return customers.ToArray();
    }


    [WebMethod]
    public string[] GetProductsAdmin(string prefix)
    {
        List<string> customers = new List<string>();
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT pm.ProductId,pm.ProductName,pm.mrp,pm.dp,pm.gst FROM ProductMaster pm WITH (nolock)   WHERE   pm.productstatus='1' and pm.ProductName like @SearchText + '%' ";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                ad.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    customers.Add(string.Format("{0}-{1}~{2}~{3}~{4}", r["ProductName"], r["ProductId"],  r["mrp"], r["dp"], r["gst"]));
                }
                conn.Close();
            }
        }

        return customers.ToArray();
    }

    [WebMethod]
    public string[] GetProductsFranchise(string prefix, string struserid)
    {
        List<string> customers = new List<string>();
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT pm.ProductId,pm.ProductName,isnull(sum(sd.stockin),0)-isnull(sum(sd.StockOut),0)- isnull( (SELECT isnull( sum(sr.Quantity),0) FROM stockRequest sr WHERE sr.RequestToId='" + struserid + "' AND sr.RequestStatus='Pending' AND sr.ProductId=pm.ProductId),0) AS availability,pm.mrp,pm.dp,pm.gst,pm.transportationcharge,pm.bv,pm.binarypv FROM ProductMaster pm WITH (nolock)  LEFT JOIN stockdetail sd WITH (nolock) ON pm.ProductId=sd.ProductId WHERE sd.UserId='" + struserid + "' and pm.productstatus='1' and pm.ProductName like @SearchText + '%'  GROUP BY pm.ProductId,pm.ProductName,pm.mrp,pm.dp,pm.gst,pm.transportationcharge,pm.bv,pm.binarypv order by pm.ProductName ";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                ad.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    customers.Add(string.Format("{0}^{1}~{2}~{3}~{4}~{5}~{6}~{7}~{8}", r["ProductName"], r["ProductId"], r["availability"], r["mrp"], r["dp"], r["gst"], r["transportationcharge"], r["bv"], r["binarypv"]));
                }
                conn.Close();
            }
        }

        return customers.ToArray();
    }


    [WebMethod]
    public string[] GetProductsFranchiseRequest(string prefix)
    {
        List<string> customers = new List<string>();
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT pm.ProductId,pm.ProductName,isnull(sum(sd.stockin),0)-isnull(sum(sd.StockOut),0)- isnull( (SELECT isnull( sum(sr.Quantity),0) FROM stockRequest sr WHERE sr.RequestToId='admin' AND sr.RequestStatus='Pending' AND sr.ProductId=pm.ProductId),0) AS availability,pm.mrp,pm.dp,pm.gst FROM ProductMaster pm WITH (nolock)  LEFT JOIN stockdetail sd WITH (nolock) ON pm.ProductId=sd.ProductId WHERE sd.UserId='admin' and pm.productstatus='1' and pm.ProductName like @SearchText + '%'  GROUP BY pm.ProductId,pm.ProductName,pm.mrp,pm.dp,pm.gst order by pm.ProductName ";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                ad.Fill(dt);
                foreach (DataRow r in dt.Rows)
                {
                    customers.Add(string.Format("{0}^{1}~{2}~{3}~{4}~{5}", r["ProductName"], r["ProductId"], r["availability"], r["mrp"], r["dp"], r["gst"]));
                }
                conn.Close();
            }
        }

        return customers.ToArray();
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    
}
