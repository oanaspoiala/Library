using System;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Library.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.QueryRepository
{
    public abstract class AuthorsQueryRepository : QueryRepositoryBase<Author, Guid>
    {
        protected AuthorsQueryRepository(LibraryDbContext context)
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
