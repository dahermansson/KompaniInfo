using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KompaniInfo.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration Configuration { get; set; }
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(string password)
        {
            if (password == Configuration["UserPassword"])
            {
                Login(Roles.User);
            }
            else if (password == Configuration["AdminPassword"])
            {
                Login(Roles.Admin);
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        async private void Login(string role)
        {
            const string Issuer = "hmvblg";
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String, Issuer));
            var userIdentity = new ClaimsIdentity("HmvBlgIdentity");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal,
              new Microsoft.AspNetCore.Authentication.AuthenticationProperties
              {
                  ExpiresUtc = DateTime.UtcNow.AddDays(14),
                  IsPersistent = true,
                  AllowRefresh = true
              });
        }

    }
}