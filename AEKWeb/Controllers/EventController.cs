using AEKWeb.Data;
using AEKWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AEKWeb.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Styrelse")]
    public class EventController : Controller
    {
        private readonly AEKContext dbContext;

        public EventController(AEKContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Post(SaveEventModel model)
        {
            dbContext.Events.Add(new CalendarEvent()
            {
                Date = model.Date,
                Place = model.Place,
                Description = model.Description
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventToDelete = dbContext.Events.Single(x => x.Id == id);

            dbContext.Events.Remove(eventToDelete);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
