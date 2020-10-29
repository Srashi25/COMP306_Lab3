using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }

    }
}
