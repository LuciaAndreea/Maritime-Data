using Microsoft.EntityFrameworkCore;

namespace MaritimeData.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Ship> Ships {get; set;}
        public DbSet<CountryVisited> CountriesVisited {get; set;}
        public DbSet<Port> Ports {get; set;}
        public DbSet<Voyage> Voyages{get; set;}
    }
}