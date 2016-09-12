using KompaniInfo.Models;
using KompaniInfo.Repositories.Interfaces;
using KompaniInfo.Services;
using KompaniInfo.ViewModels;
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
        SidaTransform st = new SidaTransform();
        var vmSida = st.Transform(sida);
				return View(vmSida);
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
		public IActionResult Skapa(VMSida vmSida, string btn)
		{
			if (btn == "LaddaUppBild" && vmSida.Fil != null)
			{
				FilService service = new FilService();
        if (!service.ValideraFil(vmSida.Fil))
        {
          ModelState.Clear();
          ModelState.TryAddModelError("Fil", "Fel fil");
          return View();
        }
				var fil = service.SparaFil(vmSida.Fil);
				_context.SparaBild(fil);
				ModelState.Clear();
				vmSida.Innehall += service.GetHtmlString(fil);
        return View(vmSida);
			}
			if (ModelState.IsValid)
			{
        SidaTransform st = new SidaTransform();
        var sida = st.Transform(vmSida);
				_context.Skapa(sida);
				return RedirectToRoute("sidor", new { Id = sida.Id });
			}
			else
				return View();
		}

		[Authorize(Roles = Roles.Admin)]
		public IActionResult Andra(int id)
		{
			var sida = _context.Get(id);
			if (sida != null)
			{
        SidaTransform st = new SidaTransform();
        var vmSida = st.Transform(sida);
				return View(vmSida);
			}
			else
			{
				return RedirectToAction("Error");
			}
		}

		[Authorize(Roles = Roles.Admin)]
		[HttpPost]
		public IActionResult Andra(VMSida vmSida, string btn)
		{
			if (btn == "LaddaUppBild" && vmSida.Fil != null)
			{
				FilService service = new FilService();
        if (!service.ValideraFil(vmSida.Fil))
        {
          ModelState.Clear();
          ModelState.TryAddModelError("Fil", "Fel fil");
          return View();
        }
        var fil = service.SparaFil(vmSida.Fil);
				_context.SparaBild(fil);
				ModelState.Clear();
				vmSida.Innehall += service.GetHtmlString(fil);
        return View(vmSida);
			}
			if (ModelState.IsValid)
			{
        SidaTransform st = new SidaTransform();
        var sida = st.Transform(vmSida);
        _context.Andra(sida);
				return RedirectToRoute("sidor", new { Id = sida.Id });
			}
			else
				return View();
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
