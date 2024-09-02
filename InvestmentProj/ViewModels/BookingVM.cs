using System;
using System.ComponentModel.DataAnnotations;

namespace InvestmentProj.Models
{
    public class BookRoomViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-in Date")]
        public DateTime Checkin { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-out Date")]
        public DateTime Checkout { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Number of adults must be between 1 and 10.")]
        public int Adults { get; set; }

        [Range(0, 10, ErrorMessage = "Number of children must be between 0 and 10.")]
        public int Children { get; set; }

        [Required]
        public int RoomId { get; set; }

        // Optional: Room details for display purposes
        public string RoomType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
