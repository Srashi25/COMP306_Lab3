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
        //    private UserManager<IdentityUser> userManager;
        //    private SignInManager<IdentityUser> signInManager;
        //    public AccountController(UserManager<IdentityUser> userMgr,
        //    SignInManager<IdentityUser> signInMgr)
        //    {
        //        userManager = userMgr;
        //        signInManager = signInMgr;
        //    }
        //    [AllowAnonymous]
        //    public ViewResult Signin(string returnUrl)
        //    {
        //        return View(new User
        //        {
        //            ReturnUrl = returnUrl
        //        });
        //    }
        //    [HttpPost]
        //    [AllowAnonymous]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Signin(User userModel)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            IdentityUser user =
        //            await userManager.FindByNameAsync(userModel.Email);
        //            if (user != null)
        //            {
        //                await signInManager.SignOutAsync();
        //                if ((await signInManager.PasswordSignInAsync(user,
        //                userModel.Password, false, false)).Succeeded)
        //                {
        //                    return Redirect(userModel?.ReturnUrl ?? "/Home/Index");
        //                }
        //            }
        //        }
        //        ModelState.AddModelError("", "Invalid user email or password");
        //        return View(userModel);
        //    }
        //    public async Task<RedirectResult> Logout(string returnUrl = "/")
        //    {
        //        await signInManager.SignOutAsync();
        //        return Redirect(returnUrl);
        //    }
        //}

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

