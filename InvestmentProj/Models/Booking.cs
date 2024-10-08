using InvestmentProj.Models;
using System.ComponentModel.DataAnnotations;

public class Booking
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set; }


    [Required]
    [Range(1, 10)]
    public int NumberofAdults { get; set; }

    [Required, Range(1, 10)]

    public int NumberofChildren { get; set; }

   

    [Required]
    [Range(0, 99999)]
    public decimal TotalPrice { get; set; }  

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public AppUser User { get; set; }  

    [Required]
    public int RoomId { get; set; }
    
    [Required]
    public Room Room { get; set; }
}
