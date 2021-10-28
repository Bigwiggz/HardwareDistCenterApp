using DataAccessLibrary.DataAccess;
using HardwareStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HardwareStoreAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStoreLocationsData _storeLocations;
        private readonly ICPIIndexData _CPIIndexData;

        public HomeController(ICPIIndexData CPIIndexData, ILogger<HomeController> logger, IStoreLocationsData storeLocations)
        {
            _logger = logger;
            _storeLocations = storeLocations;
            _CPIIndexData = CPIIndexData;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
