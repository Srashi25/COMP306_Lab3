
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Group4_Lab3.DbData;
using Group4_Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Group4_Lab3.Controllers
{
    
    public class UsersController : Controller
    {
        private IAmazonS3 amazonS3;
        private readonly MovieAppDbContext _context;

        public UsersController(MovieAppDbContext context)
        {
            _context = context;
            amazonS3 = new AmazonS3Client(RegionEndpoint.USEast2);
        }

        // GET: Users/Signin
        [HttpGet]
        public ViewResult Signin()
        {
            return View();
        }
        [HttpPost]
        // Post: Users/Signin/5
        public async Task<IActionResult> Signin(User userLogin)
        {

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == userLogin.Email);
            TempData["UserId"] = user.UserId;
            if (user == null)
            {
                TempData["LoginError"] = $"{userLogin.Email} does not exist";
                return View(userLogin);

            }
            return RedirectToAction("Index", "Movies");
        }
        [HttpGet]
        // GET: Users/Signup
        public IActionResult Signup()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup([Bind("UserId,Email,Password,ConfirmPassword")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Signin");
            }
            return View(user);
        }
        
    }
}

