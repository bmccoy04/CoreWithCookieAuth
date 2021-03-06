﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWithCookieAuth.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        [Authorize(Policy = "ReadPolicy")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            var s = HttpContext.User.Identity.IsAuthenticated;
            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error() => View();
    }
}
