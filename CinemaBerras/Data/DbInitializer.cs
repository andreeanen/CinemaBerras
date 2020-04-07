using CinemaBerras.Models;
using System;
using System.Linq;

namespace CinemaBerras.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaContext cinemaContext)
        {
            //cinemaContext.Database.EnsureDeleted();
            cinemaContext.Database.EnsureCreated();

            if (!cinemaContext.Movies.Any())
            {
                var movies = new Movie[]
                {
                    new Movie
                    {
                        Title="Titanic"
                    },
                    new Movie
                    {
                        Title="Shrek"
                    }
                };

                cinemaContext.Movies.AddRange(movies);
                cinemaContext.SaveChanges();
            }

            if (!cinemaContext.Salons.Any())
            {
                var salons = new Salon[]
                {
                    new Salon
                    {
                           Name="Room 1",
                           Seats = 50
                    },
                    new Salon
                    {
                            Name="Room 2",
                            Seats=100
                    }
                };
                cinemaContext.Salons.AddRange(salons);
                cinemaContext.SaveChanges();
            }

            if (!cinemaContext.Displays.Any())
            {

                var displays = new Display[]
                {
                    new Display
                    {
                       MovieId=1,
                       SalonId=2,
                       Time= DateTime.UtcNow.AddHours(2)
                    },
                    new Display
                    {
                        MovieId=2,
                        SalonId=1,
                        Time=DateTime.UtcNow.AddHours(1)
                    }

                };
                cinemaContext.Displays.AddRange(displays);
                cinemaContext.SaveChanges();

            }


        }
    }
}
