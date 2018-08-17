using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Core.Entities;
using Library.Domain.Core.Interfaces;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.BaseRepository
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
        private readonly DbSet<T> _dataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRepositoryBase{T, TId}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected QueryRepositoryBase(LibraryDbContext context)
        {
            Context = context;
            _dataSet = Context.Set<T>();
        }

        /// <summary>
        /// Gets all asyn.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _dataSet.ToListAsync();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<T> GetById(TId id)
        {
            return await _dataSet.FindAsync(id);
        }

        public async Task<bool> Any(TId id)
        {
            return await _dataSet.AnyAsync(i => i.Id.Equals(id));
        }
    }
}
