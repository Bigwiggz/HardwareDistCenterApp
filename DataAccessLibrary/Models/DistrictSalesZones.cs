using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class DistrictSalesZones
    {
        public long DistrictSalesZoneID { get; set; }
        public Guid DistrictManagerID { get; set; }
        public string DistrictSalesZoneName { get; set; }
        public string DistrictSalesZoneNumber { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
