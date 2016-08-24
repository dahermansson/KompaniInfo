using KompaniInfo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KompaniInfo.Models;

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
	}
}
