using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EmpireQms.SignageService.Api
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
                    webBuilder.UseUrls("https://localhost:5008", "https://localhost:5009");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
