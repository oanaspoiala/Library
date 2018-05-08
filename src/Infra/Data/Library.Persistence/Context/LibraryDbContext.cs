using Library.Domain.Entities;
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

        public DbSet<Person> People { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookExemplary> BookExemplaries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
