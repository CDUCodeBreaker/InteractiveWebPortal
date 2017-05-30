using Common;
using System.Data;

namespace DAL
{
    public class Country_DAL
    {
        public DataTable CountryList()
        {
            return MySqlDBHelper.ExecuteSelectCommand("wp_SelectAllCountry", CommandType.StoredProcedure);
        }
    }
}
