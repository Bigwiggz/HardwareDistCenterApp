using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class SalesDetails
    {
        public long SalesDetailsID { get; set; }
        public long fkSalesID { get; set; }
        public long fkProductsCatalog { get; set; }
        public long QuatitySold { get; set; }
        public string SalesSpecialNotes { get; set; }
        public string CompanyPurchaseDescription { get; set; }
        public bool ActiveStatus { get; set; }
        public decimal SalesDiscountAmount { get; set; }
        public decimal SalesLineItemCharge { get; set; }

    }
}
