using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using Common;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class News_DAL
    {
        public int InsertNews(News_BO objNewsBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_NewsHeadLine", objNewsBO.NewsHeadLine),
                new MySqlParameter("@p_NewsBody", objNewsBO.NewsBody),
                new MySqlParameter("@p_CreatedBy", objNewsBO.CreatedBy),
                new MySqlParameter("@p_Status", objNewsBO.Status)
            };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertNews", CommandType.StoredProcedure, parameters);
        }

        public int UpdateNews(News_BO objNewsBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_NewsID", objNewsBO.NewsID),
                new MySqlParameter("@p_NewsHeadLine", objNewsBO.NewsHeadLine),
                new MySqlParameter("@p_NewsBody", objNewsBO.NewsBody),
                new MySqlParameter("@p_UpdateBy", objNewsBO.UpdateBy)
            };
            return MySqlDBHelper.ExecuteNonQuery("wp_UpdateNews", CommandType.StoredProcedure, parameters);
        }

        public DataTable NewsList()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllNews", CommandType.StoredProcedure);
        }

        public void DeleteNews(int newsID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_NewsID", newsID)
            };
            MySqlDBHelper.ExecuteNonQuery("wp_DeleteNews", CommandType.StoredProcedure, parameters);
        }
    }
}
