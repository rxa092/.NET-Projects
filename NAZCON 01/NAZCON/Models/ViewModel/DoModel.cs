using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class DoModel
    {
        [Display(Name = "Remaining Quantity")]
        public int remaining { get; set; }
        [Display(Name = "Delivery Order Number")]
        public int Do_number { get; set; }
        [Display(Name = "Client Name")]
        public string Client { get; set; }
        [Display(Name = "Destination")]
        public string Destination { get; set; }
        [Display(Name = "Created By")]
        public string Created_by { get; set; }
        [Display(Name = "Date")]
        public string Date { get; set; }
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }
        [Display(Name = "Sales Order Number")]
        public int sono { get; set; }
        [Display(Name = "Item Name")]
        public string Item_Description { get; set; }

    }



}