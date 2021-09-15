using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ProductOrdersDetails
    {
        public long ProductOrdersID { get; set; }
        public long fkProductCatalogID { get; set; }
        public long QuatityofProductOrdered { get; set; }
        public long fkCompanyOrdersID { get; set; }
        public decimal LineItemCompanyOrderCosts { get; set; }
        public bool ActiveStatus { get; set; }

    }
}
