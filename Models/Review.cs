using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public class Review
    {
        public string UserId { get; set; }
        public int ReviewID { get; set; }
        [Required(ErrorMessage = "Please enter Title!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Review!")]
        public string ReviewDescription { get; set; }
        
    }
}
