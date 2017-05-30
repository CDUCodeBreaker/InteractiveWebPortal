using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using MySql.Data.MySqlClient;
using Common;
using System.Data;

namespace DAL
{
    public class GroupMember_DAL
    {
        public void InsertGroupMember(GroupMember_BO objGroupMemberBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_groupid", objGroupMemberBO.GroupID),
                new MySqlParameter("@p_userid", objGroupMemberBO.UserID)
           };
            MySqlDBHelper.ExecuteNonQuery("wp_InsertGroupMember", CommandType.StoredProcedure, parameters);
        }

        public DataTable GroupMemberListByGroupID(int groupID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_groupid", groupID)
           };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_SelectGroupMemberListByGroupID", CommandType.StoredProcedure, parameters);
        }

        public void DeleteGroupMemberByGroupID(int groupID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
          {
                new MySqlParameter("@p_groupid", groupID)
          };
            MySqlDBHelper.ExecuteNonQuery("wp_DeleteGroupMemberByGroupID", CommandType.StoredProcedure, parameters);
        }

        public DataTable ListEmailAddressByGroupID(int groupID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_groupid", groupID)
           };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("ListEmailAddressByGroupID", CommandType.StoredProcedure, parameters);
        }

        public DataTable GroupMembersByGroupID(int groupID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
          {
                new MySqlParameter("@p_groupid", groupID)
          };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_GroupMembersByGroupID", CommandType.StoredProcedure, parameters);
        }
    }
}
