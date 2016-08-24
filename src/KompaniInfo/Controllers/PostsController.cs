using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KompaniInfo.Models;
using KompaniInfo.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KompaniInfo.Controllers
{
	[Authorize(Roles = Roles.Admin)]
    public class PostController : Controller
    {
        private readonly IPostRepository _context;

        public PostController(IPostRepository context)
        {
            _context = context;    
        }

		public IActionResult Skapa()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Skapa(string text)
		{
			Post p = new Post() { Datum = DateTime.Now, Innehall = text };
			_context.Skapa(p);
			return View();
		}



	}
}
