using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class News_BL
    {
        public int SaveNews(News_BO objNewsBO)
        {
            News_DAL objNewsDAL = new News_DAL();
            try
            {
                return objNewsDAL.InsertNews(objNewsBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objNewsDAL = null;
            }
        }
        public int UpdateNews(News_BO objNewsBO)
        {
            News_DAL objNewsDAL = new News_DAL();
            try
            {
                return objNewsDAL.UpdateNews(objNewsBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objNewsDAL = null;
            }
        }
        public static DataTable ListAllNews()
        {
            News_DAL objNewsDAL = new News_DAL();
            try
            {
                return objNewsDAL.NewsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objNewsDAL = null;
            }
        }

        public void DeleteNews(int newsID)
        {
            News_DAL objNewsDAL = new News_DAL();
            try
            {
                objNewsDAL.DeleteNews(newsID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objNewsDAL = null;
            }
        }
    }
}
