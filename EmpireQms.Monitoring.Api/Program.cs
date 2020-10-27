using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EmpireQms.Monitoring.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseUrls("https://localhost:5006", "https://localhost:5007");
                        webBuilder.UseStartup<Startup>();
                    });
    }
}
