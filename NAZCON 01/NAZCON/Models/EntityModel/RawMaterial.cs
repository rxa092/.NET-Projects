using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class RawMaterial
    {
        public int Id { get; set; }
        [Display(Name = "Raw Material Name")]
        public string Name { get; set; }
        [Display(Name = "Raw Material Quantity")]
        public double Quantity { get; set; }

        
    }
}