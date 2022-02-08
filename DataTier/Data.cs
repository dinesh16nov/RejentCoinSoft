using System;
using System.StubHelpers;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Security;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Mail;
using ARA_StringHunt;

namespace DataTier
{
    public class Data
    {
        SqlConnection connection;

        public string getConnectionString()
        {
            string strin = "server=195.201.62.12,3314; Database=db_RejentCoin;  USER ID=AKIASDA22VLVCLH5HUJSPD1;PASSWORD=CCNABNtHW5jHMiptjkk9Rrco33guoQBXR+6we1qcmgrS3q; trusted_connection=false;";

            return strin;
        }
        public void StartConnection()
        {
            //string strin = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ToString();
            //string strin = "server=195.201.62.12,3314; Database=db_RejentCoin;  USER ID=AKIASDA22VLVCLH5HU;PASSWORD=BNtHW5jHMiptjkk9Rrco33guoQBXR+6we1qcmgrS3q; trusted_connection=false;";
            //string strin = "server=195.201.62.12,3314; Database=db_RejentCoin;  USER ID=AKIASDA22VLVCLH5HUJSPD1;PASSWORD=CCNABNtHW5jHMiptjkk9Rrco33guoQBXR+6we1qcmgrS3q; trusted_connection=false;";
            connection = new SqlConnection(getConnectionString());
            connection.Open();
        }
        public SqlConnection StartConnectionInTransaction()
        {
            //string str = System.Configuration.ConfigurationManager.ConnectionStrings["Connection String"].ToString();
            //string str = "server=195.201.62.12,3314; Database=db_RejentCoin;  USER ID=AKIASDA22VLVCLH5HUJSPD1;PASSWORD=CCNABNtHW5jHMiptjkk9Rrco33guoQBXR+6we1qcmgrS3q; trusted_connection=false;";
            connection = new SqlConnection(getConnectionString());
            connection.Open();
            return connection;
        }

        public void EndConnection()
        {
            connection.Close();
        }

        public DataSet RunSelectQuery(string sqlCon)
        {
            SqlCommand command = new SqlCommand(sqlCon, connection);
            command.CommandTimeout = 100000;
            SqlDataAdapter data_A = new SqlDataAdapter(command);
            DataSet ds = new DataSet();

            data_A.Fill(ds);

            return ds;
        }

        public void RunInsUpDelQuery(string sqlCon)
        {
            SqlCommand command = new SqlCommand(sqlCon, connection);
            command.ExecuteNonQuery();
        }

        public int RunInsUpDelQueryNew(string sqlCon)
        {
            SqlCommand command = new SqlCommand(sqlCon, connection);
            int a = command.ExecuteNonQuery();
            return a;
        }
        public DataTable RunDataTableParam(string sql, SqlParameter[] sqlparam)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);

