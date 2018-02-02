using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Context
{
    public sealed class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            LibraryDbSeeder.Seed(this);
        }

        public DbSet<Library.Core.Entities.Person> People { get; set; }
        public DbSet<Library.Core.Entities.Gender> Genders { get; set; }
        public DbSet<Library.Core.Entities.Book> Books { get; set; }
        public DbSet<Library.Core.Entities.BookExemplary> BookExemplaries { get; set; }
        public DbSet<Library.Core.Entities.Author> Authors { get; set; }
        public DbSet<Library.Core.Entities.Loan> Loans { get; set; }
    }
}
