using InvestmentProj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvestmentProj.Controllers
{
    [Authorize]
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

        public IActionResult AuthSelection()
        {
            return View();
        }

        // Action method for Gallery page
        [AllowAnonymous]
        public IActionResult Gallery()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult News()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult AboutUs()
        {
            return View();
        }

        [AllowAnonymous]
        // Action method for Rooms page
        public IActionResult Rooms()
        {
            return View();
        }

        // Action method for Hotels page


        [AllowAnonymous]
        // Action method for Services page
        public IActionResult Services()
        {
            return View();
        }

      
    
        // Error handling
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
