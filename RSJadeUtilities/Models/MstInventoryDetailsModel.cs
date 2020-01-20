using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSJadeUtilities.Models
{
    public class MstInventoryDetailsModel
    {
        public String ReferenceNumber { get; set; }
        public DateTime ReferenceDate { get; set; }
        public String Remarks { get; set; }
        public Decimal Quantity { get; set; }
    }
}