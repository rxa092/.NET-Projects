using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class MouldReport
    {
        [Display(Name ="Date")]
        public string date { get; set; }
        [Display(Name = "Mould")]
        public int mouldid { get; set; }
        [Display(Name = "Plates")]
        public int plates { get; set; }
        public int reportid { get; set; }
        public MouldModel mm { get; set; }
        public MouldStatusModel msm { get; set; }

    }
}