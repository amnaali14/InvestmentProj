using System.ComponentModel.DataAnnotations;

public class BookingVM
{
    public int RoomID { get; set; }
    public string RoomDescription { get; set; }
    public decimal RoomPrice { get; set; }

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set; }

    [Required]
    [Range(1, 10)]
    public int NumberOfPerson { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }
}
