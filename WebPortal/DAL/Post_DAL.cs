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
    public class Post_DAL
    {
        public int InsertPost(Post_BO objPostBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@PostSubject", objPostBO.PostSubject),
                new MySqlParameter("@PostBody", objPostBO.PostBody),
                new MySqlParameter("@CreatedBy", objPostBO.CreatedBy),
                new MySqlParameter("@Status", objPostBO.Status),
            };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertPost", CommandType.StoredProcedure, parameters);
        }

        public int UpdatePost(Post_BO objPostBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
             {
                new MySqlParameter("@p_ID", objPostBO.PostID),
                new MySqlParameter("@p_Subject", objPostBO.PostSubject),
                new MySqlParameter("@p_Body", objPostBO.PostBody),
                new MySqlParameter("@p_UpdateBy", objPostBO.UpdateBy),
             };
            return MySqlDBHelper.ExecuteNonQuery("wp_UpdatePost", CommandType.StoredProcedure, parameters);
        }

        public DataTable PostList()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllPosts", CommandType.StoredProcedure);
        }

        public void DeletePost(int postID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_ID", postID)
           };
            MySqlDBHelper.ExecuteNonQuery("wp_DeletePost", CommandType.StoredProcedure, parameters);
        }
    }
}
