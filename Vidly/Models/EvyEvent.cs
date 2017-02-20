using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evy.Models
{
    public class EvyEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
    }
}