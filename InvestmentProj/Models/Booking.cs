using InvestmentProj.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace IvestmentProj.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        public Room Room { get; set; } // Navigation property to Room

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerEmail { get; set; }

        public string PhoneNumber { get; set; }

        public int NumberOfAdults { get; set; }

        public int NumberOfChildren { get; set; }
    }
}
