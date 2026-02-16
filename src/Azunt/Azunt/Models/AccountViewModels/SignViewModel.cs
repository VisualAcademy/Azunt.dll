namespace Azunt.Models.AccountViewModels
{
    /// <summary>
    /// Lightweight sign-in model with default non-null initialization.
    /// Ensures compliance with nullable reference type requirements.
    /// </summary>
    public class SignViewModel
    {
        /// <summary>
        /// The user's email address.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The user's password.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
