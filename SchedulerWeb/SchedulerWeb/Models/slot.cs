using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWeb.Models
{
    public class slot
    {
        public TeacherClass classid { get; set; }
        public Room room { get; set; }
        public Timeslots Timeslots { get; set; }
        public Days Days { get; set; }
        public bool clash = false;
        
    }
}