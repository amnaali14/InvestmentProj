using Microsoft.AspNetCore.Mvc;
using InvestmentProj.Models; // Adjust to your actual namespace
using System.Linq;
using System.Threading.Tasks;
using InvestmentProj.Data;
using IvestmentProj.Models;

public class BookingController : Controller
{
    private readonly AppDbContext _context;

    // Constructor to initialize the context
    public BookingController(AppDbContext context)
    {
        _context = context;
    }

    // Action method to show the booking creation form
    public IActionResult Create()
    {
        return View();
    }

    // Action method to handle form submission
    [HttpPost]
    public async Task<IActionResult> Create(Booking booking)
    {
        if (ModelState.IsValid)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(booking);
    }

    // Action method to list all bookings
    public IActionResult Index()
    {
        var bookings = _context.Bookings.ToList();
        return View(bookings);
    }
}
