﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataTier;

namespace BusinessLogicTier
{
    public class clsSupport
    {
        Data ObjData = new Data();

        public string FromId { get; set; }
        public string ToId { get; set; }
        public string Messagetitle { get; set; }
        public string MessageDescription { get; set; }
        public string MentionBy { get; set; }
        public string ImageName { get; set; }
        public DataTable getInbox(clsSupport objsupport)
        {
            string str_query = "select sd.*,ud.username from SupportDetail sd with (nolock) left join userdetail ud with (nolock) on sd.fromid=ud.userid where sd.toid='" + objsupport.ToId + "' order by sd.mentiondate desc ";

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

        public DataTable getSentbox(clsSupport objsupport)
        {
            string str_query = "select * from SupportDetail where FromId='" + objsupport.FromId + "' order by mentiondate desc ";

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


        public int SendMessage(clsSupport objsupport)
        {
            int i = 0;
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {

                s2 = " declare @id int; SELECT @id= isnull(max(id),0)+1 from SupportDetail  ; insert into SupportDetail (id, FromId ,ToId  ,MessageTitle ,MessageDescription, MentionBy  ,MentionDate  ) values (@id, '" + objsupport.FromId + "', '" + objsupport.ToId + "','" + objsupport.Messagetitle + "','" + objsupport.MessageDescription + "','" + objsupport.MentionBy + "',[dbo].[getIndianDate]()) ";
                ObjData.RunInsUpDelQueryTrans(s2, tr);
                i = 1;

                tr.Commit();
            }
            catch (Exception ex)
            {
                i = 0;
                tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
                tr.Dispose();
            }
            return i;
        }


        public int SendMessageByAdmin(clsSupport objsupport)
        {
            int i = 0;
            string s2 = "";
            SqlConnection cn;
            SqlTransaction tr = null;
            DataSet ds = new DataSet();
            cn = ObjData.StartConnectionInTransaction();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                DataTable dt = new DataTable();
                dt = ObjData.RunSelectQueryTTrans("select * from logindetail where username='" + objsupport.ToId + "'", tr);
                if (dt.Rows.Count > 0)
                {

                    s2 = " declare @id int; SELECT @id= isnull(max(id),0)+1 from SupportDetail  ; insert into SupportDetail (id, FromId ,ToId  ,MessageTitle ,MessageDescription, MentionBy  ,MentionDate,imagename  ) values (@id, '" + objsupport.FromId + "', '" + objsupport.ToId + "','" + objsupport.Messagetitle + "','" + objsupport.MessageDescription + "','" + objsupport.MentionBy + "',[dbo].[getIndianDate](),'"+objsupport.ImageName+"') ";
                    ObjData.RunInsUpDelQueryTrans(s2, tr);
                    i = 1;
                }
                else
                {
                    i = 2;
                }
                tr.Commit();
            }
            catch (Exception ex)
            {
                i = 0;
                tr.Rollback();
            }
            finally
            {
                ObjData.EndConnection();
                tr.Dispose();
            }
            return i;
        }


    }
}
