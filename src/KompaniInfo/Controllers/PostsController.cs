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
using KompaniInfo.ViewModels;

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
		public IActionResult Skapa(VMPost vmPost)
		{
			if (ModelState.IsValid)
			{
				vmPost.Datum = DateTime.Now;
				PostTransform pt = new PostTransform();
				Post post = pt.Transform(vmPost);
				_context.Skapa(post);
				return RedirectToAction("index", "home");
			}
			else
				return View(vmPost);
		}

		public IActionResult Index(int id)
		{
			var post = _context.Get(id);
			if (post != null)
			{
				PostTransform pt = new PostTransform();
				var vmPost = pt.Transform(post);
				return View(vmPost);
			}
			else
			{
				return RedirectToAction("Error");
			}
		}
	}
}
