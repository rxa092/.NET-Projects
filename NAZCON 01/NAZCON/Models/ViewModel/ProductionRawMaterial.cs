using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class ProductionRawMaterial
    {
        public int TransactionId { get; set; }
        [Display(Name = "Raw Material")]
        public int RMId { get; set; }
        [Display(Name = "Aggregate Use")]
        public double AggregateUse { get; set; }
        [Display(Name = "Total Consumption")]
        public double TotalConsumption { get; set; }
        [Display(Name = "Total Weight In single Mix")]
        public double TotalWeightInSingleMix { get; set; }
        [Display(Name = "Raw Material Name")]
        public string Name { get; set; }
    }
}