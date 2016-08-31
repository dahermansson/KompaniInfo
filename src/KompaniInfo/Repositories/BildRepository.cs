using KompaniInfo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KompaniInfo.Models;

namespace KompaniInfo.Repositories
{
	public class BildRepository : IBildRepository
	{
		private KompaniInfoContext _context;
		public BildRepository(KompaniInfoContext context)
		{
			_context = context;
		}
		public IEnumerable<Bild> Get()
		{
			return _context.Bild;
		}

		public Bild Get(string bildnamn)
		{
			return _context.Bild.FirstOrDefault(t => t.Namn == bildnamn);
		}

		public void Spara(Bild bild)
		{
			_context.Add(bild);
			_context.SaveChanges();
		}
	}
}
