using CinemaBerras.Data;
using CinemaBerras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBerras.Controllers
{
    public class HomeController : Controller
    {
        private readonly CinemaContext _cinemaContext;
        public HomeController(CinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
        }
        public async Task<IActionResult> Index(string sortOrder)
        {
            var displays = from d in _cinemaContext.Displays
               .Include(d => d.Movie)
               .Include(d => d.Salon)
                           select d;

            switch (sortOrder)
            {
                case "salon_asc":
                    displays = displays.OrderBy(d => d.Salon.Name);
                    break;
                case "salon_desc":
                    displays = displays.OrderByDescending(d => d.Salon.Name);
                    break;
                case "seats_asc":
                    displays = displays.OrderBy(d => (d.Salon.Seats - d.TotalTicketsSold));
                    break;
                case "seats_desc":
                    displays = displays.OrderByDescending(d => (d.Salon.Seats - d.TotalTicketsSold));
                    break;
                case "starts_asc":
                    displays = displays.OrderBy(d => d.Time);
                    break;
                case "starts_desc":
                    displays = displays.OrderByDescending(d => d.Time);
                    break;
                case "title_asc":
                    displays = displays.OrderBy(d => d.Movie.Title);
                    break;
                case "title_desc":
                    displays = displays.OrderByDescending(d => d.Movie.Title);
                    break;
                default:
                    displays = displays.OrderBy(d => d.Time);
                    break;
            }

            return View(await displays.AsNoTracking().ToListAsync());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
