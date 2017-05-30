using MySql.Data.MySqlClient;
using System.Data;
using BO;
using Common;
using System;

namespace DAL
{
    public class User_DAL
    {
        public int InsertUser(User obj)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_firstname", obj.FirstName),
                new MySqlParameter("@p_lastname", obj.LastName),
                new MySqlParameter("@p_email", obj.Email),
                new MySqlParameter("@p_password", obj.Password),
                new MySqlParameter("@p_mobileno", obj.MobileNo),
                new MySqlParameter("@p_dateofbirth", obj.DateOfBirth),
                new MySqlParameter("@p_address1", obj.Address1),
                new MySqlParameter("@p_address2", obj.Address2),
                new MySqlParameter("@p_postalcode", obj.PostalCode),
                new MySqlParameter("@p_suburb", obj.Suburb),
                new MySqlParameter("@p_state", obj.State),
                new MySqlParameter("@p_country", obj.Country),
                new MySqlParameter("@p_status", obj.Status),
                new MySqlParameter("@p_usertype", obj.UserType),
                new MySqlParameter("@p_filename", obj.FileName),
                new MySqlParameter("@p_filepath", obj.FilePath)
            };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertUsers", CommandType.StoredProcedure, parameters);
        }

        public void UpdateUserPasswordByUserID(int userID, string tempPass)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
             {
                new MySqlParameter("@p_userID", userID),
                new MySqlParameter("@p_tempPass", tempPass)
             };
            MySqlDBHelper.ExecuteNonQuery("wp_UpdateUserPasswordByUserID", CommandType.StoredProcedure, parameters);
        }

        public DataTable GetUserByEmail(string email)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_email", email)
            };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_GetUserByEmail", CommandType.StoredProcedure, parameters);
        }

        public DataTable ListAllMembers()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllUsersForGroup", CommandType.StoredProcedure);
        }

        public DataTable UserListByStatus(int status)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_status", status)
            };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_userlistByStatus", CommandType.StoredProcedure, parameters);
        }

        public void ApproveUser(int userid,string membershipno)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
               {
                new MySqlParameter("@p_userid", userid),
                new MySqlParameter("@p_membershipno", membershipno)

               };
            MySqlDBHelper.ExecuteNonQuery("wp_ApproveUsers", CommandType.StoredProcedure, parameters);
        }

        public void BlockUser(int userid)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_userid", userid)

           };
            MySqlDBHelper.ExecuteNonQuery("wp_BlockUsers", CommandType.StoredProcedure, parameters);
        }

        public void RejectUser(int userid)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_userid", userid)

            };
            MySqlDBHelper.ExecuteNonQuery("wp_RejectUsers", CommandType.StoredProcedure, parameters);
        }

        public void RemoveUser(int userid)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_userid", userid)

           };
            MySqlDBHelper.ExecuteNonQuery("wp_RemoveUsers", CommandType.StoredProcedure, parameters);
        }

        public DataTable UserLogin(User objUserBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_email", objUserBO.Email),
                new MySqlParameter("@p_password", objUserBO.Password)
            };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_userlogin", CommandType.StoredProcedure, parameters);
        }

        public void UnBlockUser(int userid)
        {

            MySqlParameter[] parameters = new MySqlParameter[]
           {
                new MySqlParameter("@p_userid", userid)

           };
            MySqlDBHelper.ExecuteNonQuery("wp_UnBlockUsers", CommandType.StoredProcedure, parameters);
        }
    }
}
