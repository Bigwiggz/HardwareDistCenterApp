using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ICECATProductCatalog
    {
        public long ICECATEProductCatalogID { get; set; }

        public string ManufacturerProductID { get; set; }

        public string EAN_UPC { get; set; }

        public string HtmlPath { get; set; }

        public string Limited { get; set; }

        public DateTime DistributorInfoUpdated { get; set; }

        public string HighPic { get; set; }

        public string HighPicSize { get; set; }

        public string HighPicWidth { get; set; }

        public string HighPicHeight { get; set; }

        public string ProductID { get; set; }

        public DateTime Updated { get; set; }

        public string Quality { get; set; }

        public string ProdID { get; set; }

        public string fkSupplierID { get; set; }

        public string Catid { get; set; }

        public string On_Market { get; set; }

        public string ModelName { get; set; }

        public string ProductView { get; set; }
        public decimal InitialUnitPrice { get; set; }

        public DateTime DateAdded { get; set; }

        public bool ActiveStatus { get; set; }
    }
}
