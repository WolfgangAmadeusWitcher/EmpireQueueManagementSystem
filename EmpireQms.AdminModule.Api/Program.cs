using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EmpireQms.AdminModule.Api
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
                    webBuilder.UseUrls("https://localhost:5002", "https://localhost:5003");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
