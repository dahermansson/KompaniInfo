using KompaniInfo.Models;
using KompaniInfo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.Repositories.Interfaces
{
    public interface IPostRepository
    {
		IEnumerable<Post> Get();
		Post Get(int id);
		IEnumerable<Post> GetOrderdTop10();
		void Skapa(Post post);
		void Andra(Post post);
		void TaBort(Post post);
		void SparaBild(Fil bild);
	}
}
