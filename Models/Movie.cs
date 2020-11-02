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

     
      
        public string MovieId { get; set; }
        public Genre? Genre { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
   
        public string ImageUrl { get; set; }
        public S3Link MovieLink { get; set; }
        public string Substring(string desc)
        {
            string substring = desc.Substring(0, 60);
            return substring;
        }

    }

}
