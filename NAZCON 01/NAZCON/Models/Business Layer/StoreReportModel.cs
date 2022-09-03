using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class StoreReportModel
    {
        public int Balance { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string ItemName { get; set; }
        public string EmployeeName { get; set; }


    }
}