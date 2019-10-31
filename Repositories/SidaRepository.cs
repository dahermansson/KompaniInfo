using KompaniInfo.Repositories.Interfaces;
using System.Collections.Generic;
using KompaniInfo.Models;
using System.Linq;
using System;

namespace KompaniInfo.Repositories
{
    public class SidaRepository : ISidaRepository
    {
		private KompaniInfoContext _context;
		public SidaRepository(KompaniInfoContext context)
		{
			_context = context;
		}

		public Sida Get(int id)
		{
			return _context.Sida.FirstOrDefault(p => p.Id == id);
		}

		public Dictionary<int, string> GetLankarToSidor()
		{
			var res = _context.Sida.Select(t => new KeyValuePair<int, string>(t.Id, t.Namn)).ToDictionary(o => o.Key, o => o.Value);
			return res;
		}

		public void Skapa(Sida sida)
		{
			_context.Sida.Add(sida);
			_context.SaveChanges();
		}

		public void Andra(Sida sida)
		{
			_context.Sida.Update(sida);
			_context.SaveChanges();
		}

		public void TaBort(Sida sida)
		{
			_context.Sida.Remove(sida);
			_context.SaveChanges();
		}

		public void SparaBild(Fil bild)
		{
			_context.Add(bild);
			_context.SaveChanges();
		}

	}
}
