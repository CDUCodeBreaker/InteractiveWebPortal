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
    public class Group_BL
    {
        public int SaveGroup(Group_BO objGroupBO)
        {
            Group_DAL objGroupDAL = new Group_DAL();
            try
            {
                return objGroupDAL.InsertGroup(objGroupBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupDAL = null;
            }
        }

        public static DataTable ListMyGroups(int userid)
        {
            Group_DAL objGroupDAL = new Group_DAL();
            try
            {
                return objGroupDAL.MyGroupList(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupDAL = null;
            }
        }

        public int UpdateGroup(Group_BO objGroupBO)
        {
            Group_DAL objGroupDAL = new Group_DAL();
            try
            {
                return objGroupDAL.UpdateGroup(objGroupBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupDAL = null;
            }
        }
        public void DeleteGroup(int groupID)
        {
            Group_DAL objGroupDAL = new Group_DAL();
            try
            {
                objGroupDAL.DeleteGroup(groupID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupDAL = null;
            }
        }
        public static DataTable ListAllGroups()
        {
            Group_DAL objGroupDAL = new Group_DAL();
            try
            {
                return objGroupDAL.GroupList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupDAL = null;
            }
        }
    }
}
