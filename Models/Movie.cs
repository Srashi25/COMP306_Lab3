using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public class Movie
    {

        public int MovieId { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public Genre? Genre { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Movie Name is required")]
        public string MovieName { get; set; }
        public string UserEmail { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }

        public string ImageUrl { get; set; }
        //public S3Link MovieLink { get; set; }

        public ICollection<Review> Reviews;
        public string Substring(string desc)
        {
            string substring = desc.Substring(0, 60);
            return substring;
        }
    }

}
