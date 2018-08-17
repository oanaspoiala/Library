using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Library.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.QueryRepository
{
    public abstract class BookExemplariesQueryRepository : QueryRepositoryBase<BookExemplary, Guid>
    {
        protected BookExemplariesQueryRepository(LibraryDbContext context)
            : base(context)
        { }

        public override async Task<ICollection<BookExemplary>> GetAll()
        {
            var result = await Context.BookExemplaries
                .Include(b => b.Book)
                .Include(b => b.Book.Author)
                .Include(b => b.Book.Gender)
                .ToListAsync();
            return result;
        }

        public override async Task<BookExemplary> GetById(Guid id)
        {
            return await Context.BookExemplaries
                .Include(b => b.Book)
                .Include(b => b.Book.Author)
                .Include(b => b.Book.Gender)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
