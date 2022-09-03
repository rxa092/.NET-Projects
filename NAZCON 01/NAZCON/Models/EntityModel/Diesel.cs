using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class Diesel
    {
        [Display (Name ="Date")]
        public DateTime dateforview { get; set; }
        [Display (Name ="Date")]
        public string Date { get; set; }
        [Display (Name ="Vehicle #")]
        public string Vehicle { get; set; }
        [Display (Name ="Vehicle Type")]
        public string VehicleType { get; set; }
        [Display (Name ="Opening Dip")]
        public double OpeningDiesel { get; set; }
        [Display (Name = "Last Reading if meter is changed manually")]
        public double LastReading { get; set; }
        [Display (Name = "Current Dispenser Reading")]
        public double CurrentReading { get; set; }
        [Display (Name ="Diesel Consumed In Litre")]
        public double DieselDispensery { get; set; }
        [Display (Name ="Balance In Tank")]
        public double Balance { get; set; }
        [Display (Name ="Dip Record IN")]
        public double DipRecordin { get; set; }

        public int id { get; set; }
    }
}