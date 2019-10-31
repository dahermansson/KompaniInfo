using KompaniInfo.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace KompaniInfo.Services
{
  public class FilService
  {
    private readonly string[] _tillatnaFiltyper = { ".png", ".jpg", ".jpeg", ".gif", ".doc", ".docx", ".pdf" };
    private readonly string[] _filtyperBilder = { ".png", ".jpg", ".jpeg", ".gif" };


    public bool ValideraFil(IFormFile fil)
    {
      return _tillatnaFiltyper.Contains(Path.GetExtension(fil.FileName.ToLower()));
    }

    public Fil SparaFil(IFormFile formFile)
    {
      string fileName = formFile.FileName.Replace(" ", string.Empty);
      var fil = new Fil();
      fil.Data = new byte[formFile.Length];
      formFile.OpenReadStream().Read(fil.Data, 0, (int)formFile.Length);
      fil.Namn = Path.GetFileName(fileName);
      fil.Typ = Path.GetExtension(formFile.FileName).TrimStart('.');
      fil.Bild = _filtyperBilder.Contains(Path.GetExtension(formFile.FileName.ToLower()));
      return fil;

    }

    internal string GetHtmlString(Fil fil)
    {
      if(fil.Bild)
        return Environment.NewLine + "![Alternativ text till bild](/Fil/Get/" + fil.Namn + ")";
      else
        return Environment.NewLine + "[" + fil.Namn + "](/Fil/Get/" + fil.Namn + ")";
    }
  }
}
