using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Core.Interfaces
{
    /// <summary>
    /// IQueryRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IQueryRepository<T, in TId>
    {
        /// <summary>
        /// Gets all asyn.
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAll();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetById(TId id);

        /// <summary>
        /// Anies the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> Any(TId id);
    }
}
