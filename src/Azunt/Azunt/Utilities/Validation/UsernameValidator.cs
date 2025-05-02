namespace Azunt.Utilities.Validation
{
    /// <summary>
    /// Provides validation logic for checking the validity of usernames.
    /// </summary>
    public static class UsernameValidator
    {
        /// <summary>
        /// Determines whether the specified username is valid by checking for invalid characters.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <returns><c>true</c> if the username contains no invalid characters; otherwise, <c>false</c>.</returns>
        public static bool IsValid(string username)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;

            string[] invalidChars = { @"\", "/", ":", "?", "*", "\"", "<", ">", "|", " ", "'", "%", "&", "+" };

            foreach (var ch in invalidChars)
            {
                if (username.Contains(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
