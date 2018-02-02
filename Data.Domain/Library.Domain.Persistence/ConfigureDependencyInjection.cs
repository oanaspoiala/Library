using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistence
{
    public static class ConfigureDependencyInjection
    {
        public static IServiceCollection ConfigureLibraryPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnectionString"];
            services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
