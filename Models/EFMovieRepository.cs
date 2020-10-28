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
        public IQueryable<Movie> Movies=> context.Movies;
    }
}
