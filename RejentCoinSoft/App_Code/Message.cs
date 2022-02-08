using System.Data;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Web;
using System.Web.Security;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Dynamic;
using System;
/// <summary>
/// Summary description for Message
/// </summary>
public class Message
{
    public static void Show(string Message)
    {
        //Define String
        string PrintMessage = Message;
        // Script Alert For Message Alert
        string str = "<script type=\"text/javascript\">alert('" + PrintMessage + "');</script>";
        //Page Information
        Page popup = HttpContext.Current.CurrentHandler as Page;
        //Pop Up Alert
        ScriptManager.RegisterStartupScript(popup, typeof(Page), "alert", str, false);
        //End Message
    }

    public static DateTime GetIndianDate(string Datedt)
    {
        DateTime myDateTime = new DateTime();

        if (Datedt != "")
        {
            //System.Globalization.CultureInfo ukCulture = new System.Globalization.CultureInfo("en-GB");
            //myDateTime = DateTime.Parse(Datedt, ukCulture.DateTimeFormat);
            string[] str = Datedt.Split('/');
            string str_new = str[1].ToString() + " / " + str[0].ToString() + " / " + str[2].ToString();
            myDateTime = Convert.ToDateTime(str[1].ToString() + "/" + str[0].ToString() + "/" + str[2].ToString());
            return myDateTime;
        }
        else
        {
            myDateTime = Convert.ToDateTime("1/1/1900 12:00:00 AM");
            return myDateTime;
        }

    }
}