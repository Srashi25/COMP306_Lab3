using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group4_Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Charles_Sadia_Lab3.Controllers
{
    public class HomeController : Controller
    {
        private IMovieRepository repository;
        public HomeController(IMovieRepository repo)
        {
            repository = repo;
        }

        //public ViewResult List() => View(repository.Movies);
        public IActionResult Index() => View();

        public IActionResult Upload() => View();
        
    }
}
