using CinemaBerras.Models;
using System;
using System.Linq;

namespace CinemaBerras.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaContext cinemaContext)
        {
            cinemaContext.Database.EnsureDeleted();
            cinemaContext.Database.EnsureCreated();

            if (!cinemaContext.Displays.Any())
            {
                var movies = new Movie[]
            {
                    new Movie
                    {
                        Title="Titanic"
                        //Time= DateTime.UtcNow
                    },
                    new Movie
                    {
                        Title="Shrek"
                        //Time=DateTime.UtcNow.AddHours(1)
                    }
            };

                cinemaContext.Movies.AddRange(movies);
                cinemaContext.SaveChanges();

                var displays = new Display[]
                {
                    new Display
                    {
                       MovieId=1,
                       Time= DateTime.UtcNow
                    },
                    new Display
                    {
                        MovieId=2,
                        Time=DateTime.UtcNow.AddHours(1)
                    }

                };
                cinemaContext.Displays.AddRange(displays);
                cinemaContext.SaveChanges();
            }
        }

    }
}
