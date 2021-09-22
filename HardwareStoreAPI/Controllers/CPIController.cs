using AutoMapper;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using HardwareStoreAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: CPIController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CPIController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CPIController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CPIController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CPIController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CPIController/Delete/5
        public ActionResult Delete(int id)
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
