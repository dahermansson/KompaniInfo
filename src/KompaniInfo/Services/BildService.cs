using KompaniInfo.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KompaniInfo.Services
{
    public class BildService
    {
		private readonly string[] _tillatnaFiltyper  = { ".png", ".jpg"};

		public bool ValideraFil(IFormFile fil)
		{
			return _tillatnaFiltyper.Contains(Path.GetExtension(fil.FileName.ToLower()));
		}

		public Bild SparaBild(IFormFile fil)
		{
			var bild = new Bild();
			bild.Data = new byte[fil.Length];
			fil.OpenReadStream().Read(bild.Data, 0, (int)fil.Length);
			bild.Namn = Path.GetFileName(fil.FileName);
			bild.Typ = Path.GetExtension(fil.FileName.TrimStart('.'));
			return bild;
		}
    }
}
