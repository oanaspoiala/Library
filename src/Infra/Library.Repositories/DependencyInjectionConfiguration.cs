using System;
using Library.Domain.Core.Interfaces;
using Library.Domain.Entities;
using Library.Repositories.BaseRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Repositories
{
    public static class DependencyInjectionConfiguration
    {


        public static IServiceCollection ConfigureLibraryBusiness(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Book, Guid>, RepositoryBase<Book, Guid>>();

            services.AddTransient<IRepository<Author, Guid>, RepositoryBase<Author, Guid>>();

            services.AddTransient<IRepository<BookExemplary, Guid>, RepositoryBase<BookExemplary, Guid>>();

            services.AddTransient<IRepository<Gender, Guid>, RepositoryBase<Gender, Guid>>();

            services.AddTransient<IRepository<Loan, Guid>, RepositoryBase<Loan, Guid>>();

            services.AddTransient<IRepository<Person, Guid>, RepositoryBase<Person, Guid>>();

            services.AddTransient<IRepository<WearDegree, Guid>, RepositoryBase<WearDegree, Guid>>();

            services.AddTransient<IRepository<Reservation, Guid>, RepositoryBase<Reservation, Guid>>();

            return services;
        }
    }
}
