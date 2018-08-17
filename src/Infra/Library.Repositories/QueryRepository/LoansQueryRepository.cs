using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Library.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.QueryRepository
{
    public abstract class LoansQueryRepository : QueryRepositoryBase<Loan, Guid>
    {
        protected LoansQueryRepository(LibraryDbContext context)
            : base(context)
        { }

        public override async Task<ICollection<Loan>> GetAll()
        {
            return await Context.Loans.Include(b => b.Person).Include(b => b.BookExemplary)
                .Include(x => x.BookExemplary.Book)
                .Include(x => x.BookExemplary.Book.Gender)
                .Include(x => x.BookExemplary.Book.Author)
                .ToListAsync();
        }

        public override async Task<Loan> GetById(Guid id)
        {
            return await Context.Loans.Include(b => b.Person).Include(b => b.BookExemplary)
                .Include(x => x.BookExemplary.Book)
                .Include(x => x.BookExemplary.Book.Gender)
                .Include(x => x.BookExemplary.Book.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
