using InvestmentProj.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestmentProj.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [EmailDomainValidation("gmail.com", "hotmail.com", "yahoo.com")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Country code is required.")]
        public string? CountryCode { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        [Phone(ErrorMessage = "Invalid PhoneNumber format.")]
        [StringLength(15, ErrorMessage = "PhoneNumber cannot be longer than 15 digits.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "PhoneNumber must be numeric.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string? Gender { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }
        public List<Booking> Bookings { get; set; }
        
        public List<CountryCodeVM> CountryCodes { get; set; } = new List<CountryCodeVM>
        {
            new CountryCodeVM { Code = "+1", Name = "United States" },
            new CountryCodeVM { Code = "+44", Name = "United Kingdom" },
            new CountryCodeVM { Code = "+91", Name = "India" },
            new CountryCodeVM { Code = "+33", Name = "France" },
            new CountryCodeVM { Code = "+49", Name = "Germany" },
            new CountryCodeVM { Code = "+39", Name = "Italy" },
            new CountryCodeVM { Code = "+34", Name = "Spain" },
            new CountryCodeVM { Code = "+81", Name = "Japan" },
            new CountryCodeVM { Code = "+61", Name = "Australia" },
            new CountryCodeVM { Code = "+55", Name = "Brazil" },
            new CountryCodeVM { Code = "+7", Name = "Russia" },
            new CountryCodeVM { Code = "+27", Name = "South Africa" },
            new CountryCodeVM { Code = "+82", Name = "South Korea" },
            new CountryCodeVM { Code = "+60", Name = "Malaysia" },
            new CountryCodeVM { Code = "+65", Name = "Singapore" },
            new CountryCodeVM { Code = "+20", Name = "Egypt" },
            new CountryCodeVM { Code = "+92", Name = "Pakistan" },
            new CountryCodeVM { Code = "+31", Name = "Netherlands" },
            new CountryCodeVM { Code = "+41", Name = "Switzerland" },
            new CountryCodeVM { Code = "+46", Name = "Sweden" },
            new CountryCodeVM { Code = "+48", Name = "Poland" },
            new CountryCodeVM { Code = "+90", Name = "Turkey" },
            new CountryCodeVM { Code = "+63", Name = "Philippines" },
            new CountryCodeVM { Code = "+52", Name = "Mexico" },
            new CountryCodeVM { Code = "+98", Name = "Iran" },
            new CountryCodeVM { Code = "+53", Name = "Cuba" },
            new CountryCodeVM { Code = "+54", Name = "Argentina" },
            new CountryCodeVM { Code = "+57", Name = "Colombia" },
            new CountryCodeVM { Code = "+58", Name = "Venezuela" },
            new CountryCodeVM { Code = "+62", Name = "Indonesia" },
            new CountryCodeVM { Code = "+64", Name = "New Zealand" },
            new CountryCodeVM { Code = "+66", Name = "Thailand" },
            new CountryCodeVM { Code = "+67", Name = "Brunei" },
            new CountryCodeVM { Code = "+68", Name = "East Timor" },
            new CountryCodeVM { Code = "+69", Name = "Papua New Guinea" },
            new CountryCodeVM { Code = "+70", Name = "Norway" },
            new CountryCodeVM { Code = "+72", Name = "Denmark" },
            new CountryCodeVM { Code = "+73", Name = "Finland" },
            new CountryCodeVM { Code = "+74", Name = "Iceland" },
            new CountryCodeVM { Code = "+75", Name = "Ireland" },
            new CountryCodeVM { Code = "+76", Name = "Malta" },
            new CountryCodeVM { Code = "+77", Name = "Luxembourg" },
            new CountryCodeVM { Code = "+78", Name = "Belgium" },
            new CountryCodeVM { Code = "+80", Name = "Monaco" },
            new CountryCodeVM { Code = "+84", Name = "China" },
            new CountryCodeVM { Code = "+85", Name = "Hong Kong" },
            new CountryCodeVM { Code = "+86", Name = "Macau" },
            new CountryCodeVM { Code = "+87", Name = "Taiwan" },
            new CountryCodeVM { Code = "+88", Name = "Mongolia" },
            new CountryCodeVM { Code = "+89", Name = "Kyrgyzstan" },
            new CountryCodeVM { Code = "+93", Name = "Afghanistan" },
            new CountryCodeVM { Code = "+94", Name = "Sri Lanka" },
            new CountryCodeVM { Code = "+95", Name = "Nepal" },
            new CountryCodeVM { Code = "+96", Name = "Maldives" },
            new CountryCodeVM { Code = "+97", Name = "Bangladesh" },
            new CountryCodeVM { Code = "+99", Name = "Kazakhstan" }
        };
    }

    public class CountryCodeVM
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
