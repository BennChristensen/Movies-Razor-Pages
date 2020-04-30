using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Storage
{
    public class InMemoryMovieDataStorage : IMovieData
    {
        public List<Movie> Movies { get; set; }
        public InMemoryMovieDataStorage()
        {
            Movies = new List<Movie>();
            AddTestData();
        }

        public void AddMovie(Movie movie)
        {
            movie.Id = Movies.Max(m => m.Id) + 1;
            Movies.Add(movie);
        }

        public Movie GetMovieByID(int id)
        {
            return Movies.Where(m => m.Id == id).FirstOrDefault();
        }
        public List<Movie> GetAllMovies()
        {
            return Movies;
        }
        public void AddRating(int id, int rating)
        {
            GetMovieByID(id).Ratings.Add(new Rating { Stars = rating });
        }

        public void AddTestData()
        {


            Movies.Add(new Movie
            {
                Id = 1,
                Titel = "Parasite ",
                Genres = new List<Genre>
                    {
                        Genre.Drama,
                        Genre.Comedy,
                        Genre.Thriller
                    },
                ProductionYear = 2019
            });
            Movies.Add(new Movie
            {
                Id = 2,
                Titel = "Joker",
                Genres = new List<Genre>
                    {
                        Genre.Crime,
                        Genre.Drama,
                        Genre.Thriller
                    },
                ProductionYear = 2019
            });
            Movies.Add(new Movie
            {
                Id = 3,
                Titel = "1917",
                Genres = new List<Genre>
                    {
                        Genre.Drama,
                        Genre.War
                    },
                ProductionYear = 2019
            });
            Movies.Add(new Movie
            {
                Id = 4,
                Titel = "Dune",
                Genres = new List<Genre>
                    {
                        Genre.Adventure,
                        Genre.Drama,
                        Genre.SciFi
                    },
                ProductionYear = 2020
            });
            Movies.Add(new Movie
            {
                Id = 5,
                Titel = "Avengers: Endgame",
                Genres = new List<Genre>
                    {
                        Genre.Action,
                        Genre.Adventure,
                        Genre.Drama
                    },
                ProductionYear = 2019
            });
        }

    }
}
