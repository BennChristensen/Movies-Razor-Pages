using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApplication.Models;
using MovieApplication.Storage;

namespace MovieApplication.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMovieData movieData;

        [BindProperty]
        public Movie Movie { get; set; }
        [HiddenInput]
        [BindProperty]
        public int Rating { get; set; }
        public DetailsModel(IMovieData movieData)
        {
            this.movieData = movieData;
        }

        public IActionResult OnGet(int id)
        {
            Movie = movieData.GetMovieByID(id);
            if (Movie == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            movieData.AddRating(Movie.Id, Rating);
            return RedirectToPage("../Index");
        }
    }
}