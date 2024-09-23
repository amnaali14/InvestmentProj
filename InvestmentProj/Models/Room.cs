using InvestmentProj.Models;
using System.ComponentModel.DataAnnotations;

public class Room
{
    [Key]
    public int RoomID { get; set; }

    [Required]
    [StringLength(100)]
    public string Description { get; set; }

    [Required]
    [Range(0, 99999)]
    public decimal Price { get; set; }  // Use decimal

    [Range(1, 10)]
    public int Adults { get; set; }

    [Range(0, 10)]
    public int Children { get; set; }

    public List<Booking> Bookings { get; set; } // Enable bookings for this room
}
