using Microsoft.EntityFrameworkCore;
using WorldCities.Application.Interfaces;
using WorldCities.Domain;

namespace WorldCities.Persistence
{
    internal class WorldCitiesDbContext : DbContext, IWorldCitiesDbContext
    {
        public WorldCitiesDbContext()
        {

        }
        public WorldCitiesDbContext(DbContextOptions<WorldCitiesDbContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorldCitiesDbContext).Assembly);
        }
    }
}
