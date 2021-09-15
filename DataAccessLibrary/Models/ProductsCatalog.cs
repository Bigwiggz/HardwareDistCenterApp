using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ProductsCatalog
    {
        public long ProductCatalogID { get; set; }
        public string productCompanyPurchaseDescription { get; set; }
        public Guid UniversalProductID { get; set; }
        public long fkCompaniesID { get; set; }
        public bool ActiveStatus { get; set; }
        public decimal BaseRetailPrice { get; set; }
        public decimal BaseWholeSalePrice { get; set; }
        public DateTime DateItemAddedUpdated { get; set; }

    }
}
