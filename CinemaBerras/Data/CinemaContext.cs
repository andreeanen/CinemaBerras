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
    }
}
