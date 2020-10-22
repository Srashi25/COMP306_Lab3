using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    [DynamoDBTable("UserMovies")]
    public class UserMovies
    {
        [DynamoDBHashKey]
        public string UserMoviesId { get; set; }
        public string UserEmail { get; set; }
        public List<Movie> ListUserMovies { get; set; }
    }
}
