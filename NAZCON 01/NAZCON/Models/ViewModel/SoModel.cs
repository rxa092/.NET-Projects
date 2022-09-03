using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class SoModel
    {
        public string authorization { get; set; }
        [Display(Name = "Sales Order Number")]
        public int sono { get; set; }
        [Display(Name = "Quantity")]
        public int quantity { get; set; }
        [Display(Name = "Final Amount")]
        public double final { get; set; }

        [Display(Name = "Rate")]
        public int? price { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Display(Name = "Tax")]
        public double tax { get; set; }
        [Display(Name = "Location")]
        public string destination { get; set; }
        [Display(Name = "Total Amount Of Item")]
        public double total { get; set; }
        [Display(Name = "Remarks")]
        public string remarks { get; set; }
        [Display(Name = "Number Of Pallets")]
        public int pallets { get; set; }

        // public int itemid { get; set; }
        [Display(Name = "Item Name")]
        public string Description { get; set; }
        [Display(Name = "Purchase Order")]
        public string po { get; set; }

        public int Item { get; set; }

        public string Created { get; set; }

        public static int count = 0;

        public string Date { get; set; }
    }
}