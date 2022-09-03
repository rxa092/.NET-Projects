using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class DispatchReport
    {
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public string PO { get; set; }
        public int ProductId { get; set; }
        public string Truck { get; set; }
        public int DO { get; set; }
        public int DC { get; set; }
        public int Quantity { get; set; }
        [Display (Name = "Pallets")]
        public int cube_pallet { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public int DispatchId { get; set; }
        public int Cube_Pallets { get; set; }
        public string Description { get; set; }

    }
}