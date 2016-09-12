using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KompaniInfo.Models
{
    public class Fil
    {
		public int Id { get; set; }
		[Required]
		[MaxLength(250, ErrorMessage = "Filnamnet är för långt, max 250 tecken")]
		public string Namn { get; set; }
		[Required]
		[MaxLength(5, ErrorMessage = "Filtypen kan inte vara mer än 5 tecken")]
		public string Typ { get; set; }
		public byte[] Data { get; set; }
    public bool Bild { get; set; }
  }
}
