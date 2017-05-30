using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Advertisement_BO
    {
        public int AdvertisementID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
