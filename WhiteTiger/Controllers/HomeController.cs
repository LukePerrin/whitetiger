using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WhiteTiger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Covid()
        {
            return View();
        }

        public IActionResult Clients()
        {
            return View();
        }

        public IActionResult Commercial()
        {
            return View();
        }

        public IActionResult Construction()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult CarpetFloor()
        {
            return View();
        }

        public IActionResult SafeContractor()
        {
            return View();
        }

        public IActionResult IndustrialCommercial()
        {
            return View();
        }

        public IActionResult IndustrialConstruction()
        {
            return View();
        }

    }
}
