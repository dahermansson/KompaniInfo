using KompaniInfo.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KompaniInfo
{
  public class Program
  {
    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args)
    {
      var host= WebHost.CreateDefaultBuilder(args)
          .UseStartup<Startup>()
          .Build();

      using (var scope = host.Services.CreateScope())
      {
        var db = scope.ServiceProvider.GetService<KompaniInfoContext>();
        db.Database.Migrate();
      }
      return host;
    }
  }
}
