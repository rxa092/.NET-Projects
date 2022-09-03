using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class GpModel
    {
        [Display(Name = "Date")]
        public string date { get; set; }
        [Display(Name = "Gate Pass Number")]
        public int GPNO { get; set; }
        public string authorization { get; set; }
        [Display(Name = "Delivery Order Number")]
        public int dono { get; set; }
        [Display(Name = "Truck Number")]
        public string truck { get; set; }
        [Display(Name = "Item Quantity")]
        public double quantity { get; set; }
        [Display(Name = "Number Of Pallets")]
        public int no_of_pallets { get; set; }

        public ItemModel im { get; set; }
        [Display(Name = "Location")]
        public string location { get; set; }
        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        public ClientModel cm { get; set; }
        [Display(Name = "Delivery Challan Number")]
        public int dcno { get; set; }
 
    }
}