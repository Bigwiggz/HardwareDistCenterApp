using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models.SpecialModels
{
    public class CompanyContactsWithStoreLocations
    {
        public long CompanyContactsID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhone { get; set; }
        public bool CompanyContactActiveStatus { get; set; }
        public long fkStoreLocationsID { get; set; }
        public string ContactEmail { get; set; }
        public string StoreStreet { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreZipCode { get; set; }
        public string StoreEmail { get; set; }
        public string StorePhone { get; set; }
        public string StoreName { get; set; }
        public bool StoreActiveStatus { get; set; }
    }

}
