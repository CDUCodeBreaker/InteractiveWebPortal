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
    public class Suggestion_Reply_DAL
    {
        public int InsertSuggestionReply(Suggestion_Reply_BO objSuggestionReplyBO)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
             {
                new MySqlParameter("@p_suggestionid", objSuggestionReplyBO.SuggestionID),
                new MySqlParameter("@p_repliedby", objSuggestionReplyBO.RepliedBy),
                new MySqlParameter("@p_reply", objSuggestionReplyBO.Reply)
             };
            return MySqlDBHelper.ExecuteNonQuery("wp_InsertSuggestionReply", CommandType.StoredProcedure, parameters);
        }

        public DataTable ListAllReplyBySuggestionID(int suggestionID)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
         {
                new MySqlParameter("@p_suggestionID", suggestionID)
         };
            return MySqlDBHelper.ExecuteParamerizedSelectCommand("wp_ListAllReplyBySuggestionID", CommandType.StoredProcedure, parameters);
        }
    }
}
