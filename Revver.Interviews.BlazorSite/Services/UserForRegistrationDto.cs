using System.ComponentModel.DataAnnotations;

namespace Revver.Interviews.BlazorSite.Services
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "The input must be an email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(12, ErrorMessage = "The password must at least 12 characters.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
