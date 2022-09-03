using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class ClientTransaction
    {
        public int clientid { get; set; }
        [Display(Name = "Client Name")]
        public string name { get; set; }
        [Display(Name = "Client Account Balance")]
        public double account { get; set; }
        public DateTime date { get; set; }
        [Display(Name = "Transaction Amount")]
        public double amount { get; set; }

        public int paymentid { get; set; }
    }
}