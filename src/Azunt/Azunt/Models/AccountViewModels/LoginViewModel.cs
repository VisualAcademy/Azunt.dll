using System.ComponentModel.DataAnnotations;

namespace Azunt.Models.AccountViewModels
{
    /// <summary>
    /// View model used for user login operations.
    /// Provides validation attributes for authentication input fields.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// The user's email address.
        /// Must be a valid email format.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The user's password.
        /// Rendered as a password input field.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether the authentication session should be persistent.
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
