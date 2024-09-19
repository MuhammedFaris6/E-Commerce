using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Domain.AuthenticationModels
{
    public class RegisterModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        public string? ConfirmPassword { get; set; }
    }
}
