using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Platform.Api.Controllers
{
   public class Program
   {
      public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                 webBuilder.UseStartup<Startup>();
              });

      public static void Main(string[] args)
      {
         CreateHostBuilder(args).Build().Run();
      }
   }
}