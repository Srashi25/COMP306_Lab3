using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public class UserMovieList
    {
        public string ListID { get; set; }
        public string UserID { get; set; }
        public string MovieID { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
