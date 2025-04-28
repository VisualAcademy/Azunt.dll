using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azunt.Repositories
{
    /// <summary>
    /// Generic repository interface for basic CRUD operations.
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <typeparam name="TId">Identifier type (e.g., int, long, Guid, string)</typeparam>
    public interface IRepositoryBase<T, TId> where T : class
    {
        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to retrieve.</param>
        Task<T> GetByIdAsync(TId id);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        Task<bool> DeleteAsync(TId id);
    }
}
