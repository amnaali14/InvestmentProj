using InvestmentProj.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

public class BookingController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<BookingController> _logger;

    public BookingController(AppDbContext context, ILogger<BookingController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult BookRoom()
    {
        var model = new BookingVM
        {
            CheckInDate = DateTime.Today,
            CheckOutDate = DateTime.Today.AddDays(1),
            NumberofAdults = 1,
            NumberofChildren = 1,
            ConfirmationMessage = string.Empty,
            TotalPrice = 0
        };
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> BookRoom(int roomId)
    {
        try
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null)
            {
                _logger.LogWarning("Room with ID {RoomId} not found", roomId);
                return NotFound();
            }

            var model = new BookingVM
            {
                RoomID = room.RoomID,
                RoomDescription = room.Description,
                RoomPrice = room.Price,
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(1),
                NumberofAdults = 1,
                NumberofChildren = 1,
                ConfirmationMessage = string.Empty,
                TotalPrice = room.Price
            };

            return View(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching room {RoomId}", roomId);
            TempData["ErrorMessage"] = "An error occurred while processing your request.";
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BookRoom(BookingVM model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Additional validation
            if (model.CheckInDate < DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.CheckInDate), "Check-in date cannot be in the past.");
                return View(model);
            }

            if (model.CheckOutDate <= model.CheckInDate)
            {
                ModelState.AddModelError(nameof(model.CheckOutDate), "Check-out date must be after check-in date.");
                return View(model);
            }

            var room = await _context.Rooms.FindAsync(model.RoomID);
            if (room == null)
            {
                ModelState.AddModelError("", "Selected room is not available.");
                return View(model);
            }

            // Check room availability
            if (!await IsRoomAvailable(model.RoomID, model.CheckInDate, model.CheckOutDate))
            {
                ModelState.AddModelError("", "Room is not available for the selected dates.");
                return View(model);
            }

            // Calculate total price
            model.TotalPrice = CalculateTotalPrice(room.Price, model.CheckInDate, model.CheckOutDate);

            // Create booking entity
            var booking = new Booking
            {
                RoomId = model.RoomID,
                Name = model.Name,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                NumberofAdults = model.NumberofAdults,
                NumberofChildren = model.NumberofChildren,
                TotalPrice = model.TotalPrice
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Set confirmation message
            model.ConfirmationMessage = $"Thank you {model.Name} for booking room {model.RoomDescription}. Your booking is confirmed for {model.CheckInDate:d} to {model.CheckOutDate:d}.";

            // Store confirmation message in TempData for display after redirect
            TempData["SuccessMessage"] = model.ConfirmationMessage;

            // Redirect to prevent form resubmission
            return RedirectToAction(nameof(BookRoom), new { roomId = model.RoomID });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while processing booking for room {RoomId}", model.RoomID);
            ModelState.AddModelError("", "An error occurred while processing your booking. Please try again.");
            return View(model);
        }
    }

    private async Task<bool> IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
    {
        return !await _context.Bookings
            .AnyAsync(b => b.RoomId == roomId &&
                          checkIn < b.CheckOutDate &&
                          checkOut > b.CheckInDate);
    }

    private decimal CalculateTotalPrice(decimal roomPrice, DateTime checkIn, DateTime checkOut)
    {
        int numberOfNights = (int)(checkOut - checkIn).TotalDays;
        return roomPrice * numberOfNights;
    }
}