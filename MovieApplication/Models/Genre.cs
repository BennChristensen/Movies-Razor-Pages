using System.Collections.Generic;

namespace MovieApplication.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> MoviesWithThisGenre { get; set; }
    }
}