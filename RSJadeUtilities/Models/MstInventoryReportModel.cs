using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSJadeUtilities.Models
{
    class MstInventoryReportModel
    {
        public String Document { get; set; }
        public String Id { get; set; }
        public DateTime InventoryDate { get; set; }
        public String Supplier { get; set; }
        public String Barcode { get; set; }
        public String ItemDescription { get; set; }
        public Decimal BeginningQuantity { get; set; }
        public Decimal InQuantity { get; set; }
        public Decimal ReturnQuantity { get; set; }
        public Decimal SoldQuantity { get; set; }
        public Decimal OutQuantity { get; set; }
        public Decimal EndingQuantity { get; set; }
        public String Unit { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
    }
}