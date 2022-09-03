using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class InwardRawMaterial
    {
        public int InwardId { get; set; }
        public DateTime date { get; set; }
        public int ReferenceNo { get; set; }
        public int VendorId { get; set; }
        public int RawMaterialId { get; set; }
        public string Vehicle { get; set; }
        public string TimeIn { get; set; }
        public double Quantity { get; set; }
        public string Remarks { get; set; }
        public string RawMaterialName { get; set; }
        public string VendorName { get; set;  }
        
        public string RMName { get; set; }
        public string Vendor_name { get; set; } 
    }
}