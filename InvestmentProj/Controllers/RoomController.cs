using InvestmentProj.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class RoomsController : Controller
{
    public string? Room { get; private set; }

    public IActionResult Index()
    {
        var rooms = new List<RoomVM>
        {
            new RoomVM
            {
                Id = 1,
                Type = "Deluxe Room",
                Description = "A spacious room with a king-size bed and luxury amenities.",
                ImageUrl = "/images/deluxe-room.jpg",
                PricePerNight = 150.00m,
                Capacity = 2,
                ReviewCount = 25,
                Rating = 4.5m,
                IsAvailable = true // Ensure this property is set
            },
            new RoomVM
            {
                Id = 2,
                Type = "Standard Room",
                Description = "A comfortable room for budget travelers.",
                ImageUrl = "/images/standard-room.jpg",
                PricePerNight = 80.00m,
                Capacity = 2,
                ReviewCount = 10,
                Rating = 3.8m,
                IsAvailable = false // Ensure this property is set
            }
            // Add more rooms as needed
        };

        // Only select available rooms
        var availableRooms = rooms.Where(room => room.IsAvailable);

        // Return the view with available rooms
        return View(availableRooms);
    }

    public IActionResult RoomDetails(int id)
    {
        // Retrieve room details by ID and pass to the view
        var room = new RoomVM
        {
            Id = id,
            Type = "Deluxe Room",
            Description = "Detailed description of the Deluxe Room.",
            ImageUrl = "/images/deluxe-room.jpg",
            PricePerNight = 150.00m,
            Capacity = 2,
            ReviewCount = 25,
            Rating = 4.5m,
            IsAvailable = true // Example data; should be based on real availability
        };

        return View(room);
    }
}
