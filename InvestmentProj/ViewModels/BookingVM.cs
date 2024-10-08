using System.ComponentModel.DataAnnotations;

public class BookingVM
{
    public string Name { get; set; }
    public int RoomID { get; set; }
    public string RoomDescription { get; set; }
    public decimal RoomPrice { get; set; }

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
    [StringLength(100)]

    public string ConfirmationMessage { get; set; }
    [Required]
    public decimal TotalPrice { get; set; }
}
