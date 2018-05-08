using System;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class AuthorsQueryRepository : QueryRepositoryBase<Author, Guid>
    {
        public AuthorsQueryRepository(LibraryDbContext context)
            : base(context)
        {
        }

        public override async Task<Author> GetById(Guid id)
        {
            return await Context.Authors
                .Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
