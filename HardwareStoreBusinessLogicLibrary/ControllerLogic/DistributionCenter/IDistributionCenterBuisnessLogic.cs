using DataAccessLibrary.Models;
using HardwareStoreBusinessLogicLibrary.DTOModels;
using System.Collections.Generic;

namespace HardwareStoreBusinessLogicLibrary.ControllerLogic.DistributionCenter
{
    public interface IDistributionCenterBuisnessLogic
    {
        ZoneDistributionCentersGeoJSONDTO CreateGeoJSONDTOfromModel(List<ZoneDistributionCenters> zoneDistributionCentersList);
        ZoneDistributionCenters CreateSingleModelFromGeoJSON(ZoneDistributionCentersGeoJSONDTO zoneDistributionCentersGeoJSONDTO);
    }
}