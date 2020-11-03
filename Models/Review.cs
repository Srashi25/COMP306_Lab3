using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    [DynamoDBTable("Review")]
    public class Review
    {

        public string ReviewID { get; set; }
        [Required(ErrorMessage = "Please enter Title!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Review!")]
        public string ReviewDescription { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
