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
    public class Announcement_BL
    {
        public int SaveAnnouncement(Announcement_BO objAnnouncementBO)
        {
            Announcement_DAL objAnnouncementDAL = new Announcement_DAL();
            try
            {
                return objAnnouncementDAL.InsertAnnouncement(objAnnouncementBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objAnnouncementDAL = null;
            }
        }

        public int UpdateAnnouncement(Announcement_BO objAnnouncementBO)
        {
            Announcement_DAL objAnnouncementDAL = new Announcement_DAL();
            try
            {
                return objAnnouncementDAL.UpdateAnnouncement(objAnnouncementBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objAnnouncementDAL = null;
            }
        }
        public static DataTable ListAllAnnouncements()
        {
            Announcement_DAL objAnnouncementDAL = new Announcement_DAL();
            try
            {
                return objAnnouncementDAL.AnnouncementList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objAnnouncementDAL = null;
            }
        }

        public void DeleteAnnouncement(int AnnouncementID)
        {
            Announcement_DAL objAnnouncementDAL = new Announcement_DAL();
            try
            {
                objAnnouncementDAL.DeleteAnnouncement(AnnouncementID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objAnnouncementDAL = null;
            }
        }
    }
}
