using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.ViewModels
{
    public class VMIndex
    {
		public List<VMPost> Poster { get; set; }
		public List<VMPostlistaItem> Rubriker { get; set; }
		public VMIndex()
		{
			Poster = new List<VMPost>();
			Rubriker = new List<VMPostlistaItem>();
		}
	}
}
