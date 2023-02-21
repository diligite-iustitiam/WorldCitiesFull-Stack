using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorldCitiesApi.Models;

namespace WorldCitiesApi.Data
{
    public class APIAuthorizationDbContext : IdentityDbContext<ApplicationUser>
    {
        public APIAuthorizationDbContext() : base()
        {

        }

        public APIAuthorizationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
    }
}
