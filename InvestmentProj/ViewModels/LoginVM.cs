using System.ComponentModel.DataAnnotations;

namespace InvestmentProj.ViewModels
{
    public class LoginVM
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}