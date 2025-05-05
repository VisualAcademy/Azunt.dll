using System;

namespace Azunt.Utilities.DateTimes
{
    /// <summary>
    /// Utility methods for working with date and time formatting.
    /// </summary>
    public static class DateTimeUtility
    {
        /// <summary>
        /// If the date is today, returns only the time (HH:mm:ss); otherwise returns the date in the given format.
        /// </summary>
        /// <param name="dt">DateTime object or parseable string</param>
        /// <param name="format">Date format string (default: "yyyy-MM-dd")</param>
        public static string ShowTimeOrDate(object dt, string format = "yyyy-MM-dd")
        {
            if (dt != null && DateTime.TryParse(dt.ToString(), out DateTime dateTime))
            {
                return dateTime.Date == DateTime.Now.Date
                    ? dateTime.ToString("HH:mm:ss")
                    : dateTime.ToString(format);
            }
            return "";
        }

        /// <summary>
        /// Returns only the formatted date.
        /// </summary>
        /// <param name="dt">DateTime object or parseable string</param>
        /// <param name="format">Date format string (default: "yyyy-MM-dd")</param>
        public static string ShowDate(object dt, string format = "yyyy-MM-dd")
        {
            if (dt != null && DateTime.TryParse(dt.ToString(), out DateTime dateTime))
            {
                return dateTime.ToString(format);
            }
            return "";
        }

        /// <summary>
        /// Returns a relative time string such as "3 minutes ago" or "3분 전", based on the current time.
        /// </summary>
        /// <param name="dateTime">The DateTime to compare against now</param>
        /// <param name="useKorean">If true, returns Korean (e.g., "3분 전"); otherwise returns English (e.g., "3 minutes ago")</param>
        public static string TimeAgo(DateTime dateTime, bool useKorean = true)
        {
            var span = DateTime.Now - dateTime;

            if (useKorean)
            {
                if (span.TotalSeconds < 60) return "방금 전";
                if (span.TotalMinutes < 60) return $"{(int)span.TotalMinutes}분 전";
                if (span.TotalHours < 24) return $"{(int)span.TotalHours}시간 전";
                if (span.TotalDays < 7) return $"{(int)span.TotalDays}일 전";
                if (span.TotalDays < 30) return $"{(int)(span.TotalDays / 7)}주 전";
                if (span.TotalDays < 365) return $"{(int)(span.TotalDays / 30)}개월 전";
                return $"{(int)(span.TotalDays / 365)}년 전";
            }
            else
            {
                if (span.TotalSeconds < 60) return "just now";
                if (span.TotalMinutes < 60) return $"{(int)span.TotalMinutes} minutes ago";
                if (span.TotalHours < 24) return $"{(int)span.TotalHours} hours ago";
                if (span.TotalDays < 7) return $"{(int)span.TotalDays} days ago";
                if (span.TotalDays < 30) return $"{(int)(span.TotalDays / 7)} weeks ago";
                if (span.TotalDays < 365) return $"{(int)(span.TotalDays / 30)} months ago";
                return $"{(int)(span.TotalDays / 365)} years ago";
            }
        }
    }
}
