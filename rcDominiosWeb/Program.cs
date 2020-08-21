using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace rcDominiosWeb
{
  public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://*:5700/");
    }
}
