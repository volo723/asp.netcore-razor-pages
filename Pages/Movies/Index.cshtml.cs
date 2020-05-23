using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }        
        [BindProperty(SupportsGet = true)]
        public string MovieGenre {get;set;}

        public async Task OnGetAsync()
        {
            var genres = await GetGenres();
            Genres = new SelectList(genres);

            var movies = await GetMovies(SearchString, MovieGenre);
            Movie = movies.ToList();
        }        

        private async Task<IReadOnlyList<Movie>> GetMovies(string search = "", string genre = "")
        {
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(search))
            {
                movies = movies.Where(m => m.Title.Contains(search));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                movies = movies.Where(m => m.Genre == genre);
            }

            return await movies.ToListAsync();
        }

        private async Task<IReadOnlyList<string>> GetGenres()
        {
            var genreQuery = from m in _context.Movie
                             orderby m.Genre
                             select m.Genre;

            return await genreQuery.Distinct().ToListAsync();
        }
    }
}
