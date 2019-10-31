using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KompaniInfo.Models
{
    public class Sida
    {
		public int Id { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Innehåll måste anges")]
		[Display(Name ="Innehåll")]
		public string Innehall { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Namn måste anges")]
		[MaxLength(100)]
		public string Namn{ get; set; }

	}
}