            for (int i = 0; i < sqlparam.Length; i++)
            {
                cmd.Parameters.Add(sqlparam[i]);
            }
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }
            return dt;
        }

        public DataSet RunSelectQueryTrans(string sqlCon, SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(sqlCon, connection, transaction);
            SqlDataAdapter dataA = new SqlDataAdapter(command);
            DataSet ds = new DataSet();

            dataA.Fill(ds);

            return ds;
        }

        public void RunInsUpDelQueryTrans(string sqlCon, SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(sqlCon, connection, transaction);

            command.ExecuteNonQuery();

        }
        public void RunInsUpDelQueryTransProc(string sqlCon, SqlTransaction transaction, SqlParameter[] sqlparam)
        {
            SqlCommand command = new SqlCommand(sqlCon, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < sqlparam.Length; i++)
            {
                command.Parameters.Add(sqlparam[i]);
            }
            command.ExecuteNonQuery();

        }
        public string RunInsUpDelQueryTransProcScalar(string sqlCon, SqlTransaction transaction, SqlParameter[] sqlparam)
        {
            SqlCommand command = new SqlCommand(sqlCon, connection, transaction);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            for (int i = 0; i < sqlparam.Length; i++)
            {
                command.Parameters.Add(sqlparam[i]);
            }
            string s = command.ExecuteScalar().ToString();
            return s;

        }
        public DataTable RunDataTableProcedureTRans(string sql, SqlTransaction transaction, SqlParameter[] sqlparam)
        {
            SqlCommand cmd = new SqlCommand(sql, connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < sqlparam.Length; i++)
            {
                cmd.Parameters.Add(sqlparam[i]);
            }
            //cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }
            return dt;
        }
        public DataSet RunDataSetProcedureTRans(string sql, SqlTransaction transaction, SqlParameter[] sqlparam)
        {
            SqlCommand cmd = new SqlCommand(sql, connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < sqlparam.Length; i++)
            {
                cmd.Parameters.Add(sqlparam[i]);
            }
            //cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
                throw;
            }
            return ds;
        }
        public DataTable RunDataTable(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }
            return dt;
        }
        public DataTable RunDataTableProcedure(string sql, SqlParameter[] sqlparam)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandTimeout = 900;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < sqlparam.Length; i++)
            {
                cmd.Parameters.Add(sqlparam[i]);
            }
            //cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }
            return dt;
        }
        public DataSet RunDataSetProcedure(string sql, SqlParameter[] sqlparam)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            for (int i = 0; i < sqlparam.Length; i++)
            {
                cmd.Parameters.Add(sqlparam[i]);
            }
            //cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }
            return dt;
        }
        public DataTable RunSelectQueryTTrans(string sql, SqlTransaction trans)
        {
            SqlCommand cmd = new SqlCommand(sql, connection, trans);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }
        public string send_sms(string str_mobile, string str_message, string str_templateid)
        {


            //string baseurl = "http://173.45.76.227/send.aspx?";
            //WebRequest w = WebRequest.Create(baseurl);
            //w.Method = "POST";
            //w.ContentType = "application/x-www-form-urlencoded";
            //string status = "";
            //using (Stream requestStream = w.GetRequestStream())
            //{

            //    byte[] buffer = new UTF8Encoding().GetBytes("username=AmbroCabs&pass=Lucknow01&route=trans1&senderid=AMBROC&numbers=" + senders + "&message=" + message);
            //    requestStream.Write(buffer, 0, buffer.Length);
            //}
            //using (HttpWebResponse r = (HttpWebResponse)w.GetResponse())
            //{
            //    using (StreamReader reader = new StreamReader(r.GetResponseStream()))
            //    {
            //        status = reader.ReadToEnd().ToString();

            //    }
            //}
            //return status;
            //string url = "https://api.telsp.in/pushapi/sendmsg?username=Roundotp&dest="+str_mobile+"&apikey=Ua8xDVGCn3VpnzEtHZ0c9Tc6QY1lzaea&signature=MALERT&msgtype=PM&msgtxt="+str_message+"&entityid=1401636630000011182&templateid="+str_templateid+"";
            string url = "https://api.taggteleservices.com/api/v2/SendSMS?SenderId=MALERT&Is_Unicode=false&Is_Flash=false&Message=" + str_message + "." + "&MobileNumbers=" + str_mobile + "&ApiKey=PUwSz9YBwQjQ9mLGOBV7O7KZIJBcs1f44zXhlVsDbeM%3D&ClientId=a26383d3-25a5-4a99-8d2a-766ca4bbf32b";
            string Result = url.CallURL();
            Insert_SendSMS(str_mobile, Result, url);

            return "1";
        }
        public void SendEmail(string str_subject, string str_body, string str_email)
        {
            try
            {
                //using (MailMessage mm = new MailMessage("info@teamrijent.com", str_email))
                //{
                //    mm.Subject = str_subject;
                //    mm.Body = str_body;
                //    //if (fuAttachment.HasFile)
                //    //{
                //    //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                //    //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                //    //}
                //    mm.IsBodyHtml = false;
                //    SmtpClient smtp = new SmtpClient();
                //    smtp.Host = "webmail.teamrijent.com";
                //    smtp.EnableSsl = true;
                //    NetworkCredential NetworkCred = new NetworkCredential("info@teamrijent.com", "Info@2020!");
                //    smtp.UseDefaultCredentials = true;
                //    smtp.Credentials = NetworkCred;
                //    smtp.Port = 25;
                //    smtp.Send(mm);
                //    //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                //   Insert_SendSMS(str_email,  "", str_body);
                //}
                String FROM = "alert@teamrijent.in";
                String FROMNAME = "";

                // Replace recipient@example.com with a "To" address. If your account 
                // is still in the sandbox, this address must be verified.
                String TO = str_email;

                // Replace smtp_username with your Amazon SES SMTP user name.
                String SMTP_USERNAME = "AKIASDA22VLVCLH5HUWG";

                // Replace smtp_password with your Amazon SES SMTP password.
                String SMTP_PASSWORD = "BNtHW5jHMiptjkk9Rrco33guoQBXR+6we1qcmgrS3qLx";

                // (Optional) the name of a configuration set to use for this message.
                // If you comment out this line, you also need to remove or comment out
                // the "X-SES-CONFIGURATION-SET" header below.
                //String CONFIGSET = "ConfigSet";

                // If you're using Amazon SES in a region other than US West (Oregon), 
                // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
                // endpoint in the appropriate AWS Region.
                String HOST = "email-smtp.ap-south-1.amazonaws.com";

                // The port you will connect to on the Amazon SES SMTP endpoint. We
                // are choosing port 587 because we will use STARTTLS to encrypt
                // the connection.
                int PORT = 587;

                // The subject line of the email
                String SUBJECT =
                   str_subject;

                // The body of the email
                String BODY = str_body;

                // Create and build a new MailMessage object
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(FROM, FROMNAME);
                message.To.Add(new MailAddress(TO));
                message.Subject = SUBJECT;
                message.Body = BODY;
                // Comment or delete the next line if you are not using a configuration set
                //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

                using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
                {
                    // Pass SMTP credentials
                    client.Credentials =
                        new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                    // Enable SSL encryption
                    client.EnableSsl = true;

                    // Try to send the message. Show status in console.
                    try
                    {
                        // Console.WriteLine("Attempting to send email...");
                        client.Send(message);
                        // Console.WriteLine("Email sent!");
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("The email was not sent.");
                        //Console.WriteLine("Error message: " + ex.Message);
                    }
                }
            }
            catch (Exception ep)
            {


            }
        }
        public string Insert_SendSMS(string str_Mobile, string str_Result, string str_Message)
        {
            string res = "";
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                s2 = "insert into SendSms(CreateDate,Mobile,Result,Message)  values ([dbo].[getIndianDate](),'" + str_Mobile + "','" + str_Result.Replace("'", "''") + "','" + str_Message.Replace("'", "''") + "') ";
                RunInsUpDelQueryTrans(s2, tr);
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
                EndConnection();
                tr.Dispose();
            }
            return res;
        }
    }
}