using MovieApplication.Models;
using System.Collections.Generic;

namespace MovieApplication.Storage
{
    public interface IMovieData
    {
        List<Movie> GetAllMovies();
        void AddMovie(Movie movie);
        Movie GetMovieByID(int id);
        void AddRating(int id, int rating);
    }
}