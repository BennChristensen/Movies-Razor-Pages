using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApplication.Storage
{
    public class MoviesDataContext : DbContext, IMovieData
    {
        public MoviesDataContext(DbContextOptions<MoviesDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Movie>()
                .Property(m => m.Genres)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null),
                    v => JsonSerializer.Deserialize<List<Genre>>(v, null)
            );

            var valueComparer = new ValueComparer<List<Genre>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());

            modelBuilder
                .Entity<Movie>()
            .Property(m => m.Genres)
            .Metadata
            .SetValueComparer(valueComparer);
        }

        public DbSet<Movie> Movies { get; set; }
        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
            SaveChanges();
        }

        public List<Movie> GetAllMovies()
        {
            return Movies.Include(m => m.Ratings).ToList();
        }

        public Movie GetMovieByID(int id)
        {
            return Movies.Where(m => m.Id == id)
                         .Include(m => m.Ratings)
                         .FirstOrDefault();
        }

        public void AddRating(int id, int rating)
        {
            GetMovieByID(id).Ratings.Add(new Rating { Stars = rating });
            SaveChanges();
        }
    }
}
