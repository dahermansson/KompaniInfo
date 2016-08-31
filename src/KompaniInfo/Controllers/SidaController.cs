using KompaniInfo.Models;
using KompaniInfo.Repositories.Interfaces;
using KompaniInfo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

		[Authorize(Roles = Roles.Admin)]
		public IActionResult Skapa()
		{
			return View();
		}

		[Authorize(Roles = Roles.Admin)]
		[HttpPost]
		public IActionResult Skapa(Sida sida, string btn, IFormFile fil)
		{
			if (btn == "LaddaUppBild" && fil != null)
			{
				BildService service = new BildService();
				if (!service.ValideraFil(fil))
					return View(sida);
				var bild = service.SparaBild(fil);
				_context.SparaBild(bild);
				ModelState.Clear();
				sida.Innehall += Environment.NewLine + "![Alternativ text till bild](/Bild/Get/" + bild.Namn + ")";
				return View(sida);
			}
			if (ModelState.IsValid)
			{
				_context.Skapa(sida);
				return RedirectToRoute("sidor", new { Id = sida.Id });
			}
			else
				return View(sida);
		}

		[Authorize(Roles = Roles.Admin)]
		public IActionResult Andra(int id)
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

		[Authorize(Roles = Roles.Admin)]
		[HttpPost]
		public IActionResult Andra(Sida sida, string btn, IFormFile fil)
		{
			if (btn == "LaddaUppBild" && fil != null)
			{
				BildService service = new BildService();
				if (!service.ValideraFil(fil))
					return View(sida);
				var bild = service.SparaBild(fil);
				_context.SparaBild(bild);
				ModelState.Clear();
				sida.Innehall += Environment.NewLine + "![Alternativ text till bild](/Bild/Get/" + bild.Namn + ")";
				return View(sida);
			}
			if (ModelState.IsValid)
			{
				_context.Andra(sida);
				return RedirectToRoute("sidor", new { Id = sida.Id });
			}
			else
				return View(sida);
		}

		[Authorize(Roles = Roles.Admin)]
		public IActionResult TaBort(int id)
		{
			var sida = _context.Get(id);
			if (sida != null)
			{
				_context.TaBort(sida);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return RedirectToAction("Error");
			}
		}
	}
}
