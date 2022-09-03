using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class ClientModel
    {
        [Display(Name ="Client Name")]
        public string Client_name { get; set; }
        public string Date { get; set; }
        [Display(Name = "Client Email")]
        public string Client_email { get; set; }
        [Display(Name = "Client Contact")]
        public string  Client_contact { get; set; }
        [Display(Name = "Client Address")]
        public string address { get; set; }
        [Display(Name = "Client Opening Balance")]
        public double OpeningBalance { get; set; }

        public int Client_id { get; set; }

    }
}