using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorMovieDatabase.Models
{
    public class RazorMovieDatabaseContext : DbContext
    {
        public RazorMovieDatabaseContext (DbContextOptions<RazorMovieDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<RazorMovieDatabase.Models.Movie> Movie { get; set; }
    }
}
