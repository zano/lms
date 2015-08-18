using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    //[ComplexType]
    public class Schedule
    {
        public int Id { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        // Activities
    }
}