namespace Azunt.Models.Enums
{
    /// <summary>
    /// Supported database providers.
    /// Used to select the database type in EF Core or repository modules.
    /// </summary>
    public enum DbProvider
    {
        SqlServer,
        Sqlite
    }
}
