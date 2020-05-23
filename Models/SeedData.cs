using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RazorPagesMovie.Models
{
  public class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      if (serviceProvider == null)
      {
        throw new ArgumentNullException(nameof(serviceProvider));
      }

      using (var context = new RazorPagesMovieContext(
          serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
      {
        if (context.Movie.Any())
        {
          return; // DB has been seeded
        }

        context.Movie.AddRange(
            new Movie
            {
              Title = "Enter the Dragon",
              ReleaseDate = DateTime.Parse("1973-08-19"),
              Genre = "Action",
              Price = 3.99M,
              Rating = "R"
            },
            new Movie
            {
              Title = "Drunken Master",
              ReleaseDate = DateTime.Parse("1978-10-05"),
              Genre = "Action",
              Price = 2.99M,
              Rating = "PG-13"
            },
            new Movie
            {
              Title = "Terminator 2: Judgment Day",
              ReleaseDate = DateTime.Parse("1991-07-03"),
              Genre = "Action",
              Price = 2.99M,
              Rating = "R"
            },
            new Movie
            {
              Title = "The Terminator",
              ReleaseDate = DateTime.Parse("1984-10-26"),
              Genre = "Action",
              Price = 1.99M,
              Rating = "R"
            }
        );

        context.SaveChanges();

      }
    }
  }
}