using CinemaBerras.Data;
using CinemaBerras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBerras.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CinemaContext _cinemaContext;

        public HomeController(ILogger<HomeController> logger, CinemaContext cinemaContext)
        {
            _logger = logger;
            _cinemaContext = cinemaContext;
        }

        //public IActionResult Index()
        //{
        //    var displays = _cinemaContext.Displays.Include(d => d.Movie).Include(d => d.Salon).ToList();

        //    return View(displays);
        //}

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["TitleSortParm"] = sortOrder == "title_asc" ? "title_desc" : "title_asc";
            ViewData["TimeSortParm"] = sortOrder == "starts_asc" ? "starts_desc" : "starts_asc";
            ViewData["SeatsSortParm"] = sortOrder == "seats_asc" ? "seats_desc" : "seats_asc";
            ViewData["SalonSortParm"] = sortOrder == "salon_asc" ? "salon_desc" : "salon_asc";
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
                    displays = displays.OrderBy(d => d.Salon.Seats - d.TotalTicketsSold);
                    break;
                case "seats_desc":
                    displays = displays.OrderByDescending(d => d.Salon.Seats - d.TotalTicketsSold);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
