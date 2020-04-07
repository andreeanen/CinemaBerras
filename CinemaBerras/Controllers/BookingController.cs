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
            Display = _cinemaContext.Displays.Include(d => d.Movie).Include(d => d.Salon).FirstOrDefault(d => d.Id == id);

            if (Display == null)
            {
                return NotFound();
            }

            return View(Display);
        }

        public int ticketsSoldTotal = 0;
        public IActionResult Confirm(int? id)
        {
            var oldEntity = _cinemaContext.Displays.Include(d => d.Movie).Include(d => d.Salon).FirstOrDefault(d => d.Id == id);

            var totalTicketAmount = Display.TicketsSold + oldEntity.TotalTicketsSold;
            var isValidTicketAmount = totalTicketAmount <= oldEntity.Salon.Seats;

            if (isValidTicketAmount)
            {
                oldEntity.TicketsSold = Display.TicketsSold;
                oldEntity.TotalTicketsSold += Display.TicketsSold;
                _cinemaContext.Displays.Update(oldEntity);
                _cinemaContext.SaveChanges();
            }
            else
            {
                return RedirectToAction("Show");
            }

            //oldEntity.TicketsSold = Display.TicketsSold;


            //  oldEntity.TicketsAvailable = oldEntity.Salon.Seats - oldEntity.TotalTicketsSold;
            //if ()
            //{


            //}
            //else
            //{

            //    return NotFound();
            //}

            return View(oldEntity);
        }
    }
}
