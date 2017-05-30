using BO;
using Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class State_DAL
    {
        public DataTable StateList()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllStates", CommandType.StoredProcedure);
        }
    }
}
