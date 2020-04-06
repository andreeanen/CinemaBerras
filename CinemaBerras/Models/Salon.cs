using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaBerras.Models
{
    public class Salon
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Salon")]
        public string Name { get; set; }
        [Display(Name = "Available seats")]
        public int Seats { get; set; }
        public List<Display> Displays { get; set; }
    }
}
