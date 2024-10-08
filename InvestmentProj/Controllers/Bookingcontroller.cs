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
    [Route("BookingVM/BookRoom")]
    public IActionResult BookRoom()
    {
        return View(new BookingVM()); // Initialize the model to prevent null reference
    }

    [HttpGet]
    [Route("BookingVM/BookRoom/{roomId:int}")] // Ensure correct parameter name and type
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
    [Route("BookingVM/BookRoom")] // Ensure route matches for POST
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
                NumberofAdults = model.NumberofAdults,
                NumberofChildren = model.NumberofChildren,
                Name = model.Name,
                TotalPrice = model.TotalPrice,
                Room = room
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges(); // Only call once

            model.ConfirmationMessage = $"Thank you {model.Name} for booking a room.";

            // Redirect to GET method to prevent form resubmission
            return RedirectToAction("BookRoom", new { roomId = model.RoomID });
        }

        return View(model); // Return view with errors if model is not valid
    }
}
