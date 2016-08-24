using KompaniInfo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KompaniInfo.Models;
using KompaniInfo.ViewModels;

namespace KompaniInfo.Repositories
{
    public class PostRepository : IPostRepository
    {
		private KompaniInfoContext _context;
		public PostRepository(KompaniInfoContext context)
		{
			_context = context;
		}

		public IEnumerable<VMPost> Get()
		{
			var res = new List<VMPost>();
			foreach (var p in _context.Post)
			{
				res.Add(new VMPost() { Id = p.Id, Datum = p.Datum, Innehall = p.Innehall });
			}
			return res;
		}
		public void Skapa(Post post)
		{
			_context.Post.Add(post);
			_context.SaveChanges();
		}
	}
}
