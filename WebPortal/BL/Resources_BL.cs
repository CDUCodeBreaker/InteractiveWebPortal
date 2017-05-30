using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BL
{
    public class Resources_BL
    {
        public int SaveResource(Resources_BO objResourcesBO)
        {
            Resources_DAL objResourcesDAL = new Resources_DAL();
            try
            {
                return objResourcesDAL.InsertResource(objResourcesBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objResourcesDAL = null;
            }
        }

        public static DataTable ListAllResourcesByFileType(int filetype)
        {
            Resources_DAL objResourcesDAL = new Resources_DAL();
            try
            {
                return objResourcesDAL.ListAllResourcesByFileType(filetype);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objResourcesDAL = null;
            }
        }

        public static DataTable GetResourceByResourceID(int resourceID)
        {
            Resources_DAL objResourcesDAL = new Resources_DAL();
            try
            {
                return objResourcesDAL.GetResourceByResourceID(resourceID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objResourcesDAL = null;
            }
        }

        public void DeleteResourceByResourceID(int ResourceID)
        {
            Resources_DAL objResourcesDAL = new Resources_DAL();
            try
            {
                objResourcesDAL.DeleteResourceByResourceID(ResourceID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objResourcesDAL = null;
            }
        }
    }
}
