using KompaniInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.Repositories.Interfaces
{
    public interface IPostRepository
    {
		IEnumerable<Post> Get();
		void Skapa(Post post);
    }
}
