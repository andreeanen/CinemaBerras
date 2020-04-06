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
    }
}
