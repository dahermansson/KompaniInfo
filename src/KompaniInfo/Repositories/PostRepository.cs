using KompaniInfo.Repositories.Interfaces;
using System.Collections.Generic;
using KompaniInfo.Models;
using System.Linq;
using System;

namespace KompaniInfo.Repositories
{
    public class PostRepository : IPostRepository
    {
		private KompaniInfoContext _context;
		public PostRepository(KompaniInfoContext context)
		{
			_context = context;
		}

		public IEnumerable<Post> Get()
		{
			return _context.Post;
		}
		public Post Get(int id)
		{
			return _context.Post.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<Post> GetOrderdTop10()
		{
			return _context.Post.OrderByDescending(p => p.Datum).Take(10);
		}



		public void Skapa(Post post)
		{
			_context.Post.Add(post);
			_context.SaveChanges();
		}
	}
}
