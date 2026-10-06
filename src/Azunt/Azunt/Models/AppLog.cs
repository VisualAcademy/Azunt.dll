using System;

namespace Azunt.Models
{
    /// <summary>
    /// Represents the standard Serilog MSSQL log table columns
    /// without the Id column.
    /// </summary>
    public class AppLog
    {
        public string? Message { get; set; }
        public string? MessageTemplate { get; set; }
        public string? Level { get; set; }
        public DateTimeOffset? TimeStamp { get; set; }
        public string? Exception { get; set; }
        public string? Properties { get; set; }
    }
}