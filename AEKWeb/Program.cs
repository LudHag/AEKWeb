using AEKWeb.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace AEKWeb;

public class Program
{
    public static async Task Main(string[] args)
    {
        (await CreateHostBuilder(args).Build()
            .MigrateAEKDatabase()
            .InitUsers()).Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
