using KompaniInfo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KompaniInfo.Controllers
{
    public class FilController: Controller
    {
		private readonly IFilRepository _context;
		public FilController(IFilRepository context)
		{
			_context = context;
		}

		public ActionResult Get(string id)
		{
			var fil = _context.Get(id);
      if(fil.Bild)
			  return File(fil.Data, "image/" + fil.Typ);
      else
        return File(fil.Data, "application/" + fil.Typ);
    }
    }
}
