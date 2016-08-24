using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.Models
{
	public class Post
	{
		public int Id { get; set; }
		public DateTime Datum { get; set; }
		public string Innehall { get; set; }
	}
}