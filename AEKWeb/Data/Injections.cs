using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace AEKWeb.Data
{
    public static class Injections
    {
        public static IHost MigrateAEKDatabase(this IHost host)
        {

            using var scope = host.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AEKContext>();
            var migrations = dbContext.Database.GetPendingMigrations();

            if (migrations.Any())
            {
                dbContext.Database.Migrate();
            }

            return host;

        }
    }
}
