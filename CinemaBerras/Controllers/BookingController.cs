using CinemaBerras.Data;
using CinemaBerras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CinemaBerras.Controllers
{
    public class BookingController : Controller
    {
        private readonly CinemaContext _cinemaContext;
        [BindProperty]
        public Display Display { get; set; }

        public BookingController(CinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show(int? id)
        {
            Display = new Display();
            var Display2 = new Display();
            Display = _cinemaContext.Displays.Include(d => d.Movie).Include(d => d.Salon).FirstOrDefault(d => d.Id == id);
            //Display2 = _cinemaContext.Displays.Where(d => d.Id == id);

            //Display.TicketsSold += 1;
            //_cinemaContext.Displays.Update(Display);
            //_cinemaContext.SaveChanges();

            if (Display == null)
            {
                return NotFound();
            }

            return View(Display);
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}
