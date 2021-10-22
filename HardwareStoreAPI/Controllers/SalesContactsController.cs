using AutoMapper;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using HardwareStoreBusinessLogicLibrary.DTOModels.SpecialDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Controllers
{
    public class SalesContactsController : Controller
    {
        private readonly ICompanyContactsData _companyContactsData;
        private readonly ILogger<CompanyContactsData> _logger;
        private readonly IMapper _mapper;

        public SalesContactsController(ICompanyContactsData companyContactsData, ILogger<CompanyContactsData> logger, IMapper mapper)
        {
            _companyContactsData = companyContactsData;
            _logger = logger;
            _mapper = mapper;
        }
        [AllowAnonymous]
        public async Task<IActionResult> IndexAsync()
        {
            var companyContactsList = await _companyContactsData.GetCompanyContactsWithStoreLocationsAsync();
            var viewModel = _mapper.Map<IEnumerable<CompanyContactsWithStoreLocationsDTO>>(companyContactsList);
            return View(viewModel);
        }
    }
}
