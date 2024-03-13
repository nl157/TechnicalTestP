using CoffeeSubscriptionManager.FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeeSubscriptionManager.FrontEnd.Controllers
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

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Subscription()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        public IActionResult Coffee()
        {
            return View();
        }

        public IActionResult CoffeeBatch()
        {
            return View();
        }

        public IActionResult Accessory()
        {
            return View();
        }
        public IActionResult GrindSize()
        {
            return View();
        }

        public IActionResult ContactPreference()
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
