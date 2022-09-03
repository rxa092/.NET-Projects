using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class MouldStatusModel
    {
        public int id { get; set; }
        [Display(Name = "Status")]
        public string name { get; set; }
    }
}