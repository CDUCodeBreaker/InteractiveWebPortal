using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Announcement_BO
    {
        public int AnnouncementID { get; set; }
        public string Announcement { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
    }
}
