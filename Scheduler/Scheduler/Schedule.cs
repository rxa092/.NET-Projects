using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    
    class Schedule
    {
        public List<slot> schedule { get; set; }
        public int clashes { get; set; }
    }
}
