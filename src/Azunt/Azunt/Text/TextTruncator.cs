namespace Azunt.Text
{
    public static class TextTruncator
    {
        /// <summary>
        /// Safely truncates a string based on the number of Unicode text elements (graphemes),
        /// preserving complex characters such as emojis without breaking them.
        /// </summary>
        /// <param name="input">The original string to truncate.</param>
        /// <param name="maxTextElements">The maximum number of Unicode text elements to keep.</param>
        /// <param name="suffix">A string to append after truncation (default is "...").</param>
        /// <returns>A safely truncated string with the suffix if truncation occurred.</returns>
        public static string TruncateSafe(string input, int maxTextElements, string suffix = "...")
        {
            if (string.IsNullOrEmpty(input) || maxTextElements <= 0)
                return string.Empty;

            var si = new System.Globalization.StringInfo(input);
            return si.LengthInTextElements <= maxTextElements
                ? input
                : si.SubstringByTextElements(0, maxTextElements) + suffix;
        }
    }
}
