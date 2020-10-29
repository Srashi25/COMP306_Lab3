using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Group4_Lab3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Group4_Lab3.Controllers
{
    public class AccountController : Controller
    {
      

        public ViewResult Signin(string returnUrl)
        {
            return View(new User
            {
                ReturnUrl = returnUrl
            });
        }
        public ViewResult Signup(string returnUrl)
        {
            return View(new User
            {
                ReturnUrl = returnUrl
            });
        }


    }
}

