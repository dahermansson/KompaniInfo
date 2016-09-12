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
using Microsoft.AspNetCore.Http;
using System.IO;
using KompaniInfo.Services;

namespace KompaniInfo.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _context;

        public PostController(IPostRepository context)
        {
            _context = context;    
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

		[Authorize(Roles = Roles.Admin)]
		public IActionResult Skapa()
		{
			return View();
		}

		[Authorize(Roles = Roles.Admin)]
		[HttpPost]
		public IActionResult Skapa(VMPost vmPost, string btn)
		{
			if(btn == "LaddaUppBild" && vmPost.Fil != null)
			{
				FilService service = new FilService();
        if (!service.ValideraFil(vmPost.Fil))
        {
          ModelState.Clear();
          ModelState.TryAddModelError("Fil", "Fel fil");
          return View();
        }
				var fil = service.SparaFil(vmPost.Fil);
				_context.SparaBild(fil);
				ModelState.Clear();
				vmPost.Innehall += service.GetHtmlString(fil);
        return View(vmPost);
			}
			if (ModelState.IsValid)
			{
				vmPost.Datum = DateTime.Now;
				PostTransform pt = new PostTransform();
				Post post = pt.Transform(vmPost);
				_context.Skapa(post);
				return RedirectToAction("index", "home");
			}
			else
				return View();
		}

		[Authorize(Roles = Roles.Admin)]
		public IActionResult Andra(int id)
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

		[Authorize(Roles = Roles.Admin)]
		[HttpPost]
		public IActionResult Andra(VMPost vmPost, string btn)
		{
			if (btn == "LaddaUppBild" && vmPost.Fil != null)
			{
				FilService service = new FilService();
        if (!service.ValideraFil(vmPost.Fil))
        {
          ModelState.Clear();
          ModelState.TryAddModelError("Fil", "Fel fil");
          return View();
        }
        var fil = service.SparaFil(vmPost.Fil);
				_context.SparaBild(fil);
				ModelState.Clear();
				vmPost.Innehall += service.GetHtmlString(fil);
        return View(vmPost);
			}
			if (ModelState.IsValid)
			{
				var andraPost = _context.Get(vmPost.Id);
				PostTransform pt = new PostTransform();
				Post post = pt.UpdateTransform(vmPost, andraPost);
				_context.Andra(post);
				return RedirectToAction("index", "home");
			}
			else
				return View();
		}

		[Authorize(Roles = Roles.Admin)]
		public IActionResult TaBort(int id)
		{
			var post = _context.Get(id);
			if (post != null)
			{
				_context.TaBort(post);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return RedirectToAction("Error");
			}
		}
	}
}
