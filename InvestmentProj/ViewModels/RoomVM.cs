using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestmentProj.ViewModels
{
    public class RoomVM
    {
        [Key]
       
        public int RoomID { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Range(0, 99999)]
        public decimal Price { get; set; }

        [Range(1, 10)]
        public int Adults { get; set; }

        [Range(0, 10)]
        public int Children { get; set; }

        public List<BookingVM> Bookings { get; set; } // ViewModel for bookings, if needed

        // Additional properties can be added here if necessary
        public string ImageUrl { get; set; } // Optional: URL for room image
    }
}
