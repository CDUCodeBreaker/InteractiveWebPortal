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
    public class User_BL
    {

        public int SaveUser(User objUserBO)
        {
            User_DAL objUserDAL = new  User_DAL();
            try
            {
                return objUserDAL.InsertUser(objUserBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public static DataTable ListAllMembers()
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                return objUserDAL.ListAllMembers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public void UpdateUserPasswordByUserID(int UserID, string tempPass)
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                objUserDAL.UpdateUserPasswordByUserID(UserID,tempPass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public DataTable GetUserByEmail(string Email)
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                return objUserDAL.GetUserByEmail(Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public DataTable CheckLogin(User objUserBO)
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                return objUserDAL.UserLogin(objUserBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public static DataTable UserListByStatus(int Status)
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                return objUserDAL.UserListByStatus(Status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public void ApproveUser(int userid,string membershipno)
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                 objUserDAL.ApproveUser(userid, membershipno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public void RejectUser(int userid)
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                objUserDAL.RejectUser(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public void BlockUser(int userid)
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                objUserDAL.BlockUser(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public void RemoveUser(int userid)
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                objUserDAL.RemoveUser(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }

        public void UnBlockUser(int userid)
        {
            User_DAL objUserDAL = new User_DAL();
            try
            {
                objUserDAL.UnBlockUser(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserDAL = null;
            }
        }
    }
}
