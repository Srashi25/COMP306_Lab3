using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public EFReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Review> Reviews => context.Reviews.Include(r => r.Movie);
    }
}
