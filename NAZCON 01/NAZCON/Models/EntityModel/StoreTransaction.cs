using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class StoreTransaction
    {
        public int id { get; set; }

        [Display(Name = "Date")]
        public string date { get; set; }
        [Display(Name = "employee")]
        public string employee { get; set; }
        [Display(Name = "Item")]
        public int item { get; set; }
        [Display(Name = "Quantity")]
        public int quantity { get; set; }
        [Display(Name = "In OR Out ")]
        public string type { get; set; }
        [Display(Name = "Balance")]
        public int balance { get; set; }
        [Display(Name = "Employee Name")]
        public string employeename { get; set; }
        [Display(Name = "Item Name")]
        public string itemname { get; set; }

        public int? Reference { get; set; }

    }
}