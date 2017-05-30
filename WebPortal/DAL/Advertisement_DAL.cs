using System.Data;
using BO;
using MySql.Data.MySqlClient;
using Common;

namespace DAL
{
    public class Advertisement_DAL
    {
        public void DeleteAdvertisementByAdvertisementID(int advertisementID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
         {
                new MySqlParameter("@p_advertisementID", advertisementID)
         };
            MySqlDBHelper.ExecuteNonQuery("wp_DeleteAdvertisementByAdvertisementID", CommandType.StoredProcedure, parameters);
        }

        public DataTable GetAdvertisementByAdvertisementD(int advertisementID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
        {
                new MySqlParameter("@p_advertisementID", advertisementID)
        };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_SelectAdvertisementByAdvertisementD", CommandType.StoredProcedure, parameters);
        }

        public int InsertAdvertisement(Advertisement_BO objAdvertisementBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_filename", objAdvertisementBO.FileName),
                new MySqlParameter("@p_filepath", objAdvertisementBO.FilePath),
                new MySqlParameter("@p_createdby", objAdvertisementBO.CreatedBy)
           };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertAdvertisement", CommandType.StoredProcedure, parameters);
        }

        public DataTable ListAllAdvertisements()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllAdvertisements", CommandType.StoredProcedure);
        }
    }
}
