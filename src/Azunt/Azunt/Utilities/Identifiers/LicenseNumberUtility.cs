using System;
using System.Text.RegularExpressions;

namespace Azunt.Utilities.Identifiers
{
    /// <summary>
    /// Provides helper methods for incrementing license numbers
    /// that end with a numeric sequence.
    /// </summary>
    public static class LicenseNumberUtility
    {
        /// <summary>
        /// Returns the next license number by incrementing the trailing numeric part.
        /// If the input is null, empty, whitespace, or does not end with digits,
        /// an empty string is returned.
        /// </summary>
        /// <param name="currentLicenseNumber">The current license number.</param>
        /// <returns>
        /// A new license number with the trailing number incremented by 1;
        /// otherwise, an empty string.
        /// </returns>
        public static string GetNext(string currentLicenseNumber)
        {
            return IncrementTrailingNumber(currentLicenseNumber);
        }

        /// <summary>
        /// Increments the trailing numeric part of the given string by 1.
        /// If the input is null, empty, whitespace, or does not end with digits,
        /// an empty string is returned.
        /// </summary>
        /// <param name="value">The input string that ends with digits.</param>
        /// <returns>
        /// A new string with the trailing number incremented;
        /// otherwise, an empty string.
        /// </returns>
        public static string IncrementTrailingNumber(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            Match match = Regex.Match(value, @"(\d+)$");

            if (!match.Success)
            {
                return string.Empty;
            }

            string numberPart = match.Value;
            string prefixPart = value.Substring(0, value.Length - numberPart.Length);

            if (!long.TryParse(numberPart, out long currentNumber))
            {
                return string.Empty;
            }

            if (currentNumber == long.MaxValue)
            {
                return string.Empty;
            }

            long nextNumber = currentNumber + 1;
            string nextNumberPart = nextNumber.ToString();

            if (nextNumberPart.Length < numberPart.Length)
            {
                nextNumberPart = nextNumberPart.PadLeft(numberPart.Length, '0');
            }

            return prefixPart + nextNumberPart;
        }
    }
}