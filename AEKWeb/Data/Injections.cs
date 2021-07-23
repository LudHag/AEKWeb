using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading.Tasks;

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

        public static async Task<IHost> InitUsers(this IHost host)
        {

            using var scope = host.Services.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();


            var memberPass = config["memberPassword"];
            var boardPass = config["boardPassword"];


            foreach (var r in AkRoles.Roles)
            {
                var roleresult = await roleManager.FindByNameAsync(r);
                if (roleresult != null) continue;
                var role = new IdentityRole(r);
                await roleManager.CreateAsync(role);
            }

            await ReplaceUser(userManager, AkRoles.Medlem, "medlem", memberPass);
            await ReplaceUser(userManager, AkRoles.Styrelse, "styrelse", boardPass);

            return host;

        }

        private static async Task ReplaceUser(UserManager<IdentityUser> userManager, string role, string username, string password)
        {
            var memberUser = await userManager.FindByNameAsync(username);

            if (memberUser != null)
            {
                await userManager.DeleteAsync(memberUser);
            }
            var newUser = new IdentityUser() { UserName = username };
            await userManager.CreateAsync(newUser, password);
            memberUser = await userManager.FindByNameAsync(username);
            await userManager.AddToRoleAsync(memberUser, role);
        }
    }
}
