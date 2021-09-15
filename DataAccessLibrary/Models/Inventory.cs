using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Inventory
    {
        public long InventoryID { get; set; }
        public long fkProductsCatalogID { get; set; }
        public long QuantityInStock { get; set; }
        public DateTime SalesTimeStamp { get; set; }
        public long PurchaseOrSale { get; set; }
        public bool ActiveStatus { get; set; }

    }
}
