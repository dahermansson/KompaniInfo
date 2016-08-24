using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KompaniInfo.Repositories.Interfaces;

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
			return View(_context.Get());
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
