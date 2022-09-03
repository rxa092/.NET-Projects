using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class Inventory
    {
        public int id { get; set; }
        [Display(Name = "Item Name")]
        public string name { get; set; }
        [Display(Name = "Item Quantity")]
        public int quantity { get; set; }

        public int Category { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public int location { get; set; }
        [Display(Name = "Location")]
        public string LocationName { get; set; }
    }
}