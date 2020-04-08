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

            if (!cinemaContext.Movies.Any())
            {
                var movies = new Movie[]
                {
                    new Movie
                    {
                        Title="Jumanji"
                    },
                    new Movie
                    {
                        Title="Birds of Prey"
                    },
                    new Movie
                    {
                        Title="Frozen 2"
                    },
                    new Movie
                    {
                        Title="Mulan"
                    },
                    new Movie
                    {
                        Title="1917"
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
                           Seats = 10
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
                       Date=DateTime.UtcNow,
                       Time=DateTime.Parse("21:30")
                    },
                    new Display
                    {
                        MovieId=2,
                        SalonId=1,
                        Date=DateTime.UtcNow,
                        Time=DateTime.Parse("13:00")
                    },
                    new Display
                    {
                        MovieId=3,
                        SalonId=1,
                        Date=DateTime.UtcNow,
                        Time=DateTime.Parse("15:00")
                    },
                    new Display
                    {
                        MovieId=4,
                        SalonId=2,
                        Date=DateTime.UtcNow,
                        Time=DateTime.Parse("19:00")
                    },
                    new Display
                    {
                        MovieId=3,
                        SalonId=2,
                        Date=DateTime.UtcNow,
                        Time=DateTime.Parse("17:00")
                    },
                    new Display
                    {
                        MovieId=5,
                        SalonId=1,
                        Date=DateTime.UtcNow,
                        Time=DateTime.Parse("17:00")
                    }



                };
                cinemaContext.Displays.AddRange(displays);
                cinemaContext.SaveChanges();
            }
        }
    }
}
