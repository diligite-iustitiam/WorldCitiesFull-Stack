using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorldCities.Application.Interfaces;

namespace WorldCities.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
           services, IConfiguration configuration)
        {
            var shopconnection = configuration.GetConnectionString("WorldCitiesContextConnection");
            services.AddDbContext<WorldCitiesDbContext>(options =>
            {
                options.UseSqlServer(shopconnection);
            });
            services.AddScoped<IWorldCitiesDbContext>(provider =>
                provider.GetService<WorldCitiesDbContext>());
            return services;
        }
    }
}
