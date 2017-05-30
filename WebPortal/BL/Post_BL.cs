using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BL
{
    public class Post_BL
    {
        public int SavePost(Post_BO objPostBO)
        {
            Post_DAL objPostDAL = new Post_DAL();
            try
            {
                return objPostDAL.InsertPost(objPostBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objPostDAL = null;
            }
        }
        public int UpdatePost(Post_BO objPostBO)
        {
            Post_DAL objPostDAL = new Post_DAL();
            try
            {
                return objPostDAL.UpdatePost(objPostBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objPostDAL = null;
            }
        }
        public static DataTable ListAllPosts()
        {
            Post_DAL objPostDAL = new Post_DAL();
            try
            {
                return objPostDAL.PostList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objPostDAL = null;
            }
        }

        public void DeletePost(int postID)
        {
            Post_DAL objPostDAL = new Post_DAL();
            try
            {
                objPostDAL.DeletePost(postID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objPostDAL = null;
            }
        }
    }
}
