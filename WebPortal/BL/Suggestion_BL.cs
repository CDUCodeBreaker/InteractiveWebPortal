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
    public class Suggestion_BL
    {
        public int SaveSuggestion(Suggestion_BO objSuggestionBO)
        {
            Suggestion_DAL objSuggestionDAL = new Suggestion_DAL();
            try
            {
                return objSuggestionDAL.InsertSuggestion(objSuggestionBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSuggestionDAL = null;
            }
        }
        public int UpdateSuggestion(Suggestion_BO objSuggestionBO)
        {
            Suggestion_DAL objSuggestionDAL = new Suggestion_DAL();
            try
            {
                return objSuggestionDAL.UpdateSuggestion(objSuggestionBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSuggestionDAL = null;
            }
        }

        public static DataTable MySuggestionList(int UserID)
        {
            Suggestion_DAL objSuggestionDAL = new Suggestion_DAL();
            try
            {
                return objSuggestionDAL.MySuggestionList(UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSuggestionDAL = null;
            }
        }

        public void DeleteSuggestion(int SuggestionID)
        {
            Suggestion_DAL objSuggestionDAL = new Suggestion_DAL();
            try
            {
                objSuggestionDAL.DeleteSuggestion(SuggestionID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSuggestionDAL = null;
            }
        }
        public static DataTable ListAllSuggestions()
        {
            Suggestion_DAL objSuggestionDAL = new Suggestion_DAL();
            try
            {
                return objSuggestionDAL.SuggestionList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSuggestionDAL = null;
            }
        }
    }
}
