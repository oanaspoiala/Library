using System;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Library.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.QueryRepository
{
    public abstract class GendersQueryRepository : RepositoryBase<Gender, Guid>
    {
        protected GendersQueryRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<Gender> GetById(Guid id)
        {
            return await Context.Genders
                .Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
