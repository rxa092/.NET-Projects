using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class MouldModel
    {
        public int id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name ="Dimension")]
        public string Dimension { get; set; }
        [Display(Name = "Vendor")]
        public int vendor { get; set; }
        [Display(Name = "Vendor")]
        public string vendorname { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }
        [Display (Name =  "Status")]
        public string statusname { get; set; }
        [Display(Name = "Life Cycle Used")]
        public double lifecycle { get; set; }
        [Display(Name = "Date Of Installation")]
        public string dateofinstallation { get; set; }
        [Display(Name = "Mould Standard Life Cycle")]
        public double mouldstdcycle { get; set; }
    }
}