using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KompaniInfo.Models
{
    public class KompaniInfoContext : DbContext
    {
        public KompaniInfoContext (DbContextOptions<KompaniInfoContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
		public DbSet<Sida> Sida { get; set; }
	}
}
