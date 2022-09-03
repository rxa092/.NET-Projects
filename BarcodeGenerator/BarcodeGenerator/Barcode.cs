using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeGenerator
{
    class Barcode
    {
        public string ProductName { get; set; }
        public string ShiftName { get; set; }
        public string BarcodeId { get; set; }
        public int ProductId { get; set; }
        public DateTime date { get; set; }
        public int Shift { get; set; }
        public int Quantity { get; set; }
        public int Count { get; set; }
    }
}
