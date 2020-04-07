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

        [HttpPost]
        public IActionResult Show(Display model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var oldEntity = _cinemaContext.Displays.Include(d => d.Movie).Include(d => d.Salon).FirstOrDefault(d => d.Id == model.Id);

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
                ModelState.AddModelError("TicketsSold", "The amount of available seats is lower then the number of tickets you want to book.Try again!");
                return View(oldEntity);
            }

            return RedirectToAction("Confirm", new { id = Display.Id });
        }


        public IActionResult Confirm(int? id)
        {
            var oldEntity = _cinemaContext.Displays.Include(d => d.Movie).Include(d => d.Salon).FirstOrDefault(d => d.Id == id);

            return View(oldEntity);
        }
    }
}
