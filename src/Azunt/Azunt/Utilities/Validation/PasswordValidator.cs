using System.Text.RegularExpressions;

namespace Azunt.Utilities.Validation
{
    /// <summary>
    /// Provides validation logic for secure passwords.
    /// </summary>
    public static class PasswordValidator
    {
        /// <summary>
        /// Minimum password length.
        /// </summary>
        public const int MinLength = 8;

        /// <summary>
        /// Determines whether the specified password is secure based on basic rules:
        /// at least one uppercase letter, one lowercase letter, one digit, and one special character.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns><c>true</c> if the password meets security requirements; otherwise, <c>false</c>.</returns>
        public static bool IsValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < MinLength)
                return false;

            bool hasUpper = Regex.IsMatch(password, "[A-Z]");
            bool hasLower = Regex.IsMatch(password, "[a-z]");
            bool hasDigit = Regex.IsMatch(password, "[0-9]");
            bool hasSpecial = Regex.IsMatch(password, @"[\W_]");

            return hasUpper && hasLower && hasDigit && hasSpecial;
        }
    }
}
