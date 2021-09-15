using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class CompanyOrders
    {
        public long CompanyOrdersID { get; set; }
        public string CompanyPurchaseDescription { get; set; }
        public decimal CompanyOrderCosts { get; set; }
        public bool ActiveStatus { get; set; }
        public DateTime DateTimeOrdered { get; set; }
        public long fkProductOrderingDetailsID { get; set; }
        public long fkStoreLocationsID { get; set; }
        public Guid OrderAuthorizedBy { get; set; }

    }
}
