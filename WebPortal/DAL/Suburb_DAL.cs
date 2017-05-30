using Common;
using System.Data;

namespace DAL
{
    public class Suburb_DAL
    {
        public DataTable SuburbList()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllSuburbs", CommandType.StoredProcedure);
        }
    }
}
