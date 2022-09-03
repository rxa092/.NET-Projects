using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class DelieveryChallanReportModel
    {
        public int DCNO { get; set; }
        public string Date { get; set; }

        public string location { get; set; }
        public string TruckNo { get; set; }
        public string ClientName { get; set; }
        public int quantity { get; set; }
        public int pallets { get; set; }
        public string Description { get; set; }
        public string remarks { get; set; }
    }
}