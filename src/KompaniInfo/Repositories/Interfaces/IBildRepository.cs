using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KompaniInfo.Models;

namespace KompaniInfo.Repositories.Interfaces
{
    public interface IBildRepository
    {
		IEnumerable<Bild> Get();
		void Spara(Bild bild);
		Bild Get(string bildnamn);
    }
}
