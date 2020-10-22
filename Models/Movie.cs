using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    [DynamoDBTable("Movie")]
    public class Movie
    {
        [DynamoDBHashKey]
        public string MovieId{get; set;}
        public string Genre { get; set; }
        public DateTime Date { get; set; }
        public List<Review> Reviews { get; set; }
        public string Rating { get; set; }

    }
}
