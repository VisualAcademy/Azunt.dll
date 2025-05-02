using System.Text.RegularExpressions;

namespace Azunt.Utilities.Validation
{
    /// <summary>
    /// Provides validation logic for email addresses.
    /// </summary>
    public static class EmailValidator
    {
        private static readonly Regex _emailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled
        );

        /// <summary>
        /// Determines whether the specified email is valid using a simple pattern.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns><c>true</c> if the email format is valid; otherwise, <c>false</c>.</returns>
        public static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            return _emailRegex.IsMatch(email);
        }
    }
}
