using System;
using Library.Core.Entities;
using Library.Persistence.Context;

namespace Library.Buisness.Repository
{
    public class BooksCommandRepository : CommandRepositoryBase<Book, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooksCommandRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BooksCommandRepository(LibraryDbContext context)
            :base(context)
        {}
    }
}
