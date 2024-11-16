using InvestmentProj.Data;
using InvestmentProj.Models;
using InvestmentProj.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Ensure you have this using directive
using System.Diagnostics;

namespace InvestmentProj.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context; // Declare the context

        // Inject the context and logger via constructor
        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Fetch the list of Room objects from the database
            var rooms = _context.Rooms.ToList();

            // Map Room objects to RoomVM objects
            var roomVMs = rooms.Select(room => new RoomVM
            {
                RoomID = room.RoomID,
       
                // Map other properties as needed
            }).ToList();

            // Pass the list of RoomVMs to the view
            return View(roomVMs);
        }

        public IActionResult AuthSelection()
        {
            return View();
        }

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
        public IActionResult Rooms()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Services()
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
