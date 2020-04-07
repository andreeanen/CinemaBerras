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
            Display = _cinemaContext.Displays.Include(d => d.Movie).Include(d => d.Salon).FirstOrDefault(d => d.Id == id);

            if (Display == null)
            {
                return NotFound();
            }

            return View(Display);
        }

        public int ticketsSoldTotal = 0;
        public IActionResult Confirm(int? id, int numberOfBookedTickets)
        {

            Display = new Display();

            Display = _cinemaContext.Displays.Include(d => d.Movie).Include(d => d.Salon).FirstOrDefault(d => d.Id == id);
            Display.TicketsSold = numberOfBookedTickets;
            Display.TotalTicketsSold += numberOfBookedTickets;
            Display.TicketsAvailable = Display.Salon.Seats - Display.TotalTicketsSold;
            _cinemaContext.Displays.Update(Display);
            _cinemaContext.SaveChanges();

            return View(Display);
        }
    }
}
