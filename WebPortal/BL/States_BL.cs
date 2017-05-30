using System;
using System.Data;
using DAL;
namespace BL
{
    public class States_BL
    {
        public static DataTable ListStates()
        {
            State_DAL objStateDAL = new State_DAL();
            try
            {
                return objStateDAL.StateList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objStateDAL = null;
            }
        }
    }
}
