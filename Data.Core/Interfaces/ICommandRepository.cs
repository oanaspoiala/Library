using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    /// <summary>
    /// ICommandRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface ICommandRepository<in T, TId>
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<TId> Add(T item);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task Update(T item);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(TId id);
    }
}
