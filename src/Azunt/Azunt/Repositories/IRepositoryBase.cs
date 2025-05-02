using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azunt.Repositories
{
    /// <summary>
    /// Defines a generic repository interface for basic CRUD operations.
    /// This is the base abstraction used across the Azunt ecosystem to unify data access logic.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TId">The identifier type (e.g., int, long, Guid, string).</typeparam>
    public interface IRepositoryBase<T, TId> where T : class
    {
        /// <summary>
        /// Adds a new entity to the data store.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity with any generated values populated.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Retrieves all entities of the specified type.
        /// </summary>
        /// <returns>A collection of all entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Retrieves a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        Task<T> GetByIdAsync(TId id);

        /// <summary>
        /// Updates an existing entity in the data store.
        /// </summary>
        /// <param name="entity">The entity with updated values.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity based on its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        Task<bool> DeleteAsync(TId id);
    }
}
