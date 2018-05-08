using System;
using Library.Domain.Core.Interfaces;
using Library.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Repositories
{
    public static class DependencyInjectionConfiguration
    {


        public static IServiceCollection ConfigureLibraryBusiness(this IServiceCollection services)
        {
            services.AddTransient<ICommandRepository<Book, Guid>, CommandRepositoryBase<Book, Guid>>();
            services.AddTransient<IQueryRepository<Book, Guid>, BooksQueryRepository>();

            services.AddTransient<ICommandRepository<Author, Guid>, CommandRepositoryBase<Author, Guid>>();
            services.AddTransient<IQueryRepository<Author, Guid>, AuthorsQueryRepository>();

            services.AddTransient<ICommandRepository<BookExemplary, Guid>, CommandRepositoryBase<BookExemplary, Guid>>();
            services.AddTransient<IQueryRepository<BookExemplary, Guid>, BookExemplariesQueryRepository>();

            services.AddTransient<ICommandRepository<Gender, Guid>, CommandRepositoryBase<Gender, Guid>>();
            services.AddTransient<IQueryRepository<Gender, Guid>, QueryRepositoryBase<Gender, Guid>>();

            services.AddTransient<ICommandRepository<Loan, Guid>, CommandRepositoryBase<Loan, Guid>>();
            services.AddTransient<IQueryRepository<Loan, Guid>, LoansQueryRepository>();

            services.AddTransient<ICommandRepository<Person, Guid>, CommandRepositoryBase<Person, Guid>>();
            services.AddTransient<IQueryRepository<Person, Guid>, QueryRepositoryBase<Person, Guid>>();

            return services;
        }
    }
}
