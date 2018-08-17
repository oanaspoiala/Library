using System.Threading.Tasks;
using Library.Domain.Core.Entities;
using Library.Domain.Core.Interfaces;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.BaseRepository
{
    public abstract class CommandRepositoryBase<T, TId> : ICommandRepository<T, TId> where T : EntityWithId<TId>
    {
        private readonly LibraryDbContext _context;
        private readonly DbSet<T> _dataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRepositoryBase{T, TId}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected CommandRepositoryBase(LibraryDbContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public virtual async Task<TId> Add(T item)
        {
            await _dataSet.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public virtual async Task Update(T item)
        {
            _dataSet.Update(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual async Task Delete(TId id)
        {
            var item = await _dataSet.FindAsync(id);
            _dataSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
