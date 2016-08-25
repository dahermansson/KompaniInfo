using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KompaniInfo.Repositories.Interfaces;
using KompaniInfo.ViewModels;

namespace KompaniInfo.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPostRepository _context;

		public HomeController(IPostRepository context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			PostTransform pt = new PostTransform();
			VMIndex vmIndex = new VMIndex();
			foreach (var post in _context.GetOrderdTop10())
			{
				vmIndex.Poster.Add(pt.Transform(post));
			}
			foreach (var rubrik in _context.Get().OrderByDescending(p => p.Datum))
			{
				vmIndex.Rubriker.Add(new VMPostlistaItem() { Id = rubrik.Id, Rubrik = rubrik.Rubrik });
			}

			return View(vmIndex);
		}

		public IActionResult Post(int id)
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

		public IActionResult Error()
		{
			return View();
		}
	}
}
