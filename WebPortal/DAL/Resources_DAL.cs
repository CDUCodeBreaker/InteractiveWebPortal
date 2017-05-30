using BO;
using Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Resources_DAL
    {
        public int InsertResource(Resources_BO objResourcesBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_filename", objResourcesBO.FileName),
                new MySqlParameter("@p_filepath", objResourcesBO.FilePath),
                new MySqlParameter("@p_filetype", objResourcesBO.FileType),
                new MySqlParameter("@p_createdby", objResourcesBO.CreatedBy)
           };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertResources", CommandType.StoredProcedure, parameters);
        }

        public DataTable ListAllResourcesByFileType(int filetype)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_filetype", filetype)
           };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_SelectAllResourcesByFileType", CommandType.StoredProcedure, parameters);
        }

        public DataTable GetResourceByResourceID(int resourceID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_resourceID", resourceID)
           };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_SelectResourcesByResourceID", CommandType.StoredProcedure, parameters);
        }

        public void DeleteResourceByResourceID(int resourceID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
          {
                new MySqlParameter("@p_resourceID", resourceID)
          };
             MySqlDBHelper.ExecuteNonQuery("wp_DeleteResourceByResourceID", CommandType.StoredProcedure, parameters);
        }
    }
}
