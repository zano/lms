using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Activity
   {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; } // Could be TimeSpan Duration instead

        public virtual Schedule Schedule { get; set; } // Could be another Activity, where Schedule is a special case of Activity
   }
}