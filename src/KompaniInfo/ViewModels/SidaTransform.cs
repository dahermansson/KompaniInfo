using KompaniInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KompaniInfo.ViewModels
{
	public class SidaTransform
	{
		public VMSida Transform(Sida s)
		{
			return new VMSida() { Id = s.Id, Innehall = s.Innehall, Namn = s.Namn };
		}
		public Sida Transform(VMSida s)
		{
			return new Sida() { Id = s.Id, Innehall = s.Innehall, Namn = s.Namn };
		}
		public Sida UpdateTransform(VMSida s, Sida andraSida)
		{
			andraSida.Innehall = s.Innehall;
			andraSida.Namn = s.Namn;
			return andraSida;
		}
	}
}
