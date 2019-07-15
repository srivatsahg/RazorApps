using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorMovieDatabase.Models;

namespace RazorMovieDatabase.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorMovieDatabase.Models.RazorMovieDatabaseContext _context;

        public IndexModel(RazorMovieDatabase.Models.RazorMovieDatabaseContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)] //binds form values and query params to same name as property
        public string SearchString { get; set; }

        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)] //binds form values and query params to same name as property
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(g => g.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Movie = await movies.ToListAsync();
        }
    }
}
