using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Models
{
    public class UpEventModel
    {
        public string id_num { get; set; }
        public string location { get; set; }
        public string event_date { get; set; }
        public string organizer_name { get; set; }
        public string event_type { get; set; }
        public string picture { get; set; }
        public string name { get; set; }
    }
}