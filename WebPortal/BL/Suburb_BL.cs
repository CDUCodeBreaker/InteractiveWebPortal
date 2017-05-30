using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Suburb_BL
    {
        public static DataTable ListSuburbs()
        {
            Suburb_DAL objSuburbs = new Suburb_DAL();
            try
            {
                return objSuburbs.SuburbList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSuburbs = null;
            }
        }
    }
}
