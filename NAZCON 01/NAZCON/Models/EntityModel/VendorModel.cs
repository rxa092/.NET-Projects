using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class VendorModel
    {
        public int id { get; set; }
        [Display(Name = "Vendor Name")]
        public string name { get; set; }
        [Display(Name = "Vendor Contact")]
        public string cellno { get; set; }
        [Display(Name = "Vendor NIC")]
        public string nic { get; set; }
        [Display(Name = "Vendor Address")]
        public string address { get; set; }
    }
}