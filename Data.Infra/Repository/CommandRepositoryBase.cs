using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Buisness.Repository
{
    public class CommandRepositoryBase<T, TId> : ICommandRepository<T, TId> where T : EntityWithId<TId>
    {
        protected readonly LibraryDbContext Context;
        protected readonly DbSet<T> DataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandRepositoryBase{T, TId}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CommandRepositoryBase(LibraryDbContext context)
        {
            Context = context;
            DataSet = Context.Set<T>();
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public virtual async Task<TId> Add(T item)
        {
            await DataSet.AddAsync(item);
            await Context.SaveChangesAsync();
            return item.Id;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public virtual async Task Update(T item)
        {
            DataSet.Update(item);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual async Task Delete(TId id)
        {
            var item = await DataSet.FindAsync(id);
            DataSet.Remove(item);
            await Context.SaveChangesAsync();
        }
    }
}
