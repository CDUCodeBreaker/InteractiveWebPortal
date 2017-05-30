using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BL
{
    public class Comment_BL
    {
        public static DataTable ListAllCommentsByPostID(int postID)
        {
            Comment_DAL objCommentDAL = new Comment_DAL();
            try
            {
                return objCommentDAL.ListAllCommentsByPostID(postID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCommentDAL = null;
            }
        }

        public int InsertComment(Comment_BO objCommentBO, int PostID)
        {

            Comment_DAL objCommentDAL = new Comment_DAL();
            try
            {
                return objCommentDAL.InsertComment(objCommentBO,PostID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCommentDAL = null;
            }
        }

        public static DataTable ListAllBlockedComments()
        {
            Comment_DAL objCommentDAL = new Comment_DAL();
            try
            {
                return objCommentDAL.ListAllBlockedComments();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCommentDAL = null;
            }
        }

        public void DeleteComment(int commentID)
        {
            Comment_DAL objCommentDAL = new Comment_DAL();
            try
            {
                objCommentDAL.DeleteComment(commentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCommentDAL = null;
            }
        }
        public void BlockComment(int commentID)
        {
            Comment_DAL objCommentDAL = new Comment_DAL();
            try
            {
                objCommentDAL.BlockComment(commentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCommentDAL = null;
            }
        }
    }
}
