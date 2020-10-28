using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                new Movie
                {
                    MovieId = "1",
                    MovieName = "Kayak",
                    Description = "A new Movie",
                    ImageUrl = "~/images/The_SpongeBob_Movie_Sponge_on_the_Run.jpg",
                    Genre = "Animation",
                    Rating = 3.5,
                    ReleaseDate = new DateTime(2020, 08, 14)
                },
                 new Movie
                 {
                     MovieId = "2",
                     MovieName = "Kayak",
                     Description = "A new Movie",
                     ImageUrl = "~/images/The_SpongeBob_Movie_Sponge_on_the_Run.jpg",
                     Genre = "Animation",
                     Rating = 3.5,
                     ReleaseDate = new DateTime(2020, 08, 14)
                 },
                  new Movie
                  {
                      MovieId = "3",
                      MovieName = "Kayak",
                      Description = "A new Movie",
                      ImageUrl = "~/images/The_SpongeBob_Movie_Sponge_on_the_Run.jpg",
                      Genre = "Animation",
                      Rating = 3.5,
                      ReleaseDate = new DateTime(2020, 08, 14)
                  });
                context.SaveChanges();
            }
        }
    }
}

