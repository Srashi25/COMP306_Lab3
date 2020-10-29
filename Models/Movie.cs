using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public class Movie
    {
        public uint MovieId { get; set; }
        public string UserEmail { get; set; }
        public string Genre { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
     
        public string ImageUrl { get; set; }
        public string Substring(string instructions)
        {
            string substring = Description.Substring(0, 60);
            return substring;
        }

        public virtual void AddReview(Review rev)
        {
            rev.Movie = this;
            Reviews.Add(rev);
        }
        public virtual void DelReview(Review rev)
        {
            if (rev.Movie == this)
            {
                Reviews.Remove(rev);
            }
        }

    }
}
