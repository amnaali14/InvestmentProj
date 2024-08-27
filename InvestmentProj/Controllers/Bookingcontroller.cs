using Microsoft.AspNetCore.Mvc;
using InvestmentProj.Models; // Update this namespace to match your project
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvestmentProj.Data;
using Microsoft.AspNetCore.Identity.UI.Services; // For IEmailSender

namespace InvestmentProj.Controllers
{
    public class BookingController : Controller
    {
        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;
       

        [HttpGet]
        public IActionResult BookRoom()
        {
            ViewBag.ShowNavbar = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom(BookRoomViewModel booking)
        {
            // Basic form validation
            if (!ModelState.IsValid && booking.Checkin > booking.Checkout)
            {
                ModelState.AddModelError(string.Empty, "Invalid input data. Please check your inputs.");
                return View(booking); 
            }

           
                _context.Bookings.Add(new Booking 
                {
                    Name = booking.Name,
                    Email = booking.Email,
                    Checkin = booking.Checkin,
                    Checkout =booking.Checkout,
                    Adults = booking.Adults,
                    Children = booking.Children
                
                });

            await _context.SaveChangesAsync();
            return RedirectToAction("BookingConfirmation");
        }
    
        public IActionResult BookingConfirmation()
        {
            return View(); 
        }

        public async Task<IActionResult> ReservationHistory()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return View(bookings);
        }
    }
}
