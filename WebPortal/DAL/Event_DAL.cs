using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class Event_DAL
    {
        public DataTable EventList()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllEvents", CommandType.StoredProcedure);
        }

        public int InsertEvent(Event_BO objEventBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_EventName", objEventBO.EventName),
                new MySqlParameter("@p_EventDescription", objEventBO.EventDescription),
                new MySqlParameter("@p_StartDate", objEventBO.StartDate),
                new MySqlParameter("@p_EndDate", objEventBO.EndDate),
                new MySqlParameter("@p_StartTime", objEventBO.StartTime),
                new MySqlParameter("@p_EndTime", objEventBO.EndTime),
                new MySqlParameter("@p_Location", objEventBO.Location),
                new MySqlParameter("@p_Status", objEventBO.Status),
                new MySqlParameter("@p_CreatedBy", objEventBO.CreatedBy),
                new MySqlParameter("@p_FilePath", objEventBO.FilePath)

            };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertEvents", CommandType.StoredProcedure, parameters);
        }

        public int UpdateEvent(Event_BO objEventBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
             {
                new MySqlParameter("@p_EventID", objEventBO.EventID),
                new MySqlParameter("@p_EventName", objEventBO.EventName),
                new MySqlParameter("@p_EventDescription", objEventBO.EventDescription),
                new MySqlParameter("@p_StartDate", objEventBO.StartDate),
                new MySqlParameter("@p_EndDate", objEventBO.EndDate),
                new MySqlParameter("@p_StartTime", objEventBO.StartTime),
                new MySqlParameter("@p_EndTime", objEventBO.EndTime),
                new MySqlParameter("@p_Location", objEventBO.Location),
                new MySqlParameter("@p_Status", objEventBO.Status),
                new MySqlParameter("@p_UpdatedBy", objEventBO.UpdatedBy),
                new MySqlParameter("@p_FilePath", objEventBO.FilePath)
             };
            return MySqlDBHelper.ExecuteNonQuery("wp_UpdateEvents", CommandType.StoredProcedure, parameters);
        }

        public void DeleteEvents(int EventID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_EventID", EventID)
            };
            MySqlDBHelper.ExecuteNonQuery("wp_DeleteEvents", CommandType.StoredProcedure, parameters);
        }
    }
}
