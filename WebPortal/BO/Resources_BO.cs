using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Resources_BO
    {
        public int ResourceID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public int FileType { get; set; }
    }
}
