﻿using MovieApplication.Models;
using System.Collections.Generic;

namespace MovieApplication.Storage
{
    public interface IMovieData
    {
        List<Movie> GetAllMovies();
        void AddMovie(Movie movie);
        Movie GetMovieByID(int id);

        List<Genre> GetAllGenres();
        Genre GetGenreById(int i);
    }
}