using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Group4_Lab3.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View();
    }
}
