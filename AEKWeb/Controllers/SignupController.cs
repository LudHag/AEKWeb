using AEKWeb.Data;
using AEKWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AEKWeb.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Styrelse")]
    public class SignupController : Controller
    {
        private readonly AEKContext dbContext;

        public SignupController(AEKContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Post(SignupModel model)
        {
            dbContext.SignUps.Add(new SignUp()
            {
                SignupDate = DateTime.Now,
                Name = model.Name,
                Email = model.Email,
                Instrument = model.Instrument,
                StartYear = model.Startyear
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventToDelete = dbContext.SignUps.Single(x => x.Id == id);

            dbContext.SignUps.Remove(eventToDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
