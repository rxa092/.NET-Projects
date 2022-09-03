using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class StockMOvementModel
    {
        [Display(Name = "Balance")]
        public int balance { get; set; }
        [Display(Name = "Stock In")]
        public int stockin { get; set; }
        [Display(Name = "Stock Out")]
        public int stockout { get; set; }
        public ItemModel item { get; set; }
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        public int Id { get; set; }
        [Display(Name = "Broken")]
        public int broken { get; set; }
    }
}