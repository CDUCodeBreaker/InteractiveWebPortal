using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BL
{
    public class Suggestion_Reply_BL
    {
        public int SaveSuggestionReply(Suggestion_Reply_BO objSuggestionReplyBO)
        {
            Suggestion_Reply_DAL objSuggestionReplyDAL = new Suggestion_Reply_DAL();
            try
            {
                return objSuggestionReplyDAL.InsertSuggestionReply(objSuggestionReplyBO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSuggestionReplyDAL = null;
            }
        }

        public static DataTable ListAllReplyBySuggestionID(int SuggestionID)
        {
           
                Suggestion_Reply_DAL objSuggestionReplyDAL = new Suggestion_Reply_DAL();
                try
                {
                    return objSuggestionReplyDAL.ListAllReplyBySuggestionID(SuggestionID);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                objSuggestionReplyDAL = null;
                }
        }
    }
}
