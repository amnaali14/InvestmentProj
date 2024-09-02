using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using InvestmentProj.ViewModels;
using InvestmentProj.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: /Account/Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM model)
    {
        if (ModelState.IsValid)
        {

            var trimmedUsername = model.Username?.Trim().Split('@')[0];
            var result = await _signInManager.PasswordSignInAsync(trimmedUsername, model.Password!, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
        }

        return View(model);
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
    public IActionResult AuthSelection()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        if (ModelState.IsValid)
        {

            var trimmedEmail = model.Email?.Trim().ToLower();



            if (await _userManager.FindByEmailAsync(trimmedEmail) != null)
            {
                ModelState.AddModelError(string.Empty, "Email is already in use.");
                return View(model);
            }

            AppUser user = new()
            {
                Name = model.Name,
                UserName = trimmedEmail.Split('@')[0],
                Email = trimmedEmail,
                Address = model.Address
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
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