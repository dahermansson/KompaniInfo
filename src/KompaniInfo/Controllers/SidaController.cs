using KompaniInfo.Models;
using KompaniInfo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.Controllers
{
    public class SidaController: Controller
	{
		private readonly ISidaRepository _context;
		public SidaController(ISidaRepository context)
		{
			_context = context;
		}

		public IActionResult Index(int id)
		{
			var sida = _context.Get(id);
			if (sida != null)
			{
				return View(sida);
			}
			else
			{
				return RedirectToAction("Error");
			}
		}

		public IActionResult GetLankarForMeny()
		{
			return PartialView("LankarTillSidor.cshtml", _context.GetLankarToSidor());
		}

		public IActionResult Skapa()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Skapa(Sida sida)
		{
			if (ModelState.IsValid)
			{
				_context.Skapa(sida);
				return RedirectToAction("index", "home");
			}
			else
				return View(sida);
		}
	}
}
