using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public IActionResult Index(LoginViewModel ln)
        {
            if (ln.UserName == ln.Password) {
                var claims = new List<Claim>
                {
                    new Claim("Read", "true"),
                    new Claim(ClaimTypes.Name, "ayayalar"),
                    new Claim(ClaimTypes.Sid, "12345")
                };

                var claimsIdentity = new ClaimsIdentity(claims, "password");
                var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
                
                HttpContext.Authentication.SignInAsync("Cookies", claimsPrinciple);

                return Redirect("~/");
            }
            
            return View(new LoginViewModel() { UserName = "Bryan" });
        }

        public IActionResult LogOut(){
            HttpContext.Authentication.SignOutAsync("Cookies");
            return Redirect("~/");
        }
    }
}
