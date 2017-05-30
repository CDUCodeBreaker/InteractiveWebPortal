using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class News_BO
    {
        public int NewsID { get; set; }
        public string NewsHeadLine { get; set; }
        public string NewsBody { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
