using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace KompaniInfo.ViewModels
{
	public class VMPost
	{
		public int Id { get; set; }
		public DateTime Datum { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Meddelande saknas")]
		[Display(Name = "Innehåll")]
		public string Innehall { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Rubrik saknas")]
		[MaxLength(180)]
		[Display(Name = "Rubrik")]
		public string Rubrik { get; set; }
    public IFormFile Fil { get; set; }
  }
}
