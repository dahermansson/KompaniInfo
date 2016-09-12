using KompaniInfo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KompaniInfo.Models;

namespace KompaniInfo.Repositories
{
	public class FilRepository : IFilRepository
	{
		private KompaniInfoContext _context;
		public FilRepository(KompaniInfoContext context)
		{
			_context = context;
		}
		public IEnumerable<Fil> Get()
		{
			return _context.Fil;
		}

		public Fil Get(string filnamn)
		{
			return _context.Fil.FirstOrDefault(t => t.Namn == filnamn);
		}

		public void Spara(Fil fil)
		{
			_context.Add(fil);
			_context.SaveChanges();
		}
	}
}
