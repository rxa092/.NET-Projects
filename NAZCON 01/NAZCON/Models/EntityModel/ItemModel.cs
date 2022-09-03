using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class ItemModel
    {
        [Display(Name = "Item Name")]
        public int id { get; set; }
        [Display(Name = "Item Name")]
        public string description { get; set; }
        [Display(Name = "Item Price")]
        public double price { get; set; }
        [Display(Name = "Item Quantity")]
        public int quantity { get; set; }
    }
}