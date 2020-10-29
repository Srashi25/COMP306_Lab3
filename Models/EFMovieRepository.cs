using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public class EFMovieRepository: IMovieRepository
    {
        private ApplicationDbContext context;
        public EFMovieRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Movie> Movies=> context.Movies.Include(m => m.Reviews);


        public void SaveMovie(Movie movie)
        {
            if (movie.MovieId == 0)
            {
                context.Movies.Add(movie);
            }
            else
            {
                Movie dbEntry = context.Movies
                    .FirstOrDefault(m => m.MovieId == movie.MovieId);
                if (dbEntry != null)
                {
                    dbEntry.MovieName = movie.MovieName;
                    dbEntry.UserEmail= movie.UserEmail;
                    dbEntry.ImageUrl = movie.ImageUrl;
                    dbEntry.Genre = movie.Genre;
                    dbEntry.ReleaseDate = movie.ReleaseDate;
                    dbEntry.MovieId = movie.MovieId;
                    dbEntry.Description = movie.Description;
                    dbEntry.Reviews = movie.Reviews;

                }
            }
            context.SaveChanges();
        }
        public Movie DeleteMovie(int movieID)
        {

            Movie dbEntry = context.Movies
                .FirstOrDefault(m => m.MovieId == movieID);
            if (dbEntry != null)
            {
                context.Movies.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void EditReview(Review review)
        {
            Review _dbEntry = context.Reviews
                .FirstOrDefault(r => r.ReviewID == review.ReviewID);
            if (_dbEntry != null)
            {
                _dbEntry.Movie = review.Movie;
                _dbEntry.ReviewID = review.ReviewID;
                _dbEntry.ReviewDescription = review.ReviewDescription;
                _dbEntry.Title = review.Title;
                _dbEntry.UserId = review.UserId;
            }

            context.SaveChanges();
        }
        public void DelReview(Review review)
        {

            Review dbEntry = context.Reviews
                .FirstOrDefault(r => r.ReviewID == review.ReviewID);
            if (dbEntry != null)
            {
                context.Reviews.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        
    }
}
