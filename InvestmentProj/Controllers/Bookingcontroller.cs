using InvestmentProj.Data;
using Microsoft.AspNetCore.Mvc;

public class BookingController : Controller
{
    private readonly AppDbContext _context;

    public BookingController(AppDbContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    [Route("booking/bookroom")] 
    public IActionResult BookRoom()
    {
  
        return View();
    }

 
    [HttpGet]
    [Route("booking/bookroom/{roomId}")]
    public IActionResult BookRoom(int roomId)
    {
        var room = _context.Rooms.Find(roomId);  
        if (room == null)
        {
            return NotFound(); 
        }
        var model = new BookingVM
        {
            RoomID = room.RoomID,
            RoomDescription = room.Description,
            RoomPrice = room.Price 
        };


        return View(model);
            
         
    }

  

    // POST: Handle form submission
    [HttpPost]
    public IActionResult BookRoom(BookingVM model)
    {
        if (ModelState.IsValid)
        {
            var room = _context.Rooms.Find(model.RoomID);
            if (room == null)
            {
                ModelState.AddModelError("", "Room not found.");
                return View(model);
            }

            var booking = new Booking
            {
                RoomId = model.RoomID,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                NumberOfPerson = model.NumberOfPerson,
                Name = model.Name,
                TotalPrice = model.TotalPrice,
                Room = room // Assign room here after the check
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();


            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("Confirmation");
        }

        return View(model); // Return the view with validation errors
    }

    // Confirmation View
    public IActionResult Confirmation()
    {
        return View();
    }
}
