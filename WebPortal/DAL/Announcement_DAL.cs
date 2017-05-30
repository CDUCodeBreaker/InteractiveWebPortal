using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using MySql.Data.MySqlClient;
using Common;
using System.Data;

namespace DAL
{
    public class Announcement_DAL
    {
        public int InsertAnnouncement(Announcement_BO objAnnouncementBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
             {
                new MySqlParameter("@p_announcement", objAnnouncementBO.Announcement),
                new MySqlParameter("@p_createdby", objAnnouncementBO.CreatedBy),
                new MySqlParameter("@p_status", objAnnouncementBO.Status),
             };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertAnnouncement", CommandType.StoredProcedure, parameters);
        }

        public int UpdateAnnouncement(Announcement_BO objAnnouncementBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
             {
                new MySqlParameter("@p_announcementid", objAnnouncementBO.AnnouncementID),
                new MySqlParameter("@p_announcement", objAnnouncementBO.Announcement),
                new MySqlParameter("@p_createdby", objAnnouncementBO.CreatedBy),
                new MySqlParameter("@p_status", objAnnouncementBO.Status)
             };
            return MySqlDBHelper.ExecuteNonQuery("wp_UpdateAnnouncement", CommandType.StoredProcedure, parameters);
        }

        public DataTable AnnouncementList()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllAnnouncements", CommandType.StoredProcedure);
        }

        public void DeleteAnnouncement(int announcementID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_announcementid", announcementID)
           };
            MySqlDBHelper.ExecuteNonQuery("wp_DeleteAnnouncement", CommandType.StoredProcedure, parameters);
        }
    }
}
