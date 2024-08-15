using System;
using System.ComponentModel.DataAnnotations;

namespace InvestmentProj.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HotelType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Checkin { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Checkout { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Adults { get; set; }

        [Range(0, 10)]
        public int Children { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
