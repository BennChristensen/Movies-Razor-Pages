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
        public List<Genre> Genres { get; set; }
        public InMemoryMovieDataStorage()
        {
            Movies = new List<Movie>();
            Genres = new List<Genre>();
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

        public List<Genre> GetAllGenres()
        {
            return Genres;
        }
        public Genre GetGenreById(int i)
        {
            return Genres.Where(g => g.Id == i).FirstOrDefault();
        }

        public void AddTestData()
        {
            Genres.Add(new Genre
            {
                Id = 1,
                Name = "Comedy"
            });
            Genres.Add(new Genre
            {
                Id = 2,
                Name = "Thriller"
            });
            Genres.Add(new Genre
            {
                Id = 3,
                Name = "Drama"
            });
            Genres.Add(new Genre
            {
                Id = 4,
                Name = "Action"
            });
            Genres.Add(new Genre
            {
                Id = 5,
                Name = "Adventure"
            });
            Genres.Add(new Genre
            {
                Id = 6,
                Name = "Fantasy"
            });
            Genres.Add(new Genre
            {
                Id = 7,
                Name = "Romance"
            });
            Genres.Add(new Genre
            {
                Id = 8,
                Name = "SciFi"
            });
            Genres.Add(new Genre
            {
                Id = 9,
                Name = "Western"
            });
            Genres.Add(new Genre
            {
                Id = 10,
                Name = "Musical"
            });
            Genres.Add(new Genre
            {
                Id = 11,
                Name = "Crime"
            });
            Genres.Add(new Genre
            {
                Id = 12,
                Name = "War"
            });

            Movies.Add(new Movie
            {
                Id = 1,
                Titel = "Parasite ",
                Genres = new List<Genre>
                    {
                        Genres.ElementAt(1),
                        Genres.ElementAt(3),
                        Genres.ElementAt(2)
                    },
                ProductionYear = 2019
            });
            Movies.Add(new Movie
            {
                Id = 2,
                Titel = "Joker",
                Genres = new List<Genre>
                    {
                        Genres.ElementAt(10),
                        Genres.ElementAt(7),
                        Genres.ElementAt(3)
                    },
                ProductionYear = 2019
            });
            Movies.Add(new Movie
            {
                Id = 3,
                Titel = "2017",
                Genres = new List<Genre>
                    {
                        Genres.ElementAt(4),
                        Genres.ElementAt(6)
                    },
                ProductionYear = 2019
            });
            Movies.Add(new Movie
            {
                Id = 4,
                Titel = "Dune",
                Genres = new List<Genre>
                    {
                        Genres.ElementAt(11),
                        Genres.ElementAt(8)
                    },
                ProductionYear = 2020
            });
            Movies.Add(new Movie
            {
                Id = 5,
                Titel = "Avengers: Endgame",
                Genres = new List<Genre>
                    {
                        Genres.ElementAt(2),
                        Genres.ElementAt(7)
                    },
                ProductionYear = 2019
            });
        }

    }
}
