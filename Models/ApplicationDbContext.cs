using Microsoft.EntityFrameworkCore;

namespace MaritimeData.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Ship>().ToTable("ships");
         modelBuilder.Entity<Ship>().ToTable("ships");
         modelBuilder.Entity<Port>().ToTable("ports");
         modelBuilder.Entity<Voyage>().ToTable("voyages");
         modelBuilder.Entity<CountryVisited>().ToTable("countriesvisited");
    }

        public DbSet<Ship> Ships {get; set;}
        public DbSet<CountryVisited> CountriesVisited {get; set;}
        public DbSet<Port> Ports {get; set;}
        public DbSet<Voyage> Voyages{get; set;}
    }
}