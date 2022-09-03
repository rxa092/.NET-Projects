using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class SalesOrderReportModel
    {
        

        public int SONO { get; set;}
        public DateTime Date { get; set; }
        public string ClientName { get; set; }

        public string destination { get; set; }

        public string Description { get; set; }

        public int quantity { get; set; }

        public int pallets { get; set; }
        public double price { get; set; }
        public double tax { get; set; }
        public double total { get; set; }
        public string Created { get; set; }
        public string remarks { get; set; }
        public double Final_Amount { get; set; }









    }
}