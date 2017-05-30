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
   public class Advertisement_BL
    {
        public int SaveResource(Advertisement_BO objAdvertisementBO)
        {
            Advertisement_DAL objAdvertisementDAL= new Advertisement_DAL();
            try
            {
                return objAdvertisementDAL.InsertAdvertisement(objAdvertisementBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objAdvertisementDAL = null;
            }
        }

        public static DataTable ListAllAdvertisements()
        {
            Advertisement_DAL objAdvertisementDAL = new Advertisement_DAL();
            try
            {
                return objAdvertisementDAL.ListAllAdvertisements();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objAdvertisementDAL = null;
            }
        }

        public static DataTable GetAdvertisementByAdvertisementID(int advertisementID)
        {
            Advertisement_DAL objAdvertisementDAL = new Advertisement_DAL();
            try
            {
                return objAdvertisementDAL.GetAdvertisementByAdvertisementD(advertisementID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objAdvertisementDAL = null;
            }
        }

        public void DeleteAdvertisementByAdvertisementID(int advertisementID)
        {
            Advertisement_DAL objAdvertisementDAL = new Advertisement_DAL();
            try
            {
                objAdvertisementDAL.DeleteAdvertisementByAdvertisementID(advertisementID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objAdvertisementDAL = null;
            }
        }
    }
}
