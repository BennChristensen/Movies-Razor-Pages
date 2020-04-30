using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApplication.Models;
using MovieApplication.Storage;

namespace MovieApplication.Pages
{
    public class ListModel : PageModel
    {
        private readonly IMovieData movieData;

        public IEnumerable<Movie> Movies { get; set; }
        public ListModel(IMovieData movieData)
        {
            this.movieData = movieData;
        }
        [TempData]
        public string Message { get; set; }
        public void OnGet()
        {
            Movies = movieData.GetAllMovies();
        }
    }
}