using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Sales
    {
        public long SalesID { get; set; }
        public string SalesInvoiceNumber { get; set; }
        public string transactionCompanyPurchaseDescription { get; set; }
        public string SalesNotesToClient { get; set; }
        public DateTime SalesDate { get; set; }
        public bool ActiveStatus { get; set; }
        public long fkStoreLocationsID { get; set; }
        public Guid SaleAuthorizedBy {get; set;}

    }
}
