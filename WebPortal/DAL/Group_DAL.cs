using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using MySql.Data.MySqlClient;
using Common;

namespace DAL
{
    public class Group_DAL
    {
        public int InsertGroup(Group_BO objGroupBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_groupname", objGroupBO.GroupName),
                new MySqlParameter("@p_createdby", objGroupBO.CreatedBy),
                new MySqlParameter("@p_status", objGroupBO.Status)
            };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertGroup", CommandType.StoredProcedure, parameters);
        }

        public int UpdateGroup(Group_BO objGroupBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
             {
                new MySqlParameter("@p_groupid", objGroupBO.GroupID),
                new MySqlParameter("@p_groupname", objGroupBO.GroupName)
             };
            return MySqlDBHelper.ExecuteNonQuery("wp_UpdateGroup", CommandType.StoredProcedure, parameters);
        }

        public DataTable MyGroupList(int userid)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_userid", userid)
            };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_SelectAllMyGroups", CommandType.StoredProcedure, parameters);
        }

        public DataTable GroupList()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllGroups", CommandType.StoredProcedure);
        }

        public void DeleteGroup(int groupID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
          {
                new MySqlParameter("@p_groupid", groupID)
          };
            MySqlDBHelper.ExecuteNonQuery("wp_DeleteGroup", CommandType.StoredProcedure, parameters);
        }
    }
}
