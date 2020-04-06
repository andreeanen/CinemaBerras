using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBerras.Models
{
    public class Display
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Starts at")]
        public DateTime Time { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int SalonId { get; set; }
        [ForeignKey("SalonId")]
        public Salon Salon { get; set; }
        [Range(1, 12)]
        public int TicketsSold { get; set; }
    }
}
