using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class CementModel
    {
        public int id { get; set; }
        public int inwardid { get; set; }
        public DateTime date { get; set; }
        public string Bulker { get; set; }
        public string Supplier { get; set; }
        public int SupplierId { get; set; }
        public string PlantLocation { get; set; }
        public int Silo { get; set; }
        public string Quality { get; set; }
        public double Quantity { get; set; }

    }
}