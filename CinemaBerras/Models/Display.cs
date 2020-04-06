using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaBerras.Models
{
    public class Display
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int SalonId { get; set; }
        [ForeignKey("SalonId")]
        public Salon Salon { get; set; }
    }
}
