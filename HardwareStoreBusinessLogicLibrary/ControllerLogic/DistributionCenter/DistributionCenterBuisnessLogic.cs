using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwareStoreBusinessLogicLibrary.Services;
using HardwareStoreBusinessLogicLibrary.DTOModels;

namespace HardwareStoreBusinessLogicLibrary.ControllerLogic.DistributionCenter
{
    public class DistributionCenterBuisnessLogic : IDistributionCenterBuisnessLogic
    {
        public DistributionCenterBuisnessLogic()
        {

        }

        public ZoneDistributionCentersGeoJSONDTO CreateGeoJSONDTOfromModel(List<ZoneDistributionCenters> zoneDistributionCentersList)
        {
            var zoneDistributionGeoJSONDTO = new ZoneDistributionCentersGeoJSONDTO();

            List<Feature> zoneDistributionCenters = new();

            foreach (var distributionCenter in zoneDistributionCentersList)
            {
                var newFeature = new Feature();

                newFeature.type = "Feature";

                var newProperties = new DTOModels.Properties
                {
                    ZoneDistributionCenterID = distributionCenter.ZoneDistributionCenterID,
                    ZoneDistributionCenterStreet = distributionCenter.ZoneDistributionCenterStreet,
                    ZoneDistributionCenterCity = distributionCenter.ZoneDistributionCenterCity,
                    ZoneDistributionCenterState = distributionCenter.ZoneDistributionCenterState,
                    ZoneDistributionCenterZipCode = distributionCenter.ZoneDistributionCenterZipCode,
                    ZoneDistributionCenterCountryCode = distributionCenter.ZoneDistributionCenterCountryCode,
                    ZoneDistributionCenterCode = distributionCenter.ZoneDistributionCenterCode,
                    ActiveStatus = distributionCenter.ActiveStatus,
                    fkDistrictSalesZoneID = distributionCenter.fkDistrictSalesZoneID
                };

                var newGeometry = new Geometry();

                newGeometry.type = "Point";
                //TODO:-Check to see if coordinates are correct
                newGeometry.coordinates = new decimal[] { (decimal)distributionCenter.ZoneDistributionCenterLocation.Coordinates[0].X, (decimal)distributionCenter.ZoneDistributionCenterLocation.Coordinates[0].Y};

                newFeature.properties = newProperties;
                newFeature.geometry = newGeometry;
                zoneDistributionCenters.Add(newFeature);
            }

            zoneDistributionGeoJSONDTO.features = zoneDistributionCenters.ToArray();

            return zoneDistributionGeoJSONDTO;

        }

        public ZoneDistributionCenters CreateSingleModelFromGeoJSON(ZoneDistributionCentersGeoJSONDTO zoneDistributionCentersGeoJSONDTO)
        {
            var geoServices = new GeoServices();
            //TODO: Create NTS Geometry-Create a Geometry extension for NTS methods
            var zoneGeometry = geoServices.CreateNTSGeometryFromGeometryGeoJSONObject<Geometry>(zoneDistributionCentersGeoJSONDTO.features[0].geometry);

            var zoneDistributionCenter = new ZoneDistributionCenters
            {
                ZoneDistributionCenterLocation = zoneGeometry,
                ZoneDistributionCenterID = zoneDistributionCentersGeoJSONDTO.features[0].properties.ZoneDistributionCenterID,
                ZoneDistributionCenterStreet = zoneDistributionCentersGeoJSONDTO.features[0].properties.ZoneDistributionCenterStreet,
                ZoneDistributionCenterCity = zoneDistributionCentersGeoJSONDTO.features[0].properties.ZoneDistributionCenterCity,
                ZoneDistributionCenterState = zoneDistributionCentersGeoJSONDTO.features[0].properties.ZoneDistributionCenterState,
                ZoneDistributionCenterZipCode = zoneDistributionCentersGeoJSONDTO.features[0].properties.ZoneDistributionCenterZipCode,
                ZoneDistributionCenterCountryCode = zoneDistributionCentersGeoJSONDTO.features[0].properties.ZoneDistributionCenterCountryCode,
                ZoneDistributionCenterCode = zoneDistributionCentersGeoJSONDTO.features[0].properties.ZoneDistributionCenterCode,
                ActiveStatus = zoneDistributionCentersGeoJSONDTO.features[0].properties.ActiveStatus,
                fkDistrictSalesZoneID = zoneDistributionCentersGeoJSONDTO.features[0].properties.fkDistrictSalesZoneID

            };

            return zoneDistributionCenter;

        }
    }


}
