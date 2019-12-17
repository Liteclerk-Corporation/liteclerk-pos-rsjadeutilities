using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSJadeUtilities.DataGridViewModels
{
    class DgvInventoryReportListModel
    {
        public String InventoryReportListSupplier { get; set; }
        public String InventoryReportListBarcode { get; set; }
        public String InventoryReportListItemDescription { get; set; }
        public String InventoryReportListBeginningQuantity { get; set; }
        public String InventoryReportListInQuantity { get; set; }
        public String InventoryReportListReturnQuantity { get; set; }
        public String InventoryReportListSoldQuantity { get; set; }
        public String InventoryReportListOutQuantity { get; set; }
        public String InventoryReportListEndingQuantity { get; set; }
        public String InventoryReportListUnit { get; set; }
        public String InventoryReportListCost { get; set; }
        public String InventoryReportListAmount { get; set; }
    }
}