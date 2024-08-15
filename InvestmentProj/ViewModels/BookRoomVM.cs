using System;
using System.ComponentModel.DataAnnotations;

namespace InvestmentProj.Models
{
    public class BookRoomViewModel
    {
        [Required(ErrorMessage = "Hotel type is required.")]
        public string HotelType { get; set; }                                                              //Hotel type for booking and it's validation



        [Required(ErrorMessage = "Check-in date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [Display(Name = "Check-in Date")]                                                               // Check in date for booking and it's validation
        public DateTime Checkin { get; set; }



        [Required(ErrorMessage = "Check-out date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [Display(Name = "Check-out Date")]                                                               // Check out date for booking and it's validation
        public DateTime Checkout { get; set; }




        [Required(ErrorMessage = "Number of adults is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "There must be at least one adult.")]                      // Number of adults for booking and it's validation
        public int Adults { get; set; }



        [Range(0, 10, ErrorMessage = "Number of children must be between 0 and 10.")]
        public int Children { get; set; }                                                                 // Number of children for booking and it's validation



        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]                  //  Name for booking and it's validation
        public string Name { get; set; }



        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }                                                               //Email for booking and it's validation
    }
}
