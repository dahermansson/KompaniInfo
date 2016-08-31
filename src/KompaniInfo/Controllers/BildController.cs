using KompaniInfo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.Controllers
{
    public class BildController: Controller
    {
		private readonly IBildRepository _context;
		public BildController(IBildRepository context)
		{
			_context = context;
		}

		public ActionResult Get(string id)
		{
			var bild = _context.Get(id);
			return File(bild.Data, "image/" + bild.Typ);
		}
    }
}
