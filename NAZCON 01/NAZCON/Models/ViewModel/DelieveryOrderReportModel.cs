using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class DelieveryOrderReportModel
    {
        public int DONO { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public int quantity { get; set; }
        public string Date { get; set; }
        public string destination { get; set; }

        public int pallets { get; set; }
    }
}