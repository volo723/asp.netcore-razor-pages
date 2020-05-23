using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
  public class RazorPagesMovieContext : DbContext
  {
    public DbSet<Movie> Movie { get; set; }
    public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
        : base(options)
    {
      
    }
  }
}