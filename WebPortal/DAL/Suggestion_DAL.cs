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
    public class Suggestion_DAL
    {
        public int InsertSuggestion(Suggestion_BO objSuggestionBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
              {
                new MySqlParameter("@p_suggestion", objSuggestionBO.Suggestions),
                new MySqlParameter("@p_createdby", objSuggestionBO.CreatedBy),
                new MySqlParameter("@p_userid", objSuggestionBO.UserID)
              };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertSuggestion", CommandType.StoredProcedure, parameters);
        }

        public int UpdateSuggestion(Suggestion_BO objSuggestionBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
             {
                new MySqlParameter("@p_suggestionid", objSuggestionBO.SuggestionID),
                new MySqlParameter("@p_suggestion", objSuggestionBO.Suggestions)
             };
            return MySqlDBHelper.ExecuteNonQuery("wp_UpdateSuggestion", CommandType.StoredProcedure, parameters);
        }

        public void DeleteSuggestion(int suggestionID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
          {
                new MySqlParameter("@p_suggestionid", suggestionID)
          };
            MySqlDBHelper.ExecuteNonQuery("wp_DeleteSuggestion", CommandType.StoredProcedure, parameters);
        }

        public DataTable MySuggestionList(int UserID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
          {
                new MySqlParameter("@p_userid", UserID)
          };
          return  MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_SelectAllMySuggestions", CommandType.StoredProcedure, parameters);
        }

        public DataTable SuggestionList()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllSuggestions", CommandType.StoredProcedure);
        }
    }
}
