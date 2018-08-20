using System;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Library.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.QueryRepository
{
    public abstract class WearDegreesQueryRepository : RepositoryBase<WearDegree, Guid>
    {
        protected WearDegreesQueryRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<WearDegree> GetById(Guid id)
        {
            return await Context.WearDegrees
                .Include(x => x.BookExemplary)
                .Include(x => x.TimeStamp)
                .Include(x => x.ValueStatus)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
