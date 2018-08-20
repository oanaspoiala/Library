using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Library.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.QueryRepository
{
    public abstract class BooksQueryRepository : RepositoryBase<Book, Guid>
    {
        protected BooksQueryRepository(LibraryDbContext context)
            :base(context)
        {}

        /// <summary>
        /// Gets all asyn.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ICollection<Book>> GetAll()
        {
            return await Context.Books.Include(b => b.Author)
                .Include(b => b.Gender)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Book> GetById(Guid id)
        {
            return await Context.Books.Include(b => b.Author)
                .Include(b => b.Gender)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
