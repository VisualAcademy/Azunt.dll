using System;
using System.Globalization;

namespace Azunt.Extensions
{
    public static class DateTimeNormalizeExtensions
    {
        private static readonly string[] ExtraFormats =
            { "MM/yyyy", "M/yyyy", "MM/yy", "M/yy", "yyyy-MM-dd", "yyyy" };

        public static string? ToIsoDateOrNull(this string? raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return null;

            raw = raw.Trim();

            if (DateTime.TryParse(raw, out var dt))
                return dt.ToString("yyyy-MM-dd");

            if (DateTime.TryParseExact(raw, ExtraFormats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dt))
            {
                return dt.ToString("yyyy-MM-dd");
            }

            return null;
        }

        public static string? ExtractYearOrNull(this string? raw)
        {
            var normalized = raw.ToIsoDateOrNull();
            if (normalized == null) return null;

            return DateTime.TryParseExact(
                    normalized, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var dt)
                ? dt.Year.ToString()
                : null;
        }
    }
}
