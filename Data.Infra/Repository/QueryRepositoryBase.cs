using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Buisness.Repository
{
    /// <inheritdoc />
    /// <summary>
    /// QueryRepositoryBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="T:Library.Core.Interfaces.IQueryRepository`2" />
    public class QueryRepositoryBase<T, TId> : IQueryRepository<T, TId> where T: EntityWithId<TId>
    {
        protected readonly LibraryDbContext Context;
        protected readonly DbSet<T> DataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRepositoryBase{T, TId}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public QueryRepositoryBase(LibraryDbContext context)
        {
            Context = context;
            DataSet = Context.Set<T>();
        }

        /// <summary>
        /// Gets all asyn.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<ICollection<T>> GetAll()
        {
            return await DataSet.ToListAsync();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<T> GetById(TId id)
        {
            return await DataSet.FindAsync(id);
        }

        public async Task<bool> Any(TId id)
        {
            return await DataSet.AnyAsync(i => i.Id.Equals(id));
        }
    }
}
