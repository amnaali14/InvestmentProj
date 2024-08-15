using Microsoft.AspNetCore.Mvc;
using InvestmentProj.Models; // Update this namespace to match your project
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using InvestmentProj.Data;

namespace InvestmentProj.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public IActionResult BookRoom()
        {
            ViewBag.ShowNavbar = false; // This will only work if utilized in the layout or view
            return View();
        }

        [HttpPost]
        public IActionResult BookRoom(BookRoomViewModel booking)
        {
            // Basic form validation
            if (!ModelState.IsValid || booking.Checkin == default || booking.Checkout == default || booking.Checkin > booking.Checkout)
            {
                ModelState.AddModelError(string.Empty, "Invalid input data. Please check your inputs.");
                return View(booking); // Return the view with validation errors and existing data
            }

            // Process the form submission
            // You can save the data to the database or perform other actions here

            return RedirectToAction("Bookingconfirmation");
        }
        [HttpPost]
        public IActionResult BookRoomViewModel(BookRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Convert ViewModel to the database entity if needed
                var booking = new BookRoomViewModel
                {
                    Name = model.Name,
                    Checkin = model.Checkin,
                    Checkout = model.Checkout,
                    Adults = model.Adults,
                    Children = model.Children
                    // Add other properties as needed
                };


                // Redirect or return a view
                return RedirectToAction("Bookingconfirmation");
            }

            // If model is not valid, return the view with the model
            return View(model);
        }

        public IActionResult Bookingconfirmation()
        {
            return View(); // Ensure that you have a view named "Confirmation" for this action
        }
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ReservationHistory()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return View(bookings);
        }
    } 
}
