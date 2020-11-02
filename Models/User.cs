using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public class User
    {
    
       public string UserId { get; set; }
      
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
      
        [Required (ErrorMessage = "Password is required")]
        [UIHint("password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [UIHint("password")]
        public string ConfirmPassword { get; set; }
        public ICollection<Movie> MovieList { get; set; }
        //public string ReturnUrl { get; set; } = "/";
    }
}
