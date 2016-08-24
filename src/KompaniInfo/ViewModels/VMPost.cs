using HeyRed.MarkdownSharp;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.ViewModels
{
	public class VMPost
	{
		public int Id { get; set; }
		public DateTime Datum { get; set; }
		public string Innehall { get; set; }
		public HtmlString Markdown
		{
			get
			{
				return new HtmlString(new Markdown().Transform(Innehall));
			}
		}

	}
}
