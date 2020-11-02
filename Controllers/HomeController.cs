using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group4_Lab3.Data;
using Group4_Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Charles_Sadia_Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDbContext _context;

        public HomeController(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        public IActionResult Upload() => View();
        

        public IActionResult Review() => View();

        public IActionResult Detail() => View();
    }
}
