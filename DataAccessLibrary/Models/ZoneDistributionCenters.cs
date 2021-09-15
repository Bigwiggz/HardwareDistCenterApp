using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace DataAccessLibrary.Models
{
    public class ZoneDistributionCenters
    {
        public long ZoneDistributionCenterID { get; set; }
        public Geometry ZoneDistributionCenterLocation { get; set; }
        public string ZoneDistributionCenterStreet { get; set; }
        public string ZoneDistributionCenterCity { get; set; }
        public string ZoneDistributionCenterState { get; set; }
        public string ZoneDistributionCenterZipCode { get; set; }
        public string ZoneDistributionCenterCountryCode { get; set; }
        public string ZoneDistributionCenterCode { get; set; }
        public bool ActiveStatus { get; set; }
        public long fkDistrictSalesZoneID { get; set; }

    }
}
