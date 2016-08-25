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
			var res = new List<VMPost>();
			foreach (var post in _context.Get())
			{
				res.Add(pt.Transform(post));
			}
			return View(res);
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
