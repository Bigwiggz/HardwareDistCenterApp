using AutoMapper;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
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

        public DistributionCenterController(IZoneDistributionCenterData zoneDistributionCenterData, ILogger<ZoneDistributionCenters> logger, IMapper mapper)
        {
            _zoneDistributionCenterData = zoneDistributionCenterData;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var distributionCenters = await _zoneDistributionCenterData.GetAllAsync();



            return View();
        }
    }
}
