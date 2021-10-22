using AutoMapper;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using HardwareStoreBusinessLogicLibrary.ControllerLogic.DistributionCenter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Controllers
{
    public class DistributionCenterController : Controller
    {
        private readonly IZoneDistributionCenterData _zoneDistributionCenterData;
        private readonly ILogger<ZoneDistributionCenters> _logger;
        private readonly IMapper _mapper;
        private readonly IDistributionCenterBuisnessLogic _distributionCentersBusinessLogic;

        public DistributionCenterController(IZoneDistributionCenterData zoneDistributionCenterData, ILogger<ZoneDistributionCenters> logger, IMapper mapper, IDistributionCenterBuisnessLogic distributionCentersBusinessLogic)
        {
            _zoneDistributionCenterData = zoneDistributionCenterData;
            _logger = logger;
            _mapper = mapper;
            _distributionCentersBusinessLogic = distributionCentersBusinessLogic;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var distributionCenters = await _zoneDistributionCenterData.GetAllAsync();

            var viewModel = _distributionCentersBusinessLogic.CreateGeoJSONDTOfromModel(distributionCenters.ToList());

            return View(viewModel);
        }


    }
}
