using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Models;
using HardwareStoreAPI.DTOs;
using HardwareStoreBusinessLogicLibrary.Services;


namespace HardwareStoreBusinessLogicLibrary.ControllerLogic.DistributionCenter
{
    public class DistributionCenterBuisnessLogic
    {
        public DistributionCenterBuisnessLogic()
        {
            var geoServices= new GeoServices();
        }

        public ZoneDistributionCentersGeoJSONDTO CreateGeoJSONDTOfromModel(List<ZoneDistributionCenters> zoneDistributionCentersList)
        {
            var zoneDistributionGeoJSONDTO=new ZoneDistributionCentersGeoJSONDTO();

            List<ZoneDistributionCenters> zoneDistributionCenters=new();

            foreach(var distributionCenter in ZoneDistributionCenters)
            {
                var newFeature= new Feature();

                newFeature.type="Feature";

                var newProperties=new Properties
                {
                    ZoneDistributionCenterID = zoneDistributionCentersList.ZoneDistributionCenterID,
                    ZoneDistributionCenterStreet= zoneDistributionCentersList.ZoneDistributionCenterStreet,
                    ZoneDistributionCenterCity = zoneDistributionCentersList.ZoneDistributionCenterCity,
                    ZoneDistributionCenterState = zoneDistributionCentersList.ZoneDistributionCenterState,
                    ZoneDistributionCenterZipCode = zoneDistributionCentersList.ZoneDistributionCenterZipCode,
                    ZoneDistributionCenterCountryCode = zoneDistributionCentersList.ZoneDistributionCenterCountryCode,
                    ZoneDistributionCenterCode = zoneDistributionCentersList.ZoneDistributionCenterCode,
                    ActiveStatus = zoneDistributionCentersList.ActiveStatus,
                    fkDistrictSalesZoneID = zoneDistributionCentersList.fkDistrictSalesZoneID
                };

                var newGeometry=new Geometry();

                newGeometry.type="Point";
                newGeometry.coordinates=new decimal[]{zoneDistributionCentersList.Longitude,zoneDistributionCentersList.Latitude};

                newFeature.Properties=newProperties;
                newFeature.Geometry=newGeometry;
                ZoneDistributionCenters.Add(newFeature);
            }

            zoneDistributionGeoJSONDTO.features=ZoneDistributionCenters.ToArray();

            return zoneDistributionGeoJSONDTO;

        }

        public ZoneDistributionCenters CreateSingleModelFromGeoJSON(ZoneDistributionCentersGeoJSONDTO zoneDistributionCentersGeoJSONDTO)
        {
            //TODO: Create NTS Geometry-Create a Geometry extension for NTS methods
            var zoneGeometry=geoServices.CreateNTSGeometryFromGeometryGeoJSONObject<Geometry>(zoneDistributionCentersGeoJSONDTO.Feature[0].Geometry)

            var zoneDistributionCenter=new ZoneDistributionCenters
            {
                ZoneDistributionCenterLocation=zoneGeometry,
                ZoneDistributionCenterID = zoneDistributionCentersGeoJSONDTO.Feature[0].Properties.ZoneDistributionCenterID,
                ZoneDistributionCenterStreet= zoneDistributionCentersGeoJSONDTO.Feature[0].Properties.ZoneDistributionCenterStreet,
                ZoneDistributionCenterCity = zoneDistributionCentersGeoJSONDTO.Feature[0].Properties.ZoneDistributionCenterCity,
                ZoneDistributionCenterState = zoneDistributionCentersGeoJSONDTO.Feature[0].Properties.ZoneDistributionCenterState,
                ZoneDistributionCenterZipCode = zoneDistributionCentersGeoJSONDTO.Feature[0].Properties.ZoneDistributionCenterZipCode,
                ZoneDistributionCenterCountryCode = zoneDistributionCentersGeoJSONDTO.Feature[0].Properties.ZoneDistributionCenterCountryCode,
                ZoneDistributionCenterCode = zoneDistributionCentersGeoJSONDTO.Feature[0].Properties.ZoneDistributionCenterCode,
                ActiveStatus = zoneDistributionCentersGeoJSONDTO.Feature[0].Properties.ActiveStatus,
                fkDistrictSalesZoneID = zoneDistributionCentersGeoJSONDTO.Feature[0].Properties.fkDistrictSalesZoneID

            };

            return zoneDistributionCenter;

        }
    }


}
