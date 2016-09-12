using KompaniInfo.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.ViewModels
{
  public class VMSida : Sida
  {
    public IFormFile Fil { get; set; }
  }
}
