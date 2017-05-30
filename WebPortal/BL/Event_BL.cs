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
    public class Event_BL
    {
        public static DataTable ListAllEvents()
        {
            Event_DAL objEventDAL = new Event_DAL();
            try
            {
                return objEventDAL.EventList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objEventDAL = null;
            }
        }

        public int UpdateEvent(Event_BO objEventBO)
        {
            Event_DAL objEventDAL = new Event_DAL();
            try
            {
                return objEventDAL.UpdateEvent(objEventBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objEventDAL = null;
            }
        }

        public int SaveEvent(Event_BO objEventBO)
        {
           Event_DAL objEventDAL = new Event_DAL();
            try
            {
                return objEventDAL.InsertEvent(objEventBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objEventDAL = null;
            }
        }

        public void DeleteEvent(int eventID)
        {
            Event_DAL objEventDAL = new Event_DAL();
            try
            {
                objEventDAL.DeleteEvents(eventID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objEventDAL = null;
            }
        }
    }
}
