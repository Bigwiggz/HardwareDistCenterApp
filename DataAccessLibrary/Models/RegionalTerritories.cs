using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class RegionalTerritories
    {
        public long RegionalTerritoriesID { get; set; }
        public string TerritoryColorCode { get; set; }
        public Geometry TerritoryGeometry { get; set; }
        public string TerritoryNumber { get; set; }
        public decimal TerritoryPerimeterLength { get; set; }
        public decimal TerritoryArea { get; set; }
        public string TerritoryAccount { get; set; }
        public string territoryCompanyPurchaseDescription { get; set; }
        public bool ActiveStatus { get; set; }
        public DateTime DateTerritoryAddedUpdated { get; set; }
        public long fkDistrictSalesZoneID { get; set; }
        public Guid RegionalSupervisorID { get; set; }

    }
}
