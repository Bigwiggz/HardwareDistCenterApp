using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;

namespace HardwareStoreBusinessLogicLibrary.DTOModels
{
    public class ZoneDistributionCentersGeoJSONDTO
    {
        public string type { get; set; } = "FeatureCollection";
        public Feature[] features { get; set; }
    }

    public class Feature 
    {
        public string type { get; set; } = "Feature";
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Properties
    {
        public long ZoneDistributionCenterID { get; set; } 
        public string ZoneDistributionCenterStreet{ get; set; }
        public string ZoneDistributionCenterCity { get; set; }
        public string ZoneDistributionCenterState { get; set; }
        public string ZoneDistributionCenterZipCode { get; set; }
        public string ZoneDistributionCenterCountryCode { get; set; }
        public string ZoneDistributionCenterCode { get; set; }
        public bool ActiveStatus { get; set; }
        public long fkDistrictSalesZoneID { get; set; }
        public string ZoneDistributionCenterFullAddress
        {
            get { return $"{ZoneDistributionCenterStreet} {ZoneDistributionCenterCity}, {ZoneDistributionCenterState} {ZoneDistributionCenterZipCode}"; }
        }
    }

    public class Geometry
    {
        public string type { get; set; } = "Point";
        public decimal[] coordinates { get; set; }
    }

}
