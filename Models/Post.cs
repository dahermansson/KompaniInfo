using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KompaniInfo.Models
{
	public class Post
	{
		public int Id { get; set; }
		public DateTime Datum { get; set; }

		[Required]
		public string Innehall { get; set; }

		[Required]
		[MaxLength(180)]
		public string Rubrik { get; set; }
	}
}