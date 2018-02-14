using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Buisness.Repository
{
    public class BookExemplariesQueryRepository : QueryRepositoryBase<BookExemplary, Guid>
    {
        public BookExemplariesQueryRepository(LibraryDbContext context)
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
