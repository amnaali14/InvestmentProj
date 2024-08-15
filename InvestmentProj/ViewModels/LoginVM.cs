using System.ComponentModel.DataAnnotations;

namespace InvestmentProj.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username is mandatory.")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is mandatory.")]

        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}