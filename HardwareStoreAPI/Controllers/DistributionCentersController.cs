using AutoMapper;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using HardwareStoreAPI.Models;
using HardwareStoreBusinessLogicLibrary.ControllerLogic.DistributionCenter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Controllers
{
    [AllowAnonymous]
    public class DistributionCentersController : Controller
    {
        private readonly IZoneDistributionCenterData _zoneDistributionCenterData;
        private readonly ILogger<ZoneDistributionCenters> _logger;
        private readonly IMapper _mapper;
        private readonly IDistributionCenterBuisnessLogic _distributionCentersBusinessLogic;

        public DistributionCentersController(IZoneDistributionCenterData zoneDistributionCenterData, ILogger<ZoneDistributionCenters> logger, IMapper mapper, IDistributionCenterBuisnessLogic distributionCentersBusinessLogic)
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

        public async Task<IActionResult> DetailsAsync(long? Id)
        {
            var distributionCenter = await _zoneDistributionCenterData.GetByIdAsync(Id.Value);

            if (distributionCenter is null)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = Id.ToString(),
                    ControllerRedirect = this.ControllerContext.RouteData.Values["controller"].ToString()
                };
                Response.StatusCode = 404;
                return View("ResourceNotFound", errorViewModel);
            }

            return View(distributionCenter);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(long? Id)
        {
            var distributionCenter = await _zoneDistributionCenterData.GetByIdAsync(Id.Value);

            return View();
        }

    }
}
