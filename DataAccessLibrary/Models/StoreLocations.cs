using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class StoreLocations
    {
        public long StorelocationsID { get; set; }
        public long fkRegionalTerritoriesID { get; set; }
        public long fkCompaniesID { get; set; }
        public string StoreName { get; set; }
        public Geometry StoreLocation { get; set; }
        public string StoreStreet { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreZipCode { get; set; }
        public string StoreCountryCode { get; set; }
        public string StoreEmail { get; set; }
        public string StorePhone { get; set; }
        public string StoreCategory { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool ActiveStatus { get; set; }

    }
}
