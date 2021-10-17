using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Controllers
{
    public class PersonnelController : Controller
    {
        public PersonnelController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
