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
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;

        // Constructor with dependency injection for AppDbContext and IEmailSender
        public BookingController(AppDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult BookRoom()
        {
            ViewBag.ShowNavbar = false; // This will only work if utilized in the layout or view
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookRoom(BookRoomViewModel booking)
        {
            // Basic form validation
            if (!ModelState.IsValid || booking.Checkin == default || booking.Checkout == default || booking.Checkin > booking.Checkout)
            {
                ModelState.AddModelError(string.Empty, "Invalid input data. Please check your inputs.");
                return View(booking); // Return the view with validation errors and existing data
            }

            // Save the booking to the database
            _context.Bookings.Add(new Booking // Assuming Booking is your entity class
            {
                Name = booking.Name,
                Checkin = booking.Checkin,
                Checkout = booking.Checkout,
                Adults = booking.Adults,
                Children = booking.Children
                // Add other properties as needed
            });

            await _context.SaveChangesAsync();

            // Send confirmation email
            var email = booking.Email; // Ensure the ViewModel has an Email property
            var subject = "Booking Confirmation";
            var message = $"Dear {booking.Name},<br><br>Your booking has been confirmed.<br>Check-in: {booking.Checkin.ToShortDateString()}<br>Check-out: {booking.Checkout.ToShortDateString()}<br><br>Thank you for booking with us!";

            await _emailSender.SendEmailAsync(email, subject, message);

            return RedirectToAction("BookingConfirmation");
        }

        public IActionResult BookingConfirmation()
        {
            return View(); // Ensure that you have a view named "BookingConfirmation" for this action
        }

        public async Task<IActionResult> ReservationHistory()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return View(bookings);
        }
    }
}
