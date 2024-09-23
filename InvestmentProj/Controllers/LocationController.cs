using Microsoft.AspNetCore.Mvc;

public class LocationController : Controller
{
    public ActionResult Index()
    {

        return View();
    }

    [HttpPost]
    public ActionResult SaveLocation(double latitude, double longitude, string locationName)
    {
       
        return RedirectToAction("Index"); 
    }

    public ActionResult DisplayLocations()
    {

        return View();
    }
}