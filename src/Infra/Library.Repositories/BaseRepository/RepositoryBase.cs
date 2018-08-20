using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Core.Entities;
using Library.Domain.Core.Interfaces;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.BaseRepository
{
    /// <summary>
    /// RepositoryBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="Library.Domain.Core.Interfaces.IRepository{T, TId}" />
    // ReSharper disable once ClassNeverInstantiated.Global
    public class RepositoryBase<T, TId> : IRepository<T, TId> where T : EntityWithId<TId>
    {
        public readonly LibraryDbContext Context;
        private  readonly DbSet<T> _dataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T, TId}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dataSet">The data set.</param>
        public RepositoryBase(LibraryDbContext context)
        {
            Context = context;
            _dataSet = Context.Set<T>();
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<TId> Add(T item)
        {
            await _dataSet.AddAsync(item);
            await Context.SaveChangesAsync();
            return item.Id;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task Update(T item)
        {
            _dataSet.Update(item);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task Delete(TId id)
        {
            var item = await _dataSet.FindAsync(id);
            _dataSet.Remove(item);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<T>> GetAll()
        {
            return await _dataSet.ToListAsync();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<T> GetById(TId id)
        {
            return await _dataSet.FindAsync(id);
        }

        /// <summary>
        /// Anies the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> Any(TId id)
        {
            return await _dataSet.AnyAsync(i => i.Id.Equals(id));
        }
    }
}
