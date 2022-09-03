using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class Production
    {
        [Display(Name ="Date")]
        public string date { get; set; }
        public int ProductionId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Product")]
        public string ProductName { get; set; }
        [Display(Name = "A Grade Steel Pallets")]
        public double Agradesteelpallets { get; set; }
        [Display(Name = "A Grade Units")]
        public double agradeunits { get; set; }
        [Display(Name = "B Grade Units")]
        public double bgradeunits { get; set; }
        [Display(Name = "B Grade Steel Pallets")]
        public double bgradesteelpallets { get; set; }
        [Display(Name = "Broken By Machine Pallets")]
        public double bokenbymachinepallets { get; set; }
        [Display(Name = "Broken By Machine Units")]
        public double brokenbymachineunits { get; set; }
        [Display(Name = "Broken By Operator Pallets")]
        public double brokenbyoperatorpallets { get; set; }
        [Display(Name = "Broken By Operator Units")]
        public double brokenbyoperatorunits { get; set; }
        [Display(Name = "Actual Cycle Time")]
        public double actualcycletime { get; set; }
        [Display(Name = "Size mm")]
        public double size { get; set; }
        [Display(Name = "Weight kg")]
        public double weight { get; set; }
        [Display(Name = "Remarks")]
        public string remarks { get; set; }
        public int shiftinchargeid { get; set; }
        [Display(Name = "Shift Incharge")]
        public string shiftinchargename { get; set; }
        [Display(Name = "Actual Start Time")]
        public string actualstarttime { get; set; }
        [Display (Name = "Total Pallets")]
        public double totalproductionsteelapllets { get; set; }
        [Display (Name = "Total Units")]
        public double totalproductionunits { get; set; }
        [Display(Name = "Efficiency 100%")]
        public double efficiency100 { get; set; }
        [Display(Name = "Actual Efficiency")]
        public double actualefficiency { get; set; }
        [Display(Name = "Opening")]
        public double opening { get; set; }
        [Display(Name = "Recieving")]
        public double recieving { get; set; }
        [Display(Name = "Consumption")]
        public double consumption { get; set; }
        [Display(Name = "Balance")]
        public double balance { get; set; }
        [Display(Name = "Total Mixes")]
        public double totalmixes { get; set; }
        [Display(Name = "Mix Weight")]
        public double mixweight { get; set; }
        [Display(Name = "Single Piece Weight")]
        public double singlepieceweight { get; set; }
        [Display(Name = "No Of Pieces In One Pallet")]
        public double noofpiecesinonepallet { get; set; }
        [Display(Name = "No Of Pieces In One Mix")]
        public double noofpiecesinonemix { get; set; }
        [Display(Name = "No Of Plates In One Mix")]
        public double noofplatesinonemix { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public ProductionRawMaterial rawmaterial { get; set; }
        [Display(Name = "Aggregate Use")]
        public double AggregateUsed { get; set; }
        [Display (Name = "Total Consumption")]
        public double TotalConsumption { get; set; }


    }
}