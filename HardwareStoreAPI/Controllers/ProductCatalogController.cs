using AutoMapper;
using DataAccessLibrary.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Controllers
{
    public class ProductCatalogController : Controller
    {
        private readonly IICECATProductCatalogData _icecatProductCatalogData;
        private readonly ILogger<ICECATProductCatalogData> _logger;
        private readonly IMapper _mapper;

        public ProductCatalogController(IICECATProductCatalogData icecatProductCatalogData, ILogger<ICECATProductCatalogData> logger, IMapper mapper)
        {
            _icecatProductCatalogData = icecatProductCatalogData;
            _logger = logger;
            _mapper = mapper;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var catalogList = await _icecatProductCatalogData.GetAllDistinctCategoryID();

            var catalogNumberList = new List<int>();

            foreach (var item in catalogList)
            {

                int newItem = Int32.Parse(item);
                catalogNumberList.Add(newItem);
            };

            catalogNumberList.OrderBy(o => o);

            return View(catalogNumberList);
        }
    }
}
