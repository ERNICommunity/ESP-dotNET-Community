using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WarColors.Data.Repositories
{
    /// <summary>
    /// The IRepository interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IRepository<TEntity, TKey> : IDisposable where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task SaveAsync(TEntity entity);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task DeleteAsync(TKey id);

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<TKey> ids);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
