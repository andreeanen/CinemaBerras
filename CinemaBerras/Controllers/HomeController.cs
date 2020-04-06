using CinemaBerras.Data;
using CinemaBerras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

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

        public IActionResult Index()
        {
            var displays = _cinemaContext.Displays.Include(x => x.Movie).ToList();

            return View(displays);
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
