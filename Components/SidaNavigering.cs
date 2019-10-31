using KompaniInfo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.Components
{
    public class SidaNavigering: ViewComponent
    {
		private readonly ISidaRepository _context;
		public SidaNavigering(ISidaRepository context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var res = _context.GetLankarToSidor();
			return View(res);
		} 
	}
}
