using Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class Comment_DAL
    {
        public DataTable ListAllCommentsByPostID(int postID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_postid", postID)
           };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_SelectAllCommentsByPostID", CommandType.StoredProcedure, parameters);
        }

        public int InsertComment(Comment_BO objCommentBO, int postID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_comment", objCommentBO.Comment),
                new MySqlParameter("@p_commentType", objCommentBO.CommentType),
                new MySqlParameter("@p_createdby", objCommentBO.CreatedBy),
                new MySqlParameter("@p_status", objCommentBO.Status),
                new MySqlParameter("@p_postid", postID)
           };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertComment", CommandType.StoredProcedure, parameters);
        }

        public void DeleteComment(int commentID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
          {
                new MySqlParameter("@p_CommentID", commentID)
          };
            MySqlDBHelper.ExecuteNonQuery("wp_DeleteCommentByCommentID", CommandType.StoredProcedure, parameters);
        }

        public DataTable ListAllBlockedComments()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllBlockComments", CommandType.StoredProcedure);
        }

        public void BlockComment(int commentID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
          {
                new MySqlParameter("@p_CommentID", commentID)
          };
            MySqlDBHelper.ExecuteNonQuery("wp_BlockCommentByCommentID", CommandType.StoredProcedure, parameters);
        }
    }
}
