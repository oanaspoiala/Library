using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Buisness.Repository
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
