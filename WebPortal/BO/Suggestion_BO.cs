using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Suggestion_BO
    {
        public int SuggestionID { get; set; }
        public string Suggestions { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserID { get; set; }

    }
}
