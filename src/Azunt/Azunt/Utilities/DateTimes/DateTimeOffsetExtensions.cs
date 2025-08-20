using System;

namespace Azunt.Utilities.DateTimes
{
    /// <summary>
    /// Extension methods for DateTimeOffset? and DateTime? conversions.
    /// </summary>
    public static class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Converts a nullable DateTimeOffset to DateTime? in the specified time zone.
        /// </summary>
        public static DateTime? ToDateTimeIn(this DateTimeOffset? source, TimeZoneInfo timeZone)
            => TimeZoneUtility.ConvertToTimeZone(source, timeZone);

        /// <summary>
        /// Converts a non-nullable DateTimeOffset to DateTime in the specified time zone.
        /// </summary>
        public static DateTime ToDateTimeIn(this DateTimeOffset source, TimeZoneInfo timeZone)
            => TimeZoneUtility.ConvertToTimeZone(source, timeZone);

        /// <summary>
        /// Treats the input DateTime? as UTC and converts to target time zone.
        /// </summary>
        public static DateTime? FromUtcTo(this DateTime? utc, TimeZoneInfo timeZone)
            => TimeZoneUtility.FromUtc(utc, timeZone);
    }
}
