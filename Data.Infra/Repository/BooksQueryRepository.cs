using System;
using Library.Core.Entities;
using Library.Persistence.Context;

namespace Library.Buisness.Repository
{
    public class BooksQueryRepository : QueryRepositoryBase<Book, Guid>
    {
        public BooksQueryRepository(LibraryDbContext context)
            :base(context)
        {}
    }
}
