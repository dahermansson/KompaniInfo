using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Extensions.Configuration;

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
			HttpContext.Authentication.SignOutAsync("Cookie");
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