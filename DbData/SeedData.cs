using Group4_Lab3.DbData;
using Group4_Lab3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.DbData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieAppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MovieAppDbContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        MovieName = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = Genre.COMEDY,
                        Rating = 3,
                        Description = "this is the description",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/38/The_SpongeBob_Movie_Sponge_on_the_Run.jpg"
                    },

                    new Movie
                    {
                        MovieName = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = Genre.HORROR,
                        Rating = 4,
                        Description = "This is really scary kids movie",
                        ImageUrl = "~/images/The_SpongeBob_Movie_Sponge_on_the_Run.jpg"
                    },

                    new Movie
                    {
                        MovieName = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = Genre.HORROR,
                        Rating = 3,
                        Description = "This is a horror movie",
                        ImageUrl = "~/images/sonic.jpg"
                    },

                    new Movie
                    {
                        MovieName = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = Genre.THRILLER,
                        Rating = 4,
                        Description = "This is athriller movie",
                        ImageUrl = "~/images/sonic.jpg"
                    }
                ); ;
                context.SaveChanges();
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        Email = "sadia@gmail.com",
                        Password = "password",
                        ConfirmPassword = "password"
                    },

                    new User
                    {
                        Email = "charles@gmail.com",
                        Password = "123456",
                        ConfirmPassword = "123456"
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
