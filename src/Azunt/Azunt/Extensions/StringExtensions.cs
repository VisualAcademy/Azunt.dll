using System;
using System.Globalization;

namespace Azunt.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the first character to uppercase using the current culture.
        /// </summary>
        public static string FirstLetterToUpper(this string str)
            => FirstLetterToUpper(str, CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts the first character to uppercase using the invariant culture.
        /// </summary>
        public static string FirstLetterToUpperInvariant(this string str)
            => FirstLetterToUpper(str, CultureInfo.InvariantCulture);

        /// <summary>
        /// Converts the first character to uppercase using the specified culture.
        /// </summary>
        public static string FirstLetterToUpper(this string str, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(str)) return str;

            if (str.Length == 1)
                return str.ToUpper(culture);

            var first = char.ToUpper(str[0], culture);
            return first + str.Substring(1);
        }

        /// <summary>
        /// Unicode-safe: uppercases the first *text element* (grapheme cluster) using the current culture.
        /// Use this if strings may start with surrogate pairs or combining sequences (e.g., emoji, accent).
        /// </summary>
        public static string FirstTextElementToUpper(this string str)
            => FirstTextElementToUpper(str, CultureInfo.CurrentCulture);

        /// <summary>
        /// Unicode-safe: uppercases the first *text element* (grapheme cluster) using the specified culture.
        /// </summary>
        public static string FirstTextElementToUpper(this string str, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(str)) return str;

            // Works on .NET Standard 2.0
            var enumerator = StringInfo.GetTextElementEnumerator(str);
            if (!enumerator.MoveNext()) return str;

            var firstElem = enumerator.GetTextElement();
            var rest = str.Substring(firstElem.Length);

            return firstElem.ToUpper(culture) + rest;
        }
    }
}
