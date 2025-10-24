using System.ComponentModel.DataAnnotations;

namespace Azunt.Models.AccountViewModels
{
    // ViewModel used for user registration
    public class RegisterViewModel
    {
        // User email address (required)
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // User password (required, 6–100 characters)
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        // Password confirmation (must match Password)
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
