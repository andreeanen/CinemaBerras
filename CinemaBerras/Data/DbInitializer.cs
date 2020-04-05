using CinemaBerras.Models;
using System;
using System.Linq;

namespace CinemaBerras.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaContext cinemaContext)
        {
            cinemaContext.Database.EnsureCreated();

            if (!cinemaContext.Movies.Any())
            {
                var movies = new Movie[]
                {
                    new Movie
                    {
                        Title="Titanic",
                        Time= DateTime.UtcNow
                    },
                    new Movie
                    {
                        Title="Shrek",
                        Time=DateTime.UtcNow.AddHours(1)
                    }
                };

                cinemaContext.Movies.AddRange(movies);
                cinemaContext.SaveChanges();
            }
        }

    }
}
