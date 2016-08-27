using KompaniInfo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.Controllers
{
    public class SidaCotroller: Controller
	{
		private readonly ISidaRepository _context;
		public SidaCotroller(ISidaRepository context)
		{
			_context = context;
		}

		public IActionResult GetLankarForMeny()
		{
			return PartialView("LankarTillSidor.cshtml", _context.GetLankarToSidor());
		}
    }
}
