using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaBerras.Models
{
    public class Salon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public List<Display> Displays { get; set; }
    }
}
