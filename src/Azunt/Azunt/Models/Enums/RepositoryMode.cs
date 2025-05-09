using System;

namespace Azunt.Models.Enums
{
    /// <summary>
    /// Specifies the operational mode of a repository.
    /// Choose from Entity Framework Core, Dapper, or ADO.NET
    /// depending on the data access strategy required.
    /// </summary>
    public enum RepositoryMode
    {
        /// <summary>
        /// Use Entity Framework Core (EF Core) as the data access method.
        /// </summary>
        EfCore,

        /// <summary>
        /// Use Dapper as the data access method.
        /// </summary>
        Dapper,

        /// <summary>
        /// Use ADO.NET directly for data access.
        /// </summary>
        AdoNet
    }
}
