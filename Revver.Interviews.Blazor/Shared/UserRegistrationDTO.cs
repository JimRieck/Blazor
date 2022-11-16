using System.ComponentModel.DataAnnotations;

namespace Revver.Interviews.Blazor.Shared
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(12,ErrorMessage = "The minimum length for a password is 12.")]
        //[RegularExpression("/^[ A-Za-z0-9_@./#&+-]*$/", ErrorMessage="Your password needs letters, numbers and special characters")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
