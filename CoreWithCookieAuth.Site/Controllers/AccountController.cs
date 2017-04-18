using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWithCookieAuth.Site.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreWithCookieAuth.Site.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel ln){
            if(ln.UserName == ln.Password)
                return RedirectToAction("Index", "Home");
            else
                return View(new LoginViewModel(){UserName = "Bryan"});            
        }
    }
}
