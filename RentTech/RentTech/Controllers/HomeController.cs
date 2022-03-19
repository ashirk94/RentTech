using Microsoft.AspNetCore.Mvc;
using RentTech.Models;
using System.Diagnostics;

namespace RentTech.Controllers
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
            ViewBag.Current = "Home";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Current = "Privacy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            ViewBag.Current = "About";
            return View();
        }
    }
}