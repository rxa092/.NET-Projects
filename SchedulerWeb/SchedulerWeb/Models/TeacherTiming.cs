using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWeb.Models
{
    public class TeacherTiming
    {
        public Teacher Teacher { get; set; }
        public Days Days { get; set; }
        public Timeslots Timeslots { get; set; }
    }
}