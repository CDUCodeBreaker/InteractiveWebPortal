using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;
using System.Data;

namespace BL
{
    public class GroupMember_BL
    {
        public void SaveGroupMember(GroupMember_BO objGroupMemberBO)
        {
            GroupMember_DAL objGroupMemberDAL = new GroupMember_DAL();
            try
            {
                objGroupMemberDAL.InsertGroupMember(objGroupMemberBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupMemberDAL = null;
            }
        }

        public DataTable GroupMemberListByGroupID(int groupID)
        {
            GroupMember_DAL objGroupMemberDAL = new GroupMember_DAL();
            try
            {
                return objGroupMemberDAL.GroupMemberListByGroupID(groupID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupMemberDAL = null;
            }
        }

        public void DeleteGroupMemberByGroupID(int groupID)
        {
            GroupMember_DAL objGroupMemberDAL = new GroupMember_DAL();
            try
            {
                 objGroupMemberDAL.DeleteGroupMemberByGroupID(groupID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupMemberDAL = null;
            }
        }

        public static DataTable ListEmailAddressByGroupID(int GroupID)
        {
            GroupMember_DAL objGroupMemberDAL = new GroupMember_DAL();
            try
            {
                return objGroupMemberDAL.ListEmailAddressByGroupID(GroupID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupMemberDAL = null;
            }
        }

        public DataTable GroupMembersByGroupID(int groupID)
        {
            GroupMember_DAL objGroupMemberDAL = new GroupMember_DAL();
            try
            {
                return objGroupMemberDAL.GroupMembersByGroupID(groupID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objGroupMemberDAL = null;
            }
        }
    }
}
