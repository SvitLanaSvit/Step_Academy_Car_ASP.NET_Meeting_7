using ASP_Meeting_7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_Meeting_7.Controllers
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
            string name = "Serhii Ruban";
            return View("About", (object)name);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string title, double price)
        {
            return Ok(new {title, price});
        }

        [HttpPost]
        public IActionResult GetCar()
        {
            return Ok(new {Model="X5", Price=4000});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}