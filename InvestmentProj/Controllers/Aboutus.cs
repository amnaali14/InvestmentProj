using Microsoft.AspNetCore.Mvc;

namespace InvestmentProj.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
