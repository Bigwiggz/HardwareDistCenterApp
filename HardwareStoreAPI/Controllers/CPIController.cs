using AutoMapper;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using HardwareStoreBusinessLogicLibrary.DTOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HardwareStoreAPI.Controllers
{
    public class CPIController : Controller
    {
        private readonly ICPIIndexData _cpiIndexData;
        private readonly ILogger<CPIIndexData> _logger;
        private readonly IMapper _mapper;

        public CPIController(ICPIIndexData cpiIndexData, ILogger<CPIIndexData> logger, IMapper mapper)
        {
            _cpiIndexData = cpiIndexData;
            _logger = logger;
            _mapper = mapper;
        }
        // GET: CPIController
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var cpiData = await _cpiIndexData.GetAllAsync();
            var viewModel = _mapper.Map<IEnumerable<CPIIndexDTO>>(cpiData);

            return View(viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        // GET: CPIController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            long idLong;
            var isconvertedtoLong = long.TryParse(id, out idLong);
            if (isconvertedtoLong == false)
            {
                ViewBag.ErrorMessage = $"{id}";
            }
            var cpiIndex = await _cpiIndexData.GetByIdAsync(idLong);
            var viewModel = _mapper.Map<CPIIndexDTO>(cpiIndex);

            return View(viewModel); ;
        }

        [HttpGet]
        [AllowAnonymous]
        // GET: CPIController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CPIController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CPIIndexDTO cPIIndexDTO)
        {
            cPIIndexDTO.ActiveStatus = true;
            try
            {
                var cpiData = _mapper.Map<CPIIndex>(cPIIndexDTO);
                _cpiIndexData.InsertAsync(cpiData);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        // GET: CPIController/Edit/5
        public async Task<IActionResult> EditAsync(string id)
        {
            long idLong;
            var isconvertedtoLong=long.TryParse(id, out idLong);
            if (isconvertedtoLong==false)
            {
                ViewBag.ErrorMessage = $"{id}";
            }
            var cpiIndex =await _cpiIndexData.GetByIdAsync(idLong);
            var viewModel = _mapper.Map<CPIIndexDTO>(cpiIndex);

            return View(viewModel);
        }

        // POST: CPIController/Edit/5
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(CPIIndexDTO cPIIndexDTO)
        {
            if (ModelState.IsValid)
            {
                cPIIndexDTO.ActiveStatus = true;
                var cPIData = _mapper.Map<CPIIndex>(cPIIndexDTO);
                var rowsInserted = await _cpiIndexData.UpdateByIdAsync(cPIData);

                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return View();
            }
        }

        // GET: CPIController/Delete/5
        public ActionResult Delete(string id)
        {

            return View();
        }

        // POST: CPIController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
