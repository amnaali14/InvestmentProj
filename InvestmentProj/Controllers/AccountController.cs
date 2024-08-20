using InvestmentProj.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace InvestmentProj.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // Add your logic here to authenticate the user.
                bool isAuthenticated = AuthenticateUser(model.Username, model.Password);
                if (isAuthenticated)
                {
                    // Redirect to the homepage or another action after successful login.
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If authentication fails, add an error message.
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            // If we got this far, something failed, redisplay the form.
            return View(model);
        }
       
        private bool AuthenticateUser(string Username, string Password)
        {
            // Replace this with your actual authentication logic.
            if (Username == "testuser" && Password == "password")
            {
                return true;
            }
            return false;
        }
        [HttpGet]
        public IActionResult Registerconfirm()
        {
            return View();
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterVM
            {
                CountryCodes = GetCountryCodes()
            };

            return View(model);
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                // Implement your registration logic here, like saving the user to the database.
                bool isRegistered = RegisterUser(model);
                if (isRegistered)
                {
                    // Redirect to the registration confirmation page.
                    return RedirectToAction("Registerconfirm");
                }
                else
                {
                    // Add an error message if registration fails.
                    ModelState.AddModelError("", "Registration failed. Please try again.");
                }
            }

            // If we got this far, something failed, redisplay the form with the list of country codes.
            model.CountryCodes = GetCountryCodes();
            return View(model);
        }

        private bool RegisterUser(RegisterVM model)
        {
            // Replace this with your actual registration logic.
            return true;
        }

        private List<CountryCodeVM> GetCountryCodes()
        {
            var countryCodes = new List<CountryCodeVM>
            {
                new CountryCodeVM { Code = "+93", Name = "Afghanistan" },
                new CountryCodeVM { Code = "+61", Name = "Australia" },
                new CountryCodeVM { Code = "+88", Name = "Mongolia" },
                new CountryCodeVM { Code = "+55", Name = "Brazil" },
                new CountryCodeVM { Code = "+53", Name = "Cuba" },
                new CountryCodeVM { Code = "+20", Name = "Egypt" },
                new CountryCodeVM { Code = "+68", Name = "East Timor" },
                new CountryCodeVM { Code = "+33", Name = "France" },
                new CountryCodeVM { Code = "+49", Name = "Germany" },
                new CountryCodeVM { Code = "+34", Name = "Spain" },
                new CountryCodeVM { Code = "+82", Name = "South Korea" },
                new CountryCodeVM { Code = "+7", Name = "Russia" },
                new CountryCodeVM { Code = "+1", Name = "United States" },
                new CountryCodeVM { Code = "+44", Name = "United Kingdom" },
                new CountryCodeVM { Code = "+81", Name = "Japan" },
                new CountryCodeVM { Code = "+86", Name = "Macau" },
                new CountryCodeVM { Code = "+39", Name = "Italy" },
                new CountryCodeVM { Code = "+91", Name = "India" },
                new CountryCodeVM { Code = "+98", Name = "Iran" },
                new CountryCodeVM { Code = "+84", Name = "China" },
                new CountryCodeVM { Code = "+92", Name = "Pakistan" },
                new CountryCodeVM { Code = "+57", Name = "Colombia" },
                new CountryCodeVM { Code = "+52", Name = "Mexico" },
                new CountryCodeVM { Code = "+60", Name = "Malaysia" },
                new CountryCodeVM { Code = "+31", Name = "Netherlands" },
                new CountryCodeVM { Code = "+46", Name = "Sweden" },
                new CountryCodeVM { Code = "+41", Name = "Switzerland" },
                new CountryCodeVM { Code = "+65", Name = "Singapore" },
                new CountryCodeVM { Code = "+94", Name = "Sri Lanka" },
                new CountryCodeVM { Code = "+95", Name = "Nepal" },
                new CountryCodeVM { Code = "+64", Name = "New Zealand" },
                new CountryCodeVM { Code = "+66", Name = "Thailand" },
                new CountryCodeVM { Code = "+87", Name = "Taiwan" },
                new CountryCodeVM { Code = "+70", Name = "Norway" },
                new CountryCodeVM { Code = "+97", Name = "Bangladesh" },
                new CountryCodeVM { Code = "+62", Name = "Indonesia" },
                new CountryCodeVM { Code = "+80", Name = "Monaco" },
                new CountryCodeVM { Code = "+99", Name = "Kazakhstan" },
                new CountryCodeVM { Code = "+78", Name = "Belgium" },
                new CountryCodeVM { Code = "+54", Name = "Argentina" },
                new CountryCodeVM { Code = "+89", Name = "Kyrgyzstan" },
                new CountryCodeVM { Code = "+75", Name = "Ireland" },
                new CountryCodeVM { Code = "+73", Name = "Finland" },
                new CountryCodeVM { Code = "+74", Name = "Iceland" },
                new CountryCodeVM { Code = "+76", Name = "Malta" },
                new CountryCodeVM { Code = "+96", Name = "Maldives" },
                new CountryCodeVM { Code = "+77", Name = "Luxembourg" },
                new CountryCodeVM { Code = "+58", Name = "Venezuela" },
                new CountryCodeVM { Code = "+48", Name = "Poland" },
                new CountryCodeVM { Code = "+67", Name = "Brunei" },
                new CountryCodeVM { Code = "+85", Name = "Hong Kong" },
                new CountryCodeVM { Code = "+72", Name = "Denmark" },
                new CountryCodeVM { Code = "+90", Name = "Turkey" },
                new CountryCodeVM { Code = "+63", Name = "Philippines" },
                new CountryCodeVM { Code = "+69", Name = "Papua New Guinea" }
            };

            return countryCodes.OrderBy(c => c.Name).ToList();
        }
    }
}
