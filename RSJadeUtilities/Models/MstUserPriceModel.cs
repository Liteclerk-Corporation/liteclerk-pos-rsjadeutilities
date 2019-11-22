using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSJadeUtilities.Models
{
    class MstUserPriceModel
    {
        public Int32 Id { get; set; }
        public Int32 UserId { get; set; }
        public String FullName { get; set; }
        public String PriceDescription { get; set; }
    }
}
