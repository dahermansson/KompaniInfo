using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;

namespace KompaniInfo.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
    {
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public  IActionResult Index(string password)
        {
			if (password == "user")
			{
				Login(Roles.User);
			}
			else if(password == "admin")
			{
				Login(Roles.Admin);
			}
			return View();
        }

		public IActionResult Logout()
		{
			HttpContext.Authentication.SignOutAsync("Cookie");
			return View();
		}

		async private void Login(string role)
		{
			const string Issuer = "hmvblg";
			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String, Issuer));
			var userIdentity = new ClaimsIdentity("HmvBlgIdentity");
			userIdentity.AddClaims(claims);
			var userPrincipal = new ClaimsPrincipal(userIdentity);

			await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
				new AuthenticationProperties
				{
					ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
					IsPersistent = false,
					AllowRefresh = false
				});
		}

	}
}