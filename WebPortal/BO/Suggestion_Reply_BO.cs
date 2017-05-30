using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Suggestion_Reply_BO
    {
        public int ReplyID { get; set; }
        public int SuggestionID { get; set; }
        public string RepliedBy { get; set; }
        public string Reply { get; set; }
        public DateTime ReplyDate { get; set; }
    }
}
