using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Post_BO
    {
        public int PostID { get; set; }
        public string PostSubject { get; set; }
        public string PostBody { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
