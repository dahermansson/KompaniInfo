using KompaniInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.ViewModels
{
	public class PostTransform
	{
		public VMPost Transform(Post p)
		{
			return new VMPost() { Id = p.Id, Datum = p.Datum, Innehall = p.Innehall, Rubrik = p.Rubrik };
		}
		public Post Transform(VMPost p)
		{
			return new Post() { Id = p.Id, Datum = p.Datum, Innehall = p.Innehall, Rubrik = p.Rubrik };
		}
		public Post UpdateTransform(VMPost p, Post andraPost)
		{
			andraPost.Innehall = p.Innehall;
			andraPost.Rubrik = p.Rubrik;
			return andraPost;
		}
	}
}
