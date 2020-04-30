using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApplication.Models;
using MovieApplication.Storage;

namespace MovieApplication.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly IMovieData movieData;

        [BindProperty]
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        [BindProperty]
        public bool[] SelectedGenres { get; set; }
        public CreateModel(IMovieData movieData)
        {
            this.movieData = movieData;
        }
        public void OnGet()
        {
            Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>();
            Movie = new Movie();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                Movie.Genres = new List<Genre>();
                for (int i = 0; i < SelectedGenres.Length; i++)
                {
                    if (SelectedGenres[i])
                    {
                        Movie.Genres.Add((Genre)i);
                    }
                }
                movieData.AddMovie(Movie);
                TempData["Message"] = $"Movie { Movie.Titel } was added to the collection";
                return RedirectToPage("../Index");
            }
            Genres = Enum.GetValues(typeof(Genre)).Cast<Genre>();
            return Page();
        }

    }
}