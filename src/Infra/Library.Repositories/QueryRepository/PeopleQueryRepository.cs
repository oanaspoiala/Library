using System;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Library.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.QueryRepository
{
    public abstract class PeopleQueryRepository : RepositoryBase<Person, Guid>
    {
        protected PeopleQueryRepository(LibraryDbContext context) : base(context)
        {
        }

        public async Task<Person> GetById(Guid id)
        {
            return await Context.People
                .Include(x => x.FullName)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
