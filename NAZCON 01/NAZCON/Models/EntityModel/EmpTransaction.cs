using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class EmpTransaction
    {
       public string empid { get; set; }
        [Display(Name = "Employee Name")]
        public string name { get; set; }
        public int tranid { get; set; }
        [Display(Name = "Transaction Amount")]
        public double amount { get; set; }

        public DateTime date { get; set; }
        [Display(Name = "Transaction Reason")]
        public string description { get; set; }
             
    }
}