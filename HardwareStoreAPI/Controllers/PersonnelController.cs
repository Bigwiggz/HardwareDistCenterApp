using Microsoft.AspNetCore.Mvc;

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
