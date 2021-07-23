using AEKWeb.Data;
using AEKWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AEKWeb.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                if (result.IsLockedOut)
                {
                    return Json(new { success = false, message = "Utlåst" });
                }

            }
            return Json(new { success = false, message = "Inloggning misslyckades" });
        }


#if DEBUG

        [Route("InitNintendo")]
        public async Task<ActionResult> InitNintendo(string memberPass, string styrelsePass)
        {

            foreach (var r in AkRoles.Roles)
            {
                var roleresult = await roleManager.FindByNameAsync(r);
                if (roleresult != null) continue;
                var role = new IdentityRole(r);
                await roleManager.CreateAsync(role);
            }

            var memberUser = await userManager.FindByNameAsync("member");
            if (memberUser == null)
            {
                var newUser = new IdentityUser() { UserName = "member" };
                await userManager.CreateAsync(newUser, memberPass);
                memberUser = await userManager.FindByNameAsync("member");
                await userManager.AddToRoleAsync(memberUser, AkRoles.Medlem);
            }

            var styrelseUser = await userManager.FindByNameAsync("styrelse");
            if (styrelseUser == null)
            {
                var newUser = new IdentityUser() { UserName = "styrelse" };
                await userManager.CreateAsync(newUser, styrelsePass);
                styrelseUser = await userManager.FindByNameAsync("styrelse");
                await userManager.AddToRoleAsync(styrelseUser, AkRoles.Styrelse);
            }

            return Json(new { success = true });
        }
#endif

    }
}
