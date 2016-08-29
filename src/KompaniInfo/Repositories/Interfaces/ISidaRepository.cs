using KompaniInfo.Models;
using KompaniInfo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.Repositories.Interfaces
{
    public interface ISidaRepository
    {
		Dictionary<int, string> GetLankarToSidor();
		Sida Get(int id);
		void Skapa(Sida sida);
		void Andra(Sida sida);
		void TaBort(Sida sida);
    }
}
