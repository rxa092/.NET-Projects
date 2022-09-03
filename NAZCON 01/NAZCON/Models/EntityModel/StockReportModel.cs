using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class StockReportModel
    {
        public int Balance { get; set; }

        public int Broken { get; set; }
        public DateTime Date { get; set;  }
        public int StockIn { get; set; }
        public int StockOut { get; set; }

        public string Description { get; set; } 
    }
}