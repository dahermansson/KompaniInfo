using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KompaniInfo.Models;

namespace KompaniInfo.Repositories.Interfaces
{
    public interface IFilRepository
    {
		IEnumerable<Fil> Get();
		void Spara(Fil fil);
		Fil Get(string filnamn);
    }
}
