using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Charles_Sadia_Lab3.Models
{
    public class Movie
    {
        public string MovieId { get; set; }
        public string Genre { get; set; }
        public DateTime Date { get; set; }
        public List<Review> Reviews { get; set; }
        public string Rating { get; set; }

    }
}
