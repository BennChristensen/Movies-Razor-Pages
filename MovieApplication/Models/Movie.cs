using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        [Display(Prompt = "Enter movie titel")]
        public string Titel { get; set; }
        [Range(1900, 2050)]
        [Display(Name = "Production year")]
        public int ProductionYear { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Genre> Genres { get; set; }
        public int AvarageRating
        {
            get
            {
                if (Ratings.Count() > 0)
                {
                    return Ratings.Sum(r => r.Stars) / Ratings.Count();
                }
                return 0;
            }
        }

        public Movie()
        {
            Ratings = new List<Rating>();
            ProductionYear = DateTime.Today.Year;

        }
    }
}
