using HeyRed.MarkdownSharp;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.ViewModels
{
    public static class MarkDownExtension
    {
		public static HtmlString Markdown(this string value)
		{
			return new HtmlString(new Markdown().Transform(value));
		}
    }
}
