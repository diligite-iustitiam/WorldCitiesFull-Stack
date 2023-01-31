using WorldCities.Domain;
using Microsoft.EntityFrameworkCore;

namespace WorldCities.Application.Interfaces
{
    public interface IWorldCitiesDbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
