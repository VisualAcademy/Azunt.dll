using System;

namespace Azunt.Utilities.DateTimes
{
    /// <summary>
    /// Helpers for safe timezone conversions with nullable inputs.
    /// </summary>
    public static class TimeZoneUtility
    {
        /// <summary>
        /// Converts a nullable DateTimeOffset to DateTime? in the specified time zone.
        /// Returns null if source or timeZone is null.
        /// </summary>
        public static DateTime? ConvertToTimeZone(DateTimeOffset? source, TimeZoneInfo timeZone)
        {
            if (!source.HasValue || timeZone is null) return null;
            return TimeZoneInfo.ConvertTime(source.Value, timeZone).DateTime;
        }

        /// <summary>
        /// Converts a non-nullable DateTimeOffset to DateTime in the specified time zone.
        /// </summary>
        public static DateTime ConvertToTimeZone(DateTimeOffset source, TimeZoneInfo timeZone)
        {
            if (timeZone is null) throw new ArgumentNullException(nameof(timeZone));
            return TimeZoneInfo.ConvertTime(source, timeZone).DateTime;
        }

        /// <summary>
        /// Convenience overload for DateTime? assumed to be in UTC (common in APIs/DB).
        /// Converts to DateTime? of target time zone; returns null if source or timeZone is null.
        /// </summary>
        public static DateTime? FromUtc(DateTime? utc, TimeZoneInfo timeZone)
        {
            if (!utc.HasValue || timeZone is null) return null;
            var dto = new DateTimeOffset(DateTime.SpecifyKind(utc.Value, DateTimeKind.Utc));
            return TimeZoneInfo.ConvertTime(dto, timeZone).DateTime;
        }
    }
}
