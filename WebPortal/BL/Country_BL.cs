using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Country_BL
    {
        public static DataTable ListCountry()
        {
            Country_DAL objCountryDAL = new Country_DAL();
            try
            {
                return objCountryDAL.CountryList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCountryDAL = null;
            }
        }
    }
}
