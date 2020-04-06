using CinemaBerras.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBerras.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext()
        {

        }
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Display> Displays { get; set; }
        public DbSet<Salon> Salons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Display>()
                .HasOne(d => d.Movie)
                .WithMany(m => m.Displays);
            modelBuilder.Entity<Salon>()
                .HasMany(s => s.Displays)
                .WithOne(d => d.Salon);
        }
    }
}
