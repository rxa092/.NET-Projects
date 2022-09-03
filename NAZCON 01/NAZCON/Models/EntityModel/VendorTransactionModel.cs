using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class VendorTransactionModel
    {
        public int tranid { get; set; }
        public int vid { get; set; }
        [Display(Name = "Vendor Name")]
        public string vname { get; set; }
        [Display(Name = "Transaction Amount")]
        public double amount { get; set; }
        [Display(Name = "Product")]
        public string product { get; set; }
        [Display(Name = "Product Quantity")]
        public int quantity { get; set; }
        [Display(Name = "Date Of Transaction")]
        public DateTime date { get; set; }
    }
}