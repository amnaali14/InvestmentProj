using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models; // Update this namespace to match your project
using System;

namespace YourNamespace.Controllers
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
        public IActionResult BookRoom(BookingModel booking)
        {
            // Basic form validation
            if (!ModelState.IsValid || booking.CheckIn == default || booking.CheckOut == default || booking.CheckIn > booking.CheckOut)
            {
                ModelState.AddModelError(string.Empty, "Invalid input data. Please check your inputs.");
                return View(booking); // Return the view with validation errors and existing data
            }

            // Process the form submission
            // You can save the data to the database or perform other actions here

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View(); // Ensure that you have a view named "Confirmation" for this action
        }
    }
}
