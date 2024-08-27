using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InvestmentProj.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public int MyProperty { get; set; }

        public string? Name { get; set; }
        public string? PhoneNumber {  get; set; }
        public string? Password { get; set; }   
        public string? ConfirmPassword { get; set; }    

        public string? Address { get; set; }



        // PhoneNumber is inherited from IdentityUser, so no need to declare it again.
    }
}
