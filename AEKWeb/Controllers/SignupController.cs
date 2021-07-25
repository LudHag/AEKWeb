using AEKWeb.Data;
using AEKWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
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
        [HttpGet]
        public IActionResult GetAsCsv()
        {
            var signups = dbContext.SignUps.OrderBy(x => x.SignupDate);

            var csv = string.Join("\r\n", signups.Select(x => ToCsvFormat(x)));

            Encoding iso = Encoding.GetEncoding("ISO-8859-1");
            Encoding utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(csv);
            byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
            return File(isoBytes, "application/octet-stream", "Signups.csv", false);
        }

        public string ToCsvFormat(SignUp signup)
        {
            return EscapeCsvChars(signup.Name) + ";" + EscapeCsvChars(signup.Email) + ";" + EscapeCsvChars(signup.Instrument) + ";" + EscapeCsvChars(signup.StartYear);
        }

        public string EscapeCsvChars(string text)
        {
            return "\"" + text?.Replace("\"", "\"\"") + "\"";
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
