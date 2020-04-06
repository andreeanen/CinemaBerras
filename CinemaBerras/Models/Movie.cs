using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaBerras.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Movie title")]
        public string Title { get; set; }
        public IList<Display> Displays { get; set; }
    }
}
