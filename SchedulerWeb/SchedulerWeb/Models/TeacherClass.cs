using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchedulerWeb.Models
{
    public class TeacherClass
    {
        public Teacher teacher { get; set; }
        public Classes classes { get; set; }
    }
}