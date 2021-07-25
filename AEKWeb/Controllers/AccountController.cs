using AEKWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AEKWeb.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
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

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

    }
}
